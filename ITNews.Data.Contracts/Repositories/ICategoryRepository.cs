using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface ICategoryRepository: IDisposable
    {
        void CreateCategory (Category category);

        void DeleteCategory(int categoryId);

        Category GetCategoryByPostId(int postId);

        void Save();

        IEnumerable<Category> GetCategories();

    }
}
