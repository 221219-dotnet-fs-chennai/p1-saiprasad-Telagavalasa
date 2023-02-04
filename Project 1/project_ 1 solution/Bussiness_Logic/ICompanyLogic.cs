using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic
{
    public  interface ICompanyLogic
    {
        IEnumerable<Models.Company> GetCompany(string email);
        void AddCompany(string email, Models.Company c);
        void UpdateCompany(string email, Models.Company c);
        Models.Company DeleteCompany(string email, string cmpname);
    }
}
