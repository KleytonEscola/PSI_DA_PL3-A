﻿namespace CantinaDA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFuncionarios));
            this.Panelitems = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBL_ID = new System.Windows.Forms.Label();
            this.BtnConfirma = new System.Windows.Forms.Button();
            this.TBxNIF = new System.Windows.Forms.TextBox();
            this.TBxNome = new System.Windows.Forms.TextBox();
            this.BtnElimina = new System.Windows.Forms.Button();
            this.BtnAtualiza = new System.Windows.Forms.Button();
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.BtnAdicionar = new System.Windows.Forms.Button();
            this.LBLNIF = new System.Windows.Forms.Label();
            this.LBLNome = new System.Windows.Forms.Label();
            this.Panelitems.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panelitems
            // 
            this.Panelitems.AutoScroll = true;
            this.Panelitems.BackColor = System.Drawing.Color.LightGray;
            this.Panelitems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panelitems.Controls.Add(this.label4);
            this.Panelitems.Controls.Add(this.label5);
            this.Panelitems.Location = new System.Drawing.Point(12, 12);
            this.Panelitems.Name = "Panelitems";
            this.Panelitems.Size = new System.Drawing.Size(600, 433);
            this.Panelitems.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nome";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label5.Location = new System.Drawing.Point(325, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 35);
            this.label5.TabIndex = 3;
            this.label5.Text = "NIF";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LBL_ID);
            this.panel1.Controls.Add(this.BtnConfirma);
            this.panel1.Controls.Add(this.TBxNIF);
            this.panel1.Controls.Add(this.TBxNome);
            this.panel1.Controls.Add(this.BtnElimina);
            this.panel1.Controls.Add(this.BtnAtualiza);
            this.panel1.Controls.Add(this.BtnVoltar);
            this.panel1.Controls.Add(this.BtnAdicionar);
            this.panel1.Controls.Add(this.LBLNIF);
            this.panel1.Controls.Add(this.LBLNome);
            this.panel1.Location = new System.Drawing.Point(13, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 144);
            this.panel1.TabIndex = 1;
            // 
            // LBL_ID
            // 
            this.LBL_ID.AutoSize = true;
            this.LBL_ID.Location = new System.Drawing.Point(334, 61);
            this.LBL_ID.Name = "LBL_ID";
            this.LBL_ID.Size = new System.Drawing.Size(77, 13);
            this.LBL_ID.TabIndex = 13;
            this.LBL_ID.Text = "ID (Escondido)";
            this.LBL_ID.Visible = false;
            // 
            // BtnConfirma
            // 
            this.BtnConfirma.BackColor = System.Drawing.Color.Transparent;
            this.BtnConfirma.FlatAppearance.BorderSize = 0;
            this.BtnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirma.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirma.ForeColor = System.Drawing.Color.Red;
            this.BtnConfirma.Location = new System.Drawing.Point(449, 44);
            this.BtnConfirma.Name = "BtnConfirma";
            this.BtnConfirma.Size = new System.Drawing.Size(100, 40);
            this.BtnConfirma.TabIndex = 10;
            this.BtnConfirma.Text = "Confirmar";
            this.BtnConfirma.UseVisualStyleBackColor = false;
            this.BtnConfirma.Visible = false;
            this.BtnConfirma.Click += new System.EventHandler(this.BtnConfirma_Click);
            // 
            // TBxNIF
            // 
            this.TBxNIF.Font = new System.Drawing.Font("Modern No. 20", 12F);
            this.TBxNIF.Location = new System.Drawing.Point(101, 59);
            this.TBxNIF.Name = "TBxNIF";
            this.TBxNIF.ReadOnly = true;
            this.TBxNIF.Size = new System.Drawing.Size(208, 25);
            this.TBxNIF.TabIndex = 8;
            // 
            // TBxNome
            // 
            this.TBxNome.Font = new System.Drawing.Font("Modern No. 20", 12F);
            this.TBxNome.Location = new System.Drawing.Point(101, 10);
            this.TBxNome.Name = "TBxNome";
            this.TBxNome.ReadOnly = true;
            this.TBxNome.Size = new System.Drawing.Size(208, 25);
            this.TBxNome.TabIndex = 7;
            // 
            // BtnElimina
            // 
            this.BtnElimina.BackColor = System.Drawing.Color.Transparent;
            this.BtnElimina.FlatAppearance.BorderSize = 0;
            this.BtnElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnElimina.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElimina.ForeColor = System.Drawing.Color.White;
            this.BtnElimina.Location = new System.Drawing.Point(499, 90);
            this.BtnElimina.Name = "BtnElimina";
            this.BtnElimina.Size = new System.Drawing.Size(100, 40);
            this.BtnElimina.TabIndex = 6;
            this.BtnElimina.Text = "Eliminar";
            this.BtnElimina.UseVisualStyleBackColor = false;
            this.BtnElimina.Click += new System.EventHandler(this.BtnElimina_Click);
            // 
            // BtnAtualiza
            // 
            this.BtnAtualiza.BackColor = System.Drawing.Color.Transparent;
            this.BtnAtualiza.FlatAppearance.BorderSize = 0;
            this.BtnAtualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAtualiza.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAtualiza.ForeColor = System.Drawing.Color.White;
            this.BtnAtualiza.Location = new System.Drawing.Point(399, 0);
            this.BtnAtualiza.Name = "BtnAtualiza";
            this.BtnAtualiza.Size = new System.Drawing.Size(100, 40);
            this.BtnAtualiza.TabIndex = 5;
            this.BtnAtualiza.Text = "Atualizar";
            this.BtnAtualiza.UseVisualStyleBackColor = false;
            this.BtnAtualiza.Click += new System.EventHandler(this.BtnAtualiza_Click);
            // 
            // BtnVoltar
            // 
            this.BtnVoltar.BackColor = System.Drawing.Color.Transparent;
            this.BtnVoltar.FlatAppearance.BorderSize = 0;
            this.BtnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVoltar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVoltar.ForeColor = System.Drawing.Color.White;
            this.BtnVoltar.Location = new System.Drawing.Point(499, 0);
            this.BtnVoltar.Name = "BtnVoltar";
            this.BtnVoltar.Size = new System.Drawing.Size(100, 40);
            this.BtnVoltar.TabIndex = 4;
            this.BtnVoltar.Text = "Voltar";
            this.BtnVoltar.UseVisualStyleBackColor = false;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // BtnAdicionar
            // 
            this.BtnAdicionar.BackColor = System.Drawing.Color.Transparent;
            this.BtnAdicionar.FlatAppearance.BorderSize = 0;
            this.BtnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdicionar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdicionar.ForeColor = System.Drawing.Color.White;
            this.BtnAdicionar.Location = new System.Drawing.Point(399, 90);
            this.BtnAdicionar.Name = "BtnAdicionar";
            this.BtnAdicionar.Size = new System.Drawing.Size(100, 40);
            this.BtnAdicionar.TabIndex = 3;
            this.BtnAdicionar.Text = "Adicionar";
            this.BtnAdicionar.UseVisualStyleBackColor = false;
            this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // LBLNIF
            // 
            this.LBLNIF.AutoSize = true;
            this.LBLNIF.Font = new System.Drawing.Font("Modern No. 20", 12F);
            this.LBLNIF.ForeColor = System.Drawing.Color.White;
            this.LBLNIF.Location = new System.Drawing.Point(14, 62);
            this.LBLNIF.Name = "LBLNIF";
            this.LBLNIF.Size = new System.Drawing.Size(36, 18);
            this.LBLNIF.TabIndex = 1;
            this.LBLNIF.Text = "NIF";
            // 
            // LBLNome
            // 
            this.LBLNome.AutoSize = true;
            this.LBLNome.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLNome.ForeColor = System.Drawing.Color.White;
            this.LBLNome.Location = new System.Drawing.Point(14, 13);
            this.LBLNome.Name = "LBLNome";
            this.LBLNome.Size = new System.Drawing.Size(44, 18);
            this.LBLNome.TabIndex = 0;
            this.LBLNome.Text = "Nome";
            // 
            // FormFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(624, 605);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panelitems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFuncionarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.Load += new System.EventHandler(this.FormPratos_Load);
            this.Panelitems.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panelitems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAdicionar;
        private System.Windows.Forms.Label LBLNIF;
        private System.Windows.Forms.Label LBLNome;
        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.Button BtnElimina;
        private System.Windows.Forms.Button BtnAtualiza;
        private System.Windows.Forms.TextBox TBxNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBxNIF;
        private System.Windows.Forms.Button BtnConfirma;
        private System.Windows.Forms.Label LBL_ID;
    }
}