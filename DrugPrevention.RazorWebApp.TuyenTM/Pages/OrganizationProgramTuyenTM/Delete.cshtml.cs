using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;
using DrugPrevention.Services.TuyenTM;
using Microsoft.AspNetCore.Authorization;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationProgramTuyenTM
{
    [Authorize(Roles = "1")]
    public class DeleteModel : PageModel
    {
        private readonly IOrganizationProgramsTuyenTMService _organizationProgramsTuyenTMService;

        public DeleteModel(IOrganizationProgramsTuyenTMService organizationProgramsTuyenTMService)
        {
            _organizationProgramsTuyenTMService = organizationProgramsTuyenTMService;
        }

        [BindProperty]
        public OrganizationProgramsTuyenTM OrganizationProgramsTuyenTM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationprogramstuyentm = await _organizationProgramsTuyenTMService.GetByIdAsync(id.Value);

            if (organizationprogramstuyentm == null)
            {
                return NotFound();
            }
            else
            {
                OrganizationProgramsTuyenTM = organizationprogramstuyentm;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationprogramstuyentm = await _organizationProgramsTuyenTMService.GetByIdAsync(id.Value);
            if (organizationprogramstuyentm != null)
            {
                OrganizationProgramsTuyenTM = organizationprogramstuyentm;
                await _organizationProgramsTuyenTMService.DeleteAsync(OrganizationProgramsTuyenTM.OrganizationProgramTuyenTMID);
            }

            return RedirectToPage("./Index");
        }
    }
}
