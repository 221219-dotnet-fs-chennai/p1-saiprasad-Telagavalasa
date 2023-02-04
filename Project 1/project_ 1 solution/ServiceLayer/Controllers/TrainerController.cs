using Microsoft.AspNetCore.Mvc;
using Bussiness_Logic;
using Microsoft.Data.SqlClient;
using Models;

namespace ServiceLayer.Controllers
{
    [Route("api/[Controller]")]
    public class TrainerController : Controller
    {
        ILogic _logic = new Logic();
        /*public TrainerController(ILogic logic)
        {
            _logic = logic;
        }*/
        [HttpGet("All")]
        public ActionResult Get()
        {

            try
            {
                var trainers = _logic.DisplayTrainer();
                if (trainers.Count() > 0)
                    return Ok(trainers);
                else
                    return BadRequest("Seems like your database donot have records for Restaurant Table");
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
        [HttpPost("AddSignUp")] // Trying to create a resource on the server
         public ActionResult AddSignup( Trainer t)
         {
             try
             {
                 _logic.AddTrainerSignup(t);
                return Created("Add", t);
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
        //[HttpPost("Add")] // Trying to create a resource on the server
        //public ActionResult AddMoreTrainer([FromBody] Trainer t)
        //{
        //    try
        //    {
        //        _logic.AddTrainer(t);
        //        return Created("Add", t);
        //    }
        //    catch (SqlException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
        [HttpPut("Update")]
        public ActionResult UpdateTrainer( Trainer t)
        {
            try
            {
                _logic.UpdateTrainer(t);
                return Created("Add", t);
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
        public ActionResult Delete(string email)
        {
            try
            {
                var rest = _logic.RemoveTrainerByName(email);
                    if (rest != null)
                        return Ok(rest);
                    else
                        return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
     

        }
    }

               