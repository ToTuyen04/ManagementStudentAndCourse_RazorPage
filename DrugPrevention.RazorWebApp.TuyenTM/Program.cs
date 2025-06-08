using DrugPrevention.RazorWebApp.TuyenTM.Hubs;
using DrugPrevention.Repositories.TuyenTM.DBContext;
using DrugPrevention.Services.TuyenTM;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DrugPrevention.RazorWebApp.TuyenTM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUsersTuyenTMService, UsersTuyenTMService>();
            builder.Services.AddScoped<IUserCoursesTuyenTMService, UserCoursesTuyenTMService>();
            builder.Services.AddScoped<ICoursesQuangTNVService, CoursesQuangTNVService>();
            builder.Services.AddScoped<IOrganizationsTuyenTMService, OrganizationsTuyenTMService>();
            builder.Services.AddScoped<IOrganizationProgramsTuyenTMService, OrganizationProgramsTuyenTMService>();
            builder.Services.AddScoped<ICommunityProgramToanNSService, CommunityProgramToanNSService>();

            //Add Authentication & Authorization
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.AccessDeniedPath = "/Account/Forbidden";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });

            // Add services to the container.
            builder.Services.AddRazorPages();

            //SignalR
            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            //thêm RequireAuthorization để yêu cầu xác thực cho tất cả các trang Razor
            app.MapRazorPages().RequireAuthorization();

            //SignalR
            app.MapHub<DrugPreventionHub>("/DrugPreventionHub");

            app.Run();
        }
    }
}
