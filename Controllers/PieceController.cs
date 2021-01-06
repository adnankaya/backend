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
    [Route("api/pieces")]
    public class PieceController : ControllerBase
    {
        private readonly SqliteDbContext _dbContext;
        public PieceController(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPieces()
        {
            List<Piece> pieces = await _dbContext.tPiece
            .Include(p => p.machinePieces)
            .ToListAsync();

            return Ok(pieces);
        }
        [HttpPost]
        public async Task<IActionResult> PostPiece([FromBody] Piece pieceData)
        {
            _dbContext.tPiece.Add(pieceData);
            int res = await _dbContext.SaveChangesAsync();
            if (res > 0)
                return Ok(pieceData);
            return BadRequest();
        }
    }
}