namespace PIM_IV.view
{
    partial class FormEmpresas
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
            this.btnCadastrarEmpresa = new System.Windows.Forms.Button();
            this.btnAlterarEmpresa = new System.Windows.Forms.Button();
            this.btnVoltarUser = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CNPJ = new System.Windows.Forms.Label();
            this.txtCnpjBusca = new System.Windows.Forms.TextBox();
            this.btnBuscaCNPJ = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNPJDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeresponsavelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hERMESDataSet = new PIM_IV.HERMESDataSet();
            this.btnCargo = new System.Windows.Forms.Button();
            this.empresasTableAdapter = new PIM_IV.HERMESDataSetTableAdapters.EmpresasTableAdapter();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hERMESDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCadastrarEmpresa
            // 
            this.btnCadastrarEmpresa.Font = new System.Drawing.Font("Quicksand Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarEmpresa.Location = new System.Drawing.Point(739, 618);
            this.btnCadastrarEmpresa.Name = "btnCadastrarEmpresa";
            this.btnCadastrarEmpresa.Size = new System.Drawing.Size(150, 54);
            this.btnCadastrarEmpresa.TabIndex = 17;
            this.btnCadastrarEmpresa.Text = "Cadastrar Nova Empresa";
            this.btnCadastrarEmpresa.UseVisualStyleBackColor = true;
            this.btnCadastrarEmpresa.Click += new System.EventHandler(this.btnCadastrarEmpresa_Click);
            // 
            // btnAlterarEmpresa
            // 
            this.btnAlterarEmpresa.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarEmpresa.Location = new System.Drawing.Point(583, 619);
            this.btnAlterarEmpresa.Name = "btnAlterarEmpresa";
            this.btnAlterarEmpresa.Size = new System.Drawing.Size(150, 54);
            this.btnAlterarEmpresa.TabIndex = 16;
            this.btnAlterarEmpresa.Text = "Alterar";
            this.btnAlterarEmpresa.UseVisualStyleBackColor = true;
            this.btnAlterarEmpresa.Click += new System.EventHandler(this.btnAlterarEmpresa_Click);
            // 
            // btnVoltarUser
            // 
            this.btnVoltarUser.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltarUser.Location = new System.Drawing.Point(895, 618);
            this.btnVoltarUser.Name = "btnVoltarUser";
            this.btnVoltarUser.Size = new System.Drawing.Size(150, 54);
            this.btnVoltarUser.TabIndex = 15;
            this.btnVoltarUser.Text = "Voltar";
            this.btnVoltarUser.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CNPJ);
            this.groupBox4.Controls.Add(this.txtCnpjBusca);
            this.groupBox4.Controls.Add(this.btnBuscaCNPJ);
            this.groupBox4.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(11, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(403, 116);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Empresa:";
            // 
            // CNPJ
            // 
            this.CNPJ.AutoSize = true;
            this.CNPJ.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CNPJ.Location = new System.Drawing.Point(16, 24);
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.Size = new System.Drawing.Size(67, 22);
            this.CNPJ.TabIndex = 2;
            this.CNPJ.Text = "CNPJ:";
            // 
            // txtCnpjBusca
            // 
            this.txtCnpjBusca.Location = new System.Drawing.Point(20, 49);
            this.txtCnpjBusca.Name = "txtCnpjBusca";
            this.txtCnpjBusca.Size = new System.Drawing.Size(208, 29);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1034, 473);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Empresas:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nomeDataGridViewTextBoxColumn,
            this.cNPJDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.telefoneDataGridViewTextBoxColumn,
            this.nomeresponsavelDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.empresasBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 439);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigo.DataPropertyName = "codigo_empresa";
            this.codigo.HeaderText = "Cod";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 75;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn.Width = 92;
            // 
            // cNPJDataGridViewTextBoxColumn
            // 
            this.cNPJDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNPJDataGridViewTextBoxColumn.DataPropertyName = "CNPJ";
            this.cNPJDataGridViewTextBoxColumn.HeaderText = "CNPJ";
            this.cNPJDataGridViewTextBoxColumn.Name = "cNPJDataGridViewTextBoxColumn";
            this.cNPJDataGridViewTextBoxColumn.ReadOnly = true;
            this.cNPJDataGridViewTextBoxColumn.Width = 87;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 94;
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            this.telefoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.telefoneDataGridViewTextBoxColumn.DataPropertyName = "telefone";
            this.telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            this.telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            this.telefoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefoneDataGridViewTextBoxColumn.Width = 119;
            // 
            // nomeresponsavelDataGridViewTextBoxColumn
            // 
            this.nomeresponsavelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nomeresponsavelDataGridViewTextBoxColumn.DataPropertyName = "Nome_responsavel";
            this.nomeresponsavelDataGridViewTextBoxColumn.HeaderText = "Responsavel";
            this.nomeresponsavelDataGridViewTextBoxColumn.Name = "nomeresponsavelDataGridViewTextBoxColumn";
            this.nomeresponsavelDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeresponsavelDataGridViewTextBoxColumn.Width = 154;
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataMember = "Empresas";
            this.empresasBindingSource.DataSource = this.hERMESDataSet;
            // 
            // hERMESDataSet
            // 
            this.hERMESDataSet.DataSetName = "HERMESDataSet";
            this.hERMESDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCargo
            // 
            this.btnCargo.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargo.Location = new System.Drawing.Point(17, 619);
            this.btnCargo.Name = "btnCargo";
            this.btnCargo.Size = new System.Drawing.Size(150, 54);
            this.btnCargo.TabIndex = 18;
            this.btnCargo.Text = "Cargos";
            this.btnCargo.UseVisualStyleBackColor = true;
            this.btnCargo.Click += new System.EventHandler(this.btnCargo_Click);
            // 
            // empresasTableAdapter
            // 
            this.empresasTableAdapter.ClearBeforeFill = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.Location = new System.Drawing.Point(427, 618);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(150, 54);
            this.btnDeletar.TabIndex = 19;
            this.btnDeletar.Text = "Excluir";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // FormEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 690);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnCargo);
            this.Controls.Add(this.btnCadastrarEmpresa);
            this.Controls.Add(this.btnAlterarEmpresa);
            this.Controls.Add(this.btnVoltarUser);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEmpresas";
            this.Text = "FormEmpresas";
            this.Load += new System.EventHandler(this.FormEmpresas_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hERMESDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrarEmpresa;
        private System.Windows.Forms.Button btnAlterarEmpresa;
        private System.Windows.Forms.Button btnVoltarUser;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label CNPJ;
        private System.Windows.Forms.TextBox txtCnpjBusca;
        private System.Windows.Forms.Button btnBuscaCNPJ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCargo;
        private HERMESDataSet hERMESDataSet;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private HERMESDataSetTableAdapters.EmpresasTableAdapter empresasTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNPJDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeresponsavelDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnDeletar;
    }
}