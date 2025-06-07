using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationTuyenTM
{
    public class EditModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        //public EditModel(DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context)
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

        //    var organizationstuyentm =  await _context.OrganizationsTuyenTMs.FirstOrDefaultAsync(m => m.OrganizationTuyenTMID == id);
        //    if (organizationstuyentm == null)
        //    {
        //        return NotFound();
        //    }
        //    OrganizationsTuyenTM = organizationstuyentm;
        //    return Page();
        //}

        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(OrganizationsTuyenTM).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrganizationsTuyenTMExists(OrganizationsTuyenTM.OrganizationTuyenTMID))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private bool OrganizationsTuyenTMExists(int id)
        //{
        //    return _context.OrganizationsTuyenTMs.Any(e => e.OrganizationTuyenTMID == id);
        //}
    }
}
