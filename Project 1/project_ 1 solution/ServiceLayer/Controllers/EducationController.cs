using Bussiness_Logic;
using FluentApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace ServiceLayer.Controllers
{
    [Route("api/[Controller]")]
    public class EducationController : Controller
    {
        IEducationLogic logic;
        public EducationController(IEducationLogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("All")]
        public ActionResult Get([FromHeader] string email)
        {
            try
            {
                Log.Information("--Fetching the education of particular trainer--");

                var educations = logic.GetEducation(email);
                if (educations.Count() > 0)
                    return Ok(educations);
                else
                    return BadRequest("No Educations found");
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
        public ActionResult AddEducation([FromHeader]string email,[FromBody] Models.Education e)
        {
            try
            {
                Log.Information("--Adding the education details of trainer--");

                logic.AddEducation(email, e);
                return Created("Add", e);
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
        public ActionResult UpdateSkills([FromHeader] string email, [FromBody] Models.Education e)
        {
            try
            {
                Log.Information("--Updating the education details of the trainer--");

                logic.UpdateEducation(email, e);
                return Created("Updated", e);
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
        public ActionResult Delete([FromHeader]string email,[FromHeader] string Institutionname)
        {
            try
            {
                Log.Information("--Deleting the education details of the trainer--");

                var rest = logic.DeleteEducation(email, Institutionname);
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
