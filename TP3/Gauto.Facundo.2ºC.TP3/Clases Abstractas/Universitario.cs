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

        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad) :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        protected string MostrarDatos()
        {
            return "a";
        }
        protected string ParticiparEnClase()
        {
            return "";
        }
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            return true;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
