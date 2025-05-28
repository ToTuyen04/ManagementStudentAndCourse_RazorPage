using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPrevention.Repositories.TuyenTM.Models;

namespace DrugPrevention.Services.TuyenTM
{
    public interface IUsersTuyenTMService
    {
        Task<List<UsersTuyenTM>> GetAllAsync();
        Task<UsersTuyenTM> GetByIdAsync(int code);
        Task<List<UsersTuyenTM>> SearchAsync(int code, string email, string name);
        Task<int> CreateAsync(UsersTuyenTM entity);
        Task<int> UpdateAsync(UsersTuyenTM entity);
        Task<bool> DeleteAsync(int code);
    }
}
