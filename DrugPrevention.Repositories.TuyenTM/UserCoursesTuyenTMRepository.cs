using DrugPrevention.Repositories.TuyenTM.Basic;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.TuyenTM
{
    public class UserCoursesTuyenTMRepository : GenericRepository<UserCoursesTuyenTM>
    {
        public UserCoursesTuyenTMRepository() { }
        public UserCoursesTuyenTMRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        public async Task<List<UserCoursesTuyenTM>> GetAllAsync()
        {
            var userList = await _context.UserCoursesTuyenTMs.ToListAsync();
            return userList ?? new List<UserCoursesTuyenTM>();
        }

        public async Task<UserCoursesTuyenTM> GetByIdAsync(int code)
        {
            var user = await _context.UserCoursesTuyenTMs
                .FirstOrDefaultAsync(u => u.UserCourseTuyenTMID == code);
            return user ?? new UserCoursesTuyenTM();
        }

        public async Task<List<UserCoursesTuyenTM>> SearchAsync(int code, string email, string name)
        {
            var user = await _context.UserCoursesTuyenTMs
                .Where(
                u => (u.UserCourseTuyenTMID == code || code == null || code == 0) &&
                (u.User.Email.Contains(email) || string.IsNullOrEmpty(email)) &&
                (u.User.FirstName.Contains(name) || string.IsNullOrEmpty(name))
                ).ToListAsync();
            return user ?? new List<UserCoursesTuyenTM>();
        }

        
    }
}
