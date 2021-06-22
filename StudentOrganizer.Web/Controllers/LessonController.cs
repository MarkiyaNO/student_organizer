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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentOrganizer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        readonly ILessonService _service;
        readonly IMapper _mapper;
        public LessonController(ILessonService scheduleService, IMapper mapper, UserManager<Student> userManager)
        {
            _service = scheduleService;
            _mapper = mapper;
        }

        //GET: /api/schedule/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create(LessonDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            await _service.AddAsync(model);
            return Ok();
        }
    }
}
