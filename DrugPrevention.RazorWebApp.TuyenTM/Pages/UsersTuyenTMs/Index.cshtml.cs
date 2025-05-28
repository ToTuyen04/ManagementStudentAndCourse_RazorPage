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

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.UsersTuyenTMs
{
    public class IndexModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.TuyenTM.DBContext.SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;
        private readonly IUsersTuyenTMService _usersTuyenTMService;

        public IndexModel(IUsersTuyenTMService usersTuyenTMService)
        {
            _usersTuyenTMService = usersTuyenTMService;
        }

        public IList<UsersTuyenTM> UsersTuyenTM { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UsersTuyenTM = await _usersTuyenTMService.GetAllAsync();
        }
    }
}
