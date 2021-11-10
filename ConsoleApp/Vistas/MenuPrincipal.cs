using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Vistas
{
    internal class MenuPrincipal
    {
        public static void Options()
        {
            int op = 0;
            Console.WriteLine("Estacion 911");
            while (op != 3)
            {
                Console.WriteLine("1: Ingresar como administrador \n2.Ingresar como emprelado \n3. Salir");
                Console.WriteLine("Digite una opcion-> ");
                op = int.Parse(Console.ReadLine());
                Console.WriteLine(op);
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Usted está ingresando como administrador-> ");
                        Administrador.MenuAdmin();
                        break;
                    case 2:
                        Console.WriteLine("Usted está ingresando como administrador-> ");
                        break;
                    case 3:
                        Console.WriteLine("Gracias por usar nuestra plataforma ");
                        break;
                    default:
                        Console.WriteLine("Digite una opcion valida");
                        break;
                }
                

            }
        }
    }
}
