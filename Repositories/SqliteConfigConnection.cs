using Microsoft.Data.Sqlite;

namespace brokenaccesscontrol.Repositories;

public static class SqliteConfigConnection
{
    public static SqliteConnection sqliteConn;

    public static SqliteConnection GetSQLiteConnection(){        
        if (sqliteConn == null){
            sqliteConn = new SqliteConnection("Data Source=/home/zani0x03/examples/brokenaccesscontrol/Database/brokenaccesscontrol.db");
            sqliteConn.Open();
        }
        return sqliteConn;
    } 

}
