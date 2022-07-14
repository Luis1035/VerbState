using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerbState
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered",
              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dgvData,
              new object[] { true });
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        private void CargarInformacion()
        {
            using (dbInglesEntities db = new dbInglesEntities())
            {
                var verbs = db.VerbStates.ToList();

                dgvData.DataSource = verbs;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            using (dbInglesEntities db = new dbInglesEntities())
            {
                var lst = db.VerbStates.Where(x => x.Verb.StartsWith(txtFiltro.Text)).ToList();
                dgvData.DataSource = lst;
            }
        }
    }
}
