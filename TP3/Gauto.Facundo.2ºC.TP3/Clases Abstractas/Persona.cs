using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private string nombre;
        private ENacionalidad nacionalidad;

        public Persona()
        { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI;
        }
        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }
        public int DNI
        {
            get
            {
                return dni;
            }
            set
            {
                if (this.Nacionalidad == ENacionalidad.Argentino)
                { if (value > 1 && value < 89999999)
                    { this.dni = value; }
                }
                if (this.Nacionalidad == ENacionalidad.Argentino)
                {
                    if (value > 1 && value < 89999999)
                    { this.dni = value; }
                }
                dni = value;
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public string StringToDNI
        {
            set
            {
                dni = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 1;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 1;
        }
        private string ValidarNombreApellido(string dato)
        {
            return "d";
        }
        public enum ENacionalidad { Argentino, Extranjero };

   
    }
}
