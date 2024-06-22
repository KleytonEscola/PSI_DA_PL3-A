namespace CantinaDA
{
    partial class FormReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReserva));
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.PanelReserva = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.TBxNomeCliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBxCodCliente = new System.Windows.Forms.TextBox();
            this.LblCodCliente = new System.Windows.Forms.Label();
            this.LblNomeCliente = new System.Windows.Forms.Label();
            this.BtnComeca = new System.Windows.Forms.Button();
            this.BtnProfessor = new System.Windows.Forms.Button();
            this.BtnAluno = new System.Windows.Forms.Button();
            this.datapicker = new System.Windows.Forms.DateTimePicker();
            this.LblTotal = new System.Windows.Forms.Label();
            this.BtnAjuda = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGerir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnVoltar
            // 
            this.BtnVoltar.BackColor = System.Drawing.Color.White;
            this.BtnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVoltar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVoltar.ForeColor = System.Drawing.Color.Black;
            this.BtnVoltar.Location = new System.Drawing.Point(702, 566);
            this.BtnVoltar.Name = "BtnVoltar";
            this.BtnVoltar.Size = new System.Drawing.Size(219, 27);
            this.BtnVoltar.TabIndex = 2;
            this.BtnVoltar.Text = "Voltar";
            this.BtnVoltar.UseVisualStyleBackColor = false;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // PanelReserva
            // 
            this.PanelReserva.AutoScroll = true;
            this.PanelReserva.BackColor = System.Drawing.Color.White;
            this.PanelReserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelReserva.Location = new System.Drawing.Point(468, 12);
            this.PanelReserva.Name = "PanelReserva";
            this.PanelReserva.Size = new System.Drawing.Size(450, 385);
            this.PanelReserva.TabIndex = 5;
            // 
            // PanelMenu
            // 
            this.PanelMenu.AutoScroll = true;
            this.PanelMenu.BackColor = System.Drawing.Color.White;
            this.PanelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMenu.Location = new System.Drawing.Point(12, 12);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(450, 385);
            this.PanelMenu.TabIndex = 3;
            // 
            // TBxNomeCliente
            // 
            this.TBxNomeCliente.BackColor = System.Drawing.Color.White;
            this.TBxNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBxNomeCliente.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.TBxNomeCliente.Location = new System.Drawing.Point(121, 0);
            this.TBxNomeCliente.Name = "TBxNomeCliente";
            this.TBxNomeCliente.Size = new System.Drawing.Size(327, 28);
            this.TBxNomeCliente.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TBxCodCliente);
            this.panel1.Controls.Add(this.LblCodCliente);
            this.panel1.Controls.Add(this.LblNomeCliente);
            this.panel1.Controls.Add(this.TBxNomeCliente);
            this.panel1.Location = new System.Drawing.Point(12, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 81);
            this.panel1.TabIndex = 4;
            // 
            // TBxCodCliente
            // 
            this.TBxCodCliente.BackColor = System.Drawing.Color.White;
            this.TBxCodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBxCodCliente.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.TBxCodCliente.Location = new System.Drawing.Point(121, 51);
            this.TBxCodCliente.Name = "TBxCodCliente";
            this.TBxCodCliente.Size = new System.Drawing.Size(327, 28);
            this.TBxCodCliente.TabIndex = 9;
            // 
            // LblCodCliente
            // 
            this.LblCodCliente.BackColor = System.Drawing.Color.White;
            this.LblCodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCodCliente.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.LblCodCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LblCodCliente.Location = new System.Drawing.Point(-1, 51);
            this.LblCodCliente.Name = "LblCodCliente";
            this.LblCodCliente.Size = new System.Drawing.Size(122, 28);
            this.LblCodCliente.TabIndex = 8;
            this.LblCodCliente.Text = "Email";
            this.LblCodCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNomeCliente
            // 
            this.LblNomeCliente.BackColor = System.Drawing.Color.White;
            this.LblNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNomeCliente.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.LblNomeCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LblNomeCliente.Location = new System.Drawing.Point(-1, 0);
            this.LblNomeCliente.Name = "LblNomeCliente";
            this.LblNomeCliente.Size = new System.Drawing.Size(122, 28);
            this.LblNomeCliente.TabIndex = 7;
            this.LblNomeCliente.Text = "Nome";
            this.LblNomeCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnComeca
            // 
            this.BtnComeca.BackColor = System.Drawing.Color.White;
            this.BtnComeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnComeca.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnComeca.ForeColor = System.Drawing.Color.Black;
            this.BtnComeca.Location = new System.Drawing.Point(468, 407);
            this.BtnComeca.Name = "BtnComeca";
            this.BtnComeca.Size = new System.Drawing.Size(228, 27);
            this.BtnComeca.TabIndex = 8;
            this.BtnComeca.Text = "Começar Reserva";
            this.BtnComeca.UseVisualStyleBackColor = false;
            this.BtnComeca.Click += new System.EventHandler(this.BtnComeca_Click);
            // 
            // BtnProfessor
            // 
            this.BtnProfessor.BackColor = System.Drawing.Color.White;
            this.BtnProfessor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProfessor.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProfessor.ForeColor = System.Drawing.Color.Black;
            this.BtnProfessor.Location = new System.Drawing.Point(15, 566);
            this.BtnProfessor.Name = "BtnProfessor";
            this.BtnProfessor.Size = new System.Drawing.Size(223, 27);
            this.BtnProfessor.TabIndex = 9;
            this.BtnProfessor.Text = "Professor";
            this.BtnProfessor.UseVisualStyleBackColor = false;
            this.BtnProfessor.Click += new System.EventHandler(this.BtnProfessor_Click);
            // 
            // BtnAluno
            // 
            this.BtnAluno.BackColor = System.Drawing.Color.White;
            this.BtnAluno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAluno.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAluno.ForeColor = System.Drawing.Color.Black;
            this.BtnAluno.Location = new System.Drawing.Point(241, 566);
            this.BtnAluno.Name = "BtnAluno";
            this.BtnAluno.Size = new System.Drawing.Size(223, 27);
            this.BtnAluno.TabIndex = 10;
            this.BtnAluno.Text = "Aluno";
            this.BtnAluno.UseVisualStyleBackColor = false;
            this.BtnAluno.Click += new System.EventHandler(this.BtnAluno_Click);
            // 
            // datapicker
            // 
            this.datapicker.Enabled = false;
            this.datapicker.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.datapicker.Location = new System.Drawing.Point(468, 566);
            this.datapicker.Name = "datapicker";
            this.datapicker.Size = new System.Drawing.Size(228, 28);
            this.datapicker.TabIndex = 11;
            // 
            // LblTotal
            // 
            this.LblTotal.BackColor = System.Drawing.Color.White;
            this.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTotal.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.LblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LblTotal.Location = new System.Drawing.Point(702, 406);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(216, 28);
            this.LblTotal.TabIndex = 10;
            this.LblTotal.Text = "Total :";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnAjuda
            // 
            this.BtnAjuda.BackColor = System.Drawing.Color.White;
            this.BtnAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAjuda.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAjuda.ForeColor = System.Drawing.Color.Black;
            this.BtnAjuda.Location = new System.Drawing.Point(702, 455);
            this.BtnAjuda.Name = "BtnAjuda";
            this.BtnAjuda.Size = new System.Drawing.Size(219, 28);
            this.BtnAjuda.TabIndex = 12;
            this.BtnAjuda.Text = "Ajuda ";
            this.BtnAjuda.UseVisualStyleBackColor = false;
            this.BtnAjuda.Click += new System.EventHandler(this.BtnAjuda_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.White;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.Red;
            this.BtnCancelar.Location = new System.Drawing.Point(467, 456);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(228, 27);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Visible = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGerir
            // 
            this.BtnGerir.BackColor = System.Drawing.Color.White;
            this.BtnGerir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGerir.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGerir.ForeColor = System.Drawing.Color.Black;
            this.BtnGerir.Location = new System.Drawing.Point(467, 532);
            this.BtnGerir.Name = "BtnGerir";
            this.BtnGerir.Size = new System.Drawing.Size(454, 28);
            this.BtnGerir.TabIndex = 14;
            this.BtnGerir.Text = "Gerir Reservas";
            this.BtnGerir.UseVisualStyleBackColor = false;
            this.BtnGerir.Click += new System.EventHandler(this.BtnGerir_Click);
            // 
            // FormReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(933, 605);
            this.Controls.Add(this.BtnGerir);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAjuda);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.datapicker);
            this.Controls.Add(this.BtnAluno);
            this.Controls.Add(this.BtnProfessor);
            this.Controls.Add(this.BtnComeca);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelReserva);
            this.Controls.Add(this.PanelMenu);
            this.Controls.Add(this.BtnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReserva";
            this.Load += new System.EventHandler(this.FormReserva_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.Panel PanelReserva;
        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.TextBox TBxNomeCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblNomeCliente;
        private System.Windows.Forms.Button BtnComeca;
        private System.Windows.Forms.Label LblCodCliente;
        private System.Windows.Forms.TextBox TBxCodCliente;
        private System.Windows.Forms.Button BtnProfessor;
        private System.Windows.Forms.Button BtnAluno;
        private System.Windows.Forms.DateTimePicker datapicker;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnAjuda;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGerir;
    }
}