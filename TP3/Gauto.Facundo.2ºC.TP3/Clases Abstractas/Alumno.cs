using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
        { }
        protected new string MostrarDatos()
        {
            return "";
        }
        public static bool operator ==(Alumno a, EClases clase)
        {
            return true;
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }
        protected string ParticiparEnclase()
        {
            return "";
        }
        public override string ToString()
        {
            return base.ToString();
        }

        enum EEstadoCuenta { AlDia,Deudor,Becado };

    }
}
