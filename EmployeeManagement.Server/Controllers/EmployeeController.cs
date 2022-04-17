using EmployeeManagement.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeManagementDb db;

        public EmployeeController(EmployeeManagementDb _db)
        {
            this.db = _db;
        }

        [HttpGet("getlist")]
        public ActionResult GetList()
        {
            try
            {
                List<Employee> EmployeeList = db.Employee.ToList();

                if (EmployeeList != null)
                {
                    return Ok(EmployeeList);
                }

                return NotFound("Employee list is empty");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("edit")]
        public ActionResult Edit(Employee employee)
        {
            SaveResponse response = new SaveResponse();

            try
            {
                string actionCompleted = "No action taken";
                Employee existingEmployee = db.Employee.Where(e => e.ID == employee.ID).FirstOrDefault();

                if (existingEmployee != null)
                {
                    existingEmployee.EmployeeNo = employee.EmployeeNo;
                    existingEmployee.Name = employee.Name;
                    existingEmployee.PhoneNo = employee.PhoneNo;
                    existingEmployee.Email = employee.Email;
                    existingEmployee.JobID = employee.JobID;
                    existingEmployee.SalaryAmount = employee.SalaryAmount;
                    existingEmployee.StartDate = employee.StartDate;
                    existingEmployee.LeaveDate = employee.LeaveDate;
                    existingEmployee.IsActive = employee.IsActive;
                    actionCompleted = "Employee updated";
                }
                else
                {
                    employee.DateCreated = DateTime.UtcNow;
                    db.Employee.Add(employee);
                    actionCompleted = "Employee created";
                }

                db.SaveChanges();

                response.ReturnCode = 1;
                response.ReturnMessage = $"{actionCompleted} for employee name: '{employee.Name}', employee no: '{employee.EmployeeNo}'";
            }
            catch (Exception ex)
            {
                response.ReturnCode = -1;
                response.ReturnMessage = $"{ex.Message}";
            }

            return Ok(response);
        }
    }
}
