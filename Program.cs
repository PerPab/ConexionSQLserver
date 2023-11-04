using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GestorPedidos gestor = new GestorPedidos();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=LAPTOP-URAUHA04\\SQLTEST; User=sa; Password=123456; Initial Catalog=Prueba";
            conexion.Open();

            SqlCommand cmd = conexion.CreateCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select idPedido, CiudadDestino, ImporteTotal from pedidos";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                IDataRecord record = reader;
                while (reader.Read())
                {

                    gestor.AgregarPedido((int)reader[0], (string)reader[1], (double)reader[2]);

                    Console.WriteLine($"{record[0]} - {record[1]} - {record[2]}");


                }
            }

            conexion.Close();

            gestor.Total();

            Console.ReadKey();












            //string consulta = "select * from Clientes";

            //try
            //{
            //    Conexion miConexion = new Conexion("LAPTOP-URAUHA04\\SQLTEST", "sa", "123456", "Prueba");

            //    miConexion.ListarResultados(consulta);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}





        }

    }

}

//       Console.WriteLine("conectando....");
//       string consulta = "select * from Clientes";

//        try
//        {
//            SqlConnection conexion = new SqlConnection();
//            conexion.ConnectionString = "Data Source=LAPTOP-URAUHA04\\SQLTEST; User=sa; Password=123456; Initial Catalog=Prueba"; // LAPTOP-URAUHA04\\SQLTEST
//            conexion.Open();
//            Console.WriteLine("conexion realizada");

//            SqlCommand cmd = new SqlCommand(consulta, conexion);

//            SqlDataReader reader = cmd.ExecuteReader();

//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    //Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)}"); // tipo de dato y entre parentesis el numero de columna a mostrar


//                    //Console.WriteLine($"{reader[0]}"); //trae el dato en su forma original

//                    Datos(reader);  //uso de la interfaz Idatarecord

//                }
//            }

//            conexion.Close();

//            Console.ReadKey();

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Error: " + ex.Message);
//        }

//         Console.WriteLine("conexion cerrada");


//    }

//    static void Datos(IDataRecord fila)
//    {
//        Console.WriteLine($"ID: {fila[0]} - Apellido y Nombre: {fila[3]} {fila[2]}");
//    }
//}
