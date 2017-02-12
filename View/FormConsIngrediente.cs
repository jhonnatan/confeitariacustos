using Controller;
using Model;
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
    public partial class FormConsIngrediente : Form
    {
        private IngredienteController ingredienteController;

        public FormConsIngrediente(IngredienteController ingredienteController)
        {
            InitializeComponent();
            this.ingredienteController = ingredienteController;
            CarregarIngredientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvIngredientes.CurrentRow.Cells[0].Value) > 0)
            {
                if(MessageBox.Show("Deseja mesmo excluir esse registro?",
                    "Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ingredienteController.Excluir(new Ingrediente()
                    {
                        IngredienteId = Convert.ToInt32(dgvIngredientes.CurrentRow.Cells[0].Value)
                    });
                    CarregarIngredientes();
                }
                    
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvIngredientes.DataSource = null;

            //filtro : Data
            if (txtDescricao.Text == string.Empty)
            {
                dgvIngredientes.DataSource = ingredienteController.Get(
                    x => x.DataCadastro >= dtpDataInicio.Value
                    && x.DataCadastro <= dtpDataFim.Value);
            }
            // filtro: Descrição e Data
            else
            {
                dgvIngredientes.DataSource = ingredienteController.Get(
                    x => x.Descricao.Contains(txtDescricao.Text)
                        && (x.DataCadastro >= dtpDataInicio.Value
                        && x.DataCadastro <= dtpDataFim.Value));
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new FormCadIngrediente(ingredienteController).ShowDialog();
        }

        public void CarregarIngredientes()
        {
            dgvIngredientes.DataSource = null;
            dgvIngredientes.DataSource = ingredienteController.GetAll();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvIngredientes.CurrentRow.Cells[0].Value) > 0)
            {
                new FormCadIngrediente(
                    ingredienteController,
                    new Ingrediente()
                    {
                        IngredienteId = (int)dgvIngredientes.CurrentRow.Cells[0].Value,
                        Preco =         (double)dgvIngredientes.CurrentRow.Cells[1].Value,
                        Unidade =       dgvIngredientes.CurrentRow.Cells[2].Value.ToString(),
                        DataCadastro =  (DateTime)dgvIngredientes.CurrentRow.Cells[3].Value,
                    }).ShowDialog();
            }
        }
    }
}
