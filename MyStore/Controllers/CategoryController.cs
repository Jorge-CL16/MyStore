using Microsoft.AspNetCore.Mvc;
using MyStore.Context;

namespace MyStore.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext context;

        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }



        public IActionResult Index()
        {

            var categories = context.Category.ToList();
            return View(categories);
        }
    }
}
