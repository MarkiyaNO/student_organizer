﻿using Microsoft.AspNetCore.Mvc;
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
        // GET: api/<AssignmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AssignmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AssignmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AssignmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssignmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}