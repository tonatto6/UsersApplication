using UsersApplication.Models.Users;
using UsersApplication.Models;

namespace UsersApplication.Services.Interfaces
{
    public interface IUsersServices
    {
        Task<dynamic> Seek(int idUser);
        Task<ResponseActions<int>> Insert(UserInsertRequest user);
    }
}
