namespace PIM_IV.view
{
    partial class FormCRUDCargos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCRUDCargos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cargosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmpresas = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.byEmpresasToolStrip = new System.Windows.Forms.ToolStrip();
            this.codEmpresaToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.codEmpresaToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.byEmpresasToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargosBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.byEmpresasToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.cargosBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 257);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cargosBindingSource
            // 
            this.cargosBindingSource.DataMember = "Cargos";
            this.cargosBindingSource.CurrentChanged += new System.EventHandler(this.cargosBindingSource_CurrentChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnCadastrar);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Font = new System.Drawing.Font("Quicksand Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 560);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmpresas);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Location = new System.Drawing.Point(27, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar Empresas";
            // 
            // txtEmpresas
            // 
            this.txtEmpresas.Location = new System.Drawing.Point(6, 44);
            this.txtEmpresas.Name = "txtEmpresas";
            this.txtEmpresas.Size = new System.Drawing.Size(169, 26);
            this.txtEmpresas.TabIndex = 1;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(191, 38);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(107, 37);
            this.btnPesquisar.TabIndex = 0;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(482, 474);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(100, 47);
            this.btnAlterar.TabIndex = 3;
            this.btnAlterar.Text = "Alterar/\r\nExcluir\r\n";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(694, 474);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 47);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(588, 474);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(100, 47);
            this.btnCadastrar.TabIndex = 1;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // byEmpresasToolStrip
            // 
            this.byEmpresasToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codEmpresaToolStripLabel,
            this.codEmpresaToolStripTextBox,
            this.byEmpresasToolStripButton});
            this.byEmpresasToolStrip.Location = new System.Drawing.Point(0, 0);
            this.byEmpresasToolStrip.Name = "byEmpresasToolStrip";
            this.byEmpresasToolStrip.Size = new System.Drawing.Size(800, 25);
            this.byEmpresasToolStrip.TabIndex = 2;
            this.byEmpresasToolStrip.Text = "byEmpresasToolStrip";
            this.byEmpresasToolStrip.Visible = false;
            // 
            // codEmpresaToolStripLabel
            // 
            this.codEmpresaToolStripLabel.Name = "codEmpresaToolStripLabel";
            this.codEmpresaToolStripLabel.Size = new System.Drawing.Size(77, 22);
            this.codEmpresaToolStripLabel.Text = "CodEmpresa:";
            // 
            // codEmpresaToolStripTextBox
            // 
            this.codEmpresaToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.codEmpresaToolStripTextBox.Name = "codEmpresaToolStripTextBox";
            this.codEmpresaToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            this.codEmpresaToolStripTextBox.Click += new System.EventHandler(this.codEmpresaToolStripTextBox_Click);
            // 
            // byEmpresasToolStripButton
            // 
            this.byEmpresasToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.byEmpresasToolStripButton.Name = "byEmpresasToolStripButton";
            this.byEmpresasToolStripButton.Size = new System.Drawing.Size(74, 22);
            this.byEmpresasToolStripButton.Text = "ByEmpresas";
            this.byEmpresasToolStripButton.Click += new System.EventHandler(this.byEmpresasToolStripButton_Click);
            // 
            // FormCRUDCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.byEmpresasToolStrip);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCRUDCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos";
            this.Load += new System.EventHandler(this.FormCRUDCargos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargosBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.byEmpresasToolStrip.ResumeLayout(false);
            this.byEmpresasToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource cargosBindingSource;
        private System.Windows.Forms.ToolStrip byEmpresasToolStrip;
        private System.Windows.Forms.ToolStripLabel codEmpresaToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox codEmpresaToolStripTextBox;
        private System.Windows.Forms.ToolStripButton byEmpresasToolStripButton;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmpresas;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salariobaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoempresaDataGridViewTextBoxColumn;
    }
}