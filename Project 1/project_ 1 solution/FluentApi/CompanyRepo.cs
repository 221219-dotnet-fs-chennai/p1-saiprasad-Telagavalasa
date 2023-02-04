using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Entities
{
    public class CompanyRepo : ICompany<Company>
    {
        public void AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Company DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
