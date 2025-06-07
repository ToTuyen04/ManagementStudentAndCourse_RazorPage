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
        public DrugPreventionHub(IUsersTuyenTMService usersTuyenTMService)
        {
            _usersTuyenTMService = usersTuyenTMService;
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
    }
}
