using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews.Web1.ViewComponents
{
    public class PopularPostsViewComponent : ViewComponent
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;
        private readonly ICommentService commentService;

        public PopularPostsViewComponent(IMapper mapper, IPostService postService, ICommentService commentService)
        {
            this.mapper = mapper;
            this.postService = postService;
            this.commentService = commentService;
        }


        public IViewComponentResult Invoke()
        {
            var posts = postService.GetPopularPosts();
            var postsViewModel = mapper.Map<List<MainPostViewModel>>(posts);
            foreach (var item in postsViewModel)
            {
                item.CommentsCount = commentService.GetCommentsCount(item.Id);
            }
            return View(postsViewModel);
        }
    }
}
