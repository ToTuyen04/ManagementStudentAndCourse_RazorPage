using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public interface ICoursesQuangTNVService
    {
        Task<List<CoursesQuangTNV>> GetAllAsync();
        Task<CoursesQuangTNV> GetByIdAsync(int code);
        Task<List<CoursesQuangTNV>> SearchAsync(int duration, string title, string category);
        Task<int> CreateAsync(CoursesQuangTNV entity);
        Task<int> UpdateAsync(CoursesQuangTNV entity);
        Task<bool> DeleteAsync(int code);
    }
}
