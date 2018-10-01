using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor de la clase Dulce
        /// </summary>
        /// <param name="marca">Marca del dulce</param>
        /// <param name="patente">Codigo de barras del producto</param>
        /// <param name="color">Color</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color) :base(patente,marca,color)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        /// <summary>
        /// Muestra los datos del dulce
        /// </summary>
        /// <returns>string con los datos del dulce</returns>
        public override string Mostrar()
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.AppendLine("DULCE");
            myStringBuilder.AppendLine((string)this);
            myStringBuilder.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            myStringBuilder.AppendLine("");
            myStringBuilder.AppendLine("---------------------");

            return myStringBuilder.ToString();
        }
    }
}
