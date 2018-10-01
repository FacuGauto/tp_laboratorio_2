using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Constructor para un objeto Producto
        /// </summary>
        /// <param name="patente">Codigo de barras del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">Color</param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente; 
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get;}

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>string con los datos del producto</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        
        /// <summary>
        /// Operador string que devuelve los datos del producto
        /// </summary>
        /// <param name="producto">Objeto de tipo Producto</param>
        public static explicit operator string(Producto producto)
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.AppendFormat("CODIGO DE BARRAS: {0}\r\n", producto.codigoDeBarras);
            myStringBuilder.AppendFormat("MARCA          : {0}\r\n", producto.marca.ToString());
            myStringBuilder.AppendFormat("COLOR EMPAQUE  : {0}\r\n", producto.colorPrimarioEmpaque.ToString());
            myStringBuilder.AppendLine("---------------------");

            return myStringBuilder.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="productoUno">Objeto de tipo Producto</param>
        /// <param name="productoDos">Objeto de tipo Producto</param>
        /// <returns>True si tienen el mismo codigo de barras, False si el codigo de barras es distinto</returns>
        public static bool operator ==(Producto productoUno, Producto productoDos)
        {
            return (productoUno.codigoDeBarras == productoDos.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="productoUno">Objeto de tipo Producto</param>
        /// <param name="productoDos">Objeto de tipo Producto</param>
        /// <returns>True si tienen distinto codigo de barras, False si tienen el mismo codigo de barras</returns>
        public static bool operator !=(Producto productoUno, Producto productoDos)
        {
            return !(productoUno == productoDos);
        }
    }
}
