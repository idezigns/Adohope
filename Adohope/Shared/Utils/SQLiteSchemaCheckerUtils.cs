using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Shared.Utils
{
    public static class SQLiteSchemaCheckerUtils
    {
        public static bool IsFieldExists(string connectionString, string tableName, string fieldName)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DbContext>();
            dbContextOptionsBuilder.UseSqlite(connectionString);

            using (var context = new DbContext(dbContextOptionsBuilder.Options))
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = $"select cid from pragma_table_info('{tableName}') where name='{fieldName}';";

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    return reader.HasRows;
                }
            }
        }

        public static bool IsTableExists(string connectionString, string tableName)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DbContext>();
            dbContextOptionsBuilder.UseSqlite(connectionString);

            using (var context = new DbContext(dbContextOptionsBuilder.Options))
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    return reader.HasRows;
                }
            }
        }

        public static string[] WhichTableExists(string connectionString, string[] tableNames)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DbContext>();
            dbContextOptionsBuilder.UseSqlite(connectionString);

            using (var context = new DbContext(dbContextOptionsBuilder.Options))
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection.Open();

                    List<string> loopkupResult = new List<string>();

                    for (int i = 0; i < tableNames.Length; i++) tableNames[i] = $"'{tableNames[i]}'";
                    var tableNamesJoined = string.Join(",", tableNames);
                    command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name in ({tableNamesJoined});";

                    var reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        loopkupResult.Add(reader["name"].ToString());
                    }

                    return loopkupResult.ToArray();
                }
            }
        }

        public static bool IsDatabaseEmpty(string connectionString)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DbContext>();
            dbContextOptionsBuilder.UseSqlite(connectionString);

            using (var context = new DbContext(dbContextOptionsBuilder.Options))
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = $"SELECT count(name) FROM sqlite_master WHERE type='table';";

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    return !reader.HasRows;
                }
            }
        }

    }
}
