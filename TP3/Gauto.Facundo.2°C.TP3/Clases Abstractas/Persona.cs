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

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            /*if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 1 && dato < 89999999)
                    return dato;
            }
            if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato > 90000000 && dato < 99999999)
                    return dato;
            }
            throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI");*/
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
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            /*
            int auxDni;
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException("DNI Incorrecto");

            foreach (char c in dato)
                if (!(char.IsDigit(c)))
                    throw new DniInvalidoException("Dni Incorrecto, no todos los caracteres son numericos");

            if (int.TryParse(dato, out auxDni))
            {
                return this.ValidarDni(this.Nacionalidad, auxDni);
            }
            else
            {
                throw new DniInvalidoException("DNI Incorrecto");
            }*/
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
        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                    return "";
            }
            return dato;
        }


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
