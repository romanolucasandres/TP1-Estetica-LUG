using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class INFORMETurnosClientes : Form
    {
        BLLCliente _BLLcliente;
        BECliente _BECliente;
        BETurno _BEturno;
        BLLTurno _BLLturno;

        public INFORMETurnosClientes()
        {
            InitializeComponent();
            _BLLcliente = new BLLCliente();
            _BECliente = new BECliente();
        }

        private void TurnosClientes_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        
       public void Mostrar()
        {
            comboBoxCliente.DataSource = _BLLcliente.ListarTodo();
            comboBoxCliente.DisplayMember = "NroCliente";
            comboBoxCliente.Text = "Selecciona cliente";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _BECliente = (BECliente)comboBoxCliente.SelectedItem;
            dataInforme.DataSource = null;
            dataInforme.DataSource = _BECliente.Turnos;
            this.dataInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void Click(object sender, MouseEventArgs e)
        {
           
        }

        private void dobleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void doble(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
