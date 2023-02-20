using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        ILogic _logic;
        public DetailsController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpGet("GetDetails")]
        public ActionResult Get([FromQuery] string? Email)
        {
            try
            {

                var traineredu = _logic.GetDetailDetails(Email);
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
        [HttpPost("Add")]
        public ActionResult Add([FromQuery] string? Email, [FromQuery] string password, [FromBody] Details? d)
        {
            try
            {
                var addedDetail = _logic.AddDetails(Email,password, d);
                return CreatedAtAction("Add", addedDetail);
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
        [HttpPut("UpdateDetails")]
        public ActionResult UpdateDetails([FromQuery] string? Email, [FromBody] Details d)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    _logic.UpdateDetails(Email, d);
                    return Ok(d);
                }
                else
                {
                    return BadRequest("Input may be wrong. Please try again..");
                }
            }
            catch (SqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
