using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

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

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();
            foreach (Jornada jornada in uni.jornadas)
            {
                cadena.AppendLine(jornada.ToString());
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de la Universidad
        /// </summary>
        /// <returns>String con los datos de la Universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        /// <summary>
        /// Compara Universidad con alumno. Seran iguales si el alumno está inscripto en la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si son iguales. False si no lo son</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        { return !(g == a); }

        /// <summary>
        /// Compara Universidad con Profesor. Seran iguales si el profesor da clases en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si son iguales. False si no lo son</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        { return !(g == i); }

        /// <summary>
        /// Comapra Universidad con clase. 
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>La igualdad retorna el primer profesor que puede dar la clase.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException("No hay profesor para esta clase");
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException("Todos los profesores de la lista pueden dar la clase");
        }


        /// <summary>
        /// Se agrega una clase a una Universidad. Se genera una nueva jornada con un profesor y una lista de alumnos
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = g == clase;
            Jornada jornada = new Jornada(clase,profesor);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                    jornada = jornada + alumno;
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        /// <summary>
        /// Se agrega un alumno a una Uniersidad 
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Univeridad con alumno agregado</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException("ERROR. Alumno repetido");
            else
                u.Alumnos.Add(a);
            return u;
        }

        /// <summary>
        /// Se agrega un profesor a una Universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Alumno</param>
        /// <returns>Universidad con profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }

        /// <summary>
        /// Serializa los datos de la Universidad en un xml
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>True si se pudo guardar con exito</returns>
        public static bool Guardar(Universidad uni)
        {
            string path = "Universidad.xml";
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Guardar(path,uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Fallo al guardar el xml",e);
            }
            return true;
        }

        /// <summary>
        /// Lee los datos previamente serializados
        /// </summary>
        /// <returns>Objeto de tipo Universidad</returns>
        public static Universidad Leer()
        {
            string path = "Universidad.xml";
            Universidad universidad;

            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Leer(path, out universidad);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Fallo en la operacion de lectura del xml", e);
            }
            return universidad;
        }

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}
    }
}
