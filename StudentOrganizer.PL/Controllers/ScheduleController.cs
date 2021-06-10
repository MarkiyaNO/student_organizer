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
        public ScheduleController(IScheduleService scheduleService)
        {
            _service = scheduleService;
        }

        //GET: /api/schedule/
        [HttpGet]
        public ActionResult<IEnumerable<ScheduleDTO>> GetAll()
        {
            var result = _service.GetAllWithDetailsAsync();
            return Ok(result);
        }

        //GET: /api/schedule/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetById(int id)
        {
            var result = await _service.GetByIdWithDetailsAsync(id);
            return Ok(result);
        }

    }
}
