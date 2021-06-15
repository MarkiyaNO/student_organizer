using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOrganizer.PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        readonly IScheduleService _service;
        readonly IMapper _mapper;
        public ScheduleController(IScheduleService scheduleService,IMapper mapper)
        {
            _service = scheduleService;
            _mapper = mapper;
        }

        //GET: /api/schedule/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetAll()
        {
            var result = await _service.GetAllWithDetailsAsync();
            return Ok(result);
        }

        //GET: /api/schedule/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetById(int id)
        {
            var result = await _service.GetByIdWithDetailsAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ScheduleDTO schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            await _service.AddAsync(schedule);
            return Ok();
        }

    }
}
