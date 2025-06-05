using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public class UserCoursesTuyenTMService :
        IUserCoursesTuyenTMService
    {
        private readonly UserCoursesTuyenTMRepository _repository;
        public UserCoursesTuyenTMService() => _repository ??= new UserCoursesTuyenTMRepository();

        public async Task<List<UserCoursesTuyenTM>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<bool> DeleteAsync(int code)
        {
            var userCourse = await _repository.GetByIdAsync(code);
            return await _repository.RemoveAsync(userCourse);
        }
    }
}
