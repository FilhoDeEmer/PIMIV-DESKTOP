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
            this.btnCadastrarEmpresa = new System.Windows.Forms.Button();
            this.btnAlterarEmpresa = new System.Windows.Forms.Button();
            this.btnVoltarUser = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CNPJ = new System.Windows.Forms.Label();
            this.txtCnpjBusca = new System.Windows.Forms.TextBox();
            this.btnBuscaCNPJ = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnCargo = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1048, 474);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Empresas:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 28);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1022, 439);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            // FormEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 690);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNPJDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeresponsavelDataGridViewTextBoxColumn;
    }
}