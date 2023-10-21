using Case_Marking_Web_Application.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Case_Marking_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private readonly ICourtsService _courtsService;


        public CourtsController(ICourtsService courtsService)
        {
            _courtsService = courtsService;
        }

        // GET: api/<CaseCategoryController>
        [HttpGet]
        public List<Court> Get()
        {
            return _courtsService.GetCourts();
        }

    // GET api/<CaseCategoryController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CaseCategoryController>
    [HttpPost]
    public Court Post(Court caseCategory)
    {
            return _courtsService.AddCourt(caseCategory);
    }

    // PUT api/<CaseCategoryController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CaseCategoryController>/5
    [HttpDelete("{id}")]
    public Court Delete(int id)
    {
            return _courtsService.DeleteCourt(id);
    }
}
}
