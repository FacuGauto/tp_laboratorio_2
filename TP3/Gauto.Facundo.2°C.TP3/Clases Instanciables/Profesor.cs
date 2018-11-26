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

        //Profesor()
        //{ }
        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        private void _randomClases()
        {
            /*this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
            System.Threading.Thread.Sleep(500);
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));*/
            this.clasesDelDia.Enqueue((EClases)random.Next(3));
            System.Threading.Thread.Sleep(600);
            this.clasesDelDia.Enqueue((EClases)random.Next(3));
        }

        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendFormat("\n{0}",this.ParticiparEnClase());
            return cadena.ToString();
        }

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

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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
