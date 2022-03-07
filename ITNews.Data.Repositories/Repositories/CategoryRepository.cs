using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateCategory(Category category)
        {
            context.Categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var deleteCategory = context.Categories.Find(categoryId);
            context.Remove(deleteCategory);
        }

        public Category GetCategoryByPostId(int postId)
        {
            return context.Categories.Where(x=> x.Posts.FirstOrDefault().Id==postId).FirstOrDefault();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
