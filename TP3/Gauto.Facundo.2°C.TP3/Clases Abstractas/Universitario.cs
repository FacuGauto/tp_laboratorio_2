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
            if (this.GetType() == obj.GetType())
            {
                if (((Universitario)obj).legajo == this.legajo || ((Universitario)obj).legajo == this.DNI)
                    return true;
            }
            return false;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("{0} Legajo: {1}", base.ToString(),this.legajo);
            return cadena.ToString();
        }

        protected abstract string ParticiparEnClase();
        
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
