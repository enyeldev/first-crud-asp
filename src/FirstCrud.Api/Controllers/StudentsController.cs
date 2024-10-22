using FirstCrud.Api.Requests;
using FirstCrud.Domain.Data;
using FirstCrud.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCrud.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly FirstCrudDbContext _context;

        public StudentsController(FirstCrudDbContext context)
        {
            _context = context;
        }

        

        [HttpGet("GetStudents")]
        public async Task<ActionResult<List<Student>>> Get()
        {
           return await _context.Students.Where(e => e.Deleted == false).ToListAsync();
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult> Post(NewStudentRequest request)
        {
            var student = new Student();

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.Adress = request.Adress;
            student.Phone = request.Phone;

            _context.Add(student);
            await _context.SaveChangesAsync();

            return Ok(new { msg = "New student is save" });

        }

        [HttpGet("GetStudentById/{id:int}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(e => e.Id == id);

            if (student is null)
            {
                return NotFound(new {msg = "Not found student"});
            }

            return student;

        }

        [HttpPut("EditStudent/{id:int}")]
        public async Task<ActionResult> Put(int id, Student request)
        {

            var existStudent = await _context.Students.AnyAsync(e => e.Id == id);

            if (!existStudent)
            {
                return NotFound();
            }

            request.Id = id;

            _context.Students.Update(request);
            await _context.SaveChangesAsync();

            return Ok(new {msg = "Student is edited" });

        }

        [HttpDelete("DeleteStudent/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var student = await _context.Students.FirstOrDefaultAsync(e => e.Id == id);

            if (student is null )
            {
                return NotFound();
            }

            if (student.Deleted)
            {
                return BadRequest(new { msg = "This item is already deleted" });
            }


            student.Deleted = true;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return Ok(new {msg = "Student was deleted"});

        }

    }
}
