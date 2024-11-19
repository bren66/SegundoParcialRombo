using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRombos : Form
    {
        RepositorioRombos? repo;
        private List<Rombo>? listarombos;
        private int cantidadRombos;
        public frmRombos()
        {
            InitializeComponent();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRomboAE frm = new frmRomboAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Rombo? RomboIngresado = frm.GetRombo();
            if (RomboIngresado is null)
            {
                return;
            }
            repo!.Agregar(RomboIngresado);
            var r = ConstruirFila(dgvDatos);
            SetearFila(r, RomboIngresado);
            AgregarFila(r, dgvDatos);
            cantidadRombos = repo!.GetCantidad();
            MessageBox.Show("Rombo agregado!!",
                "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }



        private void AgregarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Rombo romboIngresado)
        {
            r.Cells[colMayor.Index].Value = romboIngresado.DMayor;
            r.Cells[colMenor.Index].Value = romboIngresado.DMenor;
            r.Cells[colLado.Index].Value = romboIngresado.CalcularLado();
            r.Cells[colPerimetro.Index].Value = romboIngresado.GetPerimetro();
            r.Cells[colArea.Index].Value = romboIngresado.GetArea();



            r.Tag = romboIngresado;
        }

        private DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
        }


        private void CargarComboContornos(ref ToolStripComboBox tsCboBordes)
        {
            var listaBordes = Enum.GetValues(typeof(Contorno));
            foreach (var item in listaBordes)
            {
                tsCboBordes.Items.Add(item);
            }
            tsCboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            tsCboBordes.SelectedIndex = 0;

        }


        private void lado09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void lado90ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            repo?.GuardarDatos();
            Application.Exit();
        }

        private void frmElipses_Load(object sender, EventArgs e)
        {
            CargarComboContornos(ref tsCboContornos);

        }

    }
}
