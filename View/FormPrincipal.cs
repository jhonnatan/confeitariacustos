using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FormPrincipal : Form
    {
        private IngredienteController ingredienteController = new IngredienteController();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormCadIngrediente(ingredienteController).ShowDialog();
        }
    }
}
