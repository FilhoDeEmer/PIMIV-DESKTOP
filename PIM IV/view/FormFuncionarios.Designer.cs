﻿namespace PIM_IV
{
    partial class FormFuncionarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.funcionariosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fUNCIONARIOStesteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAlterarFun = new System.Windows.Forms.Button();
            this.btnCadastrarFun = new System.Windows.Forms.Button();
            this.fUNCIONARIOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCpfBusca = new System.Windows.Forms.TextBox();
            this.btnPesquisaFuncionario = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCnpjBusca = new System.Windows.Forms.TextBox();
            this.btnBuscaCNPJ = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOStesteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOSBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Font = new System.Drawing.Font("Quicksand Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(36, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 473);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Funcionários:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.funcionariosBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1018, 448);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // funcionariosBindingSource1
            // 
            this.funcionariosBindingSource1.DataMember = "Funcionarios";
            // 
            // fUNCIONARIOStesteBindingSource
            // 
            this.fUNCIONARIOStesteBindingSource.DataMember = "FUNCIONARIOS_teste";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(894, 633);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(150, 54);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAlterarFun
            // 
            this.btnAlterarFun.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarFun.Location = new System.Drawing.Point(582, 633);
            this.btnAlterarFun.Name = "btnAlterarFun";
            this.btnAlterarFun.Size = new System.Drawing.Size(150, 54);
            this.btnAlterarFun.TabIndex = 4;
            this.btnAlterarFun.Text = "Alterar/\r\nExcluir";
            this.btnAlterarFun.UseVisualStyleBackColor = true;
            this.btnAlterarFun.Click += new System.EventHandler(this.btnAlterarFun_Click);
            // 
            // btnCadastrarFun
            // 
            this.btnCadastrarFun.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarFun.Location = new System.Drawing.Point(738, 633);
            this.btnCadastrarFun.Name = "btnCadastrarFun";
            this.btnCadastrarFun.Size = new System.Drawing.Size(150, 54);
            this.btnCadastrarFun.TabIndex = 5;
            this.btnCadastrarFun.Text = "Cadastrar Novo Funcionário";
            this.btnCadastrarFun.UseVisualStyleBackColor = true;
            this.btnCadastrarFun.Click += new System.EventHandler(this.btnCadastrarFun_Click);
            // 
            // fUNCIONARIOSBindingSource
            // 
            this.fUNCIONARIOSBindingSource.DataMember = "FUNCIONARIOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCpfBusca);
            this.groupBox1.Controls.Add(this.btnPesquisaFuncionario);
            this.groupBox1.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(559, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 116);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "CPF:";
            // 
            // txtCpfBusca
            // 
            this.txtCpfBusca.Location = new System.Drawing.Point(21, 55);
            this.txtCpfBusca.Name = "txtCpfBusca";
            this.txtCpfBusca.Size = new System.Drawing.Size(208, 29);
            this.txtCpfBusca.TabIndex = 1;
            // 
            // btnPesquisaFuncionario
            // 
            this.btnPesquisaFuncionario.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisaFuncionario.Location = new System.Drawing.Point(297, 49);
            this.btnPesquisaFuncionario.Name = "btnPesquisaFuncionario";
            this.btnPesquisaFuncionario.Size = new System.Drawing.Size(133, 41);
            this.btnPesquisaFuncionario.TabIndex = 0;
            this.btnPesquisaFuncionario.Text = "Pesquisar";
            this.btnPesquisaFuncionario.UseVisualStyleBackColor = true;
            this.btnPesquisaFuncionario.Click += new System.EventHandler(this.btnPesquisaFuncionario_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtCnpjBusca);
            this.groupBox4.Controls.Add(this.btnBuscaCNPJ);
            this.groupBox4.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(39, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(403, 116);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Empresa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "CNPJ:";
            // 
            // txtCnpjBusca
            // 
            this.txtCnpjBusca.Location = new System.Drawing.Point(6, 49);
            this.txtCnpjBusca.Name = "txtCnpjBusca";
            this.txtCnpjBusca.Size = new System.Drawing.Size(196, 29);
            this.txtCnpjBusca.TabIndex = 1;
            // 
            // btnBuscaCNPJ
            // 
            this.btnBuscaCNPJ.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaCNPJ.Location = new System.Drawing.Point(246, 43);
            this.btnBuscaCNPJ.Name = "btnBuscaCNPJ";
            this.btnBuscaCNPJ.Size = new System.Drawing.Size(133, 41);
            this.btnBuscaCNPJ.TabIndex = 0;
            this.btnBuscaCNPJ.Text = "Pesquisar";
            this.btnBuscaCNPJ.UseVisualStyleBackColor = true;
            this.btnBuscaCNPJ.Click += new System.EventHandler(this.btnBuscaCNPJ_Click);
            // 
            // FormFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1072, 729);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCadastrarFun);
            this.Controls.Add(this.btnAlterarFun);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFuncionarios";
            this.Text = "s\\z,ol";
            this.Load += new System.EventHandler(this.FormFuncionarios_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOStesteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOSBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAlterarFun;
        private System.Windows.Forms.Button btnCadastrarFun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource fUNCIONARIOSBindingSource;
        private System.Windows.Forms.BindingSource fUNCIONARIOStesteBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPFDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCpfBusca;
        private System.Windows.Forms.Button btnPesquisaFuncionario;
        private System.Windows.Forms.BindingSource funcionariosBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigocargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataadimicaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigousuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBuscaCNPJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCnpjBusca;
    }
}