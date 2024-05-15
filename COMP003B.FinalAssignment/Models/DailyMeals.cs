using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Models
{
    public class DailyMeals : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
