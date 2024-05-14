using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SegundoProyectoVisualStudio
{
    public partial class Insertar : Form
    {
        public Insertar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String infraccion = txtPost.Text;

            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/controladorUsuario", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                id = textBox1.Text,
                nombre = textBox2.Text,
                apellido = textBox3.Text,
                fechaInscripcion = textBox4.Text,
                mensualidad = textBox5.Text,
            });
            RestResponse result = client.Execute(request);

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == ""
                || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == ""
                || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado todos la información del usuario que intenta guardar.", "Error");
            }
            else if (!int.TryParse(textBox1.Text, out int id))
            {
                MessageBox.Show("El formato del Id no es válido.Debe ser de tipo int");

            }
            else if (!DateTime.TryParseExact(textBox4.Text, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                MessageBox.Show("El formato de fecha y hora ingresado no es válido. Debe ser yyyy-MM-ddTHH:mm:ss");
            }
            else if (!double.TryParse(textBox5.Text, out double mensualidad))
            {
                MessageBox.Show("El formato de la mensualidad no es válido. Debe ser de tipo double.");
            }
            else if (int.TryParse(textBox2.Text, out int nombre) || int.TryParse(textBox3.Text, out int apellido)) {
                MessageBox.Show("El formato del nombre y del apellido debe ser texto.");
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                MessageBox.Show("Error al intentar guardar el usuario.", "Error");
                dynamic jsonObj = JsonSerializer.Deserialize<ExpandoObject>(result.Content);
                //MessageBox.Show(jsonObj.message);
                //MessageBox.Show(Convert.ToString(jsonObj.message));
                //textBox6.Text = Convert.ToString(jsonObj.message);
                //txtPost.Text = result.Content;
            }
            else if (result.StatusCode == HttpStatusCode.Conflict)
            {
                MessageBox.Show("El usuario con estos datos ya existe.", "Error");
                dynamic jsonObj = JsonSerializer.Deserialize<ExpandoObject>(result.Content);
                //textBox6.Text = Convert.ToString(jsonObj.message);
                //MessageBox.Show(jsonObj.message);
            }
            else if (result.StatusCode == HttpStatusCode.Created)
            {
                MessageBox.Show("El usuario: " + result.Content + " ha sido agregado exitosamente.");
                textBox1.ResetText();
                textBox2.ResetText();
                textBox3.ResetText();
                textBox4.ResetText();
                textBox5.ResetText();
                //txtPost.Text = result.Content;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
