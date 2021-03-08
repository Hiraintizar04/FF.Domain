using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FF.Data.Repository;
using FF.Data.Models;

namespace AssignmentFF.Controllers
{/// <summary>
/// set route attribute to make request as 'api/applicant'
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {


        private readonly ApplicantRepository _repository;
        /// <summary>
        /// initiate the repository
        /// </summary>
        /// <param name="repository"></param>
        public ApplicantController(ApplicantRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// this post method is used to fill all the applicant properties 
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns> </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] Applicant applicant)
        {
            await _repository.AddApplicant(applicant);
            return CreatedAtAction(nameof(GetById), new { id = applicant.ApplicantId }, applicant);
        }
        /// <summary>
        /// this get method is used to view the all the applicants along with its details which has been posted
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Applicant> Get()
        {
            return _repository.GetAllApplicants();
        }

        /// <summary>
        /// this get method can view the existing applicant by giving its specific id
        /// i-e filter applicant records by applicant id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Applicant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            if (!_repository.GetApplicantById(id, out var applicantDetails))
            {
                return NotFound();
            }
            return Ok(applicantDetails);
        }
        /// <summary>
        ///  this put method is used to update the selected applicant details from the list using its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicant"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Applicant applicant)
        {
            await _repository.UpdateApplicant(id, applicant);
            return NoContent();

        }


        /// <summary>
        /// this method is used to delete the selected applicant and its details by giving its specific id 
        /// i-e  delete by applicant id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteApplicant(id);
            return NoContent();
        }
    }
}
