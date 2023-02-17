using Microsoft.AspNetCore.Mvc;
using Bussiness_Logic;
using Microsoft.Data.SqlClient;
using Models;

namespace ServiceLayer.Controllers
{
    [Route("api/[Controller]")]
    public class TrainerController : Controller
    {
           private  ILogic _logic ;
        private Validation _validation;
        public TrainerController(ILogic logic ,  Validation v)
        {
            _logic = logic;
            _validation = v;
        }
        [HttpGet("All")]
        public ActionResult Get()
        {

            try
            {
                var trainers = _logic.DisplayTrainer();
                if (trainers.Count() > 0)
                    return Ok(trainers);
                else
                    return BadRequest("database donot have records for Trainer Table");
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

        [HttpGet("getTrainerDetails")]
        public ActionResult Get([FromHeader] string email)
        {

            var trainer = _logic.GetTrainer(email);
            if (trainer != null)
            {
                return Ok(trainer);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("AddSignUp")] // Trying to create a resource on the server
         public ActionResult AddSignup( [FromBody] Trainer t)
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

        [HttpGet("Login")] // Trying to create a resource on the server
        public ActionResult AddLogin(string email,string password)
        {
            try
            {
               var ans = _validation.CheckTrainerExists(email,password);
                if (ans == true)
                {
                    return Ok(" Login Sucessfull");
                }
                else
                {
                    return Ok("Login failed Please try again!");
                }
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
        public ActionResult UpdateTrainer([FromBody] Trainer t)
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
        public ActionResult Delete([FromHeader]string email)
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

               