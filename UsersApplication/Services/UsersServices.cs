using UsersApplication.Models;
using UsersApplication.Models.Users;
using UsersApplication.Repository.Interfaces;
using UsersApplication.Services.Interfaces;

namespace UsersApplication.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository usersRepository;

        public UsersServices(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<ResponseActions<int>> Insert(UserInsertRequest user)
        {
            //Hash password here!!!!
            return await usersRepository.Insert(user);
        }

        public async Task<dynamic> Seek(int idUser)
        {
            return await usersRepository.Seek(idUser); 
        }
    }
}
