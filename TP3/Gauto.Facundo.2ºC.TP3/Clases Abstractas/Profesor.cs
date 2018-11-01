using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public sealed class Profesor:Universitario
    {
        private Queue<EClases> clasesDelDia;
        private Random random;

        Profesor()
        { }
        private Profesor()
        { }
        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
        { }
        private void _randomClases()
        { }
        protected new string MostrarDatos()
        { return ""; }

        protected string ParticiparEnClase()
        { return ""; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
