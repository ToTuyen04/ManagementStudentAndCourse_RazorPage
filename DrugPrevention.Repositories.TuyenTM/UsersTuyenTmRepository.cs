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
    public class UsersTuyenTmRepository : GenericRepository<UsersTuyenTM>
    {
        public UsersTuyenTmRepository() { }
        public UsersTuyenTmRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        public async Task<List<UsersTuyenTM>> GetAllAsync()
        {
            var userList = await _context.UsersTuyenTMs.Include(u => u.UserCoursesTuyenTMs).ToListAsync();
            return userList ?? new List<UsersTuyenTM>();
        }

        public async Task<UsersTuyenTM> GetByIdAsync(int code)
        {
            var user = await _context.UsersTuyenTMs
                .Include(u => u.UserCoursesTuyenTMs)
                .ThenInclude(uc => uc.Course)
                .Include(u => u.ConsultantsTrongLHs)
                .ThenInclude(uc => uc.ConsultantScheduleTrongLHs)
                .Include(u => u.ProgramParticipantsToanNs)
                .Include(u => u.CommunityProgramsToanNs)
                .Include(u => u.UserSurveysNamNDs)
  
                .FirstOrDefaultAsync(u => u.UserTuyenTMID == code);

            return user ?? new UsersTuyenTM();
        }

        public async Task<List<UsersTuyenTM>> SearchAsync(int code, string email, string name)
        {
            var user = await _context.UsersTuyenTMs.Include(u => u.UserCoursesTuyenTMs)
                .Where(
                u => (u.UserTuyenTMID == code || code == null || code == 0) && 
                (u.Email.Contains(email) || string.IsNullOrEmpty(email)) && 
                (u.Username.Contains(name) || string.IsNullOrEmpty(name))
                ).ToListAsync();
            return user ?? new List<UsersTuyenTM>();
        }
        public async Task<bool> RemoveCustomize(UsersTuyenTM entity)
        {
            _context.UserCoursesTuyenTMs.RemoveRange(entity.UserCoursesTuyenTMs);
            _context.ConsultantsTrongLHs.RemoveRange(entity.ConsultantsTrongLHs);
            _context.ProgramParticipantsToanNs.RemoveRange(entity.ProgramParticipantsToanNs);
            _context.UsersTuyenTMs.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }


    }
}
