using Microsoft.AspNetCore.Mvc;
using ttcm_mvc.Services;
using ttcm_mvc.Data;
using ttcm_mvc.Models.DTOs;
using ttcm_mvc.Interfaces;
using System.Drawing.Printing;

namespace ttcm_mvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryCRUD _categoryService;
        public CategoriesController(
             ICategoryCRUD categoryService
            )
        {
            _categoryService = categoryService;

        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var paginatedList = await _categoryService.GetPaginatedCategoriesAsync(pageIndex, pageSize);
            return View(paginatedList);
        }
    }
}
