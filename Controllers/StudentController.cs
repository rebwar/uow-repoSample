using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using uow_repoSample.Core.IConfiguration;
using uow_repoSample.Models;

namespace uow_repoSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StudentController> _logger;
        public StudentController(IUnitOfWork unitOfWork, ILogger<StudentController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Students = await _unitOfWork.Student.All();
            return Ok(Students);
        }

        [HttpPost]
        public async Task<IActionResult> NewStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = Guid.NewGuid();
                await _unitOfWork.Student.Add(student);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetStudent", new { student.Id }, student);

            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var existStudent = await _unitOfWork.Student.Get(id);
            if (existStudent is not null)
                return Ok(existStudent);

            return NotFound();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _unitOfWork.Student.Get(id);
            if (student is null)
                return BadRequest();
            await _unitOfWork.Student.Delete(id);
            await _unitOfWork.CompleteAsync();
            return Ok(student);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Student student,Guid id){
            if(id!=student.Id)
                return BadRequest();
            else{
                await _unitOfWork.Student.Update(student);
                await _unitOfWork.CompleteAsync();
                return NoContent();
                
            }
        }


    }
}