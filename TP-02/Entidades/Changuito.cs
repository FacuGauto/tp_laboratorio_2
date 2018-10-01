using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> productos;
        int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor de la clase Changuito. Crea la instancia de la lista de tipo Producto
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Constructor de la clase Changuito 
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible</param>
        public Changuito(int espacioDisponible) :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="changuito">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>string con los datos del changuito y sus productos</returns>
        public static string Mostrar(Changuito changuito, ETipo tipo)
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", changuito.productos.Count, changuito.espacioDisponible);
            myStringBuilder.AppendLine("");
            foreach (Producto producto in changuito.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (producto is Snacks)
                            myStringBuilder.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (producto is Dulce)
                            myStringBuilder.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (producto is Leche)
                            myStringBuilder.AppendLine(producto.Mostrar());
                        break;
                    default:
                        myStringBuilder.AppendLine(producto.Mostrar());
                        break;
                }
            }

            return myStringBuilder.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="chango">Objeto donde se agregará el elemento</param>
        /// <param name="producto">Objeto a agregar</param>
        /// <returns>Objeto Changuito con un producto agregado</returns>
        public static Changuito operator +(Changuito chango, Producto producto)
        {
            foreach (Producto v in chango.productos)
            {
                if (v == producto)
                    return chango;
            }

            if(chango.productos.Count < chango.espacioDisponible)
                chango.productos.Add(producto);

            return chango;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="chango">Objeto donde se quitará el elemento</param>
        /// <param name="producto">Objeto a quitar</param>
        /// <returns>Objeto Changuito con un elemento menos</returns>
        public static Changuito operator -(Changuito chango, Producto producto)
        {
            foreach (Producto v in chango.productos)
            {
                if (v == producto)
                {
                    chango.productos.Remove(v);
                    break;
                }
            }

            return chango;
        }
        #endregion
    }
}
