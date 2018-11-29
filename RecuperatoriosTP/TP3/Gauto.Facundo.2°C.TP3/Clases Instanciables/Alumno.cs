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

        /// <summary>
        /// Muestra los datos del Alumno
        /// </summary>
        /// <returns>String con los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendFormat("\n{0}",this.ParticiparEnClase());
            cadena.AppendFormat("\nEstado de cuenta: {0}",this.estadoCuenta);
            return cadena.ToString();
        }

        /// <summary>
        /// Compara un alumno con unna clase. Seran iguales si el alumno toma esa clase y su estado no es deudor.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si son iguales. False si no son iguales</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != Alumno.EEstadoCuenta.Deudor)
                return true;

            return false;
        }

        /// <summary>
        /// Compara la desigualdad entre un alumno y una clase. Seran distintos si el alumno no toma la clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si son distintos. False si no son distintos</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a.claseQueToma == clase);
        }

        /// <summary>
        /// Muestra la clase que toma el alumno
        /// </summary>
        /// <returns>String con la clase que toma el Alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        /// Have publicos los datos del Alumno
        /// </summary>
        /// <returns>String con los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public enum EEstadoCuenta { AlDia, Deudor, Becado }
    }
}
