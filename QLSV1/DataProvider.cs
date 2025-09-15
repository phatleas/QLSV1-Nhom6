using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSV1
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private readonly string connectionSTR = @"Server=.\SQLEXPRESS;Database=QuanLySinhVien;Integrated Security=True;TrustServerCertificate=True;";

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        AddParameters(command, parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(data);
                    }
                }
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        AddParameters(command, parameters);
                    }
                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object result;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        AddParameters(command, parameters);
                    }
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }

        private void AddParameters(SqlCommand command, object[] parameters)
        {
            // Lấy tất cả các tham số dạng @xxx trong query
            var parameterNames = command.CommandText.Split(new[] { ' ', ',', '(', ')', '=', '<', '>', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int paramIndex = 0;
            foreach (var name in parameterNames)
            {
                if (name.StartsWith("@") && !command.Parameters.Contains(name))
                {
                    if (paramIndex < parameters.Length)
                    {
                        command.Parameters.AddWithValue(name, parameters[paramIndex] ?? DBNull.Value);
                        paramIndex++;
                    }
                }
            }
        }
    }
}