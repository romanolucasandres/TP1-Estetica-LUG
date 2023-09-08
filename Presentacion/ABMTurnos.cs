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
    public partial class ABMTurnos : Form
    {
        BLLCliente _BLLcliente;
        BECliente _BEcliente;
        BLLProfesional _BLLprofesional;
        BEProfesional _BEprofesional;
        BLLTratamiento _BLLTratamiento;
        BETratamiento _BETratamiento;
        BETurno _BEturno;
        BLLTurno _BLLturno;
        public ABMTurnos()
        {
            InitializeComponent();
            _BLLcliente = new BLLCliente();
            _BEcliente = new BECliente();
            _BLLprofesional = new BLLProfesional();
            _BEprofesional = new BEProfesional();
            _BLLTratamiento = new BLLTratamiento();
            _BETratamiento= new BETratamiento();
            _BEturno = new BETurno();
            _BLLturno =new BLLTurno();

        }

        private void ABMTurnos_Load(object sender, EventArgs e)
        {
            mostrar();
            ModoSeleccion();
            
            
        }

        private void mostrar()
        {
            comboBoxCliente.DataSource = _BLLcliente.Listar();
            comboBoxCliente.DisplayMember = "NroCliente";
            comboBoxCliente.Text = "Selecciona cliente";


            comboBoxProf.DataSource = _BLLprofesional.Listar();
            comboBoxProf.DisplayMember = "Apellido";
           
            comboBoxProf.Text = "Selecciona profesional";

            comboBoxTratamiento.DataSource = _BLLTratamiento.Listar();
            comboBoxTratamiento.DisplayMember = "Nombre";
            comboBoxTratamiento.ValueMember = "Id";
            
            comboBoxTratamiento.Text = "Selecciona tratamiento";

            comboBoxConsul.DataSource = Enum.GetValues(typeof(Consultorios));
            comboBoxConsul.SelectedIndex = 0;
            comboBoxConsul.Text = "Selecciona el consultorio";

            comboBoxHora.Items.Add("11:00");
            comboBoxHora.Items.Add("13:00");
            comboBoxHora.Items.Add("14:00");
            comboBoxHora.Items.Add("15:00");
            comboBoxHora.Items.Add("16:00");
            comboBoxHora.Items.Add("17:00");
            comboBoxHora.Items.Add("18:00");
            comboBoxHora.Items.Add("19:00");
            comboBoxHora.Text = "Selecciona la hora";

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _BLLturno.Listar();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (dataGridView1.DataSource != null)
            {
                //pongo el id al principio del dgv
                dataGridView1.Columns["Id"].DisplayIndex = 0;
            }
        }

        private void Vaciar()
        {
            comboBoxCliente = null;
            comboBoxConsul = null;
            comboBoxHora = null;
            comboBoxProf=null;
            comboBoxTratamiento = null;
            textBox7.Text = "";
            dateTimePicker1.Value = DateTime.Now;

        }
        private void ModoSeleccion()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            d = dateTimePicker1.Value;
            
            _BEturno.Cliente=(BECliente)comboBoxCliente.SelectedItem;
            _BEturno.Profesional=(BEProfesional)comboBoxProf.SelectedItem;
            _BEturno.Tratamiento=(BETratamiento)comboBoxTratamiento.SelectedItem;
            _BEturno.Fecha = Convert.ToDateTime(d.ToShortDateString());
            _BEturno.Hora = (comboBoxHora.SelectedItem).ToString();
            _BEturno.Consultorio=comboBoxConsul.SelectedItem.ToString();
            _BEturno.CalcularTotal();
            if (_BLLturno.Listar().Exists(x => x.Fecha == _BEturno.Fecha && x.Hora == _BEturno.Hora && x.Consultorio == _BEturno.Consultorio))
            {
                MessageBox.Show("Para este consultorio ya existe el turno otorgado, busque otro horario o cambie de consultorio.", "Aviso");
            }
            else
            {
                _BLLturno.Alta(_BEturno);
                mostrar();
                Vaciar();
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _BEturno.Id = Convert.ToInt32(textBox7.Text);

                DialogResult resultado = MessageBox.Show("Está por eliminar el turno seleccionado ¿Confirma esta acción?", "Confirmar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    _BLLturno.Baja(_BEturno);
                    mostrar();
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
            DateTime d = new DateTime();
            d = dateTimePicker1.Value;

            _BEturno.Cliente = (BECliente)comboBoxCliente.SelectedItem;
            _BEturno.Profesional = (BEProfesional)comboBoxProf.SelectedItem;
            _BEturno.Tratamiento = (BETratamiento)comboBoxTratamiento.SelectedItem;
            _BEturno.Fecha = Convert.ToDateTime(d.ToShortDateString());
            _BEturno.Hora = (comboBoxHora.SelectedItem).ToString();
            _BEturno.Consultorio = comboBoxConsul.SelectedItem.ToString();
            _BEturno.CalcularTotal();
            if (_BLLturno.Listar().Exists(x => x.Fecha == _BEturno.Fecha && x.Hora == _BEturno.Hora && x.Consultorio == _BEturno.Consultorio))
            {
                MessageBox.Show("Para este consultorio ya existe el turno otorgado, busque otro horario o cambie de consultorio.", "Aviso");
            }
            else
            {
                _BLLturno.Modifcacion(_BEturno);
                mostrar();
            }
        }

        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                BETurno aux = dataGridView1.SelectedRows[0].DataBoundItem as BETurno;
                dateTimePicker1.Value = aux.Fecha;

                comboBoxCliente.Text=aux.Cliente.ToString();
                comboBoxConsul.Text=aux.Consultorio.ToString();
                comboBoxHora.Text=aux.Hora.ToString();
                comboBoxProf.Text=aux.Profesional.ToString();
                comboBoxTratamiento.Text=aux.Tratamiento.ToString();
                textBox7.Text = aux.Id.ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
