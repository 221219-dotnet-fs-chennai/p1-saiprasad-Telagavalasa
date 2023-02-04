using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi
{
      public interface ICompany<Company>
      {
        List<Company> GetCompany(int id);
        void AddCompany(Entities.Company company);
        void UpdateCompany(Entities.Company company);

        Company DeleteCompany(Entities.Company company);
        }
}
