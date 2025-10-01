using Dapper;
using System.Data;
using System.Data.SqlClient;
using UsersApplication.ConnectionFactory;
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
    }
}
