using System.Runtime.CompilerServices;
using Bussiness_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace ServiceLayer.Controllers
{
    [Route("api/[Controller]")]
    public class SkillController : Controller
    {
      ISkillLogic logic;
        public SkillController(ISkillLogic _logic)
        {
           logic= _logic;
        }
        [HttpGet("All")]
        public ActionResult Get([FromHeader] string email)
        {
            try
            {
                Log.Information("--Fetching the skill of Particular Trainer--");

                var skills = logic.GetSkills(email);
                if (skills.Count() > 0)
                    return Ok(skills);
                else
                    return BadRequest("No skills found");
            }
            catch (SqlException ex) {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpPost("Add")] 
            // Trying to create a resource on the server
            public ActionResult Addskills( [FromHeader]string email,[FromBody]Skill s)
            {
                try
                {
                Log.Information("--Adding Skill of a particular Trainer--");

                logic.AddSkills(email, s);
                    return Created("Add", s);
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


        [HttpPut("Update")]
        public ActionResult UpdateSkills([FromHeader]string email, [FromBody] Skill s)
        {
            try
            {
                Log.Information("--Updating the skill of particular trainer--");

                logic.UpdateSkill(email,s);
                return Created("Add", s);
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



        [HttpDelete("Delete")]
        public ActionResult Delete([FromHeader]string email, [FromHeader]string skillname)
        {
            try
            {
                Log.Information("--Deleting the skill of particular trainer--");

                var rest =logic.DeleteSkill(email,skillname);
                if (rest != null)
                    return Ok(rest);
                else
                    return NotFound(); }
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


