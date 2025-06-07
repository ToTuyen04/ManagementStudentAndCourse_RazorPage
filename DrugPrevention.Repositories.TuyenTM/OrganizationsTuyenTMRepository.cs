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
    public class OrganizationsTuyenTMRepository : GenericRepository<OrganizationsTuyenTM>
    {
        public OrganizationsTuyenTMRepository() { }

        public OrganizationsTuyenTMRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        public async Task<List<OrganizationsTuyenTM>> GetAllAsync()
        {
            var organizations = await _context.OrganizationsTuyenTMs.ToListAsync();
            return organizations ?? new List<OrganizationsTuyenTM>();
        }

        public async Task<OrganizationsTuyenTM> GetByIdAsync(int id)
        {
            var organization = await _context.OrganizationsTuyenTMs
                .Include(o => o.OrganizationProgramsTuyenTMs)
                .FirstOrDefaultAsync(o => o.OrganizationTuyenTMID == id);
            return organization ?? new OrganizationsTuyenTM();
        }

        public async Task<List<OrganizationsTuyenTM>> SearchAsync(int id, string name, string type)
        {
            var organizations = await _context.OrganizationsTuyenTMs
                .Where(o => (o.OrganizationTuyenTMID == id || id == 0) &&
                            (string.IsNullOrEmpty(name) || o.OrganizationName.Contains(name)) &&
                            (string.IsNullOrEmpty(type) || o.Type.Contains(type)))
                .ToListAsync();
            return organizations ?? new List<OrganizationsTuyenTM>();
        }
    }
}
