using COMP003B.FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIDailies : Controller
    {
        private List<Daily> _dailies = new List<Daily>();

        public APIDailies()
        {
            _dailies.Add(new Daily { DailyId = 1, MealTime = "Spring" });
            _dailies.Add(new Daily { DailyId = 2, MealTime = "Summer" });
            _dailies.Add(new Daily { DailyId = 3, MealTime = "Fall" });
            _dailies.Add(new Daily { DailyId = 4, MealTime = "Winter" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Daily>> GetAllDailies()
        {
            return _dailies;
        }

        [HttpGet("(id)")]
        public ActionResult<Daily> GetDailyById(int id)
        {
            var daily = _dailies.FirstOrDefault(d => d.DailyId == id);

            if (daily == null)
            {
                return NotFound();
            }
            return daily;
        }

        [HttpPost]
        public ActionResult<Daily> CreateDaily(Daily daily)
        {
            daily.DailyId = _dailies.Max(d => d.DailyId) + 1;
            _dailies.Add(daily);
            return CreatedAtAction(nameof(GetDailyById), new { id = daily.DailyId }, daily);
        }

        [HttpPut]
        public ActionResult<Daily> UpdateDaily(int id, Daily updateDaily)
        {
            var daily = _dailies.Find(d => d.DailyId == id);

            if (daily == null)
            {
                return BadRequest();
            }

            daily.MealTime = updateDaily.MealTime;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteDaily(int id)
        {
            var daily = _dailies.Find(d => d.DailyId == id);
            if (daily == null)
            {
                return NotFound();
            }
            _dailies.Remove(daily);
            return NoContent();
        }
    }
}
