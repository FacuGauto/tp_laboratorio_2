using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendFormat("\n{0}",this.ParticiparEnClase());
            cadena.AppendFormat("\nEstado de cuenta: {0}",this.estadoCuenta);
            return cadena.ToString();
        }
        public static bool operator ==(Alumno a, EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != Alumno.EEstadoCuenta.Deudor)
                return true;

            return false;
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            //return !(a.claseQueToma == clase);
            return !(a == clase);
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public enum EEstadoCuenta { AlDia, Deudor, Becado }
    }
}
