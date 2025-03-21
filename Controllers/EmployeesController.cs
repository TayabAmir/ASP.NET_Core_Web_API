using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.DTOs;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext;
        public EmployeesController(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var emps = _dBContext.Employees.ToList();
            return Ok(emps);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var emp = _dBContext.Employees.Find(id);
            if(emp is not null)
            {
                return Ok(emp);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO empDTO)
        {
            var empEntity = new Employee()
            {
                Name = empDTO.Name,
                Email = empDTO.Email,
                Phone = empDTO.Phone,
                Salary = empDTO.Salary
            };
            _dBContext.Employees.Add(empEntity);
            _dBContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO empDTO)
        {
            var emp = _dBContext.Employees.Find(id);
            if (emp is not null)
            {
                emp.Name = empDTO.Name;
                emp.Email = empDTO.Email;
                emp.Phone = empDTO.Phone;
                emp.Salary = empDTO.Salary;
                _dBContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var emp = _dBContext.Employees.Find(id);
            if (emp is not null)
            {
                _dBContext.Employees.Remove(emp);
                _dBContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
A