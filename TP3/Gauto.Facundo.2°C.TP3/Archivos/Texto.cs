using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo);

            try
            {
                sw.Write(datos);
            }
            catch (Exception)
            {
                throw new ArchivosException("Error en operacion guardar");
            }
            finally
            {
                sw.Close();
            }
            return true;
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = new StreamReader(archivo);

            try
            {
                datos = sr.ReadToEnd();
            }
            catch (Exception)
            {
                throw new ArchivosException("Error en operacion Leer");
            }
            finally
            {
                sr.Close();
            }
            return true;
        }
    }
}
