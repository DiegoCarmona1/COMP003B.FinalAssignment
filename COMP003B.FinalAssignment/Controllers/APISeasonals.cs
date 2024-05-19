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
            _seasonals.Add(new Seasonal { SeasonalId = 1 });
            _seasonals.Add(new Seasonal { SeasonalId = 2 });
            _seasonals.Add(new Seasonal { SeasonalId = 3 });
            _seasonals.Add(new Seasonal { SeasonalId = 4 });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Seasonal>> GetAllSeasonals()
        {
            return _seasonals;
        }

        [HttpGet("(id)")]
        public ActionResult<Seasonal> GetSeasonalById(int id)
        {
            var seasonal = _seasonals.FirstOrDefault(s => s.SeasonalId == id);

            if (seasonal == null)
            {
                return NotFound();
            }
            return seasonal;
        }

        [HttpPost]
        public ActionResult<Seasonal> CreateSeasonal(Seasonal seasonal)
        {
            seasonal.SeasonalId = _seasonals.Max(s => s.SeasonalId) + 1;
            _seasonals.Add(seasonal);
            return CreatedAtAction(nameof(GetSeasonalById), new {id = seasonal.SeasonalId}, seasonal);
        }

        [HttpPut]
        public ActionResult<Seasonal> UpdateSeasonal(int id, Seasonal updateSeasonal)
        {
            var seasonal = _seasonals.Find(s => s.SeasonalId == id);

            if (seasonal == null)
            {
                return BadRequest();
            }

            

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteSeasonal(int id)
        {
            var seasonal = _seasonals.Find(s => s.SeasonalId == id);
            if (seasonal == null)
            {
                return NotFound();
            }
            _seasonals.Remove(seasonal);
            return NoContent();
        }
    }
}
