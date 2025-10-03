using Microsoft.AspNetCore.SignalR;
using UsersApplication.Helpers;
using UsersApplication.Models;
using UsersApplication.Models.Users;
using UsersApplication.Repository.Interfaces;
using UsersApplication.Services.Interfaces;

namespace UsersApplication.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository usersRepository;
        private readonly IHubContext<ChatHub> _hubContext;

        public UsersServices(IUsersRepository usersRepository, IHubContext<ChatHub> hubContext)
        {
            this.usersRepository = usersRepository;
            this._hubContext = hubContext;
        }

        public async Task<ResponseActions<int>> Insert(UserInsertRequest user)
        {
            user.Password = Encrypt.HashPassword(user.Password);
            return await usersRepository.Insert(user);
        }

        public async Task<dynamic> Seek(int idUser)
        {
            return await usersRepository.Seek(idUser); 
        }

        public async Task<ResponseActions<int>> SendMessage(string username, UsersSendMessageRequest userMessage)
        {
            var resp = await usersRepository.SendMessage(username, userMessage);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", username, userMessage.Message);
            return resp;
        }

        public async Task<string> ValidatePassword(UsersLoginRequest user)
        {
            var hashPass = await usersRepository.SeekPassword(user);

            return Authorization.GenerateJwtToken(user.Username, hashPass);

            //return Encrypt.VerifyPassword(user.Password, hashPass);
        }
    }
}
