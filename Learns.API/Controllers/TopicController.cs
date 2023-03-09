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
    [Route("Api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;
        public TopicController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        [HttpGet]
        [Route("GetTopics")]
        public async Task<IActionResult> GetTopics()
        {
            return Ok(await _topicRepository.GetTopics());
        }

        [HttpGet]
        [Route("GetTopicByID/{Id}")]
        public async Task<IActionResult> GetTopic(long Id)
        {
            return Ok(await _topicRepository.GetTopic(Id));
        }

        [HttpPost]
        [Route("AddTopic")]
        public async Task<IActionResult> AddTopic(Topic topic)
        {
            var result = await _topicRepository.InsertTopic(topic);
            if(0 == result.ID)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateTopic")]
        public async Task<IActionResult> UpdateTopic(Topic topic)
        {
            await _topicRepository.UpdateTopic(topic);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteTopic/{Id}")]
        public JsonResult DeleteTopic(long Id)
        {
            _topicRepository.DeleteTopic(Id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
