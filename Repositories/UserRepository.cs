using Dapper;
using brokenaccesscontrol.Models;
using System.Security.Cryptography;
using System.Text;
using brokenaccesscontrol.Services;

namespace brokenaccesscontrol.Repositories;

public static class UserRepository
{

    public static async Task<UserRequestReturn> Insert(UserRequest userRequest){

        var userRequestReturn = new UserRequestReturn {
            Id = Guid.NewGuid().ToString(),
            DateInsert = DateTime.UtcNow,
            IsAdmin = userRequest.IsAdmin.HasValue ? userRequest.IsAdmin.Value : false,
            Login = userRequest.Login,
            Name = userRequest.Name,
            Password = UtilService.ReturnSha512(userRequest.Password)
        };

        try{
            var conn = SqliteConfigConnection.GetSQLiteConnection(); 
            var query = "insert into users (id,name,login, password,isAdmin,dateInsert) values(@id,@name,@login,@password,@isAdmin,@dateInsert)";
            var table = await conn.ExecuteAsync(query, new{
                id = userRequestReturn.Id,
                name = userRequestReturn.Name,
                login = userRequestReturn.Login,
                password = userRequestReturn.Password,
                isAdmin = userRequestReturn.IsAdmin,
                dateInsert = userRequestReturn.DateInsert.ToString("yyyy-MM-dd HH:mm:ss")
            });        
        }catch(Exception ex){
            userRequestReturn.Id = "";
            userRequestReturn.Password = "";
            userRequestReturn.Message = $"Erro: {ex.Message}";
        }

        return userRequestReturn;        
    }

    public static async Task<IEnumerable<User>> GetAllUsers()
    {
        var conn = SqliteConfigConnection.GetSQLiteConnection();
        string query = "Select id, name, login, password, dateInsert, dateUpdate, isAdmin from users";
        var lstUsers = await conn.QueryAsync<User>(query);
        return lstUsers;
    }       

    // public static bool UserExist(string login){
    //     try{
    //         var conn = SqliteConfigConnection.GetSQLiteConnection();
    //         var query = "select count(*) from users where login = @login";
    //     }catch(Exception ex){

    //     }
    // }
}
