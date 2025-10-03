using Microsoft.AspNetCore.SignalR;

namespace UsersApplication.Helpers
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message) 
        { 
            await Clients.All.SendAsync("ReceiveMessage", user, message); 
        }
    }
}
