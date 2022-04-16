using EmployeeManagement.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly EmployeeManagementDb db;

        public JobController(EmployeeManagementDb _db)
        {
            this.db = _db;
        }

        [HttpGet("getjobs")]
        public IEnumerable<Job> Get()
        {
            var JobList = db.Job.ToList();

            return JobList;
        }

        [HttpGet("job/list")]
        public ActionResult GetList()
        {
            var JobList = db.Job.ToList();

            if (JobList != null)
            {
                return Ok(JobList);
            }

            return NotFound("List is empty");
        }
    }
}
