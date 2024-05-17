using COMP003B.FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APISeasonals : Controller
    {
        private List<Seasonal> _seasonals = new List<Seasonal>();

        public APISeasonals()
        {
            _seasonals.Add(new Seasonal { SeasonalId = 1, SeasonalName = "Spring" });
            _seasonals.Add(new Seasonal { SeasonalId = 2, SeasonalName = "Summer" });
            _seasonals.Add(new Seasonal { SeasonalId = 3, SeasonalName = "Fall" });
            _seasonals.Add(new Seasonal { SeasonalId = 4, SeasonalName = "Winter" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Seasonal>> GetAllSeasonals()
        {
            return _seasonals;
        }

        [HttpGet("(id)")]
        public ActionResult<Seasonal> GetSeasonalById(int id)
        {
            var seasonal = _seasonals.FirstOrDefault(s = s.Id == id);

            if (seasonal == null)
            {
                return NotFound();
            }
            return seasonal;
        }
    }
}
