using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Web1.ViewComponents
{
    public class TagsViewComponent:ViewComponent
    {
        private readonly ITagService tagService;
        private readonly IPostTagService postTagService;
        private readonly IMapper mapper;

        public TagsViewComponent(IMapper mapper, ITagService tagService, IPostTagService postTagService)
        {
            this.mapper = mapper;
            this.tagService = tagService;
            this.postTagService = postTagService;
        }


        public IViewComponentResult Invoke()
        {
            List<CloudTags> countTags = new List<CloudTags>();

            var tags = tagService.GetTags();

            var postTags = postTagService.GetPostsTags();

            foreach (var item in tags)
            {
                countTags.Add(new CloudTags
                {
                    Id = item.Id,
                    Content = item.Content,
                    Count = postTags.Where(x=>x.TagId==item.Id).Count()
                });
            }
         
            return View(countTags);
        }
    }
}
