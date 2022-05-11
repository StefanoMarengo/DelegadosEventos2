using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleEJ4
{
    internal class Program
    {
        //Cree una clase Ascensor que tenga los métodos.
        //DefinirPiso(int pisoNuevo) - público
        //subirPiso() - privado
        //bajarPiso() - privado
        //LlamarAscensor(int pisoActual)- público

        //Internamente los métodos públicos deben usar únicamente los métodos privados.
        //Los métodos privados únicamente pueden subir o bajar 1 piso a la vez.

        //Dispare un evento cada vez que cambie el piso en el que está el ascensor.
        //Investigue y utilice Thread.Sleep(1000).

        //En el manejador del evento imprima el piso actual, con el objetivo de que su visualización sea idéntica al display del ascensor en la realidad.
        //Console.Clear() - Borra la consola.
        //Console.Foreground y similares.

        static void Main(string[] args)
        {
            Ascensor ascensor = new Ascensor(0);
            ascensor.PisoAhora += PisoHandler;
            bool loop = true;
            while (loop)
            {
                Console.Write("Comandos del auto:\n1 | Llamar Ascensor\n2 | Definir Piso\n9 | Salir\nEleccion: ");
                int nro = int.Parse(Console.ReadLine());
                switch (nro)
                {
                    case 1:
                        Console.WriteLine("Ingrese su piso: ");
                        ascensor.LlamarAscensor(int.Parse(Console.ReadLine()));
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese su piso destino: ");
                        ascensor.DefinirPiso(int.Parse(Console.ReadLine()));
                        Console.Clear();
                        break;
                    case 9:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void PisoHandler(object sender, PisoArgs pisoArgs)
        {
            Console.WriteLine($"\nPiso Actual: {pisoArgs.Piso} {pisoArgs.Mensaje}");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
