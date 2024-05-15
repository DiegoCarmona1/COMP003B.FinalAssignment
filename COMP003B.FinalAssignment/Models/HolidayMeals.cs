using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Models
{
    public class HolidayMeals : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
