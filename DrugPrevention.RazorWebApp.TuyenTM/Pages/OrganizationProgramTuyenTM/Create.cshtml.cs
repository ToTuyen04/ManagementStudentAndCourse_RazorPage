using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;
using DrugPrevention.Services.TuyenTM;
using Microsoft.AspNetCore.Authorization;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationProgramTuyenTM
{
    [Authorize(Roles = "1,2")]
    public class CreateModel : PageModel
    {
        private readonly IOrganizationProgramsTuyenTMService _organizationProgramsTuyenTMService;
        private readonly IOrganizationsTuyenTMService _organizationsTuyenTMService;
        private readonly ICommunityProgramToanNSService _communityProgramToanNSService;

        public CreateModel(IOrganizationProgramsTuyenTMService organizationProgramsTuyenTMService, IOrganizationsTuyenTMService organizationsTuyenTMService, ICommunityProgramToanNSService communityProgramToanNSService)
        {
            _organizationProgramsTuyenTMService = organizationProgramsTuyenTMService;
            _organizationsTuyenTMService = organizationsTuyenTMService;
            _communityProgramToanNSService = communityProgramToanNSService;
        }

        public async Task<IActionResult> OnGet()
        {
            var organizations = await _organizationsTuyenTMService.GetAllAsync();
            var communityProgram = await _communityProgramToanNSService.GetAllAsync();
            ViewData["OrganizationID"] = new SelectList(organizations, "OrganizationTuyenTMID", "OrganizationName");
        ViewData["ProgramToanNSID"] = new SelectList(communityProgram, "ProgramToanNSID", "ProgramName");
            return Page();
        }

        [BindProperty]
        public OrganizationProgramsTuyenTM OrganizationProgramsTuyenTM { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _organizationProgramsTuyenTMService.AddAsync(OrganizationProgramsTuyenTM);

            return RedirectToPage("./Index");
        }
    }
}
