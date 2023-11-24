namespace PIM_IV
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.btnGerenciarFuncionarios = new System.Windows.Forms.Button();
            this.btnRelatoriosGerais = new System.Windows.Forms.Button();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNotificacoes = new System.Windows.Forms.Button();
            this.btnGerenciarEmpresas = new System.Windows.Forms.Button();
            this.btnGerarFolha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nomeUsuario = new System.Windows.Forms.Label();
            this.panelHome = new System.Windows.Forms.Panel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerenciarFuncionarios
            // 
            this.btnGerenciarFuncionarios.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGerenciarFuncionarios.FlatAppearance.BorderSize = 0;
            this.btnGerenciarFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarFuncionarios.Font = new System.Drawing.Font("Quicksand Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarFuncionarios.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnGerenciarFuncionarios.Location = new System.Drawing.Point(0, 151);
            this.btnGerenciarFuncionarios.Name = "btnGerenciarFuncionarios";
            this.btnGerenciarFuncionarios.Size = new System.Drawing.Size(278, 63);
            this.btnGerenciarFuncionarios.TabIndex = 1;
            this.btnGerenciarFuncionarios.Text = "Gerenciar Funcionários";
            this.btnGerenciarFuncionarios.UseVisualStyleBackColor = false;
            this.btnGerenciarFuncionarios.Click += new System.EventHandler(this.btnGerenciarFuncionarios_Click);
            // 
            // btnRelatoriosGerais
            // 
            this.btnRelatoriosGerais.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRelatoriosGerais.FlatAppearance.BorderSize = 0;
            this.btnRelatoriosGerais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatoriosGerais.Font = new System.Drawing.Font("Quicksand Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatoriosGerais.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnRelatoriosGerais.Location = new System.Drawing.Point(0, 357);
            this.btnRelatoriosGerais.Name = "btnRelatoriosGerais";
            this.btnRelatoriosGerais.Size = new System.Drawing.Size(278, 63);
            this.btnRelatoriosGerais.TabIndex = 4;
            this.btnRelatoriosGerais.Text = "Relatórios Gerais";
            this.btnRelatoriosGerais.UseVisualStyleBackColor = false;
            this.btnRelatoriosGerais.Visible = false;
            this.btnRelatoriosGerais.Click += new System.EventHandler(this.btnRelatoriosGerais_Click);
            // 
            // btnAjuda
            // 
            this.btnAjuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAjuda.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAjuda.FlatAppearance.BorderSize = 0;
            this.btnAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAjuda.Font = new System.Drawing.Font("Quicksand Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjuda.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnAjuda.Location = new System.Drawing.Point(12, 582);
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(81, 41);
            this.btnAjuda.TabIndex = 5;
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.UseVisualStyleBackColor = false;
            this.btnAjuda.Visible = false;
            this.btnAjuda.Click += new System.EventHandler(this.btnAjuda_Click);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSair.BackColor = System.Drawing.Color.Red;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnSair.Location = new System.Drawing.Point(6, 19);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(266, 69);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.btnNotificacoes);
            this.groupBox1.Controls.Add(this.btnGerenciarEmpresas);
            this.groupBox1.Controls.Add(this.btnGerarFolha);
            this.groupBox1.Controls.Add(this.btnGerenciarFuncionarios);
            this.groupBox1.Controls.Add(this.btnRelatoriosGerais);
            this.groupBox1.Location = new System.Drawing.Point(0, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 495);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnNotificacoes
            // 
            this.btnNotificacoes.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNotificacoes.FlatAppearance.BorderSize = 0;
            this.btnNotificacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotificacoes.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotificacoes.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnNotificacoes.Location = new System.Drawing.Point(0, 426);
            this.btnNotificacoes.Name = "btnNotificacoes";
            this.btnNotificacoes.Size = new System.Drawing.Size(278, 63);
            this.btnNotificacoes.TabIndex = 11;
            this.btnNotificacoes.Text = "Notificações";
            this.btnNotificacoes.UseVisualStyleBackColor = false;
            this.btnNotificacoes.Visible = false;
            // 
            // btnGerenciarEmpresas
            // 
            this.btnGerenciarEmpresas.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGerenciarEmpresas.FlatAppearance.BorderSize = 0;
            this.btnGerenciarEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarEmpresas.Font = new System.Drawing.Font("Quicksand Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarEmpresas.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnGerenciarEmpresas.Location = new System.Drawing.Point(0, 253);
            this.btnGerenciarEmpresas.Name = "btnGerenciarEmpresas";
            this.btnGerenciarEmpresas.Size = new System.Drawing.Size(278, 63);
            this.btnGerenciarEmpresas.TabIndex = 10;
            this.btnGerenciarEmpresas.Text = "Gerenciar Empresas";
            this.btnGerenciarEmpresas.UseVisualStyleBackColor = false;
            this.btnGerenciarEmpresas.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGerarFolha
            // 
            this.btnGerarFolha.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGerarFolha.FlatAppearance.BorderSize = 0;
            this.btnGerarFolha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarFolha.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarFolha.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnGerarFolha.Location = new System.Drawing.Point(0, 53);
            this.btnGerarFolha.Name = "btnGerarFolha";
            this.btnGerarFolha.Size = new System.Drawing.Size(278, 63);
            this.btnGerarFolha.TabIndex = 0;
            this.btnGerarFolha.Text = "Gerar Folha de Pagamentos";
            this.btnGerarFolha.UseVisualStyleBackColor = false;
            this.btnGerarFolha.Click += new System.EventHandler(this.btnGerarFolha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuário:";
            // 
            // nomeUsuario
            // 
            this.nomeUsuario.AutoSize = true;
            this.nomeUsuario.Font = new System.Drawing.Font("Quicksand Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeUsuario.Location = new System.Drawing.Point(113, 28);
            this.nomeUsuario.Name = "nomeUsuario";
            this.nomeUsuario.Size = new System.Drawing.Size(72, 24);
            this.nomeUsuario.TabIndex = 8;
            this.nomeUsuario.Text = "NONE";
            // 
            // panelHome
            // 
            this.panelHome.Controls.Add(this.pictureLogo);
            this.panelHome.Location = new System.Drawing.Point(278, 0);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(1072, 729);
            this.panelHome.TabIndex = 9;
            this.panelHome.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHome_Paint);
            // 
            // pictureLogo
            // 
            this.pictureLogo.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureLogo.Image = global::PIM_IV.Properties.Resources.logo;
            this.pictureLogo.InitialImage = global::PIM_IV.Properties.Resources.PHOTO_2023_04_26_19_33_45;
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(1072, 729);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSair);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 629);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnAjuda);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.nomeUsuario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.groupBox1.ResumeLayout(false);
            this.panelHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGerenciarFuncionarios;
        private System.Windows.Forms.Button btnRelatoriosGerais;
        private System.Windows.Forms.Button btnAjuda;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nomeUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Button btnGerenciarEmpresas;
        private System.Windows.Forms.Button btnNotificacoes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGerarFolha;
    }
}