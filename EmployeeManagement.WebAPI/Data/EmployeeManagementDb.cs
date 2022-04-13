using EmployeeManagement.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.WebAPI.Data
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
    }
}
