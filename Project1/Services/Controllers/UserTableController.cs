using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTableController : ControllerBase
    {
        ILogic _logic;
        public UserTableController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpGet("GetAllUsers")]
        public ActionResult Get()
        {
            try
            {
                var allusers = _logic.GetAllUsers();
                if (allusers != null) {
                    return Ok(allusers);
                }
                return BadRequest();
                
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("SignUp")] // Trying to create a resource on the server
        public ActionResult Add(UserTable? t)
        {
            try
            {
                var addedUserDet = _logic.AddUserTable(t);
                return CreatedAtAction("Add", addedUserDet); //201 -> Serialization of restaurant object
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
        [HttpPut("UpdateUserTable/{Email}")]
        public ActionResult Update([FromRoute]string? Email, [FromBody]UserTable? t)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    _logic.UpdateUserTable(Email, t);
                    return Ok(t);
                }
                else
                    return BadRequest("Email not found!");
                
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
