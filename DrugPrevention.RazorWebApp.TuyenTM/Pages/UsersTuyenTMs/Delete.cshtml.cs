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
    public class DeleteModel : PageModel
    {
        private readonly IUsersTuyenTMService _usersTuyenTMService;

        public DeleteModel(IUsersTuyenTMService usersTuyenTMService)
        {
            _usersTuyenTMService = usersTuyenTMService;
        }

        [BindProperty]
        public UsersTuyenTM UsersTuyenTM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userstuyentm = await _usersTuyenTMService.GetByIdAsync(id.Value);

            if (userstuyentm == null)
            {
                return NotFound();
            }
            else
            {
                UsersTuyenTM = userstuyentm;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userstuyentm = await _usersTuyenTMService.GetByIdAsync(id.Value);
            if (userstuyentm != null)
            {
                UsersTuyenTM = userstuyentm;
                await _usersTuyenTMService.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
