using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ttcm_mvc.Models.Views;

namespace ttcm_mvc.Controllers
{
    [Authorize]
    public class TrainersController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTrainerViewModel addTrainerViewModel) { 
            
            return View(); 
        
        }
    }
}
