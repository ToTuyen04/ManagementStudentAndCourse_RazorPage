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

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationProgramTuyenTM
{
    public class DetailsModel : PageModel
    {
        private readonly IOrganizationProgramsTuyenTMService _organizationProgramsTuyenTMService;
        private readonly IOrganizationsTuyenTMService _organizationsTuyenTMService;

        public DetailsModel(
            IOrganizationProgramsTuyenTMService organizationProgramsTuyenTMService,
            IOrganizationsTuyenTMService organizationsTuyenTMService)
        {
            _organizationProgramsTuyenTMService = organizationProgramsTuyenTMService;
            _organizationsTuyenTMService = organizationsTuyenTMService;
        }

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
    }
}
