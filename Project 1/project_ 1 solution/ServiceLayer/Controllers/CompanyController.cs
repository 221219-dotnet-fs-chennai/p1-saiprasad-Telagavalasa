using Bussiness_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ServiceLayer.Controllers
{



    [Route("api/[Controller]")]

    public class CompanyController : Controller
    {



        ICompanyLogic logic = new CompanyLogic();

        [HttpGet("All")]
        public ActionResult Get(string email)
        {
            try
            {
                var companies = logic.GetCompany(email);
                if (companies.Count() > 0)
                    return Ok(companies);
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
        public ActionResult AddCompany(string email, Models.Company c)
        {
            try
            {
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
        public ActionResult UpdateCompany(string email, Models.Company c)
        {
            try
            {
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
        public ActionResult Delete(string email, string cmpname)
        {
            try
            {
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
