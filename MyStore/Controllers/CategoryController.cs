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
        public async Task<IActionResult> AddEdit(int id)
        {
            var categoryVM = await categoryService.GetByIdAsync(id);
            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(CategoryVM entityVM)
        {
            ViewBag.message = null;
            if (!ModelState.IsValid) return View(entityVM);

            if(entityVM.CategoryId == 0)
            {
                await categoryService.AddAsync(entityVM);
                ModelState.Clear();
                entityVM = new CategoryVM();
                ViewBag.message = "Created category";

            }
            else
            {
                await categoryService.EditAsync(entityVM);
                ViewBag.message = "Edited Category";
            }

            return View(entityVM);
        }

        public async Task<IActionResult>Delete(int id)
        {
            await categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
