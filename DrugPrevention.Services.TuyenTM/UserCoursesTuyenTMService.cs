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
        private readonly DrugPrevention.Repositories.TuyenTM.UserCoursesTuyenTMRepository _repository;
        public UserCoursesTuyenTMService() => _repository ??= new DrugPrevention.Repositories.TuyenTM.UserCoursesTuyenTMRepository();

        public async Task<List<DrugPrevention.Repositories.TuyenTM.Models.UserCoursesTuyenTM>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
