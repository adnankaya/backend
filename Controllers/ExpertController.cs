using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Data.Abstract;
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
        private readonly IExpertRepo _expertRepo;
        public ExpertController(IExpertRepo expertRepo)
        {
            _expertRepo = expertRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetExperts([FromQuery(Name = "fname")] string fname)
        {
            List<Expert> expertList = await _expertRepo.GetList(fname);
            return Ok(expertList);
        }
        [HttpGet("custom-list")]
        public async Task<IActionResult> GetCustomExperts()
        {
            List<ExpertListDTO> customList = await _expertRepo.GetCustomList();

            // // second way
            // var customList = _expertRepo.tExpert
            // .Include(e => e.machines)
            // .Select(e => new
            // {
            //     fullName = $"{e.firstName} {e.lastName}",
            //     machineNames = e.machines.Select(m => m.name).ToList(),
            //     message = "Tebrikler başardın!"
            // })
            // .ToList();
            return Ok(customList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpertById(int id)
        {
          Expert expert = await _expertRepo.GetById(id);
          return Ok(expert);  
        }

        [HttpPost]
        public async Task<IActionResult> PostExpert([FromBody] Expert expertData)
        {
            return Ok(await _expertRepo.Post(expertData));
        }
        [HttpPut]
        public async Task<IActionResult> PutExpert([FromBody] Expert expertNewData)
        {
            return Ok(await _expertRepo.Put(expertNewData));
        }
    }
}