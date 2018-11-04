using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        { }

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            { }
        }
        public List<Profesor> Instructores
        {
            get
            { return this.profesores; }
            set
            { }
        }
        public List<Jornada> Jornadas
        {
            get
            { return this.jornada; }
            set
            { }
        }
        public bool Guardar(Universidad uni)
        { return true; }
        private string MostrarDatos(Universidad uni)
        {
            return "";
        }

        public static bool operator ==(Universidad g, Alumno a)
        { return true; }
        public static bool operator !=(Universidad g, Alumno a)
        { return true; }
        public static bool operator ==(Universidad g, Profesor i)
        { return true; }
        public static bool operator !=(Universidad g, Profesor i)
        { return true; }
        /*public static Profesor operator ==(Universidad u, EClases clase)
        { return true; }
        public static Profesor operator !=(Universidad u, EClases clase)
        { return true; }*/
        public static Universidad operator +(Universidad g, EClases clase)
        { return g; }
        public static Universidad operator +(Universidad u, Alumno a)
        { return u; }
        public static Universidad operator +(Universidad u, Profesor i)
        { return u; }
        public override string ToString()
        {
            return base.ToString();
        }

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}
    }
}
