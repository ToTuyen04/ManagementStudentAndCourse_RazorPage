using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrugPrevention.Repositories.TuyenTM.Models;
using DrugPrevention.Services.TuyenTM;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace DrugPrevention.RazorWebApp.TuyenTM.Pages.UsersTuyenTMs
{
    [Authorize(Roles = "1,2")]
    public class EditModel : PageModel
    {
        private readonly IUsersTuyenTMService _usersTuyenTMService;
        private readonly IUserCoursesTuyenTMService _userCoursesTuyenTMService;
        private readonly ICoursesQuangTNVService _coursesQuangTNVService;

        public EditModel(IUsersTuyenTMService usersTuyenTMService, IUserCoursesTuyenTMService userCoursesTuyenTMService, ICoursesQuangTNVService coursesQuangTNVService)
        {
            _usersTuyenTMService = usersTuyenTMService;
            _userCoursesTuyenTMService = userCoursesTuyenTMService;
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

            // Lấy danh sách các CourseID đã chọn
            SelectedCourseIds = UsersTuyenTM.UserCoursesTuyenTMs
                .Select(x => x.CourseID)
                .ToList();

            var courses = await _coursesQuangTNVService.GetAllAsync();

            // Đánh dấu các khóa học đã chọn
            //AllCourses = courses.Select(c => new SelectListItem
            //{
            //    Value = c.CourseQuangTNVID.ToString(),
            //    Text = c.Title,
            //    Selected = SelectedCourseIds.Contains(c.CourseQuangTNVID)
            //}).ToList();
            ViewData["Courses"] = courses.Select(c => new SelectListItem
            {
                Value = c.CourseQuangTNVID.ToString(),
                Text = c.Title,
                Selected = SelectedCourseIds.Contains(c.CourseQuangTNVID)
            }).ToList();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                var courses = await _coursesQuangTNVService.GetAllAsync();
                ViewData["Courses"] = courses.Select(c => new SelectListItem
                {
                    Value = c.CourseQuangTNVID.ToString(),
                    Text = c.Title,
                    Selected = SelectedCourseIds.Contains(c.CourseQuangTNVID)
                }).ToList();

                return Page();
            }


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

            // Lấy danh sách hiện tại từ database (không xóa ngay)
            var existingCourseIds = userToUpdate.UserCoursesTuyenTMs.Select(x => x.CourseID).ToList();

            // Xóa các khóa học không còn được chọn
            var coursesToRemove = userToUpdate.UserCoursesTuyenTMs
                .Where(x => !SelectedCourseIds.Contains(x.CourseID))
                .ToList();

            foreach (var courseToRemove in coursesToRemove)
            {
                userToUpdate.UserCoursesTuyenTMs.Remove(courseToRemove);
                await _userCoursesTuyenTMService.DeleteAsync(courseToRemove.UserCourseTuyenTMID);
            }

            // Thêm các khóa học mới được chọn (mà chưa tồn tại)
            var courseIdsToAdd = SelectedCourseIds
                .Where(courseId => !existingCourseIds.Contains(courseId))
                .ToList();

            foreach (var courseId in courseIdsToAdd)
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
