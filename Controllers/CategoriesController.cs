using Microsoft.AspNetCore.Mvc;
using ttcm_mvc.Interfaces;
using ttcm_mvc.Models.DTOs;
using ttcm_mvc.Services;

namespace ttcm_mvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryCRUD _categoryService;

        public CategoriesController(ICategoryCRUD categoryService)
        {
            _categoryService = categoryService;
        }
        //Get
        public async Task<IActionResult> Index(string searchQuery = "",int pageIndex = 1, int pageSize = 5)
        {
            var paginatedList = await _categoryService.GetPaginatedListAsync(searchQuery,pageIndex, pageSize);
            ViewBag.searchQuery = searchQuery;
            return View(paginatedList);// IEnumerable<CategoryDTOResponse
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid) { 
                return View();
            }
            await _categoryService.Create(categoryDto);
            return RedirectToAction("Index");
        }
    }
}
