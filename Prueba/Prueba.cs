using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string LineaCommand ="";
            foreach(string s in Program.Linea)
            {
                LineaCommand = LineaCommand + s;
            }

            
            string MiDominio = SystemInformation.UserDomainName;
            string MiUsuario = SystemInformation.UserName;
            string MiPC = SystemInformation.ComputerName;
            string CantidadMonitor = SystemInformation.MonitorCount.ToString();
            label1.Text = "Dominio: " + MiDominio + "\r\n" + "Usuario: " + MiUsuario + "\r\n" + "NombrePC: " + MiPC + "\r\n" + "Monitores: " + CantidadMonitor + "\r\n" + "L.Comandos: " + LineaCommand;

        }
    }
}
