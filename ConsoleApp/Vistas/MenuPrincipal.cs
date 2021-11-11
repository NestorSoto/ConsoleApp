using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Vistas
{
    internal class MenuPrincipal
    {
        public static void Options()
        {
            bool log=login();
            if (log)
            {
                Console.WriteLine("Usted está ingresando como administrador-> ");
                Administrador.MenuAdmin();
            }
            else
            {
                Console.WriteLine("Usted está ingresando como Empleado-> ");
                Empleador.MenuEmploye();
            }

            /*int op = 0;
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
                        Console.WriteLine("Usted está ingresando como Empleado-> ");
                        Empleador.MenuEmploye();
                        break;
                    case 3:
                        Console.WriteLine("Gracias por usar nuestra plataforma ");
                        break;
                }
                

            }
            */
        }
        static Boolean login()
        {


            using (var user = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(user);
                // Check for token claim with well-known Administrators group SID
                const string LOCAL_ADMININSTRATORS_GROUP_SID = "S-1-5-32-544";
                if (principal.Claims.SingleOrDefault(x => x.Value == LOCAL_ADMININSTRATORS_GROUP_SID) != null)
                {
                    Console.WriteLine("es admin");
                    return true;
                    
                }
                else
                {
                    Console.WriteLine("no es admin");
                    return false;
                }
            }
        }
    }
}
