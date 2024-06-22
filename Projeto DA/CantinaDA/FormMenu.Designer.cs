namespace CantinaDA
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.BtnMenuLeft = new System.Windows.Forms.Button();
            this.BtnMenuRight = new System.Windows.Forms.Button();
            this.datapicker = new System.Windows.Forms.DateTimePicker();
            this.PanelProdutos = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPratosVeg = new System.Windows.Forms.Button();
            this.BtnExtras = new System.Windows.Forms.Button();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.BtnPratoCarne = new System.Windows.Forms.Button();
            this.BtnPratosPeixe = new System.Windows.Forms.Button();
            this.BtnAjuda = new System.Windows.Forms.Button();
            this.PanelProdutos.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnVoltar
            // 
            this.BtnVoltar.BackColor = System.Drawing.Color.White;
            this.BtnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVoltar.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnVoltar.Location = new System.Drawing.Point(695, 447);
            this.BtnVoltar.Name = "BtnVoltar";
            this.BtnVoltar.Size = new System.Drawing.Size(222, 35);
            this.BtnVoltar.TabIndex = 0;
            this.BtnVoltar.Text = "Voltar";
            this.BtnVoltar.UseVisualStyleBackColor = false;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // BtnMenuLeft
            // 
            this.BtnMenuLeft.BackColor = System.Drawing.Color.White;
            this.BtnMenuLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMenuLeft.BackgroundImage")));
            this.BtnMenuLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMenuLeft.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnMenuLeft.ForeColor = System.Drawing.Color.DimGray;
            this.BtnMenuLeft.Location = new System.Drawing.Point(12, 403);
            this.BtnMenuLeft.Name = "BtnMenuLeft";
            this.BtnMenuLeft.Size = new System.Drawing.Size(40, 35);
            this.BtnMenuLeft.TabIndex = 2;
            this.BtnMenuLeft.UseVisualStyleBackColor = false;
            this.BtnMenuLeft.Click += new System.EventHandler(this.BtnMenuLeft_Click);
            // 
            // BtnMenuRight
            // 
            this.BtnMenuRight.BackColor = System.Drawing.Color.White;
            this.BtnMenuRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMenuRight.BackgroundImage")));
            this.BtnMenuRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMenuRight.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnMenuRight.ForeColor = System.Drawing.Color.DimGray;
            this.BtnMenuRight.Location = new System.Drawing.Point(422, 403);
            this.BtnMenuRight.Name = "BtnMenuRight";
            this.BtnMenuRight.Size = new System.Drawing.Size(40, 35);
            this.BtnMenuRight.TabIndex = 3;
            this.BtnMenuRight.UseVisualStyleBackColor = false;
            this.BtnMenuRight.Click += new System.EventHandler(this.BtnMenuRight_Click);
            // 
            // datapicker
            // 
            this.datapicker.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datapicker.Location = new System.Drawing.Point(58, 403);
            this.datapicker.Name = "datapicker";
            this.datapicker.Size = new System.Drawing.Size(358, 36);
            this.datapicker.TabIndex = 4;
            this.datapicker.ValueChanged += new System.EventHandler(this.datapicker_ValueChanged);
            // 
            // PanelProdutos
            // 
            this.PanelProdutos.BackColor = System.Drawing.Color.White;
            this.PanelProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelProdutos.Controls.Add(this.label3);
            this.PanelProdutos.Controls.Add(this.label2);
            this.PanelProdutos.Controls.Add(this.label1);
            this.PanelProdutos.Location = new System.Drawing.Point(468, 12);
            this.PanelProdutos.Name = "PanelProdutos";
            this.PanelProdutos.Size = new System.Drawing.Size(450, 385);
            this.PanelProdutos.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(325, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Preco";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPratosVeg
            // 
            this.BtnPratosVeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPratosVeg.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnPratosVeg.ForeColor = System.Drawing.Color.Black;
            this.BtnPratosVeg.Location = new System.Drawing.Point(13, 447);
            this.BtnPratosVeg.Name = "BtnPratosVeg";
            this.BtnPratosVeg.Size = new System.Drawing.Size(222, 35);
            this.BtnPratosVeg.TabIndex = 10;
            this.BtnPratosVeg.Text = "Pratos - Vegetariano";
            this.BtnPratosVeg.UseVisualStyleBackColor = true;
            this.BtnPratosVeg.Click += new System.EventHandler(this.BtnPratos_Click);
            // 
            // BtnExtras
            // 
            this.BtnExtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExtras.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnExtras.ForeColor = System.Drawing.Color.Black;
            this.BtnExtras.Location = new System.Drawing.Point(469, 403);
            this.BtnExtras.Name = "BtnExtras";
            this.BtnExtras.Size = new System.Drawing.Size(222, 35);
            this.BtnExtras.TabIndex = 11;
            this.BtnExtras.Text = "Extras";
            this.BtnExtras.UseVisualStyleBackColor = true;
            this.BtnExtras.Click += new System.EventHandler(this.BtnExtras_Click);
            // 
            // PanelMenu
            // 
            this.PanelMenu.AutoScroll = true;
            this.PanelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMenu.Location = new System.Drawing.Point(13, 12);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(450, 385);
            this.PanelMenu.TabIndex = 12;
            // 
            // BtnPratoCarne
            // 
            this.BtnPratoCarne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPratoCarne.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnPratoCarne.ForeColor = System.Drawing.Color.Black;
            this.BtnPratoCarne.Location = new System.Drawing.Point(241, 447);
            this.BtnPratoCarne.Name = "BtnPratoCarne";
            this.BtnPratoCarne.Size = new System.Drawing.Size(222, 35);
            this.BtnPratoCarne.TabIndex = 13;
            this.BtnPratoCarne.Text = "Pratos - Carne";
            this.BtnPratoCarne.UseVisualStyleBackColor = true;
            this.BtnPratoCarne.Click += new System.EventHandler(this.BtnPratoCarne_Click);
            // 
            // BtnPratosPeixe
            // 
            this.BtnPratosPeixe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPratosPeixe.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnPratosPeixe.ForeColor = System.Drawing.Color.Black;
            this.BtnPratosPeixe.Location = new System.Drawing.Point(469, 447);
            this.BtnPratosPeixe.Name = "BtnPratosPeixe";
            this.BtnPratosPeixe.Size = new System.Drawing.Size(222, 35);
            this.BtnPratosPeixe.TabIndex = 14;
            this.BtnPratosPeixe.Text = "Pratos - Peixe";
            this.BtnPratosPeixe.UseVisualStyleBackColor = true;
            this.BtnPratosPeixe.Click += new System.EventHandler(this.BtnPratosPeixe_Click);
            // 
            // BtnAjuda
            // 
            this.BtnAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAjuda.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.BtnAjuda.ForeColor = System.Drawing.Color.Black;
            this.BtnAjuda.Location = new System.Drawing.Point(696, 403);
            this.BtnAjuda.Name = "BtnAjuda";
            this.BtnAjuda.Size = new System.Drawing.Size(222, 35);
            this.BtnAjuda.TabIndex = 15;
            this.BtnAjuda.Text = "Ajuda";
            this.BtnAjuda.UseVisualStyleBackColor = true;
            this.BtnAjuda.Click += new System.EventHandler(this.BtnAjuda_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(930, 489);
            this.Controls.Add(this.BtnAjuda);
            this.Controls.Add(this.BtnPratosPeixe);
            this.Controls.Add(this.BtnPratoCarne);
            this.Controls.Add(this.PanelMenu);
            this.Controls.Add(this.BtnExtras);
            this.Controls.Add(this.BtnPratosVeg);
            this.Controls.Add(this.PanelProdutos);
            this.Controls.Add(this.datapicker);
            this.Controls.Add(this.BtnMenuRight);
            this.Controls.Add(this.BtnMenuLeft);
            this.Controls.Add(this.BtnVoltar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.PanelProdutos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.Button BtnMenuLeft;
        private System.Windows.Forms.Button BtnMenuRight;
        private System.Windows.Forms.DateTimePicker datapicker;
        private System.Windows.Forms.Panel PanelProdutos;
        private System.Windows.Forms.Button BtnPratosVeg;
        private System.Windows.Forms.Button BtnExtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Button BtnPratoCarne;
        private System.Windows.Forms.Button BtnPratosPeixe;
        private System.Windows.Forms.Button BtnAjuda;
    }
}