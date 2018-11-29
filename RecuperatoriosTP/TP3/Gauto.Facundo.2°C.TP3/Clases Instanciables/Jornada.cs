using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using static Clases_Instanciables.Universidad;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            { this.alumnos = value; }
        }
        public EClases Clase
        {
            get
            { return this.clase; }
            set
            { this.clase = value; }
        }
        public Profesor Instructor
        {
            get
            { return this.instructor; }
            set
            { this.instructor = value; }
        }


        /// <summary>
        /// Compara una jornada con un alumno. Seran iguales si el alumno participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Tru si son iguales. Flase si no lo son</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega alumnos a la clase, validando que no esten cargados previamente
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Joranda con el alumno agregado o lanza una excepcion si el alumno ya se encontraba</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }
            else
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns>String con los datos de la Jornada</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("Jornada\n");
            cadena.AppendFormat("->Clase: {0}\n",this.Clase);
            cadena.AppendFormat("->Profesor: {0}\n",this.Instructor.ToString());

            foreach (Alumno alumno in this.Alumnos)
            {
                cadena.AppendLine("->ALUMNO:");
                cadena.AppendLine(alumno.ToString());
            }
            cadena.AppendLine("------------------------------------------------------>");
            return cadena.ToString();
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            string path = "texto.txt";
            return txt.Guardar(path,jornada.ToString());
        }

        /// <summary>
        /// Lee los datos de un archivo de texto y los devuelve
        /// </summary>
        /// <returns>String con los datos de la jornada</returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string path = "texto.txt";
            string cadena = "";
            txt.Leer(path,out cadena);
            return cadena;
        }
    }
}
