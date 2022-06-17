using Dapper;
using brokenaccesscontrol.Models;
using System.Security.Cryptography;
using System.Text;

namespace brokenaccesscontrol.Repositories;

public static class UserRepository
{

    public static UserRequestReturn Insert(UserRequest userRequest){

        var userRequestReturn = new UserRequestReturn {
            Id = Guid.NewGuid().ToString(),
            DateInsert = DateTime.UtcNow,
            IsAdmin = userRequest.IsAdmin.HasValue ? userRequest.IsAdmin.Value : false,
            Login = userRequest.Login,
            Name = userRequest.Name,
            Password = Convert.ToBase64String((SHA512.Create()).ComputeHash(Encoding.UTF8.GetBytes(userRequest.Password)))
        };

        try{
            var conn = SqliteConfigConnection.GetSQLiteConnection(); 
            var query = "insert into users (id,name,login, password,isAdmin,dateInsert) values(@id,@name,@login,@password,@isAdmin,@dateInsert)";
            var table = conn.Execute(query, new{
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

    // public static bool UserExist(string login){
    //     try{
    //         var conn = SqliteConfigConnection.GetSQLiteConnection();
    //         var query = "select count(*) from users where login = @login";
    //     }catch(Exception ex){

    //     }
    // }
}
