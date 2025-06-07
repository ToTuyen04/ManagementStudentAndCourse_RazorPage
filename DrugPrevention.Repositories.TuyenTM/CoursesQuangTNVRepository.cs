using DrugPrevention.Repositories.TuyenTM.Basic;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Repositories.TuyenTM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.TuyenTM
{
    public class CoursesQuangTNVRepository : GenericRepository<CoursesQuangTNV>
    {
        public CoursesQuangTNVRepository() { }
        public CoursesQuangTNVRepository(SU25_PRN222_SE1709_G2_DrugPreventionSystemContext context) => _context = context;

        public async Task<List<CoursesQuangTNV>> GetAllAsync()
        {
            var courseList = await _context.CoursesQuangTNVs.ToListAsync();
            return courseList;
        }

        public async Task<CoursesQuangTNV> GetByIdAsync(int code)
        {
            var course = await _context.CoursesQuangTNVs
                .FirstOrDefaultAsync(c => c.CourseQuangTNVID == code);
            return course ?? new CoursesQuangTNV();
        }

        public async Task<List<CoursesQuangTNV>> SearchAsync(int duration, string title, string category)
        {
            var course = await _context.CoursesQuangTNVs
                .Where(
                c => (c.DurationInMinutes == duration || duration == null || duration == 0) &&
                (c.Title.Contains(title) || string.IsNullOrEmpty(title)) &&
                (c.Category.Contains(category) || string.IsNullOrEmpty(category))
                ).ToListAsync();
            return course ?? new List<CoursesQuangTNV>();
        }

    }
}
