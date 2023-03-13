using Learns.Model.Classes;
using Learns.Model.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learns.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private readonly IInstituteRepository _instituteRepository;
        public InstituteController(IInstituteRepository instituteRepository)
        {
            _instituteRepository = instituteRepository;
        }
        [HttpGet]
        [Route("GetInstitute")]
        public async Task<IActionResult> Get()
        {
            //return Ok(await new InstituteRepository(new LearnsContext()).GetInstitutes());
            return Ok(await _instituteRepository.GetInstitutes());
        }

        [Route("GetInstituteByID/{Id}")]
        public async Task<IActionResult> GetEmpByID(long Id)
        {
            return Ok(await _instituteRepository.GetInstituteByID(Id));
        }
        [HttpPost]
        [Route("AddInstitute")]
        public async Task<IActionResult> Post(Institute emp)
        {
            var result = await _instituteRepository.InsertInstitute(emp);
            if (result.ID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateInstitute")]
        public async Task<IActionResult> Put(Institute emp)
        {
            await _instituteRepository.UpdateInstitute(emp);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteInstitute")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var result = _instituteRepository.DeleteInstitute(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
