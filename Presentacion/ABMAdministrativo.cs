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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class ABMAdministrativo : Form
    {
        BLLAdministrativo _BLLadmin;
        BEAdministrativo _BEadmin;
        BLLSeguridad seguridad;
        public ABMAdministrativo()
        {
            InitializeComponent();
            _BLLadmin = new BLLAdministrativo();
            _BEadmin = new BEAdministrativo();
            seguridad = new BLLSeguridad();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _BEadmin.Id = 0;

                CargarDatos();

                _BLLadmin.Alta(_BEadmin);
                Mostrar();
                Vaciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
 
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                _BEadmin.Id = Convert.ToInt32(textBox7.Text);

                DialogResult resultado = MessageBox.Show("Está por eliminar al administrativo/a " +
                    _BEadmin.DNI + "¿Confirma esta acción?", "Confirmar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    _BLLadmin.Baja(_BEadmin);
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
                BEAdministrativo aux = dataGridViewADMINISTRATIVO.SelectedRows[0].DataBoundItem as BEAdministrativo;
                _BEadmin.Id = aux.Id;
                _BEadmin.DNI = textBox1.Text;
                _BEadmin.Nombre = textBox2.Text;
                _BEadmin.Apellido = textBox3.Text;
                _BEadmin.Telefono = textBox4.Text;
                _BEadmin.Email = textBox5.Text;
                _BEadmin.FechaNac = dateTimePicker1.Value;
                _BEadmin.CalcularEdad();
                _BEadmin.Contraseña = textBox6.Text;
                Vaciar();

                // mando el BEAdministrativo con las propiedades cargadas a la BLL
                _BLLadmin.Modifcacion(_BEadmin);

                Mostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ABMAdministrativo_Load(object sender, EventArgs e)
        {
            Mostrar();
            ModoSeleccion();
        }

        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                BEAdministrativo aux = dataGridViewADMINISTRATIVO.SelectedRows[0].DataBoundItem as BEAdministrativo;
                textBox1.Text = aux.DNI;
                textBox2.Text = aux.Nombre;
                textBox3.Text = aux.Apellido;
                textBox4.Text = aux.Telefono;
                textBox5.Text = aux.Email;
                dateTimePicker1.Value = aux.FechaNac;
                _BEadmin.CalcularEdad();
                textBox6.Text = seguridad.EncriptarPW(aux.Contraseña);
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
            dataGridViewADMINISTRATIVO.DataSource = null;
            dataGridViewADMINISTRATIVO.DataSource = _BLLadmin.Listar();

            if (dataGridViewADMINISTRATIVO.DataSource != null)
            {
                dataGridViewADMINISTRATIVO.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
                //pongo el id al principio del dgv
                dataGridViewADMINISTRATIVO.Columns["Id"].DisplayIndex = 0;
            }


        }
        private void ModoSeleccion()
        {
            dataGridViewADMINISTRATIVO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewADMINISTRATIVO.MultiSelect = false;
            dataGridViewADMINISTRATIVO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        private void CargarDatos()
        {
            //DateTime d = new DateTime();
            //d = dateTimePicker1.Value;

            _BEadmin.DNI = textBox1.Text;
            _BEadmin.Nombre = textBox2.Text;
            _BEadmin.Apellido = textBox3.Text;
            _BEadmin.Telefono = textBox4.Text;
            _BEadmin.Email = textBox5.Text;
            _BEadmin.Contraseña = seguridad.EncriptarPW(textBox6.Text);

            if (dateTimePicker1.Value.Year < DateTime.Today.Year)
                _BEadmin.FechaNac = (dateTimePicker1.Value);
            else
                throw new Exception("La fecha no es válida. Por favor, ingrese su fecha de nacimiento");
            _BEadmin.CalcularEdad();
            
            _BEadmin.Tarea = textBox8.Text;
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
            dateTimePicker1.Value = DateTime.Today;



        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
