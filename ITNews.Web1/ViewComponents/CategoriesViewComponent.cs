using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ITNews.Web1.ViewComponents
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesViewComponent(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories();
            var categoriesViewModel = mapper.Map<List<CategoryViewModel>>(categories);
            return View(categoriesViewModel);
        }
    }
}
