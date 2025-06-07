using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public class OrganizationProgramsTuyenTMService : IOrganizationProgramsTuyenTMService
    {
        private readonly OrganizationProgramsTuyenTMRepository _repository;
        public OrganizationProgramsTuyenTMService(OrganizationProgramsTuyenTMRepository repository) => _repository = repository ?? new OrganizationProgramsTuyenTMRepository();

        public async Task<List<OrganizationProgramsTuyenTM>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OrganizationProgramsTuyenTM> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<OrganizationProgramsTuyenTM>> SearchAsync(int id, string name, string type)
        {
            return await _repository.SearchAsync(id, name, type);
        }

        public async Task<int> AddAsync(OrganizationProgramsTuyenTM program)
        {
            return await _repository.CreateAsync(program);
        }

        public async Task<int> UpdateAsync(OrganizationProgramsTuyenTM program)
        {
            return await _repository.UpdateAsync(program);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var program = await _repository.GetByIdAsync(id);
            if (program != null)
            {
                return await _repository.RemoveAsync(program);
            }
            return false;
        }
    }
}
