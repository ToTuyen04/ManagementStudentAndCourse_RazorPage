using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public class CommunityProgramToanNSService : ICommunityProgramToanNSService
    {
        private CommunityProgramToanNSRepository _repository;
        public CommunityProgramToanNSService() => _repository ??= new CommunityProgramToanNSRepository();
        public async Task<List<CommunityProgramsToanN>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CommunityProgramsToanN> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
