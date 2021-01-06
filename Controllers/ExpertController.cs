using System.Collections.Generic;
using System.Linq;
using backend.Data;
using backend.DTOs;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/experts")]
    public class ExpertController : ControllerBase
    {
        private readonly SqliteDbContext _dbContext;
        public ExpertController(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetExperts([FromQuery(Name = "fname")] string fname)
        {
            var query = _dbContext.tExpert.AsQueryable();
            if (fname != null)
                query = query.Where(e => e.firstName.Contains(fname));

            List<Expert> expertList = query.Include(e => e.machines).ToList();
            return Ok(expertList);
        }
        [HttpGet("custom-list")]
        public IActionResult GetExpertCustomExperts()
        {
            // List<ExpertListDTO> customList = _dbContext.tExpert
            // .Include(e => e.machines)
            // .Select(e => new ExpertListDTO{
            //     fullName = $"{e.firstName} {e.lastName}",
            //     machineNames = e.machines.Select(m=>m.name).ToList()
            // })            
            // .ToList();

            // second way
            var customList = _dbContext.tExpert
            .Include(e => e.machines)
            .Select(e => new
            {
                fullName = $"{e.firstName} {e.lastName}",
                machineNames = e.machines.Select(m => m.name).ToList(),
                message = "Tebrikler başardın!"
            })
            .ToList();
            return Ok(customList);
        }

        [HttpGet("{id}")]
        public IActionResult GetExpertById(int id)
        {
            Expert expert = _dbContext.tExpert
                .Where(e => e.Id == id)
                .Include(e => e.machines)
                .SingleOrDefault();
            return Ok(expert);
        }

        [HttpPost]
        public IActionResult PostExpert([FromBody] Expert expertData)
        {
            _dbContext.tExpert.Add(expertData);
            int res = _dbContext.SaveChanges();
            if (res > 0)
                return Ok(expertData);
            return BadRequest();
        }
    }
}