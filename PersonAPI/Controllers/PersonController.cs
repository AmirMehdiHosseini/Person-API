using Microsoft.AspNetCore.Mvc;
using PersonAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonAPI.Controllers
{
    public record CreatePersonModel
    {
        public string? Name { get; set; }
        public string? FamilyName { get; set; }
        public string? FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int NationalCode { get; set; }
    }
    public record UpdatePersonModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FamilyName { get; set; }
        public string? FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        public static List<Person> _peopleList = [];

        // GET: api/<PersonController>
        [HttpGet]
        public List<Person> GetAll()
        {
            return _peopleList;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id:int}")]
        public Person? GetByID(int id)
        {
            return FindIndexById(id);
        }


        // GET api/<PersonController>/5,
        [HttpGet("{NationalCode:length(8,10)}")]
        public Person? GetByNationalCode(int NationalCode)
        {
            return FindIndexByNationalCode(NationalCode);
        }


        // POST api/<PersonController>
        [HttpPost]
        public void Create([FromBody] CreatePersonModel model)
        {
            Person person = new Person(model.Name, model.FamilyName, model.FatherName, model.BirthDate, model.NationalCode);
            _peopleList.Add(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut]
        public void Put([FromBody] UpdatePersonModel model)
        {
            var person = FindIndexById(model.Id);
            ArgumentNullException.ThrowIfNull(person, nameof(model));

            person.BirthDate = model.BirthDate;
            person.Name = model.Name;
            person.FamilyName = model.FamilyName;
            person.FatherName = model.FatherName;
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var person = FindIndexById(id);
            ArgumentNullException.ThrowIfNull(person, nameof(person));
            _peopleList.Remove(person);
        }



        private static Person? FindIndexById(int id)
        {
            return _peopleList.Find(x => x.Id == id);
        }

        private static Person? FindIndexByNationalCode(int nationalCode)
        {
            return _peopleList.Find(x => x.NationalCode == nationalCode);
        }
    }
}
