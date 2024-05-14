using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoProyectoVisualStudio
{
    public partial class BuscarMultiple : Form
    {
        public BuscarMultiple()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/controladorUsuario/buscarUsuarioId/{textBox1.Text}", Method.Get);
            RestResponse result = client.Execute(request);

            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Por favor digite el Id del usuario que desea consultar.", "Precaución");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Usuario no encontrado.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                var jsonObj = JsonSerializer.Deserialize<Usuario>(result.Content);
                textBox2.Text = jsonObj.nombre;
                textBox3.Text = jsonObj.apellido;
                textBox4.Text = jsonObj.fechaInscripcion.ToString();
                textBox5.Text = jsonObj.mensualidad.ToString();
            }
            else {
                MessageBox.Show("Id inválido.", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/controladorUsuario/buscarUsuarioNombre/{textBox2.Text}", Method.Get);

            RestResponse result = client.Execute(request);

            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Por favor digite el nombre del usuario que desea consultar.", "Precaución");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Usuario no encontrado.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                var jsonObj = JsonSerializer.Deserialize<Usuario>(result.Content);
                textBox1.Text = jsonObj.id.ToString();
                textBox3.Text = jsonObj.apellido;
                textBox4.Text = jsonObj.fechaInscripcion.ToString();
                textBox5.Text = jsonObj.mensualidad.ToString();
            }
            else {
                MessageBox.Show("Formato del nombre inválido.", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/controladorUsuario/buscarUsuarioIdNombre/{textBox1.Text}/{textBox2.Text}", Method.Get);

            RestResponse result = client.Execute(request);

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Por favor digite el Id y el nombre del usuario que desea consultar.", "Precaución");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Usuario no encontrado.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                var jsonObj = JsonSerializer.Deserialize<Usuario>(result.Content);
                textBox3.Text = jsonObj.apellido;
                textBox4.Text = jsonObj.fechaInscripcion.ToString();
                textBox5.Text = jsonObj.mensualidad.ToString();
            }
            else
            {
                MessageBox.Show("Formato del Id y/o nombre inválido.", "Error");
            }
        }
    }
}
