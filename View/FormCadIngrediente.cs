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
    public partial class FormCadIngrediente : Form
    {
        private IngredienteController controller;
        private Ingrediente ingrediente;
        
        public FormCadIngrediente(IngredienteController controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.ingrediente = new Ingrediente();
        }

        public FormCadIngrediente(IngredienteController controller, Ingrediente ingredienteEdicao)
        {
            InitializeComponent();
            this.controller = controller;
            this.ingrediente = ingredienteEdicao;
            CarregarCampos(ingredienteEdicao);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {                
                ingrediente.Descricao = txtDescricao.Text;
                ingrediente.Preco = Convert.ToDouble(txtPreco.Text);
                ingrediente.Unidade = cbxUnidade.Text;
                ingrediente.DataCadastro = dtpDataCadastro.Value;

                if (ingrediente.IngredienteId > 0)
                    controller.Atualizar(ingrediente);
                else
                    controller.Adicionar(ingrediente);
                controller.SalvarTodos();

                MessageBox.Show("Cadastrado com sucesso!");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao gravar registro!");                
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o registro?",
                    "Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    controller.Excluir(ingrediente);
                    controller.SalvarTodos();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível excluir registro!","Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void CarregarCampos(Ingrediente ingr)
        {
            txtDescricao.Text = ingr.Descricao;
            txtPreco.Text = ingr.Preco.ToString();
            cbxUnidade.Text = ingr.Unidade.ToString();
            dtpDataCadastro.Value = ingr.DataCadastro;
        }
    }
}
