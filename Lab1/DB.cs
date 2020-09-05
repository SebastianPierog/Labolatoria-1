using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Lab1
{
    public class DB
    {
        public void Select(SqlConnection connection)
        {
            var sql = "SELECT * FROM Region";
            var command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["RegionDescription"]); // zczytujemy cos z bazy
            }
            reader.Close();
            Console.WriteLine();
        }

        public void Insert(SqlConnection connection, int id, string regionName)  // dodajemy do bazy 
        {
            var sql = "INSERT INTO Region(RegionId, RegionDescription) VALUES (@id, @regionName)";
            var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@regionName", regionName);

            int affected = command.ExecuteNonQuery();
        }


        public void Delete(SqlConnection connection, int id)  // usuwamy z bazy
        {
            var query = "DELETE FROM Region WHERE RegionID = @id";
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows deleted");
        }

        public void Update(SqlConnection connection, int id, string regionName)  // zmieniamy w bazie
        {
            var query = "UPDATE Region SET RegionDescription = @regionName WHERE RegionID = @id";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@regionName", regionName);

            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows updated");

        }
    }
}
