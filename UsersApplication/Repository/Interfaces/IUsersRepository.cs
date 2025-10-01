namespace UsersApplication.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<dynamic> Seek(int idUser);
    }
}
