using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationTuyenTM
{
    public class CreateModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;

        //public CreateModel(DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public OrganizationsTuyenTM OrganizationsTuyenTM { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.OrganizationsTuyenTMs.Add(OrganizationsTuyenTM);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
