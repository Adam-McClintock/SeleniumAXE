using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAXE.Utilities
{
    public static class DatabaseHelper
    {
        public static DataTable RunSQLQuery(String sql)
        {
            var table = new DataTable();
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    table.Load(reader);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }

            }
            return table;
        }

        public static int RunSQLCountQuery(String sql)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                int count = 0;
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return (int)count;
            }
        }
    }
}
