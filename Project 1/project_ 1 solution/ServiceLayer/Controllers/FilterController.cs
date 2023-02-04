using Bussiness_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ServiceLayer.Controllers
{

    [Route("api/[Controller]")]
    public class FilterController : Controller
    {
        IFilterLogic logic = new FilterLogic();

        [HttpGet("GetTrainerByDay")]
        public ActionResult Get(string Day)
        {
            try
            {
                var trainers = logic.GetTrainersByDay(Day);
                if (trainers.Count() > 0)
                    return Ok(trainers);
                else
                    return BadRequest("No Trainers found");
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

        [HttpGet("GetTrainerByHourlyRate")]
        public ActionResult GetTrainer(string HourlyRate1,string HourlyRate2)
        {
            try
            {
                var trainers = logic.GetTrainersByHourlyRate(HourlyRate1,HourlyRate2);
                if (trainers.Count() > 0)
                    return Ok(trainers);
                else
                    return BadRequest("No Trainers found");
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
