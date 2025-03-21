using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
