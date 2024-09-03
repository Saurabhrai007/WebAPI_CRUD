using APICore.Data;
using APICore.Models;
using APICore.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AplDBContext dBContext;

        public EmployeesController(AplDBContext dBContext)
        {
            this.dBContext = dBContext;
        }



        [HttpGet]
        public IActionResult GetData()
        {

            return Ok(dBContext.employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetDatabyId(Guid id)
        {
            var data = dBContext.employees.Find(id);
           if(data is null)
            {
                return NotFound();
            }

            return Ok(data);
        }



        [HttpPost]
        public IActionResult PostData(AddEmployeeDTO dTO)
        {

            var employeeEntity = new Employee()
            {
                Name = dTO.Name,
                Email = dTO.Email,
                Phone = dTO.Phone,
                Salary = dTO.Salary,

            };

            dBContext.employees.Add(employeeEntity);
            dBContext.SaveChanges();
            return Ok(employeeEntity);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateData(Guid id, UpdateEmployeeDTO dTO )
        {
            var data = dBContext.employees.Find(id);
            if(data is null)
            {
                return NotFound();
            }

            data.Name = dTO.Name;
            data.Email = dTO.Email;
            data.Phone = dTO.Phone;
            data.Salary = dTO.Salary;

            dBContext.SaveChanges();
            return Ok(data);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteData(Guid id)
        {
            var data = dBContext.employees.Find(id);
            if(data is null)
            {
                return NotFound();
            }
            dBContext.employees.Remove(data);
            dBContext.SaveChanges();
            return Ok();

        }


    }
}
