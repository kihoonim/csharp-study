using System;
using Microsoft.Data.Sqlite;

namespace Sqlite.Basic
{
    class Program
    {
        static void Basic1()
        {
            var baseConnectionString = "Data Source=hello.db";
            var password = "1234";

            var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                //Password = password
            }.ToString();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT name
                    FROM user
                    WHERE id = $id
                ";
                int id = 5;
                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }

        }

        static void Basic2()
        {
            var baseConnectionString = "Data Source=hello.db";
            var password = "1234";

            var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                //Password = password
            }.ToString();

            var connection = new SqliteConnection(connectionString);
            connection.Open();

            using (var firstTransaction = connection.BeginTransaction())
            {
                var updateCommand = connection.CreateCommand();
                updateCommand.CommandText =
                @"
                    UPDATE data
                    SET value = 'dirty'
                ";
                updateCommand.ExecuteNonQuery();
            }
        }

        static void Main(string[] args)
        {
            Basic1();
        }
    }
}
