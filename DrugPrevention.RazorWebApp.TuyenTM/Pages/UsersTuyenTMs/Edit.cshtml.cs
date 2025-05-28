using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrugPrevention.Repositories.TuyenTM.Models;
using DrugPrevention.Services.TuyenTM;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.UsersTuyenTMs
{
    public class EditModel : PageModel
    {
        private readonly IUsersTuyenTMService _usersTuyenTMService;
        private readonly ICoursesQuangTNVService _coursesQuangTNVService;

        public EditModel(IUsersTuyenTMService usersTuyenTMService, ICoursesQuangTNVService coursesQuangTNVService)
        {
            _usersTuyenTMService = usersTuyenTMService;
            _coursesQuangTNVService = coursesQuangTNVService;
        }

        [BindProperty]
        public UsersTuyenTM UsersTuyenTM { get; set; }

        [BindProperty]
        public List<int> SelectedCourseIds { get; set; } = new();

        public List<SelectListItem> AllCourses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            UsersTuyenTM = await _usersTuyenTMService.GetByIdAsync(id.Value);
            if (UsersTuyenTM == null)
                return NotFound();

            var courses = await _coursesQuangTNVService.GetAllAsync();
            AllCourses = courses.Select(c => new SelectListItem
            {
                Value = c.CourseQuangTNVID.ToString(),
                Text = c.Title
            }).ToList();

            SelectedCourseIds = UsersTuyenTM.UserCoursesTuyenTMs
                .Select(x => x.CourseID)
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var userToUpdate = await _usersTuyenTMService.GetByIdAsync(UsersTuyenTM.UserTuyenTMID);
            if (userToUpdate == null)
                return NotFound();

            // Cập nhật thông tin người dùng
            userToUpdate.Username = UsersTuyenTM.Username;
            userToUpdate.Password = UsersTuyenTM.Password;
            userToUpdate.Email = UsersTuyenTM.Email;
            userToUpdate.FirstName = UsersTuyenTM.FirstName;
            userToUpdate.LastName = UsersTuyenTM.LastName;
            userToUpdate.Role = UsersTuyenTM.Role;
            userToUpdate.RegistrationDate = UsersTuyenTM.RegistrationDate;
            userToUpdate.IsActive = UsersTuyenTM.IsActive;
            userToUpdate.PhoneNumber = UsersTuyenTM.PhoneNumber;

            // Cập nhật các khóa học đã chọn
            userToUpdate.UserCoursesTuyenTMs.Clear();
            foreach (var courseId in SelectedCourseIds)
            {
                userToUpdate.UserCoursesTuyenTMs.Add(new UserCoursesTuyenTM
                {
                    CourseID = courseId,
                    UserID = userToUpdate.UserTuyenTMID,
                    EnrollmentDate = DateTime.Now
                });
            }

            await _usersTuyenTMService.UpdateAsync(userToUpdate);

            return RedirectToPage("./Index");
        }
    }
}
