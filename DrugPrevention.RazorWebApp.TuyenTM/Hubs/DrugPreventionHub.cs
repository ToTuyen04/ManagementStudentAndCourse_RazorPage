using DrugPrevention.Services.TuyenTM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DrugPrevention.RazorWebApp.TuyenTM.Hubs
{
    public class DrugPreventionHub : Hub
    {
        private readonly IUsersTuyenTMService _usersTuyenTMService;
        public DrugPreventionHub(IUsersTuyenTMService usersTuyenTMService)
        {
            _usersTuyenTMService = usersTuyenTMService;
        }
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
