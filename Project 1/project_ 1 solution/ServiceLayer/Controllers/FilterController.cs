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

        [HttpGet("GetTrainerBySkillName")]
        public ActionResult GetTrainerBySkill(string SkillName)
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
        public ActionResult GetTrainerExperience(int Experience)
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
