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
            List<Job> JobList = db.Job.ToList();

            return JobList;
        }

        [HttpPost("edit")]
        public ActionResult Edit(Job job)
        {
            SaveResponse response = new SaveResponse();

            try
            {
                string actionCompleted = "No action taken";
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
                response.ReturnMessage = $"{actionCompleted} for job title: '{job.Title}', active status: '{job.IsActive}'";
            }
            catch (Exception ex)
            {
                response.ReturnCode = -1;
                response.ReturnMessage = $"{ex.Message}";
            }

            return Ok(response);
        }

        [HttpPost("delete")]
        public ActionResult Delete(Job job)
        {
            SaveResponse response = new SaveResponse();

            try
            {
                string actionCompleted = "No action taken";
                Job existingJob = db.Job.Where(j => j.ID == job.ID).FirstOrDefault();

                if (existingJob != null)
                {
                    db.Job.Remove(existingJob);
                    actionCompleted = "Job deleted";
                    db.SaveChanges();

                    response.ReturnCode = 1;
                    response.ReturnMessage = $"{actionCompleted} for job title: '{job.Title}', active status: '{job.IsActive}'";
                }
                else
                {
                    response.ReturnCode = -1;
                    response.ReturnMessage = $"{actionCompleted}, cannot find job title: '{job.Title}', active status: '{job.IsActive}'";
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                response.ReturnCode = -1;
                response.ReturnMessage = $"{ex.Message}";
            }

            return Ok(response);
        }

        [HttpGet("getlist")]
        public ActionResult GetList()
        {
            List<Job> JobList = db.Job.Where(j => j.IsActive).ToList();

            if (JobList != null)
            {
                return Ok(JobList);
            }

            return NotFound("List is empty");
        }
    }
}
