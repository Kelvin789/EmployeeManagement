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
    }
}
