using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITNews.Web1.Controllers
{
    public class MainController : Controller
    {
        private readonly IPostService postService;
        private readonly IPostTagService postTagService;
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        private readonly IProfilService profileService;
        private readonly ILikeService likeService;
        private readonly IPostRatingService postRatingService;
        private readonly IMapper mapper;

        public MainController(IPostService postService, IMapper mapper, ICategoryService categoryService,
            ITagService tagService, IPostTagService postTagService, IUserService userService, ICommentService commentService,
            IProfilService profileService, ILikeService likeService, IPostRatingService postRatingService)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.tagService = tagService;
            this.postTagService = postTagService;
            this.userService = userService;
            this.commentService = commentService;
            this.profileService = profileService;
            this.likeService = likeService;
            this.postRatingService = postRatingService;
        }

        // GET: Main
        public ActionResult Index()
        {
            Response.Cookies.Delete("userIdAdmin");
            var posts = postService.GetPublishedPosts();
            var postsViewModel = mapper.Map<List<MainPostViewModel>>(posts);
            foreach (var item in postsViewModel)
            {
                var fullname = profileService.FindFullName(item.UserId);

                item.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };

                item.CommentsCount = commentService.GetCommentsCount(item.Id);
            }
            return View(postsViewModel);
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            if (search != null)
            {
                var posts = postService.Search(search);
                var postsViewModel = mapper.Map<List<SearchViewModel>>(posts);
                return View(postsViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var post = postService.GetPostById(id);
            var postViewModel = mapper.Map<PostViewModel>(post);
            var fullname = profileService.FindFullName(postViewModel.UserId);
            postViewModel.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    ViewBag.UserId = userId.Value;

                    var fullnameGuest = profileService.FindFullName(userId.Value);

                    if (fullnameGuest != null)
                    {
                        ViewBag.Username = fullnameGuest.FirstName + " " + fullnameGuest.LastName;
                    }
                    else
                    {
                        ViewBag.Username = userService.FindUsername(userId.Value);
                    }
                }
            }
            catch
            {
                ViewBag.Username = null;
            }
            return View(postViewModel);
        }

        public ActionResult TagLink(int tagId)
        {
            var postsTags = postTagService.GetPostsByTagId(tagId);

            ViewBag.TagName = tagService.GetTagNameById(tagId);

            List<MainPostViewModel> result = new List<MainPostViewModel>();

            foreach (var item in postsTags)
            {
                var post = postService.GetPostById(item.PostId);
                var postViewModel = mapper.Map<MainPostViewModel>(post);
                result.Add(postViewModel);
            }

            foreach (var item in result)
            {
                var fullname = profileService.FindFullName(item.UserId);
                item.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };
                item.CommentsCount = commentService.GetCommentsCount(item.Id);
            }

            return View(result);
        }


        [Authorize(Roles = "Admin, Reader, Writer")]
        public ActionResult Like([FromQuery]int commentId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                bool isLiked = likeService.IsAddedLike(commentId, userId);
                var likeAmount = likeService.GetCountLikes(commentId);
                return Ok (new { isLiked, likeAmount });
            }
            catch
            {

                return Unauthorized();
            }
        }

        [Authorize(Roles = "Admin, Reader, Writer")]
        public ActionResult Rating([FromQuery]int vote, [FromQuery]int postId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var addedRating = postRatingService.IsAddedRating(userId, postId, vote);

                if (addedRating)
                {
                    postService.AddRating(postId, vote);

                    return Ok();
                }
                else
                {
                    return Forbid();
                }                
            }
            catch
            {

                return  Unauthorized();
            }
        }

        public IActionResult SetTheme(string data)
        {
            CookieOptions cookies = new CookieOptions();
            cookies.Expires = DateTime.Now.AddYears(1);

            Response.Cookies.Append("theme", data, cookies);
            return Ok();
        }

    }
}