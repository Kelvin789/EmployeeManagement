using System;

namespace EmployeeManagement.Shared.Models
{
    public class Employee
    {
        public Int16 ID { get; set; }
        public string EmployeeNo { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public Int16 JobID { get; set; }
        public string SalaryAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
