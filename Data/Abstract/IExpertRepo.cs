using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DTOs;
using backend.Entities;

namespace backend.Data.Abstract
{
    public interface IExpertRepo
    {
        Task<List<Expert>> GetList(string fname);
        Task<Expert> GetById(int id);
        Task<List<ExpertListDTO>> GetCustomList();
        Task<Expert> Post(Expert expertData);
        Task<Expert> Put(Expert expertNewData);
    }
}