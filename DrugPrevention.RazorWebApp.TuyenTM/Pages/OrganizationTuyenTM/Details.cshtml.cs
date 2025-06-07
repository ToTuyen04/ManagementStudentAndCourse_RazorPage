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

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.OrganizationTuyenTM
{
    public class DetailsModel : PageModel
    {
        private readonly IOrganizationsTuyenTMService _organizationsTuyenTMService;

        public DetailsModel(IOrganizationsTuyenTMService organizationsTuyenTMService)
        {
            _organizationsTuyenTMService = _organizationsTuyenTMService;
        }

        public OrganizationsTuyenTM OrganizationsTuyenTM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationstuyentm = await _organizationsTuyenTMService.GetByIdAsync(id.Value);
            if (organizationstuyentm == null)
            {
                return NotFound();
            }
            else
            {
                OrganizationsTuyenTM = organizationstuyentm;
            }
            return Page();
        }
    }
}
