using EmployeeManagement.Server.Data.Models;
using EmployeeManagement.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Server.Data
{
    public class EmployeeManagementDb : DbContext
    {
        ConfigService _configService;

        public EmployeeManagementDb(ConfigService configService)
        {
            _configService = configService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configService.ConnectionString);
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
