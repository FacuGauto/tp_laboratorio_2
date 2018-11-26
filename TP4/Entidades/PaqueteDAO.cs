using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        
        /// <summary>
        /// Inicializa la conexion.
        /// </summary>
        static PaqueteDAO()
        {
            string connectionStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=True;";
            conexion = new SqlConnection(connectionStr);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        /// <summary>
        /// Inserta en la base en la tabla Paquetes
        /// </summary>
        /// <param name="p">Paquete</param>
        /// <returns>True si la operacion se realiza con exito</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                string alumno = "Gauto Facundo";
                conexion.Open();
                comando.CommandText = string.Format("INSERT INTO Paquetes (direccionEntrega,trackinkID,alumno) VALUES ({0},{1},{2})",p.DireccionEntrega,p.TranckingID,alumno);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return true;
        }

    }
}
