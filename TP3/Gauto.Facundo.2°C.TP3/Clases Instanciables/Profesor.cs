using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        static Random random;

        Profesor()
        { }
        static Profesor()
        {
            random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
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

        public static bool operator ==(Profesor i, EClases clase)
        {
            return true;
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return true;
        }
    }
}
