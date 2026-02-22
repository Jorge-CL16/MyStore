using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
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

        [HttpGet]
        public async Task<IActionResult> AddEdit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(CategoryVM entityVM)
        {
            ViewBag.message = null;
            if (!ModelState.IsValid) return View(entityVM);

            await categoryService.AddAsync(entityVM);
            ViewBag.message = "Categoria creada";
            return View();
        }
    }
}
