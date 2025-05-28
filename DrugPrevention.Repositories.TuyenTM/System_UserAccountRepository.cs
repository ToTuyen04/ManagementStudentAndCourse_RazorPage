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
    public class System_UserAccountRepository : GenericRepository<System_UserAccount>
    {
        public System_UserAccountRepository() { }
        public System_UserAccountRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        //public async Task<List<System_UserAccount>> GetAllAsync()
        //{
        //    var userList = await _context.System_UserAccounts.ToListAsync();
        //    return userList ?? new List<System_UserAccount>();
        //}

        public async Task<System_UserAccount> GetUserAccountAsync(string username, string password)
        {
            var user = await _context.System_UserAccounts
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.IsActive);
            return user ?? new System_UserAccount();
        }

    }
}
