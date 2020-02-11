using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agenda
{
    public partial class frmCadastroContato : Form
    {
        public string operacao = "";
        public frmCadastroContato()
        {
            InitializeComponent();
        }

        public void AlteraBotoes(int op)
        {
            pDados.Enabled = false;
            btInserir.Enabled = false;
            btLocalizar.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;

            if (op == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
             }
            if (op == 2)
            {
                pDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;
            }
            if (op == 3)
            {
                btExcluir.Enabled = true;
                btAlterar.Enabled = true;
                btCancelar.Enabled = true;
            }
        }
        public void LimpaCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
        }

        private void frmCadastroContato_Load(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.AlteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
            this.LimpaCampos();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Contato contato = new Contato();
                if (txtNome.Text.Length <= 0)
                {
                    MessageBox.Show("É necessário informar um nome");
                    return;
                }
                if (txtTelefone.Text.Length <= 0)
                {
                    MessageBox.Show("É necessário informar um telefone");
                    return;
                }
                contato.Nome = txtNome.Text;
                contato.Telefone = txtTelefone.Text;
                String strConexao = "Data Source=DESKTOP-64F0TTG;Initial Catalog=Agenda1;Integrated Security=True";
                Conexao conexao = new Conexao(strConexao);
                DALContato dal = new DALContato(conexao);
                if (this.operacao == "inserir")
                {
                    dal.Incluir(contato);
                    MessageBox.Show("Foi gerado o código:" + contato.Codigo.ToString());

                }
                else
                {
                    contato.Codigo = Convert.ToInt32(txtCodigo.Text);
                    dal.Alterar(contato);
                    MessageBox.Show("O contato foi alterado com sucesso");
                }
                this.AlteraBotoes(1);
                this.LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaContatos f = new frmConsultaContatos();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                String strConexao = "Data Source=DESKTOP-64F0TTG;Initial Catalog=Agenda1;Integrated Security=True";
                Conexao conexao = new Conexao(strConexao);
                DALContato dal = new DALContato(conexao);
                Contato contato = dal.carregaContato(f.codigo);
                txtCodigo.Text = contato.Codigo.ToString();
                txtNome.Text = contato.Nome;
                txtTelefone.Text = contato.Telefone;
                this.AlteraBotoes(3);
            }
            f.Dispose();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.AlteraBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja excluir o contato?", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                String strConexao = "Data Source=DESKTOP-64F0TTG;Initial Catalog=Agenda1;Integrated Security=True";
                Conexao conexao = new Conexao(strConexao);
                DALContato dal = new DALContato(conexao);
                dal.Excluir(Convert.ToInt32(txtCodigo.Text));
                this.AlteraBotoes(1);
                this.LimpaCampos();
            }
        }
    }
}
