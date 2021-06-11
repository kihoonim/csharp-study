using System;
using Npgsql;

namespace Basic
{
    class Program
    {
        static async void Run()
        {
            string ip = "127.0.0.1";
            string userName = "postgres";
            string password = "1234";
            string database = "test1";

            var connString = $"" +
                $"Host={ip};" +
                $"Username={userName};" +
                $"Password={password};" +
                $"Database={database}";

            await using var connection = new NpgsqlConnection(connString);
            await connection.OpenAsync();

            string query = "";

            await using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        static void Main(string[] args)
        {
            Run();
        }
    }
}
