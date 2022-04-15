using System;

namespace EmployeeManagement.Server.Data.Models
{
    public class Job
    {
        public short ID { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }
    }
}
