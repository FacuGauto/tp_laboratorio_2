using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

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
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) :this()
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
            this.StringToDNI = dni;
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Valida el dni. Para ser correcto si es argentino tiene que estar entre 1 y 89999999 y si es extranjero entre 90000000 y 99999999.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">Dni a validar</param>
        /// <returns>Devuelce el dni si es correcto o lanza una excepcion si es incorrecto</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                        return dato;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                        return dato;
                    break;
            }
            throw new NacionalidadInvalidaException("ERROR, Nacionalidad INVALIDA");
        }

        /// <summary>
        /// Valida un dni con respecto a su nacionalidad. Primero verifica que el string del dni sea correcto.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns>Devuelce el dni si es correcto o lanza una excepcion si es incorrecto</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxdni;
            if (dato.Length <= 8 && dato.Length > 0 && (int.TryParse(dato, out auxdni)))
            {
                foreach (char c in dato)
                {
                    if (!char.IsDigit(c))
                        throw new DniInvalidoException("ERROR, DNI contiene caracteres NO numericos");
                }
                return ValidarDni(nacionalidad, auxdni);
            }
            else
                throw new DniInvalidoException("ERROR, Cantidad de caracteres erronea || Imposibilidad de pasar a valor Numerico");
        }

        /// <summary>
        /// Valida que el nombre y apellido sean solo letras
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns>Devuelve el mismo dato que ingreso si es correcto o una cadena vacia de ser incorrecto</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                    return "";
            }
            return dato;
        }

        /// <summary>
        /// Informacion de una persona
        /// </summary>
        /// <returns>String con los datos de una persona</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("Apellido: {0}, Nombre {1}.\n",this.Apellido,this.Nombre);
            cadena.AppendFormat("Nacionalidad: {0}.\n",this.Nacionalidad);
            cadena.AppendFormat("DNI: {0}.\n",this.DNI);

            return cadena.ToString();
        }

        public enum ENacionalidad { Argentino, Extranjero };
    }
}
