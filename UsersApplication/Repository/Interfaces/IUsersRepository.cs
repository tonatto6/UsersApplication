using UsersApplication.Models.Users;
using UsersApplication.Models;

namespace UsersApplication.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<dynamic> Seek(int idUser);
        Task<ResponseActions<int>> Insert(UserInsertRequest user);
        Task<string> SeekPassword(UsersLoginRequest user);
        Task<ResponseActions<int>> SendMessage(string username, UsersSendMessageRequest userMessage);
    }
}
