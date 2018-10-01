using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        private ETipo tipo;


        /// <summary>
        /// Constructor de la clase Leche
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color</param>
        /// <param name="tipo">Tipo de leche(Entera,Descremada)</param>
        public Leche(EMarca marca, string patente, ConsoleColor color,ETipo tipo)
            : base(patente, marca, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Constructor de la clase Leche sin tipo. Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            tipo = ETipo.Entera;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Muestra los datos de objeto Leche
        /// </summary>
        /// <returns>string con los datos del objeto leche</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine((string)this);
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
