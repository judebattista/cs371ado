using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace cs371ado
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = @"server=db4free.net;userid=cs371student;password=whitworth;database=cs371ado;old guids=true";
            var conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            Console.WriteLine("MySql version: {0}.", conn.ServerVersion);
            
            string sql = "SELECT * FROM ships";
            var cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine("Ship ID: {0}, ship name: {1}, registration number: {2}.", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            reader.Close();

            sql = "INSERT INTO crew (fname, lname, age, roleid) VALUES ('I cannot follow', 'simple instructions', 20, 8)";
            cmd.CommandText = sql;
            cmd.Connection = conn;
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine("Insert result: {0}", result);

            sql = "SELECT id, fname, lname, age FROM crew";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Crew ID: {0}, first name: {1}, last name: {2}, age: {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            reader.Close();

            sql = "DELETE FROM crew WHERE lname = 'simple instructions'";
            cmd.CommandText = sql;
            cmd.Connection = conn;
            result = cmd.ExecuteNonQuery();

            Console.WriteLine("Delete result: {0}", result);

            sql = "SELECT id, fname, lname, age FROM crew";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Crew ID: {0}, first name: {1}, last name: {2}, age: {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            reader.Close();


            conn.Close();
        }

        public void OpenConnection(IDbConnection conn) {
            conn.Open();
        }


    }
}
