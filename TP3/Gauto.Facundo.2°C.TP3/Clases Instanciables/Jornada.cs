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
            this.alumnos = new List<Alumno>();
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

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("Clase: {0}, Profesor: {1}",this.Clase,this.Instructor);

            foreach (Alumno alumno in this.Alumnos)
            {
                cadena.AppendLine(alumno.ToString());
            }

            return cadena.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            string path = "texto.txt";
            return txt.Guardar(path,jornada.ToString());
        }

        public static string Leer()
        {
            Texto txt = new Texto();
            string path = "text.txt";
            string cadena = "";
            txt.Leer(path,out cadena);
            return cadena;
        }
    }
}
