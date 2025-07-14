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
    [Authorize(Roles = "1, 2")]
    public class IndexModel : PageModel
    {
        private readonly IOrganizationProgramsTuyenTMService _organizationProgramsTuyenTMService;
        public IndexModel(IOrganizationProgramsTuyenTMService organizationProgramsTuyenTMService)
        {
            _organizationProgramsTuyenTMService = organizationProgramsTuyenTMService;
        }

        public IList<OrganizationProgramsTuyenTM> OrganizationProgramsTuyenTM { get; set; } = default!;

        public async Task OnGetAsync()
        {
            OrganizationProgramsTuyenTM = await _organizationProgramsTuyenTMService.GetAllAsync();
        }
    }
}
