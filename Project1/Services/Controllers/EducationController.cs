using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        ILogic _logic;
        public EducationController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpPost("AddEducation/{Email}")]
        public ActionResult Add([FromRoute] string? Email, [FromBody] Education ed)
        {
            try
            {
                var addedexp = _logic.AddEducation(Email, ed);
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

        [HttpGet("GetEducationDetails/{Email}")]
        public ActionResult GetEducation([FromRoute] string? Email)
        {
            try
            {

                var traineredu = _logic.GetEducationDetails(Email);
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
    }
}
