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
    public class CommunityProgramToanNSRepository : GenericRepository<CommunityProgramsToanN>
    {
        public CommunityProgramToanNSRepository() { }
        public CommunityProgramToanNSRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        public async Task<List<CommunityProgramsToanN>> GetAllAsync()
        {
            var programs = await _context.CommunityProgramsToanNs
                .Include(p => p.Organizer)
                .ToListAsync();
            return programs ?? new List<CommunityProgramsToanN>();
        }

        public async Task<CommunityProgramsToanN> GetByIdAsync(int id)
        {
            var program = await _context.CommunityProgramsToanNs
                .Include(p => p.Organizer)
                .FirstOrDefaultAsync(p => p.ProgramToanNSID == id);
            return program ?? new CommunityProgramsToanN();
        }
    }
}
