using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete: IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string tranckingID;
        public delegate void DelegadoEstado(object obj, EventArgs args);
        public event DelegadoEstado InformarEsatdo;


        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TranckingID = tranckingID;
        }

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TranckingID
        {
            get
            {
                return this.tranckingID;
            }
            set
            {
                this.tranckingID = value;
            }
        }

        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.Estado++;
                InformarEsatdo.Invoke(this, null);
            } while (this.Estado != Paquete.EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}",p.TranckingID,p.DireccionEntrega);
        }
        
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TranckingID == p2.TranckingID)
                return true;
            return false;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        { return !(p1 == p2); }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public enum EEstado {Ingresado, EnViaje, Entregado}
    }
}
