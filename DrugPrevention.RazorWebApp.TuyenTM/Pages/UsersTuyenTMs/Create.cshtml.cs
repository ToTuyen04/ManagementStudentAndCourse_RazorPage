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

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.UsersTuyenTMs
{
    public class CreateModel : PageModel
    {
        private readonly IUsersTuyenTMService _usersTuyenTMService;
        private readonly IUserCoursesTuyenTMService _userCoursesTuyenTMService;
        private readonly ICoursesQuangTNVService _coursesQuangTNVService;

        public CreateModel(IUsersTuyenTMService usersTuyenTMService, IUserCoursesTuyenTMService userCoursesTuyenTMService, ICoursesQuangTNVService coursesQuangTNVService)
        {
            _usersTuyenTMService = usersTuyenTMService;
            _userCoursesTuyenTMService = userCoursesTuyenTMService;
            _coursesQuangTNVService = coursesQuangTNVService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userCourses = await _userCoursesTuyenTMService.GetAllAsync();
            var courses = await _coursesQuangTNVService.GetAllAsync();

            ViewData["CourseNo"] = new SelectList(userCourses, "CourseNo", "CourseNo");
            ViewData["Title"] = new SelectList(courses, "Title", "Title");

            //if (!ModelState.IsValid)
            //{
                return Page();
            //}
            
        }

        [BindProperty]
        public UsersTuyenTM UsersTuyenTM { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            UsersTuyenTM.RegistrationDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _usersTuyenTMService.CreateAsync(UsersTuyenTM);

            return RedirectToPage("./Index");
        }
    }
}
