using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspDotNetCoreAPI.DAL;
using AspDotNetCoreAPI.Model;

namespace AspDotNetCoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetPersons()
        {
            var persons = await _context.persons
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .ToListAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonModel(int id)
        {
            var person = await _context.persons
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PersonId == id && !x.IsDeleted);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> AddPerson(PersonModel personModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.persons.AddAsync(personModel);
                await _context.SaveChangesAsync();
                return Ok(new ResponseModel { respCode = "000", respDesp = "Saving successful!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel { respCode = "999", respDesp = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, PersonModel personModel)
        {
            var person = await _context.persons.FindAsync(id);

            if (person == null)
            {
                return NotFound("No data found.");
            }

            person.PersonNo = personModel.PersonNo;
            person.PersonName = personModel.PersonName;
            person.Gender = personModel.Gender;
            person.MaritalStatus = personModel.MaritalStatus;
            person.Race = personModel.Race;
            person.Religion = personModel.Religion;
            person.NrcNo = personModel.NrcNo;
            person.Photo = personModel.Photo;
            person.DOB = personModel.DOB;
            person.POB = personModel.POB;
            person.Height_ft = personModel.Height_ft;
            person.Height_in = personModel.Height_in;
            person.BloodType = personModel.BloodType;
            person.DistinguishMark = personModel.DistinguishMark;
            person.JoinDate = personModel.JoinDate;
            person.FatherName = personModel.FatherName;
            person.MotherName = personModel.MotherName;
            person.PrevOccupation = personModel.PrevOccupation;
            person.OtherQualification = personModel.OtherQualification;
            person.PerAddress = personModel.PerAddress;
            person.TownshipCode = personModel.TownshipCode;
            person.Heir_Person = personModel.Heir_Person;
            person.EmployDate = personModel.EmployDate;
            person.duty_start = personModel.duty_start;
            person.insurance = personModel.insurance;
            person.policyno = personModel.policyno;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ResponseModel { respCode = "000", respDesp = "Update successful!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel { respCode = "999", respDesp = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var personModel = await _context.persons.FindAsync(id);

            if (personModel == null)
            {
                return NotFound("No data found.");
            }

            try
            {
                personModel.IsDeleted = true;
                _context.persons.Update(personModel);
                await _context.SaveChangesAsync();
                return Ok(new ResponseModel { respCode = "000", respDesp = "Delete successful!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel { respCode = "999", respDesp = ex.Message });
            }
        }
        private bool PersonModelExists(int id)
        {
            return _context.persons.Any(e => e.PersonId == id);
        }
    }
}
