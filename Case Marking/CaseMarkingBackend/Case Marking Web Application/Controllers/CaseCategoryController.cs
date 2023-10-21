using Case_Marking_Web_Application.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Case_Marking_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseCategoryController : ControllerBase
    {
        private readonly ICaseCategoryService _caseCategoryService;


        public CaseCategoryController(ICaseCategoryService caseCategoryService)
        {
            _caseCategoryService = caseCategoryService;
        }

        // GET: api/<CaseCategoryController>
        [HttpGet]
        public List<CaseCategory> Get()
        {
            return _caseCategoryService.GetCaseCategories();
        }

    // GET api/<CaseCategoryController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CaseCategoryController>
    [HttpPost]
    public CaseCategory Post(CaseCategory caseCategory)
    {
            return _caseCategoryService.AddCaseCategory(caseCategory);
    }

    // PUT api/<CaseCategoryController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CaseCategoryController>/5
    [HttpDelete("{id}")]
    public CaseCategory Delete(int id)
    {
            return _caseCategoryService.DeleteCaseCategory(id);
    }
}
}
