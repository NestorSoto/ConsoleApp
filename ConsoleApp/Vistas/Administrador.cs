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
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.WriteLine("Bienvenido" + userName);
            Console.WriteLine("Mostrando menu de opciones de administrador");
            int opc = 0;
            while (opc!=4)
            {
                Console.WriteLine("1. Mostrar los aviones registrados");
                Console.WriteLine("2. Mostrar los los destinos registrados");
                Console.WriteLine("3. Mostrar rutas registradas");
                Console.WriteLine("4. salir");
                Console.Write("Digite una opcion -> ");
                try
                {
                    opc = int.Parse(Console.ReadLine());

                }
                catch(Exception e)
                {
                    opc = 0;
                }

                switch (opc)
                {
                    case 1:
                        showAirplane();
                        administracionAviones();

                        break;
                    case 2:
                        
                        showCities();
                        administracionRutas();
                        break;
                    case 3:
                        Empleador.showRoute();

                        break;


                }

            }

        }

        static void administracionRutas()
        {
            int opcR = 0;
            while(opcR != 3)
            {
                Console.WriteLine("1.Registrar nueva ciudad \n2.Eliminar una ciudad \n3.Salir");
                Console.WriteLine("Eliga una opcion->");
                opcR = int.Parse(Console.ReadLine());
                switch (opcR)
                {
                    case 1:
                        Console.Write("Ingrese nombre de la ciudad-> ");
                        String ciudad = Console.ReadLine();
                        Console.Write("Ingrese pais donde está ubicado la ciudad-> ");
                        String pais = Console.ReadLine();
                        MySqlConnection conexion = mysql.getConexion();
                        conexion.OpenAsync();
                        string qwery = "INSERT INTO ciudad (Nombre,Pais) VALUES(@ciudad,@pais)";
                        MySqlCommand consulta = new MySqlCommand(qwery, conexion);
                        consulta.Parameters.AddWithValue("@ciudad", ciudad);
                        consulta.Parameters.AddWithValue("@pais", pais);
                        consulta.ExecuteNonQuery();
                        Console.WriteLine("---------Registro de ciudad exitoso-----------");
                        break;
                    case 2:
                        Console.Write("Ingrese nombre de la ciuadad-> ");
                        String ciudadD = Console.ReadLine();
                        Console.Write("Ingrese pais de la ciudad-> ");
                        String paisD = Console.ReadLine();

                        MySqlConnection conexionD = mysql.getConexion();
                        conexionD.OpenAsync();
                        string qweryD = "DELETE FROM ciudad WHERE Nombre=@ciudad and Pais=@pais";
                        MySqlCommand consultaD = new MySqlCommand(qweryD, conexionD);
                        consultaD.Parameters.AddWithValue("@ciudad", ciudadD);
                        consultaD.Parameters.AddWithValue("@pais", paisD);
                        consultaD.ExecuteNonQuery();
                        Console.WriteLine("---------Eliminacion exitosa-----------");
                        break;

                }
            }
            
        }
        static async Task showCities()
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
        static void administracionAviones()
        {
            int opcA = 0;

            while (opcA != 3)
            {
                Console.WriteLine("1.Registrar nuevo avion \n2.Eliminar un Avion \n3.Salir");
                Console.WriteLine("Eliga una opcion->");
                opcA = int.Parse(Console.ReadLine());
                switch (opcA)
                {
                    case 1:
                        Console.Write("Ingrese marca del avion-> ");
                        String marca = Console.ReadLine();
                        Console.Write("Ingrese modelo del avion-> ");
                        String modelo = Console.ReadLine();
                        Console.Write("Ingrese capacidad del avion-> ");
                        int capacidad = int.Parse(Console.ReadLine());
                        MySqlConnection conexion = mysql.getConexion();
                        conexion.OpenAsync();
                        string qwery = "INSERT INTO avion(Capacidad,Marca,Modelo) VALUES(@capacidad,@marca,@modelo)";
                        MySqlCommand consulta = new MySqlCommand(qwery, conexion);
                        consulta.Parameters.AddWithValue("@capacidad", capacidad);
                        consulta.Parameters.AddWithValue("@marca", marca);
                        consulta.Parameters.AddWithValue("@modelo", modelo);
                        consulta.ExecuteNonQuery();
                        Console.WriteLine("---------Operacion terminada-----------");
                        break;
                    case 2:
                        Console.Write("Ingrese marca del avion-> ");
                        String marcaD = Console.ReadLine();
                        Console.Write("Ingrese modelo del avion-> ");
                        String modeloD = Console.ReadLine();
                        
                        MySqlConnection conexionD = mysql.getConexion();
                        conexionD.OpenAsync();
                        string qweryD = "DELETE FROM avion WHERE Marca=@marcaD and Modelo=@modelo";
                        MySqlCommand consultaD = new MySqlCommand(qweryD, conexionD);
                        consultaD.Parameters.AddWithValue("@marcaD", marcaD);
                        consultaD.Parameters.AddWithValue("@modelo", modeloD);
                        consultaD.ExecuteNonQuery();
                        Console.WriteLine("---------Eliminacion exitosa-----------");
                        break;
                }
            }
            Console.WriteLine("Mostrando lista de aviones");
            showAirplane();

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
