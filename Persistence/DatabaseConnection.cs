﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LivrariaFive.Persistence
{
    public static class DatabaseConnection
    {
        private const string ConnectionString = (@"Data Source=IAN;Initial Catalog=Livraria;Integrated Security=True");

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static int GetLastInsertedId(SqlConnection connection)
        {
            string query = "SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);

            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            // Se não houver um ID válido, você pode lançar uma exceção ou retornar um valor padrão, dependendo do seu caso de uso.
            throw new Exception("Failed to retrieve last inserted ID.");
        }
    }


}
