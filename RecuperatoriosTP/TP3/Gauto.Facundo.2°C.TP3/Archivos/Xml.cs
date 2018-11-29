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
