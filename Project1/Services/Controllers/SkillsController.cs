using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;
namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ILogic _logic;
        public SkillsController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpPost("AddSkills/{Email}")] // Trying to create a resource on the server
        public ActionResult Add([FromRoute] string? Email, [FromBody] Skills s)
        {
            try
            {
                var addedSkill = _logic.AddSkills(Email, s);
                return CreatedAtAction("Add", addedSkill);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
