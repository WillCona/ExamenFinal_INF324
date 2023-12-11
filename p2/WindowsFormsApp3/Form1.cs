using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();

            DataSet ds = ws.ListaEstudiante();

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Desselecciona todas las filas
                dataGridView1.ClearSelection();

                // Selecciona la fila haciendo referencia al índice de la celda
                dataGridView1.Rows[e.RowIndex].Selected = true;

                // Puedes acceder a los valores de las celdas de la fila seleccionada, por ejemplo:
                string valorCelda = dataGridView1.Rows[e.RowIndex].Cells["ci"].Value.ToString();

                textBox1.Text = valorCelda;

                button1.Enabled = false;

                // Supongamos que tienes un TextBox llamado textBox1 en tu formulario

                // Para hacer que el TextBox no sea editable en el código:
                textBox1.ReadOnly = true;


                valorCelda = dataGridView1.Rows[e.RowIndex].Cells["nombre_completo"].Value.ToString();

                textBox2.Text = valorCelda;

                valorCelda = dataGridView1.Rows[e.RowIndex].Cells["fecha_nacimiento"].Value.ToString();

                textBox3.Text = valorCelda;

                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["telefono"].Value.ToString();

                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["departamento"].Value.ToString();

                // Haz lo que necesites con el valor de la celda seleccionada
                //MessageBox.Show("Ejecutadamente");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();


            String ci = textBox1.Text;
            String nombre = textBox2.Text;
            String fechan = textBox3.Text;
            String telf = textBox4.Text;
            String depto = textBox5.Text;

            int car = sw.IngresarEstudiante(ci, nombre, fechan, telf, depto);

            if (car == 1)
            {
                MessageBox.Show("Agregado");

                ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();

                DataSet ds = ws.ListaEstudiante();

                dataGridView1.DataSource = ds.Tables[0];
                textBox1.ReadOnly = false;

                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                button1.Enabled = true;

            }
            else
            {
                MessageBox.Show("fallo...!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();


            String ci = textBox1.Text;
            String nombre = textBox2.Text;
            String fechan = textBox3.Text;
            String telf = textBox4.Text;
            String depto = textBox5.Text;

            if (!ci.Equals(""))
            {
                sw.ActualizarEstudiante(ci, nombre, fechan, telf, depto);

                MessageBox.Show("Actualizado");

                ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();

                DataSet ds = ws.ListaEstudiante();

                dataGridView1.DataSource = ds.Tables[0];

                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                textBox1.ReadOnly = false;
                button1.Enabled = true;
            }
            else {
                MessageBox.Show("Seleccione un registro primero...!!!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient sw = new ServiceReference1.WebService1SoapClient();
            String ci = textBox1.Text;
            if (!ci.Equals(""))
            {
                sw.EliminarEstudiante(ci);
                MessageBox.Show("Eliminiado");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                textBox1.ReadOnly = false;

                DataSet ds = sw.ListaEstudiante();

                dataGridView1.DataSource = ds.Tables[0];
                button1.Enabled = true;

            }
            else {
                MessageBox.Show("Seleccione un registro primero...!!!");
            }
            

           

        }




        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


    }
}
