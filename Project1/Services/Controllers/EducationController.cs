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
        [HttpPost("AddEducation")]
        public ActionResult Add([FromQuery] string? Email, [FromBody] Education ed)
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

        [HttpGet("GetEducationDetails")]
        public ActionResult GetEducation([FromQuery] string? Email)
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
        [HttpGet("GetFilteredUsers/{Percentage}")]
        public ActionResult GetFilteredUsers(double Percentage)
        {
            var filteredUsers = _logic.GetFilteredUsers(Percentage);
            if (filteredUsers != null)
                return Ok(filteredUsers);
            else
                return BadRequest();
        }
        [HttpPut("UpdateEducation/{Email}")]
        public ActionResult UpdateEducation([FromRoute] string? Email, [FromBody] Education ed)
        {
            try
            {
                _logic.UpdateEducation(Email, ed);
                return Ok(ed);
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
        //[HttpGet("FilterPercentage/{Percentage}")]
        //public ActionResult FilterPercentage([FromRoute] double Percentage)
        //{
        //    try
        //    {
        //        var filteredList = _logic.GetFilteredPercentage(Percentage);

        //    }
        //}
    }
}

