using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Abstract;
using backend.DTOs;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Concrete
{
    public class ExpertRepo : IExpertRepo
    {
        private readonly SqliteDbContext _dbContext;
        public ExpertRepo(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Expert> GetById(int id)
        {
            Expert expert = await _dbContext.tExpert.Where(e => e.Id == id).SingleOrDefaultAsync();
            return expert;
        }

        public async Task<List<ExpertListDTO>> GetCustomList()
        {
            List<ExpertListDTO> customList = await _dbContext.tExpert
            .Include(e => e.machines)
            .Select(e => new ExpertListDTO
            {
                fullName = $"{e.firstName} {e.lastName}",
                machineNames = e.machines.Select(m => m.name).ToList()
            })
            .ToListAsync();

            return customList;
        }

        public async Task<List<Expert>> GetList(string fname)
        {
            var query = _dbContext.tExpert.AsQueryable();
            if (fname != null)
                query = query.Where(e => e.firstName.Contains(fname));

            List<Expert> expertList = await query.Include(e => e.machines).ToListAsync();
            return expertList;
        }

        public async Task<Expert> Post(Expert expertData)
        {
            _dbContext.tExpert.Add(expertData);
            int res = await _dbContext.SaveChangesAsync();
            if (res > 0)
                return expertData;
            throw new Exception();
        }

        public async Task<Expert> Put(Expert expertNewData)
        {
            _dbContext.tExpert.Update(expertNewData);
            int res = await _dbContext.SaveChangesAsync();
            if (res > 0)
                return expertNewData;
            throw new Exception();
        }
    }
}