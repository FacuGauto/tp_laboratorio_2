using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo: IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                    hilo.Abort();
            }
        }

        /// <summary>
        /// Devuelve la informacion de los paquetes de la lista.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>String con la Informacion de los paquetes de la lista</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string infoPaquetes = "";
            foreach (Paquete p in (List<Paquete>)((Correo)elemento).Paquetes)
            {
                infoPaquetes += string.Format("{0} para {1} ({2})\n", p.TranckingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return infoPaquetes;
        }

        /// <summary>
        /// Agrega un paquete a la lista
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns>Retorna el correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
            }

            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }


    }
}
