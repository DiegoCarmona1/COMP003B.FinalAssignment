using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Models
{
    public class Recipe : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
