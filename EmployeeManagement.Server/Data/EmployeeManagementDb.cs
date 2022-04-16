using EmployeeManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Server.Data
{
    public class EmployeeManagementDb : DbContext
    {
        public EmployeeManagementDb(DbContextOptions<EmployeeManagementDb> options) : base(options)
        {
        }

        public DbSet<Job> Job { get; set; }
    }
}
