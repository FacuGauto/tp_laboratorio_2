using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda un objeto en un archivo xml
        /// </summary>
        /// <param name="archivo">path donde se va a guardar</param>
        /// <param name="datos">Objeto a guardar</param>
        /// <returns>True si salio bien</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter xmlWr = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            try
            {
                xmlSer.Serialize(xmlWr, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error en operacion Guardar xml", e);
            }
            finally
            {
                xmlWr.Close();
            }
            return true;
        }

        /// <summary>
        /// Lee un objeto desde un archivo xml
        /// </summary>
        /// <param name="archivo">path de donde se leé</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>True si la operacion se realizo con exito</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader xmlRd = new XmlTextReader(archivo);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));

            try
            {
                datos = (T)xmlSer.Deserialize(xmlRd);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error en operacion Leer xml", e);
            }
            finally
            {
                xmlRd.Close();
            }
            return true;
        }
    }
}
