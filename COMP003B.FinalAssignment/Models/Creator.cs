using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Models
{
    public class Creator : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
