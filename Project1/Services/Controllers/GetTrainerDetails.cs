//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using Models;

//namespace Services.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GetTrainerDetails : ControllerBase
//    {
//        [HttpGet("Details")]
//        public ActionResult Get()
//        {
//            try
//            {
//                var listOfTrainers = new List<Details>();
//                //TryGetValue(checks if cahce still exists and if it does "out listOfrestautrants" puts that that inside our variable)
//                if (!_cache.TryGetValue("rest", out listOfRestaurants))
//                {
//                    listOfRestaurants = _logic.GetRestaurants().ToList();
//                    _cache.Set("rest", listOfRestaurants, new TimeSpan(0, 0, 30));
//                }
//                return Ok(listOfRestaurants);
//            }
//            catch (SqlException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//    }
//}
