using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public interface IOrganizationsTuyenTMService
    {
        Task<List<OrganizationsTuyenTM>> GetAllAsync();
        Task<OrganizationsTuyenTM> GetByIdAsync(int id);
        Task<List<OrganizationsTuyenTM>> SearchAsync(int id, string name, string type);
        Task<int> AddAsync(OrganizationsTuyenTM organization);
        Task<int> UpdateAsync(OrganizationsTuyenTM organization);
        Task<bool> DeleteAsync(int id);
    }
}
