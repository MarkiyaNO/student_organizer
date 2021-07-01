using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentOrganizer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleLessonController : ControllerBase
    {
        readonly IScheduleLessonService _service;
        readonly IMapper _mapper;
        public ScheduleLessonController(IScheduleLessonService scheduleService, IMapper mapper)
        {
            _service = scheduleService;
            _mapper = mapper;
        }


        //GET: /api/schedulelesson/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleLessonDTO>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        //GET: /api/schedulelesson/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return Forbid();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ScheduleLessonDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            await _service.AddAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRange(IEnumerable<ScheduleLessonDTO> model)
        {
            foreach(var scheduleLesson in model)
            {
                await _service.DeleteByIdAsync(scheduleLesson.Id);
            }
            return Ok();
        }
    }
}
