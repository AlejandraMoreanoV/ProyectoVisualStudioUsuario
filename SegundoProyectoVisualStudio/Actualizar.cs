using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace SegundoProyectoVisualStudio
{
    public partial class Actualizar : Form
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
            else {
                MessageBox.Show("Id inválido.", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != ""
                && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != ""
                && textBox5.Text.Trim() != "" && int.TryParse(textBox1.Text, out int num)
                && double.TryParse(textBox5.Text, out double mensualidad) 
                && !(int.TryParse(textBox2.Text, out int nombre) || int.TryParse(textBox3.Text, out int apellido))
                )
            {
                DialogResult decision = MessageBox.Show("¿Estás seguro de que quieres actualizar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decision == DialogResult.Yes)
                {
                    var new_options = new RestClientOptions("http://localhost:8080");
                    var new_client = new RestClient(new_options);
                    var new_request = new RestRequest($"/controladorUsuario/actualizarUsuario", Method.Put);
                    new_request.RequestFormat = DataFormat.Json;

                    try
                    {
                        string fechaString = textBox4.Text;
                        DateTime fecha = DateTime.ParseExact(fechaString, "dd/MM/yyyy hh:mm:ss tt", null);
                        string fechaISO8601 = fecha.ToString("yyyy-MM-ddTHH:mm:ss");
                        fechaISO8601 = fechaISO8601.Replace(" ", "T");
                        new_request.AddBody(new
                        {
                            id = textBox1.Text,
                            nombre = textBox2.Text,
                            apellido = textBox3.Text,
                            fechaInscripcion = fechaISO8601,
                            mensualidad = textBox5.Text,
                        });
                        RestResponse new_result = new_client.Execute(new_request);
                        //MessageBox.Show(new_result.Content);
                        if (new_result.StatusCode == HttpStatusCode.OK)
                        {
                            MessageBox.Show("El usuario ha sido actualizado exitosamente.", "Información");
                            textBox1.ResetText();
                            textBox2.ResetText();
                            textBox3.ResetText();
                            textBox4.ResetText();
                            textBox5.ResetText();
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            textBox5.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No fue posible actualizar el usuario.", "Error");
                        }
                    } catch (Exception ex)
                    {
                        MessageBox.Show("El formato de la fecha de inscripción no es válido.", "Error") ;
                    }
                }
            }
            else {
                MessageBox.Show("No ha ingresado toda la información requerida completa y/o correcta para actualizar el usuario. Por favor, si aun no lo ha hecho, busque el usuario, obtenga su información actual y actualice completa y correctamente.", "Información");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
