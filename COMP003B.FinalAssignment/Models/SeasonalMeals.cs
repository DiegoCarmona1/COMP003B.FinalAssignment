using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Models
{
    public class SeasonalMeals : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
