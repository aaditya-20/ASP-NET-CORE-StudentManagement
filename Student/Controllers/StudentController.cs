using DnsClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Student.Data;
using Student.Models;

namespace Student.Controllers
{
    [ApiController]
    [Route("api")]

    public class StudentController : ControllerBase
    {
        private readonly MongoDbContext _mongoDbContext;
        public StudentController(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }
        [HttpPost]//HTTP VERB ITS DEFINE THAT BELOW END PT is get endpt.
        [Route("register")]
        public IActionResult Registration([FromBody] Register register)
        {
            // create user inside db
            var AllStudents = _mongoDbContext.students.Find(b => (b.Email == register.Email)).FirstOrDefault();
            if (AllStudents != null)
            {
                return BadRequest("User Already Exist");
            }

            register.Id = ObjectId.GenerateNewId().ToString();
            _mongoDbContext.students.InsertOne(register);


            return Ok(register);


        }
        [HttpPost]//HTTP VERB ITS DEFINE THAT BELOW END PT is get endpt.
        [Route("login")]
        public IActionResult Login([FromBody] Login login)
        {
           // check if user exists
            var AllStudents = _mongoDbContext.students.Find(b => (b.Email == login.Email&&b.Password==login.Password)).FirstOrDefault();

            if (AllStudents == null)
            {
                return NotFound();
            }

            return Ok(AllStudents);            

        }

        [HttpPost]//HTTP VERB ITS DEFINE THAT BELOW END PT is get endpt.
        [Route("addFreind")]
        public IActionResult update([FromBody] Register updated)
        {
            // check if user exists
            

             ReplaceOneResult result = _mongoDbContext.students.ReplaceOne(b => (b.Id == updated.Id), updated);

            var data = _mongoDbContext.students.Find(b => (b.Id == updated.Id)).FirstOrDefault();

            return Ok(data);

        }




    }
}
