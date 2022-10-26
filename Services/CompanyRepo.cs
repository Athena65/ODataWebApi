using Microsoft.EntityFrameworkCore;
using ODataWebApi.Data;
using ODataWebApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ODataWebApi.Services
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly DataContext _context;

        public CompanyRepo(DataContext context)
        {
            _context = context;
        }
        public void CreateCompany(Company company)
        {
           _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public  IQueryable<Company> GetAllCompanies()
        {
            return _context.Companies.Include(a => a.Products).AsQueryable();
        }

        public  IQueryable<Company> GetCompanyById(int id)
        {
            return _context.Companies.Include(x => x.Products).AsQueryable().Where(c => c.ID == id);
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies
                .Update(company);
            _context.SaveChanges();



        }
    }
}
