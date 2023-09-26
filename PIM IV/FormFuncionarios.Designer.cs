namespace PIM_IV
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAlterarFun = new System.Windows.Forms.Button();
            this.btnCadastrarFun = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pIMIIIDataSet = new PIM_IV.PIMIIIDataSet();
            this.fUNCIONARIOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fUNCIONARIOSTableAdapter = new PIM_IV.PIMIIIDataSetTableAdapters.FUNCIONARIOSTableAdapter();
            this.pIMIIIDataSet1 = new PIM_IV.PIMIIIDataSet1();
            this.fUNCIONARIOStesteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fUNCIONARIOS_testeTableAdapter = new PIM_IV.PIMIIIDataSet1TableAdapters.FUNCIONARIOS_testeTableAdapter();
            this.cODFUNCIONARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIMIIIDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIMIIIDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOStesteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(12, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(597, 295);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Funcionários:";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(597, 76);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Empresa:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(496, 401);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(113, 37);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // btnAlterarFun
            // 
            this.btnAlterarFun.Location = new System.Drawing.Point(258, 401);
            this.btnAlterarFun.Name = "btnAlterarFun";
            this.btnAlterarFun.Size = new System.Drawing.Size(113, 37);
            this.btnAlterarFun.TabIndex = 4;
            this.btnAlterarFun.Text = "Alterar";
            this.btnAlterarFun.UseVisualStyleBackColor = true;
            // 
            // btnCadastrarFun
            // 
            this.btnCadastrarFun.Location = new System.Drawing.Point(377, 401);
            this.btnCadastrarFun.Name = "btnCadastrarFun";
            this.btnCadastrarFun.Size = new System.Drawing.Size(113, 37);
            this.btnCadastrarFun.TabIndex = 5;
            this.btnCadastrarFun.Text = "Cadastrar Novo Funcionário";
            this.btnCadastrarFun.UseVisualStyleBackColor = true;
            this.btnCadastrarFun.Click += new System.EventHandler(this.btnCadastrarFun_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODFUNCIONARIODataGridViewTextBoxColumn,
            this.nOMEDataGridViewTextBoxColumn,
            this.cPFDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fUNCIONARIOStesteBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(585, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // pIMIIIDataSet
            // 
            this.pIMIIIDataSet.DataSetName = "PIMIIIDataSet";
            this.pIMIIIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fUNCIONARIOSBindingSource
            // 
            this.fUNCIONARIOSBindingSource.DataMember = "FUNCIONARIOS";
            this.fUNCIONARIOSBindingSource.DataSource = this.pIMIIIDataSet;
            // 
            // fUNCIONARIOSTableAdapter
            // 
            this.fUNCIONARIOSTableAdapter.ClearBeforeFill = true;
            // 
            // pIMIIIDataSet1
            // 
            this.pIMIIIDataSet1.DataSetName = "PIMIIIDataSet1";
            this.pIMIIIDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fUNCIONARIOStesteBindingSource
            // 
            this.fUNCIONARIOStesteBindingSource.DataMember = "FUNCIONARIOS_teste";
            this.fUNCIONARIOStesteBindingSource.DataSource = this.pIMIIIDataSet1;
            // 
            // fUNCIONARIOS_testeTableAdapter
            // 
            this.fUNCIONARIOS_testeTableAdapter.ClearBeforeFill = true;
            // 
            // cODFUNCIONARIODataGridViewTextBoxColumn
            // 
            this.cODFUNCIONARIODataGridViewTextBoxColumn.DataPropertyName = "COD_FUNCIONARIO";
            this.cODFUNCIONARIODataGridViewTextBoxColumn.HeaderText = "COD.";
            this.cODFUNCIONARIODataGridViewTextBoxColumn.Name = "cODFUNCIONARIODataGridViewTextBoxColumn";
            this.cODFUNCIONARIODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOMEDataGridViewTextBoxColumn
            // 
            this.nOMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nOMEDataGridViewTextBoxColumn.DataPropertyName = "NOME";
            this.nOMEDataGridViewTextBoxColumn.HeaderText = "NOME";
            this.nOMEDataGridViewTextBoxColumn.Name = "nOMEDataGridViewTextBoxColumn";
            // 
            // cPFDataGridViewTextBoxColumn
            // 
            this.cPFDataGridViewTextBoxColumn.DataPropertyName = "CPF";
            this.cPFDataGridViewTextBoxColumn.HeaderText = "CPF";
            this.cPFDataGridViewTextBoxColumn.Name = "cPFDataGridViewTextBoxColumn";
            // 
            // FormFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(621, 450);
            this.Controls.Add(this.btnCadastrarFun);
            this.Controls.Add(this.btnAlterarFun);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFuncionarios";
            this.Text = "FormFuncionarios";
            this.Load += new System.EventHandler(this.FormFuncionarios_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIMIIIDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIMIIIDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUNCIONARIOStesteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAlterarFun;
        private System.Windows.Forms.Button btnCadastrarFun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private PIMIIIDataSet pIMIIIDataSet;
        private System.Windows.Forms.BindingSource fUNCIONARIOSBindingSource;
        private PIMIIIDataSetTableAdapters.FUNCIONARIOSTableAdapter fUNCIONARIOSTableAdapter;
        private PIMIIIDataSet1 pIMIIIDataSet1;
        private System.Windows.Forms.BindingSource fUNCIONARIOStesteBindingSource;
        private PIMIIIDataSet1TableAdapters.FUNCIONARIOS_testeTableAdapter fUNCIONARIOS_testeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODFUNCIONARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPFDataGridViewTextBoxColumn;
    }
}