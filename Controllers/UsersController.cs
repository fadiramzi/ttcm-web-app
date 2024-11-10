using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ttcm_mvc.Data;
using ttcm_mvc.Models.DTOs;

namespace ttcm_mvc.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UsersController(ApplicationDbContext applicableDbContext)
        {
            _applicationDbContext = applicableDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Users = await _applicationDbContext.Users
                .Select(u => new UserResponseDTO()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Phone = u.PhoneNumber,
                    Email = u.Email
                })
                .ToListAsync();

            return View(Users);
        }
    }
}
