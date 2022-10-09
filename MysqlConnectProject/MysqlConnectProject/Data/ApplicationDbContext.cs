using Microsoft.Extensions.Options;
using MysqlConnectProject.Model;

namespace MysqlConnectProject.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        
        {
           
        
        }


        public DbSet<Employee> Employees { get; set; }





    }
}
