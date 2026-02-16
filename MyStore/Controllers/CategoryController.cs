using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class CategoryController : Controller
    {

        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllAsync();
            return View(categories);
        }

    }
}
