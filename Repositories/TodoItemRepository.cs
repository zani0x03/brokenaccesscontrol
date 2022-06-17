using Dapper;
using brokenaccesscontrol.Models;
using System.Security.Cryptography;
using System.Text;

namespace brokenaccesscontrol.Repositories;

public static class TodoItemRepository
{

    public static async Task<IEnumerable<TodoItem>> GetToDoItems()
    {
        var conn = SqliteConfigConnection.GetSQLiteConnection();
        string query = "Select id, name, description from todoitems";
        var lstTodoItens = await conn.QueryAsync<TodoItem>(query);
        return lstTodoItens;
    }    

}