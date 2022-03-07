using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITNews.Web1.Controllers
{
    [Authorize(Roles = "Admin, Writer")]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;


        public PostController(IPostService postService, IMapper mapper, ICategoryService categoryService,
            ITagService tagService, IHostingEnvironment hostingEnvironment)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.tagService = tagService;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: Post
        public ActionResult Index()
        {
            List<PostViewModel> postsViewModel;

            var userIdAdmin = Request.Cookies["userIdAdmin"];

            if (userIdAdmin != null)
            {
                var posts = postService.GetPostsByUserId(userIdAdmin);

                postsViewModel = mapper.Map<List<PostViewModel>>(posts);
            }
            else
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var posts = postService.GetPostsByUserId(userId);

                postsViewModel = mapper.Map<List<PostViewModel>>(posts);
            }

            return View(postsViewModel);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.value = @"<p>Please, enter your post </p>";

            var categories = categoryService.GetCategories();

            var categoriesViewModel = mapper.Map<List<CategoryViewModel>>(categories);

            ViewBag.Categories = new SelectList(categoriesViewModel, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult SaveFile()
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var httpPostedFile = HttpContext.Request.Form.Files["UploadFiles"];

                if (httpPostedFile != null)
                {
                    var destinationPath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", httpPostedFile.FileName);

                    using (var stream = new FileStream(destinationPath, FileMode.Create))
                    {
                        httpPostedFile.CopyTo(stream);
                    }
                }
                return Content("");
            }
            else
            {
                return null;
            }
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel post)
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (ModelState.IsValid)
                {
                    var postDomainModel = mapper.Map<PostDomainModel>(post);
                    var newPostId = postService.CreatePost(postDomainModel, id);

                    if (post.Tag.Content != null)
                    {
                        tagService.AddTags(post.Tag.Content, newPostId);
                    }

                    return RedirectToAction(nameof(Index));
                }

                else
                {
                     return BadRequest();
                }
            }

            catch
            {
                return RedirectToPage("/Account/Login");
            }
        }

        public class AutocompleteResultViewModel
        {
            public int Id
            {
                get;
                set;
            }

            public string Label
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }
        }

        public JsonResult Autocomplete(string term)
        {

            var tags = tagService.GetTags().ToList();

            var taglist = tags.Where(n => n.Content.Contains(term)).Select(x => new AutocompleteResultViewModel
            {
                Id = x.Id,
                Label = x.Content,
                Value = x.Content
            }).ToList();

            return new JsonResult(taglist);
        }



        // GET: Post/Edit/5
        public ActionResult Edit(int postId)
        {
            if (postId != 0)
            {

                var post = postService.FindPost(postId);

                var postViewModel = mapper.Map<PostViewModel>(post);

                var tagContent = tagService.FindTagsByPostId(postId);

                if (tagContent != null)
                {
                    postViewModel.Tag = new TagViewModel { Content = tagContent };
                }

                var categories = categoryService.GetCategories();

                var categoriesViewModel = mapper.Map<List<CategoryViewModel>>(categories);

                ViewBag.Categories = new SelectList(categoriesViewModel, "Id", "Name");

                return View(postViewModel);

            }
            else
            {
                return NotFound();
            }

        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostViewModel post)
        {
            var userIdAdmin = Request.Cookies["userIdAdmin"];

            if (userIdAdmin != null)
            {
                if (ModelState.IsValid)
                {
                    var postDomainModel = mapper.Map<PostDomainModel>(post);

                    postService.UpdatePostByAdmin(postDomainModel);

                    if (post.Tag.Content != null)
                    {
                        tagService.AddTags(post.Tag.Content, post.Id);
                    }

                    return RedirectToAction(nameof(PostController.Index));
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (ModelState.IsValid)
                {
                    var postDomainModel = mapper.Map<PostDomainModel>(post);

                    postService.UpdatePost(postDomainModel, userId);

                    if (post.Tag.Content != null)
                    {
                        tagService.AddTags(post.Tag.Content, post.Id);
                    }

                    return RedirectToAction(nameof(PostController.Index));
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int postId)
        {
            postService.DeletePost(postId);

            return RedirectToAction(nameof(PostController.Index));
        }


    }
}