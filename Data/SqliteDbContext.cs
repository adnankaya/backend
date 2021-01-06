using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Expert> tExpert { get; set; }
        public DbSet<Machine> tMachine { get; set; }
        public DbSet<MachinePiece> tMachinePiece { get; set; }
        public DbSet<Piece> tPiece { get; set; }
    }
}