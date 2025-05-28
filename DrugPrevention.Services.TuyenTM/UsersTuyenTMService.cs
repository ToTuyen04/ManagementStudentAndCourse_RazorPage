using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;

namespace DrugPrevention.Services.TuyenTM
{
    public class UsersTuyenTMService : IUsersTuyenTMService
    {
        private readonly UsersTuyenTmRepository _repository;

        public UsersTuyenTMService() => _repository ??= new UsersTuyenTmRepository();

        public async Task<List<UsersTuyenTM>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<UsersTuyenTM> GetByIdAsync(int code)
        {
            return await _repository.GetByIdAsync(code);
        }
        public async Task<List<UsersTuyenTM>> SearchAsync(int code, string email, string name)
        {
            return await _repository.SearchAsync(code, email, name);
        }
        public async Task<int> CreateAsync(UsersTuyenTM entity)
        {
            return await _repository.CreateAsync(entity);
        }
        public async Task<int> UpdateAsync(UsersTuyenTM entity)
        {
            return await _repository.UpdateAsync(entity);
        }
        public async Task<bool> DeleteAsync(int code)
        {
            var user = await _repository.GetByIdAsync(code);
            if(user != null)
            {
                return await _repository.RemoveAsync(user);
            }
            return false;
        }
    }
}
