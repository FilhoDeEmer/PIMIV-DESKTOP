﻿using PIM_IV.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.view
{
    
    public partial class FormGerEmpresas : Form
    {
        string cod = null;
        public FormGerEmpresas(string cod)
        {
            InitializeComponent();
            CRUDEmpresas pesquisa = new CRUDEmpresas();
            pesquisa.BuscarEmpresa(cod);
            txtNomeEmpresa.Text = Convert.ToString(pesquisa.Nome);
            txtCNPJ.Text = Convert.ToString(pesquisa.Cnpj);
            txtInscricao.Text = Convert.ToString(pesquisa.InscricaoEstadual);
            txtResponsavel.Text = Convert.ToString(pesquisa.NomeResponsavel);
            txtEndEmpresa.Text = Convert.ToString(pesquisa.Rua);
            txtCidadeEmpresa.Text = Convert.ToString(pesquisa.Cidade);
            txtNumEmpresa.Text = Convert.ToString(pesquisa.Numero);
            txtCepEmpresa.Text = Convert.ToString(pesquisa.Cep);
            txtUfEmpresa.Text = Convert.ToString(pesquisa.Estado);
            txtTelefone.Text = Convert.ToString(pesquisa.Telefone);
            txtEmail.Text = Convert.ToString(pesquisa.Email);
            this.cod = cod;

        }
        public FormGerEmpresas()
        {
            InitializeComponent();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Os dados alteradso serão perdidos. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();

            }
            else
            {

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CRUDEmpresas empresa1 = new CRUDEmpresas();
            empresa1.Nome = txtNomeEmpresa.Text;
            empresa1.Cnpj = txtCNPJ.Text;
            empresa1.InscricaoEstadual = txtInscricao.Text;
            empresa1.Rua = txtEndEmpresa.Text;
            empresa1.Cep = txtCepEmpresa.Text;
            empresa1.Numero = int.Parse(txtNumEmpresa.Text);
            empresa1.Cidade = txtCidadeEmpresa.Text;
            empresa1.Estado = txtUfEmpresa.Text;
            empresa1.Telefone = txtTelefone.Text;
            empresa1.Email = txtEmail.Text;
            empresa1.NomeResponsavel = txtResponsavel.Text;
            if (this.cod == null)
            {
                empresa1.CadastraEmpresa();
                Close();
            }
            else
            {
                empresa1.Codigo = this.cod;
                empresa1.AlterarEmpresa(cod);
                Close();
            }
        }
    }
}
