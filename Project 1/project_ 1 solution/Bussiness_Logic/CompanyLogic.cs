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
        Project1Context context;
        Validation v ;
        ICompany<FluentApi.Entities.Company> repo;
        public CompanyLogic(Validation _v,Project1Context _context, ICompany<FluentApi.Entities.Company> _repo) 
        {
            repo = _repo;
            v = _v;
            context= _context;

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

