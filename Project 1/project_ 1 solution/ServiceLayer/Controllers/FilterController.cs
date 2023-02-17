using Bussiness_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ServiceLayer.Controllers
{

    [Route("api/[Controller]")]
    public class FilterController : Controller
    {
        IFilterLogic logic;
        public FilterController(IFilterLogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("GetTrainerByDay")]
        public ActionResult Get([FromHeader ]string Day)
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
        public ActionResult GetTrainer([FromHeader] string HourlyRate1, [FromHeader]string HourlyRate2)
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

        [HttpGet("GetTrainerBySkillName")]
        public ActionResult GetTrainerBySkill([FromHeader]string SkillName)
        {
            try
            {
                var trainers = logic.GetTrainersBySkillName(SkillName);
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

        [HttpGet("GetTrainerByExperience")]
        public ActionResult GetTrainerExperience([FromHeader]int Experience)
        {
            try
            {
                var trainers = logic.GetTrainersByExperience(Experience);
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
