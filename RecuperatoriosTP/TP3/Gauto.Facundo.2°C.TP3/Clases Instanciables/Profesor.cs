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

        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)random.Next(3));
            System.Threading.Thread.Sleep(600);
            this.clasesDelDia.Enqueue((EClases)random.Next(3));
        }

        /// <summary>
        /// Muestra los datos del Profesor
        /// </summary>
        /// <returns>String con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendFormat("\n{0}",this.ParticiparEnClase());
            return cadena.ToString();
        }

        /// <summary>
        /// Muestra la clase que da el profesor
        /// </summary>
        /// <returns>String con la clase que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases c in this.clasesDelDia)
            {
                cadena.AppendLine(c.ToString());
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns>String con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara la igualdad entre un profesor y una clase. Seran iguales si el profesor da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si son iguales. False si son distintos</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
                return true;
            return false;
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
    }
}
