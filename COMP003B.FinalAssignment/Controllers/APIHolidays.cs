﻿using COMP003B.FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIHolidays : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}