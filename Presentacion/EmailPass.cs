using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class EmailPass : UserControl
    {
        BELogin log;
        BLLLogin login;
        Menu menu;
        BLLSeguridad seguridad;
        public EmailPass()
        {
            InitializeComponent();
            log = new BELogin();
            login = new BLLLogin();
            seguridad = new BLLSeguridad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Email = txtMail.Text;
            log.Password=seguridad.EncriptarPW( txtPw.Text);
            bool l = login.Validacion(log);
            if (l == true)
            {
                menu = new Menu();
                menu.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Incorrecto", "Aviso");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
