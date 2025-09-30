namespace UsersApplication.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<dynamic> SeekAll();
    }
}
