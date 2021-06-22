using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Models;
using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentOrganizer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        readonly IAssignmentService _service;
        readonly IMapper _mapper;

        public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
        {
            _service = assignmentService;
            _mapper = mapper;
        }

        //GET: /api/assignment/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        //GET: /api/assignment/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return Forbid();
        }

        [HttpPost]
        public async Task<ActionResult> Create(JObject model)
        {
            var assignment = model["assignment"].ToObject<AssignmentDTO>();
            var scheduleLessonId = model["id"].ToObject<int>();

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            await _service.AddAsync(assignment, scheduleLessonId);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromQuery]int? state)
        {
            if (state == null)
                return BadRequest();
           await _service.UpdateState(id, state.Value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
