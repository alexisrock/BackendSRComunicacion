using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Clases
{
    public class Log
    {

        private static string Path = "C:\\";





        private static string GetNameFile()
        {
            string nombre = "";

            nombre = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";

            return nombre;
        }

        public static void Add(string sLog)
        {
            CreateDirectory();
            string nombre = GetNameFile();
            string cadena = "";

            cadena += DateTime.Now + " - " + sLog + Environment.NewLine;

            StreamWriter sw = new StreamWriter(Path + "/Logs/" + nombre, true);
            sw.Write(cadena);
            sw.Close();

        }


        public static void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);


            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
