using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public class CoursesQuangTNVService : ICoursesQuangTNVService
    {
        private readonly CoursesQuangTNVRepository _repository;

        public CoursesQuangTNVService() => _repository ??= new CoursesQuangTNVRepository();

        public Task<int> CreateAsync(CoursesQuangTNV entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int code)
        {
            var enity = await _repository.GetByIdAsync(code);
            if(enity != null)
            {
                return await _repository.RemoveAsync(enity);
            }
            return false;
        }

        public async Task<List<CoursesQuangTNV>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CoursesQuangTNV> GetByIdAsync(int code)
        {
            return await _repository.GetByIdAsync(code);
        }

        public async Task<List<CoursesQuangTNV>> SearchAsync(int duration, string title, string category)
        {
            return await _repository.SearchAsync(duration, title, category);
        }


        public async Task<int> UpdateAsync(CoursesQuangTNV entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
