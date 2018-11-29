using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda datos en un archivo de texto
        /// </summary>
        /// <param name="archivo">path donde se van a gauadar los datos</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>True si se pudo guardar con exito</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo);

            try
            {
                sw.Write(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error en operacion guardar", e);
            }
            finally
            {
                sw.Close();
            }
            return true;
        }

        /// <summary>
        /// Lee un archivo de texto 
        ///  </summary>
        /// <param name="archivo">path del archivo a leer</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>True si la operacion salio con exito</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = new StreamReader(archivo);

            try
            {
                datos = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error en operacion Leer", e);
            }
            finally
            {
                sr.Close();
            }
            return true;
        }
    }
}
