using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MysqlConnectProject.Data;
using MysqlConnectProject.Model;

namespace MysqlConnectProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {


        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext) { 
            
            this.dbContext = dbContext;

        
        }



        [HttpGet]
        public async Task<IActionResult> getAllEmployes()
        {
            //Console.WriteLine(dbContext.Employees.ToListAsync());

           return Ok(dbContext.Employees.FromSqlRaw("SELECT * FROM employees")) ;
        }




        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> getEmployee([FromRoute] int id)
        {
            var contact = await dbContext.Employees.FindAsync(id);

            if (contact == null)
            {
                return NotFound();

            }

            return Ok(contact);


        }



        [HttpPost]
        public async Task<IActionResult> addEmployee(Employee employee) {

            var employee1 = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,  
                Email = employee.Email,
                Address = employee.Address, 
                Phone = employee.Phone,



            };

            
            await dbContext.Employees.AddAsync(employee1);
            await dbContext.SaveChangesAsync();
            return Ok(employee1);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmploye([FromRoute] int id, Employee employee)
        {


            var employee1 = dbContext.Employees.Find(id);


            if (employee1 == null)
            {
                return NotFound();


            }
            else
            {
                employee1.Id = employee.Id;
                employee1.Phone = employee.Phone;
                employee1.Name = employee.Name;
                employee1.Email = employee.Email;
                employee1.Address = employee.Address;


                await dbContext.SaveChangesAsync();
                return Ok(employee1);

            }


        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deleteEmploye([FromRoute] int id)  {


            var employee1  =  await dbContext.Employees.FindAsync(id);

            if (employee1 == null) { 
                return NotFound();
            
            }

            dbContext.Employees.Remove(employee1);
            await dbContext.SaveChangesAsync ();

            return Ok(employee1);


        }

    }



}
