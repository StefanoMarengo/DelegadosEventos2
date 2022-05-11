using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEJ4
{
    //Cree una clase Ascensor que tenga los métodos.
    //DefinirPiso(int pisoNuevo) - público
    //subirPiso() - privado
    //bajarPiso() - privado
    //LlamarAscensor(int pisoActual)- público
    public class PisoArgs : EventArgs
    {
        public int Piso { get; set; }
        public string Mensaje { get; set; }
    }
    public class Ascensor
    {
        private delegate bool DelegLlamarAscensor();
        private delegate bool DelegDefinirPiso();

        public EventHandler<PisoArgs> PisoAhora;
        public int PisoActual { get; set; }
        //public int CantidadDePisos { get; set;}
        public Ascensor(int pisoActual)//, int cantidadDePisos)
        {
            PisoActual = pisoActual;
           //CantidadDePisos = cantidadDePisos;
        }
        private void SubirPiso()
        {
            PisoActual++;
            this.PisoAhora(this, new PisoArgs
            {
                Piso = PisoActual
            });
            //if (PisoActual>CantidadDePisos)
            //    return false;
            //return true;
        }        
        private void BajarPiso()
        {
            PisoActual--;
            this.PisoAhora(this, new PisoArgs
            {
                Piso = PisoActual
            });
            //if (PisoActual<0)
            //    return false;
            //return true;
        }
        public void LlamarAscensor(int piso)
        {
            while (PisoActual-1!=piso)
            {
                if (piso > PisoActual)
                    SubirPiso();
                else
                    BajarPiso();
            }
            this.PisoAhora(this, new PisoArgs
            {
                Mensaje = "El ascensor llegó a su piso"
            });
        }
        public void DefinirPiso(int pisoDeseado)
        {
            int diferencia;
            if (pisoDeseado>PisoActual)
            {
                diferencia = pisoDeseado - PisoActual;
                for (int i = 1; i < diferencia; i++)
                {
                    SubirPiso();
                }
            }
            else if(pisoDeseado<PisoActual)
            {
                diferencia = PisoActual - pisoDeseado;
                for (int i = 1; i < diferencia; i++)
                {
                    BajarPiso();
                }
            }
            else
            {
                this.PisoAhora(this, new PisoArgs
                {
                    Mensaje = "Llego a su piso destino"
                });
            }
        }
    }
}
