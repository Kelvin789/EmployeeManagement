using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Shared.Services
{
    public class ConfigService
    {
        private IConfiguration _config;

        public ConfigService(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionString => _config["ConnectionStrings:EmployeeManagementDb"];
    }
}
