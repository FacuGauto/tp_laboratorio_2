﻿using System;
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
        public event DelegadoEstado DataBase;
        


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

        /// <summary>
        /// Realiza el cambio de estado del paquete.
        /// </summary>
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
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemento">Paquete</param>
        /// <returns>String con la informacion del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}",p.TranckingID,p.DireccionEntrega);
        }
        
        /// <summary>
        /// Compara si dos paquetes son iguales por su TrackingID
        /// </summary>
        /// <param name="p1">Primer paquete</param>
        /// <param name="p2">Segundo paquete</param>
        /// <returns>True si son iguales, False si no lo son</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TranckingID == p2.TranckingID)
                return true;
            return false;
        }

        /// <summary>
        /// Compara si dos paquetes son distintos por su TrackingID
        /// </summary>
        /// <param name="p1">Primer paquete</param>
        /// <param name="p2">Segundo paquete</param>
        /// <returns>True si son distintos, False si no lo son</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        { return !(p1 == p2); }

        /// <summary>
        /// Devuelve la inforacion del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public enum EEstado {Ingresado, EnViaje, Entregado}
    }
}
