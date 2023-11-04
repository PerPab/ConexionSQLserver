using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSQL
{
    internal class Conexion
    {

        SqlConnection conexion = new SqlConnection();

        public Conexion( string server, string user, string clave, string db)
      
        {
            conexion.ConnectionString = $"Data Source={server}; User={user}; Password={clave}; Initial Catalog={db}";


        }

        public void ListarResultados(string consulta)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.conexion;
                cmd.CommandText = consulta;

                conexion.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    
                    {
                        IDataRecord fila = reader;
                        
                        Console.WriteLine($"ID: {fila[0]} - Nombre: {fila[3]} {fila[2]}");

                    }

                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conexion.Close();


            


        }

        




    }
}
