namespace SegundoProyectoVisualStudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insertar insertar = new Insertar();
            insertar.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar eliminar = new Eliminar();
            eliminar.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarMultiple buscarMultiple = new BuscarMultiple();
            buscarMultiple.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acerca = new AcercaDe();
            acerca.ShowDialog();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar listar = new Listar();
            listar.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar actualizar = new Actualizar();
            actualizar.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
