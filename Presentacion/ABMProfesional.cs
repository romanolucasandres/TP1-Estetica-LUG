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
    public partial class ABMProfesional : Form
    {
        BEProfesional _BEprof;
        BLLProfesional _BLLprof;
        public ABMProfesional()
        {
            InitializeComponent();
            _BEprof = new BEProfesional();
            _BLLprof = new BLLProfesional();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _BEprof.Id = 0;

            CargarDatos();

            _BLLprof.Alta(_BEprof);
            Mostrar();
            Vaciar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _BEprof.Id = Convert.ToInt32(textBox7.Text);

                DialogResult resultado = MessageBox.Show("Está por eliminar al profesional " +
                    _BEprof.DNI + "¿Confirma esta acción?", "Confirmar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    _BLLprof.Baja(_BEprof);
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
                BEAdministrativo aux = dataGridViewPROFESIONAL.SelectedRows[0].DataBoundItem as BEAdministrativo;
                _BEprof.Id = aux.Id;
                _BEprof.DNI = textBox1.Text;
                _BEprof.Nombre = textBox2.Text;
                _BEprof.Apellido = textBox3.Text;
                _BEprof.Telefono = textBox4.Text;
                _BEprof.Email = textBox5.Text;
                _BEprof.FechaNac = dateTimePicker1.Value;
                _BEprof.CalcularEdad();
                _BEprof.Titulo = textBox6.Text;
                Vaciar();

                // mando el BEProfesional con las propiedades cargadas a la BLL
                _BLLprof.Modifcacion(_BEprof);

                Mostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void ABMProfesional_Load(object sender, EventArgs e)
        {
            Mostrar();
            ModoSeleccion();
        }

        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                BEProfesional aux = dataGridViewPROFESIONAL.SelectedRows[0].DataBoundItem as BEProfesional;
                textBox1.Text = aux.DNI;
                textBox2.Text = aux.Nombre;
                textBox3.Text = aux.Apellido;
                textBox4.Text = aux.Telefono;
                textBox5.Text = aux.Email;
                dateTimePicker1.Value = aux.FechaNac;
                _BEprof.CalcularEdad();
                textBox6.Text = aux.Titulo;
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
            dataGridViewPROFESIONAL.DataSource = null;
            dataGridViewPROFESIONAL.DataSource = _BLLprof.Listar();

            if (dataGridViewPROFESIONAL.DataSource != null)
            {
                dataGridViewPROFESIONAL.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
                //pongo el id al principio del dgv
                dataGridViewPROFESIONAL.Columns["Id"].DisplayIndex = 0;
            }


        }


        private void ModoSeleccion()
        {
            dataGridViewPROFESIONAL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPROFESIONAL.MultiSelect = false;
            dataGridViewPROFESIONAL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        private void CargarDatos()
        {

            _BEprof.DNI = textBox1.Text;
            _BEprof.Nombre = textBox2.Text;
            _BEprof.Apellido = textBox3.Text;
            _BEprof.Telefono = textBox4.Text;
            _BEprof.Email = textBox5.Text;
            _BEprof.Titulo = textBox6.Text;

            if (dateTimePicker1.Value.Year < DateTime.Today.Year)
                _BEprof.FechaNac = (dateTimePicker1.Value);
            else
                throw new Exception("La fecha no es válida. Por favor, ingrese su fecha de nacimiento");
            _BEprof.CalcularEdad();
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


    }
}
