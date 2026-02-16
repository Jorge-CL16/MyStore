using Microsoft.AspNetCore.Mvc;
using MyStore.Context;
using MyStore.Entities;
using MyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext context;

        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await context.Category
                .AsNoTracking()
                .Select(c => new CategoryVM
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                })
                .ToListAsync();

            return View(categories);
        }

    }
}
