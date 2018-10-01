using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks: Producto
    {
        /// <summary>
        /// Constructor de la clase Snacks
        /// </summary>
        /// <param name="marca">Marca del Snacks</param>
        /// <param name="patente">Codigo del producto</param>
        /// <param name="color">Color</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente,marca,color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Muestra los datos del producto
        /// </summary>
        /// <returns>string con los datos del snack</returns>
        public override sealed string Mostrar()
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.AppendLine("SNACKS");
            myStringBuilder.AppendLine((string)this);
            myStringBuilder.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            myStringBuilder.AppendLine("");
            myStringBuilder.AppendLine("---------------------");

            return myStringBuilder.ToString();
        }
    }
}
