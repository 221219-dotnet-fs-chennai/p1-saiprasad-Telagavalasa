using Bussiness_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ServiceLayer.Controllers
{
    [Route("api/[Controller]")]
    public class AvailabilityController : Controller
    {
        IAvailabiityLogic logic;
        public AvailabilityController(IAvailabiityLogic _logic)
        {
            logic= _logic;
        }

        [HttpGet("All")]
        public ActionResult Get([FromHeader] string email)
        {
            try
            {
                Log.Information("--fetching the trainer availability to teach--");

                var availabilities = logic.GetAvailability(email);
                if (availabilities.Count() > 0)
                    return Ok(availabilities);
                else
                    return BadRequest("No Availability found");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public ActionResult AddAvailability([FromHeader] string email, [FromBody] Models.Availability a)
        {
            try
            {
                Log.Information("--Adding the Avaliability of trainer for tutoring ---");

                logic.AddAvailability(email, a);
                return Created("Add", a);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public ActionResult UpdateAvailabiity([FromHeader] string email, [FromBody] Models.Availability a)
        {
            try
            {
                Log.Information("--Updating the Availabiity of trainer for tutoring--");

                logic.UpdateAvailability(email, a);
                return Created("Updated", a);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpDelete("Delete")]
        public ActionResult Delete([FromHeader] string email, [FromHeader] string avaday)
        {
            try
            {
                Log.Information("--Deleting the trainer Availability--");

                var rest = logic.DeleteAvaiability(email, avaday);
                if (rest != null)
                    return Ok(rest);
                else
                    return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

    

