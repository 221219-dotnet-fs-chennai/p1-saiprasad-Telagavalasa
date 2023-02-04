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
        IEducationLogic logic = new EducationLogic();

        [HttpGet("All")]
        public ActionResult Get(string email)
        {
            try
            {
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
        public ActionResult AddEducation(string email, Models.Education e)
        {
            try
            {
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
        public ActionResult UpdateSkills(string email, Models. Education e)
        {
            try
            {
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
        public ActionResult Delete(string email, string Institutionname)
        {
            try
            {
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
