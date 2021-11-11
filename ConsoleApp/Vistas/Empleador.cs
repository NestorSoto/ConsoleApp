using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Vistas
{
    internal class Empleador
    {
        public static void MenuEmploye()
        {

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.WriteLine("Bienvenido" + userName);
            Console.WriteLine("Mostrando rutas disponibles");
            showRoute();
            Console.WriteLine("1.Registrar pasajero \n2.Salir");
            int opc = int.Parse(Console.ReadLine());
            if (opc == 1)
            {
                Console.Write("Ingrese el codigo del vuelo-> ");
                int codigo = int.Parse(Console.ReadLine());
                Console.Write("Ingrese los nombres  del pasajero-> ");
                String nombres = Console.ReadLine();
                Console.Write("Ingrese los apellidos  del pasajero-> ");
                String apellidos = Console.ReadLine();
                Console.Write("Ingrese DNI  del pasajero-> ");
                String DNI = Console.ReadLine();
                Console.Write("Ingrese el email  del pasajero-> ");
                String email = Console.ReadLine();
                MySqlConnection conexion = mysql.getConexion();
                Console.WriteLine("¿Es adulto? \n1. Si \n2. No");
                int adulto = int.Parse(Console.ReadLine());
                bool esadulto = true;
                if (adulto == 1)
                {
                    esadulto = true;
                }
                else
                {
                    esadulto = false;
                }
                conexion.OpenAsync();
                string qwery = "CrearPasajero";
                MySqlCommand consulta = new MySqlCommand(qwery, conexion);
                consulta.CommandType = System.Data.CommandType.StoredProcedure;
                consulta.Parameters.Add(new MySqlParameter("VueloID", codigo));
                consulta.Parameters.Add(new MySqlParameter("PasajeroNombre", nombres));
                consulta.Parameters.Add(new MySqlParameter("PasajeroApellido", apellidos));
                consulta.Parameters.Add(new MySqlParameter("PasajeroDNI", DNI));
                consulta.Parameters.Add(new MySqlParameter("PasajeroEmail", email));
                consulta.Parameters.Add(new MySqlParameter("PasajeroAdulto", esadulto));
                consulta.ExecuteNonQuery();
                Console.WriteLine("Pasajero registrado con exito");
            }
        }
        static async Task showRoute()
        {
            using var connection = mysql.getConexion();
            await connection.OpenAsync();
            string qwery = "SELECT v.vueloID, v.FechaSalida, v.FechaLlegada,co.Nombre, co.Pais , cd.Nombre, cd.Pais ,a.Marca, a.Modelo FROM vuelo v INNER JOIN ciudad cd ON cd.CiudadID = v.CiudadDestinoID INNER JOIN ciudad co ON co.CiudadID = v.CiudadOrigenID INNER JOIN avion a  ON a.AvionID = v.AvionID; ";
            using var command = new MySqlCommand(qwery,connection);
            using var reader = await command.ExecuteReaderAsync();
            Console.WriteLine("Mostrando lista de Rutas");
            Console.WriteLine("Codigo \tFecha de salida \t Fecha llegada \t cuidad origen \t Pais origen \t Ciudad destino \t Pais destino");
            while (await reader.ReadAsync())
            {

                Console.WriteLine(reader.GetValue(0) + "\t"+reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3)+ "\t" + reader.GetValue(4) + "\t" + reader.GetValue(5) + "\t" + reader.GetValue(6));
            }
        }


    }
}
