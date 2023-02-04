using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Entities
{
    public class CompanyRepo : ICompany<Company>
    {
        Project1Context context=new Project1Context();
        public void AddCompany(Company company)
        {
            context.Companies.Add(company);

            context.SaveChanges();
        }

        public Company DeleteCompany(Company company)
        {

            context.Companies.Remove(company);

            context.SaveChanges();
            return company;

        }

        public List<Company> GetCompany(int id)
        {
          return context.Companies.Where(c=>c.TrainerId==id).ToList();
        }

        public void UpdateCompany(Company company)
        {

            context.Companies.Update(company);

            context.SaveChanges();
        }
    }
}
