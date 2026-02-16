using Microsoft.EntityFrameworkCore;
using MyStore.Entities;
using MyStore.Models;
using MyStore.Repositories;

namespace MyStore.Services
{
    public class CategoryService
    {
        private readonly GenericRepository<Category> _categoryRepository;

        public CategoryService(GenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesVM = categories
                .Select(item => new CategoryVM
                {
                    CategoryId = item.CategoryId,
                    Name = item.Name
                })
                .ToList();

            return categoriesVM;
        }
    }

}
