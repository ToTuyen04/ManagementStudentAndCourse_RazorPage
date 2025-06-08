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
    public class OrganizationProgramsTuyenTMRepository : GenericRepository<OrganizationProgramsTuyenTM>
    {
        public OrganizationProgramsTuyenTMRepository() { }
        public OrganizationProgramsTuyenTMRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        public async Task<List<OrganizationProgramsTuyenTM>> GetAllAsync()
        {
            var programs = await _context.OrganizationProgramsTuyenTMs
                .Include(o => o.Organization)
                .Include(o => o.ProgramToanNS)
                .ToListAsync();
            return programs ?? new List<OrganizationProgramsTuyenTM>();
        }
        public async Task<OrganizationProgramsTuyenTM> GetByIdAsync(int id)
        {
            var program = await _context.OrganizationProgramsTuyenTMs
                .Include(p => p.Organization)
                .Include(p => p.ProgramToanNS)
                .FirstOrDefaultAsync(p => p.OrganizationProgramTuyenTMID == id);
            return program ?? new OrganizationProgramsTuyenTM();
        }
        public async Task<List<OrganizationProgramsTuyenTM>> SearchAsync(int id, string name, string type)
        {
            var query = _context.OrganizationProgramsTuyenTMs
                .Include(p => p.ProgramToanNS)
                .Include(p => p.Organization)
                .AsQueryable();

            if (id > 0)
            {
                query = query.Where(p => p.OrganizationProgramTuyenTMID == id);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.ProgramToanNS.ProgramName.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query = query.Where(p => p.Organization.Type.Contains(type));
            }

            return await query.ToListAsync();
        }

    }
}
