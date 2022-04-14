using EmployeeManagement.Server.Data.Models;
using EmployeeManagement.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private EmployeeManagementDb db;

        [HttpGet]
        public IEnumerable<Job> Get()
        {
            var JobList = db.Jobs.ToList();

            return JobList;
        }

        [HttpGet("job/list")]
        public ActionResult GetList()
        {
            var JobList = db.Jobs.ToList();

            if (JobList != null)
            {
                return Ok(JobList);
            }

            return NotFound("List is empty");
        }
    }
}
