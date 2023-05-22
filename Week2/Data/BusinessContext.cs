using Microsoft.EntityFrameworkCore;

namespace Week2.Data
{
    public class BusinessContext:DbContext
    {
        public BusinessContext(DbContextOptions<BusinessContext> options):base(options) 
        {
        
        }
        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
    }
}
