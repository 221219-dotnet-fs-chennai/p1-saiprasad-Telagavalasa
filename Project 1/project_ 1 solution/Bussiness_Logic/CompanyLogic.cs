using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;
using FluentApi;
using Models;

namespace Bussiness_Logic
{
    public class CompanyLogic : ICompanyLogic
    {
        private static Project1Context context = new Project1Context();
        Validation v = new Validation();
        ICompany<FluentApi.Entities.Company> repo;
        public CompanyLogic() 
        {
            repo = new FluentApi.Entities.CompanyRepo();

        }
        public void AddCompany(string email, Models.Company c)
        {
            c.TrainerId = v.TrainerIdByEmail(email);

            repo.AddCompany(Mapper.Map(c));
        }

        public Models.Company DeleteCompany(string email, string cmpname)
        {
            var deletedcompany = v.getcompanyname(v.TrainerIdByEmail(email), cmpname);
            return Mapper.Map(repo.DeleteCompany((deletedcompany)));
        }

        public IEnumerable<Models.Company> GetCompany(string email)
        {
            int id = v.TrainerIdByEmail(email);
            return Mapper.Map(repo.GetCompany(id));
        }

        public void UpdateCompany(string email, Models.Company c)
        {

            c.TrainerId = v.TrainerIdByEmail(email);
            var company = context.Companies.Where(item => item.TrainerId == c.TrainerId).First();
            if (company != null)
            {
                company.CmpName=c.CmpName;
                company.Role   =c.Role;
                company.Experience=c.Experience;
                repo.UpdateCompany(company);
            }
        }
    }
}

