using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        ILogic _logic;
        public ExperienceController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpPost("Add/{Email}")]
        public ActionResult Add([FromRoute] string? Email, [FromBody] Experience ex)
        {
            try
            {
                var addedexp = _logic.AddExperience(Email, ex);
                return CreatedAtAction("Add", addedexp);
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
        [HttpGet("GetExperienceDetails/{Email}")]
        public ActionResult GetExperience([FromRoute] string? Email)
        {
            try
            {
                var trainerexp = _logic.GetExperienceDetails(Email);
                if (trainerexp != null)
                {
                    return Ok(trainerexp);
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
        [HttpPut("UpdateExperience/{Email}")]
        public ActionResult UpdateExperience([FromRoute] string? Email, [FromBody] Experience exp)
        {
            try
            {
                _logic.UpdateExperience(Email, exp);
                return Ok(exp);
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
