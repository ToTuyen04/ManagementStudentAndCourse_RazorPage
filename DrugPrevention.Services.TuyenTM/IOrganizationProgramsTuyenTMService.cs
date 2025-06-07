using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public interface IOrganizationProgramsTuyenTMService
    {
        Task<List<OrganizationProgramsTuyenTM>> GetAllAsync();
        Task<OrganizationProgramsTuyenTM> GetByIdAsync(int id);
        Task<List<OrganizationProgramsTuyenTM>> SearchAsync(int id, string name, string type);
        Task<int> AddAsync(OrganizationProgramsTuyenTM program);
        Task<int> UpdateAsync(OrganizationProgramsTuyenTM program);
        Task<bool> DeleteAsync(int id);
    }
}
