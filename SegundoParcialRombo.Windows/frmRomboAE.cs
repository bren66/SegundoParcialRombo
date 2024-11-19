using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {
         RepositorioRombos? repo;
        public List<Rombo>? rombos;
        public frmRomboAE()
        {
            InitializeComponent();
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public void ValidorDatos()
        {

        }

        public Rombo GetRombo() => rombos;
    }
}
