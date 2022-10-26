using ODataWebApi.Models;

namespace ODataWebApi.Services
{
    public interface ICompanyRepo
    {
        public IQueryable<Company> GetAllCompanies();
        public IQueryable<Company> GetCompanyById(int id);
        public void CreateCompany(Company company);  
        public void DeleteCompany(Company company);
        public void UpdateCompany(Company company);
        
    }
}
