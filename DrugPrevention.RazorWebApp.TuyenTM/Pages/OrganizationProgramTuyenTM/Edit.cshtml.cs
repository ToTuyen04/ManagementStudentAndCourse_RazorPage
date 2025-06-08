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
using DrugPrevention.Services.TuyenTM;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationProgramTuyenTM
{
    public class EditModel : PageModel
    {
        private readonly IOrganizationProgramsTuyenTMService _organizationProgramsTuyenTMService;
        private readonly IOrganizationsTuyenTMService _organizationsTuyenTMService;
        private readonly ICommunityProgramToanNSService _communityProgramToanNS;
        public EditModel(
            IOrganizationProgramsTuyenTMService organizationProgramsTuyenTMService,
            IOrganizationsTuyenTMService organizationsTuyenTMService,
            ICommunityProgramToanNSService communityProgramToanNS)

        {
            _organizationProgramsTuyenTMService = organizationProgramsTuyenTMService;
            _organizationsTuyenTMService = organizationsTuyenTMService;
            _communityProgramToanNS = communityProgramToanNS;
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
            OrganizationProgramsTuyenTM = organizationprogramstuyentm;
            var organizations = await _organizationsTuyenTMService.GetAllAsync();
            var communityPrograms = await _communityProgramToanNS.GetAllAsync();
            ViewData["OrganizationID"] = new SelectList(organizations, "OrganizationTuyenTMID", "OrganizationName");
            ViewData["ProgramToanNSID"] = new SelectList(communityPrograms, "ProgramToanNSID", "ProgramName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(OrganizationProgramsTuyenTM).State = EntityState.Modified;

            try
            {
                await _organizationProgramsTuyenTMService.UpdateAsync(OrganizationProgramsTuyenTM);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationProgramsTuyenTMExists(OrganizationProgramsTuyenTM.OrganizationProgramTuyenTMID).Result)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> OrganizationProgramsTuyenTMExists(int id)
        {
            var organizationPrograms = await _organizationProgramsTuyenTMService.GetByIdAsync(id);
            return organizationPrograms != null && organizationPrograms.OrganizationProgramTuyenTMID == id;
        }
    }
}
