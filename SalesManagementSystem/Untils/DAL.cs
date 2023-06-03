using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Untils
{
    //Data Access Layer
    public class DAL
    {
        private static string Server = "localHost";
        private static string Database = "sales_system";
        private static string User = "root";
        private static string Password = "isa159357";
        private static string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;Charset=utf8";
        private static MySqlConnection Connection;

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }
        //Wait command type SELECT in the string sql
        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(Command);
            da.Fill(data);
            return data;
        }
        //Wait command type INSERT, UPDATE or DELETE in the string sql
        public void ExecuteSQLCommand(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }
    }
}
