using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Models;
using StudentOrganizer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOrganizer.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : ControllerBase
    {
        readonly IScheduleService _service;
        readonly IMapper _mapper;
        readonly UserManager<Student> _userManager;
        public ScheduleController(IScheduleService scheduleService, IMapper mapper, UserManager<Student> userManager)
        {
            _service = scheduleService;
            _mapper = mapper;
            _userManager = userManager;
        }

        //GET: /api/schedule/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetAll()
        {
            var result = await _service.GetAllWithDetailsAsync(User);
            return Ok(result);
        }

        //GET: /api/schedule/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetById(int id)
        {
            var result = await _service.GetByIdWithDetailsAsync(id, User);
            if (result != null)
                return Ok(result);
            return Forbid();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ScheduleDTO schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            await _service.AddAsync(schedule, User);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id, User);
            return Ok();
        }

    }
}
