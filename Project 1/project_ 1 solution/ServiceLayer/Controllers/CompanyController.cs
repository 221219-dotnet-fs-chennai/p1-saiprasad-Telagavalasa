using Bussiness_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ServiceLayer.Controllers
{



    [Route("api/[Controller]")]

    public class CompanyController : Controller
    {



        ICompanyLogic logic;
        public CompanyController(ICompanyLogic _logic)
        {
            logic= _logic;
        }

        [HttpGet("All")]
        public ActionResult Get([FromHeader] string email)
        {
            try
            {
                Log.Information("--fetching the comapny details of the trainer--");

                var companies = logic.GetCompany(email);
                if (companies.Count() > 0)
                    return Ok(companies);
                else
                    return BadRequest("No Companies found");
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
        public ActionResult AddCompany([FromHeader]string email,[FromBody] Models.Company c)
        {
            try
            {
                Log.Information("--Adding company details of  trainer--");

                logic.AddCompany(email, c);
                return Created("Add", c);
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
        public ActionResult UpdateCompany([FromHeader]string email,[FromBody] Models.Company c)
        {
            try
            {
                Log.Information("--Updating the comapny details of trainer--");

                logic.UpdateCompany(email, c);
                return Created("Updated", c);
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
        public ActionResult Delete([FromHeader] string email, [FromHeader] string cmpname)
        {
            try
            {
                Log.Information("deleting the company details of trainer");

                var rest = logic.DeleteCompany(email, cmpname);
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
