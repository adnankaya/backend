using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/machines")]
    public class MachineController : ControllerBase
    {
        private readonly SqliteDbContext _dbContext;
        public MachineController(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetMachines()
        {
            List<Machine> machineList = _dbContext.tMachine
            .Include(m => m.Expert)
            .ToList();
            return Ok(machineList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachineById(int id)
        {
            Machine machine = await _dbContext.tMachine
            .Where(m => m.Id == id)
            .Include(m => m.Expert)
            .Include(m => m.machinePieces)
                .ThenInclude(mp => mp.piece)
            .SingleOrDefaultAsync();

            return Ok(machine);
        }
        [HttpPost]
        public IActionResult PostMachine([FromBody] Machine machineData)
        {
            _dbContext.tMachine.Add(machineData);
            int res = _dbContext.SaveChanges();
            if (res > 0)
                return Ok(machineData);
            return BadRequest();
        }
    }
}