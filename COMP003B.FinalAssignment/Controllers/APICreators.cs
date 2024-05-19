using COMP003B.FinalAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APICreators : Controller
    {
        private List<Creator> _creators = new List<Creator>();

        public APICreators()
        {
            _creators.Add(new Creator { CreatorId = 1, Name = "Spring" });
            _creators.Add(new Creator { CreatorId = 2, Name = "Summer" });
            _creators.Add(new Creator { CreatorId = 3, Name = "Fall" });
            _creators.Add(new Creator { CreatorId = 4, Name = "Winter" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Creator>> GetAllCreators()
        {
            return _creators;
        }

        [HttpGet("(id)")]
        public ActionResult<Creator> GetCreatorById(int id)
        {
            var creator = _creators.FirstOrDefault(c => c.CreatorId == id);

            if (creator == null)
            {
                return NotFound();
            }
            return creator;
        }

        [HttpPost]
        public ActionResult<Creator> CreateCreator(Creator creator)
        {
            creator.CreatorId = _creators.Max(s => s.CreatorId) + 1;
            _creators.Add(creator);
            return CreatedAtAction(nameof(GetCreatorById), new { id = creator.CreatorId }, creator);
        }

        [HttpPut]
        public ActionResult<Creator> UpdateCreator(int id, Creator updateCreator)
        {
            var seasonal = _creators.Find(c => c.CreatorId == id);

            if (seasonal == null)
            {
                return BadRequest();
            }

            seasonal.Name = updateCreator.Name;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCreator(int id)
        {
            var creator = _creators.Find(c => c.CreatorId == id);
            if (creator == null)
            {
                return NotFound();
            }
            _creators.Remove(creator);
            return NoContent();
        }
    }
}
