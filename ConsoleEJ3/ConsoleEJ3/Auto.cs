using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEJ3
{
    public class VelocidadArgs : EventArgs
    {
        public int limiteVelocidad { get; set; }
    }
    class Auto
    {
        private delegate bool EncenderDelegado();
        private delegate bool VelocidadDelegado(int velocidad);

        public EventHandler<VelocidadArgs> VelocidadMaximaSuperada;

        public bool Encendido { get; set; }
        public int VelActual { get; set; }
        public int VelMaxima { get; set; }
        public Auto(bool encendido, int velActual, int velMaxima)
        {
            Encendido = encendido;
            VelActual = velActual;
            VelMaxima = velMaxima;
        }
        public Auto(int velMaxima)
        {
            Encendido = false;
            VelActual = 0;
            VelMaxima = velMaxima;
        }
        private bool Encender()
        {
            Encendido = true;
            return Encendido;
        }
        private bool Apagar()
        {
            Encendido = false;
            return true;
        }
        private bool SubirVelocidad(int velocidad)
        {
            VelActual = velocidad;
            if (velocidad > VelMaxima)
            {
                this.VelocidadMaximaSuperada(this, new VelocidadArgs
                {
                    limiteVelocidad = VelMaxima
                });
            }
            return true;
        }
        private bool BajarVelocidad(int velocidad)
        {
            if (velocidad <= 0)
                Apagar();
            else
                VelActual = velocidad;
            return true;
        }
        public bool Arrancar()
        {
            EncenderDelegado encenderDelegado;
            encenderDelegado = !this.Encendido ? new EncenderDelegado(Encender) : null;
            return encenderDelegado != null ? encenderDelegado() : false;
        }
        public bool ModificarVelocidad(int velocidad)
        {
            VelocidadDelegado velocidadDelegado = velocidad >= VelActual ? new VelocidadDelegado(SubirVelocidad) : new VelocidadDelegado(BajarVelocidad);
            velocidadDelegado(velocidad);
            return true;
        }
    }
}
