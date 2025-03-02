namespace Hotel
{
    partial class FrmCadastroUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroUser));
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridClient = new System.Windows.Forms.DataGridView();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.btnPromo = new System.Windows.Forms.Button();
            this.btnCola = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAlter = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridClient)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtSenha.Location = new System.Drawing.Point(150, 198);
            this.txtSenha.Multiline = true;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(310, 30);
            this.txtSenha.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(83, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Senha:";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.SystemColors.Window;
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtLogin.Location = new System.Drawing.Point(150, 151);
            this.txtLogin.Multiline = true;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(310, 30);
            this.txtLogin.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.label4.Location = new System.Drawing.Point(87, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Login:";
            // 
            // txtSenha2
            // 
            this.txtSenha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtSenha2.Location = new System.Drawing.Point(150, 245);
            this.txtSenha2.Multiline = true;
            this.txtSenha2.Name = "txtSenha2";
            this.txtSenha2.Size = new System.Drawing.Size(310, 30);
            this.txtSenha2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(55, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Confirmar:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(82)))), ((int)(((byte)(122)))));
            this.txtFind.Location = new System.Drawing.Point(89, 392);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(308, 30);
            this.txtFind.TabIndex = 14;
            this.txtFind.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.label3.Location = new System.Drawing.Point(22, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Buscar: ";
            // 
            // gridClient
            // 
            this.gridClient.AllowUserToAddRows = false;
            this.gridClient.AllowUserToDeleteRows = false;
            this.gridClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClient.Location = new System.Drawing.Point(26, 437);
            this.gridClient.Name = "gridClient";
            this.gridClient.ReadOnly = true;
            this.gridClient.Size = new System.Drawing.Size(371, 174);
            this.gridClient.TabIndex = 23;
            this.gridClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClient_CellClick);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnExcluir.CausesValidation = false;
            this.BtnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExcluir.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.BtnExcluir.Location = new System.Drawing.Point(430, 452);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(110, 42);
            this.BtnExcluir.TabIndex = 24;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // btnPromo
            // 
            this.btnPromo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPromo.CausesValidation = false;
            this.btnPromo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.btnPromo.Location = new System.Drawing.Point(430, 511);
            this.btnPromo.Name = "btnPromo";
            this.btnPromo.Size = new System.Drawing.Size(110, 42);
            this.btnPromo.TabIndex = 25;
            this.btnPromo.Text = "Supervisor";
            this.btnPromo.UseVisualStyleBackColor = true;
            this.btnPromo.Click += new System.EventHandler(this.btnPromo_Click);
            // 
            // btnCola
            // 
            this.btnCola.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCola.CausesValidation = false;
            this.btnCola.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCola.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCola.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.btnCola.Location = new System.Drawing.Point(430, 569);
            this.btnCola.Name = "btnCola";
            this.btnCola.Size = new System.Drawing.Size(110, 42);
            this.btnCola.TabIndex = 26;
            this.btnCola.Text = "Colaborador";
            this.btnCola.UseVisualStyleBackColor = true;
            this.btnCola.Click += new System.EventHandler(this.btnCola_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.btnCancel.Location = new System.Drawing.Point(168, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 42);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.CausesValidation = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.btnSave.Location = new System.Drawing.Point(344, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 42);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAlter
            // 
            this.btnAlter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlter.CausesValidation = false;
            this.btnAlter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.btnAlter.Location = new System.Drawing.Point(430, 392);
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Size = new System.Drawing.Size(110, 42);
            this.btnAlter.TabIndex = 29;
            this.btnAlter.Text = "Alterar";
            this.btnAlter.UseVisualStyleBackColor = true;
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.label6.Location = new System.Drawing.Point(206, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 23);
            this.label6.TabIndex = 31;
            this.label6.Text = "Cadastro de Usuário";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(23)))), ((int)(((byte)(93)))));
            this.label5.Location = new System.Drawing.Point(158, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(281, 58);
            this.label5.TabIndex = 30;
            this.label5.Text = "Host Hotel";
            // 
            // FrmCadastroUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(569, 630);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAlter);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCola);
            this.Controls.Add(this.btnPromo);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.gridClient);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSenha2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(585, 669);
            this.MinimumSize = new System.Drawing.Size(585, 669);
            this.Name = "FrmCadastroUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuários";
            this.Load += new System.EventHandler(this.FrmCadastroUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSenha2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridClient;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button btnPromo;
        private System.Windows.Forms.Button btnCola;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAlter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}