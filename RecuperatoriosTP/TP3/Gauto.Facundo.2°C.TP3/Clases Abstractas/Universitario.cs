using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType() && (((Universitario)obj).legajo == this.legajo || (this.DNI == ((Universitario)obj).DNI)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Muestra los datos del Universitario
        /// </summary>
        /// <returns>String con los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.ToString());
            cadena.AppendFormat("Legajo: {0}\n",this.legajo);
            return cadena.ToString();
        }

        protected abstract string ParticiparEnClase();
        
        /// <summary>
        /// Compara la igualdad de dos universitarios. Seran iguales si son del mismo tipo y su legajo o dni son iguales
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo Universitario</param>
        /// <returns>True si son iguales. False si son distintos</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Compara si dos universitarios son distintos.
        /// </summary>
        /// <param name="pg1">Primer Universitario</param>
        /// <param name="pg2">Segundo Universitario</param>
        /// <returns>True si son distintos. False si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
