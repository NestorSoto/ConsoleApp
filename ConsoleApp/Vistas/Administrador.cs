using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp.Vistas
{
    internal class Administrador
    {
        public Administrador()
        {


        }
        public static void MenuAdmin()
        {
            Console.WriteLine("Mostrando menu de opciones de administrador");
            showCitiesAsync();
            showAirplane();


        }

        static async Task showCitiesAsync()
        {
            using var connection = mysql.getConexion();
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM ciudad;", connection);
            using var reader = await command.ExecuteReaderAsync();
            Console.WriteLine("Mostrando lista de cuidades\n CIUDAD || PAIS");
            while (await reader.ReadAsync())
            {

                Console.WriteLine(reader.GetValue(1) + " || " + reader.GetValue(2));
            }
        }
        static async Task showAirplane()
        {
            using var connection = mysql.getConexion();
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM avion;", connection);
            using var reader = await command.ExecuteReaderAsync();
            Console.WriteLine("Mostrando lista de Aviones \n Marca || modelo || Capacidad");
            while (await reader.ReadAsync())
            {

                Console.WriteLine(reader.GetValue(2) + " || " + reader.GetValue(3)+" || "+ reader.GetValue(1));
            }
        }


    }
}
