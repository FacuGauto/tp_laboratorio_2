using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda en un archivo de texto en el escritorio de la maquina
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = string.Format("{0}\\{1}", path, archivo);
            StreamWriter sw = new StreamWriter(path, true);
            try
            {
                sw.WriteLine(texto);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sw.Close();
            }

            return true;
        }
    }
}
