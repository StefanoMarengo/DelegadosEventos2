using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEJ3
{
    class ConsoleMain
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto(150);
            auto.VelocidadMaximaSuperada += VelocidadMaximaHandler;
            bool loop = true;
            while (loop)
            {
                Console.Write("Comandos del auto:\n1 | Arrancar\n2 | Modificar Velocidad\n9 | Salir\nEleccion: ");
                int nro = int.Parse(Console.ReadLine());
                switch (nro)
                {
                    case 1:
                        auto.Arrancar();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese velocidad: ");
                        auto.ModificarVelocidad(int.Parse(Console.ReadLine()));
                        break;
                    case 9:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void VelocidadMaximaHandler(object sender, VelocidadArgs velocidadArgs)
        {
            Console.WriteLine($"\nLa velocidad máxima ({velocidadArgs.limiteVelocidad}km/h) ha sido sobrepasada. ");
        }
    }
}
