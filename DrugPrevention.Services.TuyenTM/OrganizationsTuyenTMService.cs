using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public class OrganizationsTuyenTMService : IOrganizationsTuyenTMService
    {
        private readonly OrganizationsTuyenTMRepository _repository;
        public OrganizationsTuyenTMService() => _repository ??= new OrganizationsTuyenTMRepository();

        public async Task<List<OrganizationsTuyenTM>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<OrganizationsTuyenTM> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<List<OrganizationsTuyenTM>> SearchAsync(int id, string name, string type)
        {
            return await _repository.SearchAsync(id, name, type);
        }
        public async Task<int> AddAsync(OrganizationsTuyenTM organization)
        {
            return await _repository.CreateAsync(organization);
        }
        public async Task<int> UpdateAsync(OrganizationsTuyenTM organization)
        {
            return await _repository.UpdateAsync(organization);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var organization = await _repository.GetByIdAsync(id);
            if (organization != null)
            {
                return await _repository.RemoveAsync(organization);
            }
            return false;
        }
    }
}
