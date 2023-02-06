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
    }
}
