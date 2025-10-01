using Dapper;
using System.Data;
using System.Data.SqlClient;
using UsersApplication.ConnectionFactory;
using UsersApplication.Models;
using UsersApplication.Models.Users;
using UsersApplication.Repository.Interfaces;

namespace UsersApplication.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<dynamic> Seek(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser, DbType.Int32, ParameterDirection.Input);

            using (var conexion = ConnectionFactory.ConnectionFactory.GetConnection)
            {
                return await conexion.QueryFirstAsync<dynamic>("usp_Users_Seek",
                                            parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<ResponseActions<int>> Insert(UserInsertRequest user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Fullname", user.FullName, DbType.String, ParameterDirection.Input);
            parameters.Add("@Email", user.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Username", user.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("@Password", user.Password, DbType.String, ParameterDirection.Input);

            using (var conexion = ConnectionFactory.ConnectionFactory.GetConnection)
            {
                return await conexion.QueryFirstAsync<ResponseActions<int>>("usp_Users_Insert",
                                            parameters, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
