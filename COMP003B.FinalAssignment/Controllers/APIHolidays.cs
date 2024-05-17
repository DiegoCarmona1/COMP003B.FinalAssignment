using COMP003B.FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIHolidays : Controller
    {
        private List<Holiday> _holidays = new List<Holiday>();

        public APIHolidays()
        {
            _holidays.Add(new Holiday { HolidayId = 1, HolidayName = "New Years" });
            _holidays.Add(new Holiday { HolidayId = 2, HolidayName = "Halloween" });
            _holidays.Add(new Holiday { HolidayId = 3, HolidayName = "Christmas" });
            _holidays.Add(new Holiday { HolidayId = 4, HolidayName = "Valentines" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Holiday>> GetAllHolidays()
        {
            return _holidays;
        }

        [HttpGet("(id)")]
        public ActionResult<Holiday> GetHolidayById(int id)
        {
            var holiday = _holidays.FirstOrDefault(h = h.HolidayId == id);

            if (holiday == null)
            {
                return NotFound();
            }
            return holiday;
        }

        [HttpPost]
        public ActionResult<Holiday> CreateHoliday(Holiday holiday)
        {
            holiday.HolidayId = _holidays.Max(h => h.HolidayId) + 1;
            _holidays.Add(holiday);
            return CreatedAtAction(nameof(GetHolidayById), new { id = holiday.HolidayId }, holiday);
        }

        [HttpPut]
        public ActionResult<Holiday> UpdateHoliday(int id, Holiday updateHoliday)
        {
            var holiday = _holidays.Find(h = h.HolidayId == id);

            if (holiday == null)
            {
                return BadRequest();
            }

            holiday.HolidayName = updateHoliday.HolidayName;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteHoliday(int id)
        {
            var holiday = _holidays.Find(h = h.HolidayId == id);
            if (holiday == null)
            {
                return NotFound();
            }
            _holidays.Remove(holiday);
            return NoContent();
        }
    }
}
