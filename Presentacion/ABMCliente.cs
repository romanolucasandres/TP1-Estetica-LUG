using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class ABMCliente : Form
    {
        BLLCliente _BLLcliente;
        BECliente _BEcliente;

        public ABMCliente()
        {
            InitializeComponent();
            _BEcliente = new BECliente();
            _BLLcliente = new BLLCliente();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            _BEcliente.Id = 0;
            
            CargarDatos();

            _BLLcliente.Alta(_BEcliente);
            Mostrar();
            Vaciar();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _BEcliente.Id = Convert.ToInt32(textBox7.Text);

                DialogResult resultado = MessageBox.Show("Está por eliminar al cliente " +
                    _BEcliente.ToString() + "¿Confirma esta acción?", "Confirmar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    _BLLcliente.Baja(_BEcliente);
                    Mostrar();
                    Vaciar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BECliente aux = dataGridViewCLIENTE.SelectedRows[0].DataBoundItem as BECliente;
                _BEcliente.Id = aux.Id;
                _BEcliente.DNI = textBox1.Text;
                _BEcliente.Nombre = textBox2.Text;
                _BEcliente.Apellido = textBox3.Text;
                _BEcliente.Telefono = textBox4.Text;
                _BEcliente.Email = textBox5.Text;
                _BEcliente.FechaNac = dateTimePicker1.Value;
                _BEcliente.CalcularEdad();
                _BEcliente.NroCliente = Convert.ToInt32(textBox1.Text);

                _BEcliente.Direccion = textBox6.Text;
                Vaciar();



                // mando el BECliente con las propiedades cargadas a la BLL
                _BLLcliente.Modifcacion(_BEcliente);

                Mostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void ABMCliente_Load(object sender, EventArgs e)
        {
            Mostrar();
            ModoSeleccion();
        }
        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                BECliente aux = dataGridViewCLIENTE.SelectedRows[0].DataBoundItem as BECliente;
                textBox1.Text = aux.DNI;
                textBox2.Text = aux.Nombre;
                textBox3.Text = aux.Apellido;
                textBox4.Text = aux.Telefono;
                textBox5.Text = aux.Email;
                dateTimePicker1.Value = aux.FechaNac;
                _BEcliente.CalcularEdad();
                textBox8.Text = aux.NroCliente.ToString();
                textBox6.Text = aux.Direccion;
                textBox7.Text = aux.Id.ToString();
                

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        #region METODOS
        private void Mostrar()
        {
            dataGridViewCLIENTE.DataSource = null;
            dataGridViewCLIENTE.DataSource = _BLLcliente.Listar();

            if (dataGridViewCLIENTE.DataSource != null)
            {
                dataGridViewCLIENTE.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
                dataGridViewCLIENTE.Columns["NroCliente"].HeaderText = "Número de Cliente";
                dataGridViewCLIENTE.Columns["Id"].DisplayIndex = 0;
                dataGridViewCLIENTE.Columns["NroCliente"].DisplayIndex = 1;
            }
        }


        private void ModoSeleccion()
        {
            dataGridViewCLIENTE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCLIENTE.MultiSelect = false;
            dataGridViewCLIENTE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        private void CargarDatos()
        {
            DateTime d = new DateTime();
            d = dateTimePicker1.Value;

            _BEcliente.DNI = textBox1.Text;
            _BEcliente.Nombre = textBox2.Text;
            _BEcliente.Apellido = textBox3.Text;
            _BEcliente.Telefono = textBox4.Text;
            _BEcliente.Email = textBox5.Text;

            if (d.Year < DateTime.Today.Year)
                _BEcliente.FechaNac = Convert.ToDateTime(d.ToShortDateString());
            else
                throw new Exception("La fecha no es válida. Por favor, ingrese su fecha de nacimiento");
            _BEcliente.CalcularEdad();
            _BEcliente.NroCliente = Convert.ToInt32(textBox1.Text);
            _BEcliente.Direccion = textBox6.Text;
        }

        private void Vaciar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Value = DateTime.Today;



        }
        #endregion
    }
}
