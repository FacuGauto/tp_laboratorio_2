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
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                ser.Serialize(xmlWr, datos);
            }
            catch (Exception)
            {
                throw new ArchivosException("Error en operacion Guardar xml");
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
            XmlSerializer ser = new XmlSerializer(typeof(T));

            try
            {
                datos = (T)ser.Deserialize(xmlRd);
            }
            catch (Exception)
            {
                throw new ArchivosException("Error en operacion Leer xml");
            }
            finally
            {
                xmlRd.Close();
            }
            return true;
        }
    }
}
