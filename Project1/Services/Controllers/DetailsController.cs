using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        [HttpPost("Add/{Email}")] 
        public ActionResult Add([FromRoute] string? Email, [FromBody] Details? d)
        {
            try
            {
                var addedDetail = _logic.AddDetails(Email,d);
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
    }
}
