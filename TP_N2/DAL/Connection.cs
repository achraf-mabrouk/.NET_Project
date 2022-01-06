using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    class DbConnection
    {
        private static string ConnectionString;
        private MySqlConnection conn;

        public static void ChangeConnString(string ConnStr)
        {
            ConnectionString = ConnStr;
        }
        public DbConnection()
        {
            ConnectionString = "Server=localhost; Database=mydb; Uid=root; Pwd=franticboy95";
            conn = new MySqlConnection(ConnectionString);
	
            try
            {
                conn.Open();
                Console.WriteLine("You have Been Connected To Database \'mydb\' Succesfully !");
                Console.WriteLine();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERROR : {0}", e);
            }
        }
        public MySqlConnection GetConnection()
        {
            return conn;
        }
    }
}
