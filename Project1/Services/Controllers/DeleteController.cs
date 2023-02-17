using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.IO;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        ILogic _logic;
        public DeleteController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpDelete("DeleteTrainer/{Email}")]
        public ActionResult Delete([FromRoute] string? Email, [FromRoute] string password)
        {
            try
            {
                var trainer = _logic.GetUserDetails(Email, password);
                if (!string.IsNullOrEmpty(Email))
                {
                    _logic.DeleteTrainer(trainer);
                    return Ok(trainer);
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
//try
//{
//    if (!string.IsNullOrEmpty(Email))
//    {
//        var trainer = _logic.DeleteTrainer(Email);
//        if (trainer != null)
//        {
//            return Ok(trainer);
//        }
//        else
//            return NotFound();
//    }
//    else
//        return BadRequest();
//}
//catch (SqlException ex)
//{
//    return BadRequest(ex.Message);
//}
//catch (Exception ex)
//{
//    return BadRequest(ex.Message);
//}