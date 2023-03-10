using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learns.Model.Classes;
using Learns.Model.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learns.API.Controllers
{
    
    [ApiController]
    [Route("Api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        [Route("GetSubjects")]
        public async Task<IActionResult> GetSubjects()
        {
            return Ok(await _subjectRepository.GetSubjects());
        }

        [HttpGet]
        [Route("GetSubjectID/{Id}")]
        public async Task<IActionResult> GetSubject(long Id)
        {
            return Ok(await _subjectRepository.GetSubjectByID(Id));
        }

        [HttpPost]
        [Route("AddSubject")]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            var result = await _subjectRepository.InsertSubject(subject);
            if(0 == result.ID)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPost]
        [Route("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(Subject subject)
        {
            await _subjectRepository.UpdateSubject(subject);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteSubject")]
        public JsonResult DeleteSubject(long Id)
        {
            _subjectRepository.DeleteSubject(Id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
