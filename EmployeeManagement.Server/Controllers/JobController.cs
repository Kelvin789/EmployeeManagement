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

        [HttpPost("edit")]
        public ActionResult Edit(Job job)
        {
            SaveJobResponse response = new SaveJobResponse();

            try
            {
                string actionCompleted = "none";
                Job existingJob = db.Job.Where(j => j.ID == job.ID).FirstOrDefault();

                if (existingJob != null)
                {
                    existingJob.Title = job.Title;
                    existingJob.IsActive = job.IsActive;
                    actionCompleted = "Job updated";
                }
                else
                {
                    db.Job.Add(job);
                    actionCompleted = "Job created";
                }

                db.SaveChanges();

                response.ReturnCode = 1;
                response.ReturnMessage = $"Job {job.ID} - {job.Title} - {job.IsActive} - {actionCompleted}";
            }
            catch (Exception ex)
            {
                response.ReturnCode = -1;
                response.ReturnMessage = $"{ex.Message}";
            }

            return Ok(response);
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
