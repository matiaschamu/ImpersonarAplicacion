using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prueba
{
    static class Program
    {
        public static string[] Linea;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            Linea = args;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Prueba());   
        }
    }
}
