using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public interface ICommunityProgramToanNSService
    {
        Task<List<CommunityProgramsToanN>> GetAllAsync();
        Task<CommunityProgramsToanN> GetByIdAsync(int id);
        //Task<List<CommunityProgramsToanN>> SearchAsync(int id, string name, string location, string status);
        //Task<bool> AddAsync(CommunityProgramsToanN program);
        //Task<bool> UpdateAsync(CommunityProgramsToanN program);
        //Task<bool> DeleteAsync(int id);
    }
}
