using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface ICategoryService
    {
        void DeleteCategory(int categoryId);

        void CreateCategory(CategoryDomainModel category);

        CategoryDomainModel GetCategoryByPostId(int postId);

        List<CategoryDomainModel> GetCategories();
    }
}
