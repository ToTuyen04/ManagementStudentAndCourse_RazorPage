using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationTuyenTM
{
    public class IndexModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        //public IndexModel(DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context)
        //{
        //    _context = context;
        //}

        public IList<OrganizationsTuyenTM> OrganizationsTuyenTM { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    OrganizationsTuyenTM = await _context.OrganizationsTuyenTMs.ToListAsync();
        //}
    }
}
