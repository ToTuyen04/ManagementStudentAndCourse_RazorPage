using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;
using DrugPrevention.Services.TuyenTM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace DrugPrevention.RazorWebApp.TuyenTM.Hubs
{
    public class DrugPreventionHub : Hub
    {
        private readonly IUsersTuyenTMService _usersTuyenTMService;
        private readonly IOrganizationProgramsTuyenTMService _organizationProgramsTuyenTMService;
        private readonly IOrganizationsTuyenTMService _organizationsTuyenTMService;
        private readonly ICommunityProgramToanNSService _communityProgramToanNSService;
        public DrugPreventionHub(IUsersTuyenTMService usersTuyenTMService, IOrganizationProgramsTuyenTMService organizationProgramsTuyenTMService, IOrganizationsTuyenTMService organizationsTuyenTMService, ICommunityProgramToanNSService communityProgramToanNSService)
        {
            _usersTuyenTMService = usersTuyenTMService;
            _organizationProgramsTuyenTMService = organizationProgramsTuyenTMService;
            _organizationsTuyenTMService = organizationsTuyenTMService;
            _communityProgramToanNSService = communityProgramToanNSService;
        }

        //Create
        public async Task HubCreate_UserTuyenTM(string usersTuyenTMJsonString)
        {

            var item = JsonConvert.DeserializeObject<UsersTuyenTM>(usersTuyenTMJsonString);

            await Clients.All.SendAsync("Receiver_CreateUserTuyenTM", item);

            await _usersTuyenTMService.CreateAsync(item);
        }

        //Delete
        public async Task HubDelete_UserTuyenTM(string userTuyenTMID)
        {
            // Hub sẽ gửi lệnh xóa người dùng đến tất cả các client đang kết nối
            await Clients.All.SendAsync("Receiver_DeleteUserTuyenTM", userTuyenTMID);

            // Thực hiện xóa người dùng trong cơ sở dữ liệu
            await _usersTuyenTMService.DeleteAsync(int.Parse(userTuyenTMID));

            await Clients.Caller.SendAsync("UserDeletedRedirect");
        }

        public async Task HubDelete_OrganizationProgramTuyenTM(string organizationProgramTuyenTMID)
        {
            // Hub sẽ gửi lệnh xóa người dùng đến tất cả các client đang kết nối
            await Clients.All.SendAsync("Receiver_DeleteOrganizationTuyenTM", organizationProgramTuyenTMID);

            // Thực hiện xóa người dùng trong cơ sở dữ liệu
            await _organizationProgramsTuyenTMService.DeleteAsync(int.Parse(organizationProgramTuyenTMID));

            await Clients.Caller.SendAsync("OrganizationProgramDeletedRedirect");
        }

        public async Task HubCreate_OrganizationProgramTuyenTM(string organizationProgramTuyenTMJsonString)
        {

            var item = JsonConvert.DeserializeObject<OrganizationProgramsTuyenTM>(organizationProgramTuyenTMJsonString);

            await _organizationProgramsTuyenTMService.AddAsync(item);

            var organization = await _organizationsTuyenTMService.GetByIdAsync(item.OrganizationID);
            var communityProgram = await _communityProgramToanNSService.GetByIdAsync(item.ProgramToanNSID);

            var viewModel = new
            {
                item.OrganizationProgramTuyenTMID,
                item.JoinedDate,
                item.ContributionDescription,
                item.IsSponsor,
                item.IsOrganizer,
                item.ProgramRole,
                item.FundingAmount,
                item.Feedback,
                item.LastUpdated,
                OrganizationName = organization?.OrganizationName,
                ProgramName = communityProgram?.ProgramName
            };

            await Clients.All.SendAsync("Receiver_CreateOrganizationProgramTuyenTM", viewModel);

        }
        
        public async Task HubUpdate_OrganizationProgramTuyenTM(string organizationProgramTuyenTMJsonString)
        {
            var item = JsonConvert.DeserializeObject<OrganizationProgramsTuyenTM>(organizationProgramTuyenTMJsonString);
            
            var organization = await _organizationsTuyenTMService.GetByIdAsync(item.OrganizationID);
            var communityProgram = await _communityProgramToanNSService.GetByIdAsync(item.ProgramToanNSID);
            var viewModel = new
            {
                item.OrganizationProgramTuyenTMID,
                item.JoinedDate,
                item.ContributionDescription,
                item.IsSponsor,
                item.IsOrganizer,
                item.ProgramRole,
                item.FundingAmount,
                item.Feedback,
                item.LastUpdated,
                OrganizationName = organization?.OrganizationName,
                ProgramName = communityProgram?.ProgramName
            };
            await Clients.All.SendAsync("Receiver_UpdateOrganizationProgramTuyenTM", viewModel);

            await _organizationProgramsTuyenTMService.UpdateAsync(item);
        }
    } 
}
