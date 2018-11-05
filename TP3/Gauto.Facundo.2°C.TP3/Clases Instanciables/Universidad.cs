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
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public Universidad()
        { }

        public List<Alumno> Alumnos
        {
            get
            {return this.alumnos; }
            set
            { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get
            { return this.profesores; }
            set
            { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get
            { return this.jornadas; }
            set
            { this.jornadas = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornadas[i]; }
            set { this.jornadas[i] = value; }
        }

        public bool Guardar(Universidad uni)
        { return true; }
        private string MostrarDatos(Universidad uni)
        {
            return "";
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        { return !(g == a); }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        { return !(g == i); }

        /*public static Profesor operator ==(Universidad u, EClases clase)
        { return true; }
        public static Profesor operator !=(Universidad u, EClases clase)
        { return true; }*/

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesor;

            return g;
        }

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
