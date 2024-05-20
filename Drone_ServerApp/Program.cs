using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Drone_ServerApp
{
    class Program
    {
        NpgsqlConnection conn = DataBase.GetDBConnection();
        static void Main()
        {
         Console.WriteLine("Getting Connection ...");

            try
            {
                Console.WriteLine("Openning Connection ...");
                NpgsqlConnection conn = DataBase.GetDBConnection();
                conn.Open();
                Console.WriteLine("Connection successful!");
                DataBase database = new DataBase();
            }
            catch (Exception e)
            {
                Console.WriteLine("Can`t connect to database");
            }
            Connector con = new Connector();
            con.connect();
        }

    }
       
}
   

