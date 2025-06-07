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
    public class DeleteModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        //public DeleteModel(DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context)
        //{
        //    _context = context;
        //}

        [BindProperty]
        public OrganizationsTuyenTM OrganizationsTuyenTM { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var organizationstuyentm = await _context.OrganizationsTuyenTMs.FirstOrDefaultAsync(m => m.OrganizationTuyenTMID == id);

        //    if (organizationstuyentm == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        OrganizationsTuyenTM = organizationstuyentm;
        //    }
        //    return Page();
        //}

        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var organizationstuyentm = await _context.OrganizationsTuyenTMs.FindAsync(id);
        //    if (organizationstuyentm != null)
        //    {
        //        OrganizationsTuyenTM = organizationstuyentm;
        //        _context.OrganizationsTuyenTMs.Remove(OrganizationsTuyenTM);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
    }
}
