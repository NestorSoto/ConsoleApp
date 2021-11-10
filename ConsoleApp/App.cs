
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Vistas;
using MySqlConnector;
namespace Menu
{
    class App
    {
        static void Main(String[] args)
        {

        
            MenuPrincipal.Options();


            /*
            using var connection =mysql.getConexion();
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM ciudad;", connection);
            using var reader = await command.ExecuteReaderAsync();
            Console.WriteLine("Mostrando lista de cuidades\n CIUDAD || PAIS");
            while (await reader.ReadAsync())
            {

                Console.WriteLine(reader.GetValue(1) + " || " + reader.GetValue(2));
            }
            
            int opcion = 0;
            do
            {
                opcion += 1;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu Opciones");
            } while (opcion != 3);
            */
        }
    }
}

