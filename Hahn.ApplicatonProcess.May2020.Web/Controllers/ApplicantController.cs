using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Service;
using Hahn.ApplicatonProcess.May2020.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [Route("api/applicant")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _service;

        public ApplicantController(IApplicantService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Applicant>> Post(Applicant applicant)
        {
            _service.Insert(applicant);

            return CreatedAtAction(nameof(Get), new { id = applicant.ID }, applicant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Applicant applicant)
        {
            if (id != applicant.ID)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(applicant);
            }
            catch (Exception)
            {
                if (!_service.Any(o => o.ID == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> Get(int id)
        {
            var applicant = _service.Get(o => o.ID == id).FirstOrDefault();

            if (applicant == null)
            {
                return NotFound();
            }

            return applicant;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Applicant>> Delete(int id)
        {
            var applicant = _service.Get(o => o.ID == id).FirstOrDefault();

            if (applicant == null)
            {
                return NotFound();
            }

            _service.Remove(applicant);

            return NoContent();
        }
    }
}
