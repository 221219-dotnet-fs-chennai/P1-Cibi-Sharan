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
        [HttpGet("GetSkills")]
        public ActionResult GetSkills([FromQuery] string? Email)
        {
            try
            {

                var traineredu = _logic.GetSkillsDetails(Email);
                if (traineredu != null)
                {
                    return Ok(traineredu);
                }
                else
                    return BadRequest("No trainer Logins found!");
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        [HttpPut("UpdateSkills/{Email}")]
        public ActionResult UpdateSkills([FromRoute] string? Email, [FromBody] Skills s)
        {
            try
            {
                _logic.UpdateSkills(Email, s);
                return Ok(s);
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
