using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using ODataWebApi.Models;
using ODataWebApi.Services;

namespace ODataWebApi.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepo _repo;

        public CompaniesController(ICompanyRepo repo)
        {
            _repo = repo;
        }

        [EnableQuery(PageSize =3)] //to enable OData
        [HttpGet]
        public  IQueryable<Company> GetAll()
        {
      
             return _repo.GetAllCompanies();


        }

        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<Company> GetById([FromODataUri] int key)
        {
            return SingleResult.Create(_repo.GetCompanyById(key));
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            try
            {
                _repo.CreateCompany(company);
                return Created("companies", company);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut]
        public IActionResult Update(Company company, [FromODataUri] int id)
        {
            try
            {
                _repo.UpdateCompany(company);
                return Ok(company);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpDelete]
        public  IActionResult Delete([FromODataUri] int key)
        {
            try
            {
                var company=_repo.GetCompanyById(key);
                _repo.DeleteCompany(company.First());
                return Ok("deleted!");

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
