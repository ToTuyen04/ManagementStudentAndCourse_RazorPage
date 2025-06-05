using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public interface IUserCoursesTuyenTMService
    {
        Task<List<UserCoursesTuyenTM>> GetAllAsync();
        Task<bool> DeleteAsync(int code);
    }
}
