using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ITNews.Web1.ViewComponents
{
    public class CommentsViewComponent:ViewComponent
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly IProfilService profileService;
        private readonly ILikeService likeService;

        public CommentsViewComponent(IMapper mapper, ICommentService commentService, IProfilService profileService,
            ILikeService likeService)
        {
            this.mapper = mapper;
            this.commentService = commentService;
            this.profileService = profileService;
            this.likeService = likeService;
        }

        public IViewComponentResult Invoke(int id, string userId)
        {
            var comments = commentService.GetComments(id);

            if (comments != null)
            {
                var commentsViewModel = mapper.Map<List<CommentViewModel>>(comments);

                if (userId != null)
                {

                    foreach (var item in commentsViewModel)
                    {
                        var fullname = profileService.FindFullName(item.UserId);

                        item.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };

                        item.UserLike = likeService.UserLike(item.Id, userId);

                        item.Count = likeService.GetCountLikes(item.Id);
                    }
                }
                else
                {
                    foreach (var item in commentsViewModel)
                    {
                        var fullname = profileService.FindFullName(item.UserId);

                        item.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };

                        item.Count = likeService.GetCountLikes(item.Id);
                    }
                }
                return View(commentsViewModel);
            }
            else
            {
                return null;
            }
        }
    }
}
