using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario :Persona
    {
        private int legajo;

        public Universitario()
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        protected string MostrarDatos()
        {
            return "a";
        }
    }
}
