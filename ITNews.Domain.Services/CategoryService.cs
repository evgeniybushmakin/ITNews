using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        private IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public void CreateCategory(CategoryDomainModel category)
        {
            var createCategory = mapper.Map<Category>(category);
            categoryRepository.CreateCategory(createCategory);
            categoryRepository.Save();
        }

        public void DeleteCategory(int categoryId)
        {
            categoryRepository.DeleteCategory(categoryId);
            categoryRepository.Save();
        }

        public CategoryDomainModel GetCategoryByPostId(int postId)
        {
            var category = categoryRepository.GetCategoryByPostId(postId);
            var categoryDomainModel = mapper.Map<CategoryDomainModel>(category);
            return categoryDomainModel;
        }

        public List<CategoryDomainModel> GetCategories()
        {
            var categories= categoryRepository.GetCategories();
            var categoriesDomainModel = mapper.Map<List<CategoryDomainModel>>(categories);
            return categoriesDomainModel;
        }
    }
}
