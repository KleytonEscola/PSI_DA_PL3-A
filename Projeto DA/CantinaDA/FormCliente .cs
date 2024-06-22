using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using MySqlX.XDevAPI.Relational;
using System.Security.Cryptography;

namespace CantinaDA
{
    public partial class FormCliente : Form
    {
        int typeact;

        public FormCliente()
        {
            InitializeComponent();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            this.Hide();
        }

        private void FormPratos_Load(object sender, EventArgs e)
        {
            if(Global.tipocliente == 1)
            {
                BtnProfessor.ForeColor = Color.Red;
                BtnEstudante.ForeColor = Color.White;
                Global.tipocliente = 1;
                criacliente();
            }
            else if(Global.tipocliente == 2)
            {
                BtnEstudante.ForeColor = Color.Red;
                BtnProfessor.ForeColor = Color.White;
                Global.tipocliente = 2;
                criacliente();
            }
        }

        void criacliente()
        {
            TBxNome.Text = "";
            TBxNIF.Text = "";
            TBxSaldo.Text = "";
            TBxExtra.Text = "";
            LBL_ID.Text = "";
            TBxNome.ReadOnly = true;
            TBxNIF.ReadOnly = true;
            TBxSaldo.ReadOnly = true;
            TBxExtra.ReadOnly = true;

            int x, i;
            int altura = 35;

            MySqlConnection connectionsize = new MySqlConnection();
            connectionsize.ConnectionString = Global.connectionString;

            string querysize = "SELECT * FROM clientes WHERE ClienteTipo=@ClienteTipo ORDER BY ClienteID DESC";


            MySqlCommand search_commandsize = new MySqlCommand(querysize, connectionsize);

            search_commandsize.Parameters.AddWithValue("@ClienteTipo", Global.tipocliente);

            MySqlDataAdapter adaptersize = new MySqlDataAdapter(search_commandsize);
            DataTable tablesize = new DataTable();

            adaptersize.Fill(tablesize);

            x = tablesize.Rows.Count;

            if (Global.tipocliente == 1)
            {
                LBLextra.Text = "Email";
                Lblextradesc.Text = "Email";
                if (x > 0)
                {
                    for (i = 0; i < x; i++)
                    {

                        System.Windows.Forms.Button btnnome = new System.Windows.Forms.Button();
                        btnnome.Text = tablesize.Rows[i][1].ToString();
                        btnnome.Location = new System.Drawing.Point(0, altura);
                        btnnome.Size = new System.Drawing.Size(275, 35);
                        btnnome.Click += new System.EventHandler(btnartigo_Click);
                        btnnome.Tag = tablesize.Rows[i][0];
                        btnnome.Cursor = Cursors.Hand;
                        btnnome.Font = new Font("Modern No. 20", 14);
                        btnnome.BackColor = Color.White;
                        btnnome.TextAlign = ContentAlignment.MiddleLeft;
                        btnnome.FlatStyle = FlatStyle.Flat;
                        btnnome.FlatAppearance.BorderSize = 1;

                        System.Windows.Forms.Label LblNIF = new System.Windows.Forms.Label();
                        LblNIF.Text = tablesize.Rows[i][2].ToString();
                        LblNIF.Location = new System.Drawing.Point(275, altura);
                        LblNIF.Font = new Font("Modern No. 20", 14);
                        LblNIF.BackColor = Color.White;
                        LblNIF.AutoSize = false;
                        LblNIF.Size = new Size(150, 35);
                        LblNIF.TextAlign = ContentAlignment.MiddleLeft;
                        LblNIF.BorderStyle = BorderStyle.FixedSingle;

                        System.Windows.Forms.Label LblSaldo = new System.Windows.Forms.Label();
                        LblSaldo.Text = tablesize.Rows[i][3].ToString();
                        LblSaldo.Location = new System.Drawing.Point(425, altura);
                        LblSaldo.Font = new Font("Modern No. 20", 14);
                        LblSaldo.BackColor = Color.White;
                        LblSaldo.AutoSize = false;
                        LblSaldo.Size = new Size(150, 35);
                        LblSaldo.TextAlign = ContentAlignment.MiddleLeft;
                        LblSaldo.BorderStyle = BorderStyle.FixedSingle;

                        System.Windows.Forms.Label Lbl_extra = new System.Windows.Forms.Label();
                        Lbl_extra.Text = tablesize.Rows[i][4].ToString();
                        Lbl_extra.Location = new System.Drawing.Point(575, altura);
                        Lbl_extra.Font = new Font("Modern No. 20", 14);
                        Lbl_extra.BackColor = Color.White;
                        Lbl_extra.AutoSize = false;
                        Lbl_extra.Size = new Size(199, 35);
                        Lbl_extra.TextAlign = ContentAlignment.MiddleLeft;
                        Lbl_extra.BorderStyle = BorderStyle.FixedSingle;

                        Panelitems.Controls.Add(LblSaldo);
                        Panelitems.Controls.Add(LblNIF);
                        Panelitems.Controls.Add(btnnome);
                        Panelitems.Controls.Add(Lbl_extra);

                        altura += 35;
                    }

                }
            }

            else if (Global.tipocliente == 2)
            {
                LBLextra.Text = "Numero";
                Lblextradesc.Text = "Numero";
                if (x > 0)
                {
                    for (i = 0; i < x; i++)
                    {

                        System.Windows.Forms.Button btnnome = new System.Windows.Forms.Button();
                        btnnome.Text = tablesize.Rows[i][1].ToString();
                        btnnome.Location = new System.Drawing.Point(0, altura);
                        btnnome.Size = new System.Drawing.Size(275, 35);
                        btnnome.Click += new System.EventHandler(btnartigo_Click);
                        btnnome.Tag = tablesize.Rows[i][0];
                        btnnome.Cursor = Cursors.Hand;
                        btnnome.Font = new Font("Modern No. 20", 14);
                        btnnome.BackColor = Color.White;
                        btnnome.TextAlign = ContentAlignment.MiddleLeft;
                        btnnome.FlatStyle = FlatStyle.Flat;
                        btnnome.FlatAppearance.BorderSize = 1;

                        System.Windows.Forms.Label LblNIF = new System.Windows.Forms.Label();
                        LblNIF.Text = tablesize.Rows[i][2].ToString();
                        LblNIF.Location = new System.Drawing.Point(275, altura);
                        LblNIF.Font = new Font("Modern No. 20", 14);
                        LblNIF.BackColor = Color.White;
                        LblNIF.AutoSize = false;
                        LblNIF.Size = new Size(150, 35);
                        LblNIF.TextAlign = ContentAlignment.MiddleLeft;
                        LblNIF.BorderStyle = BorderStyle.FixedSingle;

                        System.Windows.Forms.Label LblSaldo = new System.Windows.Forms.Label();
                        LblSaldo.Text = tablesize.Rows[i][3].ToString();
                        LblSaldo.Location = new System.Drawing.Point(425, altura);
                        LblSaldo.Font = new Font("Modern No. 20", 14);
                        LblSaldo.BackColor = Color.White;
                        LblSaldo.AutoSize = false;
                        LblSaldo.Size = new Size(150, 35);
                        LblSaldo.TextAlign = ContentAlignment.MiddleLeft;
                        LblSaldo.BorderStyle = BorderStyle.FixedSingle;

                        System.Windows.Forms.Label Lbl_extra = new System.Windows.Forms.Label();
                        Lbl_extra.Text = tablesize.Rows[i][5].ToString();
                        Lbl_extra.Location = new System.Drawing.Point(575, altura);
                        Lbl_extra.Font = new Font("Modern No. 20", 14);
                        Lbl_extra.BackColor = Color.White;
                        Lbl_extra.AutoSize = false;
                        Lbl_extra.Size = new Size(199, 35);
                        Lbl_extra.TextAlign = ContentAlignment.MiddleLeft;
                        Lbl_extra.BorderStyle = BorderStyle.FixedSingle;

                        Panelitems.Controls.Add(LblSaldo);
                        Panelitems.Controls.Add(LblNIF);
                        Panelitems.Controls.Add(btnnome);
                        Panelitems.Controls.Add(Lbl_extra);

                        altura += 35;
                    }

                }

            }
        }

        private void btnartigo_Click(object sender, EventArgs e)
        {
            int clientetag;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            clientetag = Int32.Parse(converte);

            MySqlConnection connectionP = new MySqlConnection();
            connectionP.ConnectionString = Global.connectionString;

            string queryP = "SELECT * FROM clientes WHERE ClienteID=@ClienteID";

            MySqlCommand search_commandP = new MySqlCommand(queryP, connectionP);

            search_commandP.Parameters.AddWithValue("@ClienteID", clientetag);

            MySqlDataAdapter adapterP = new MySqlDataAdapter(search_commandP);
            DataTable tableP = new DataTable();

            adapterP.Fill(tableP);

            if (tableP.Rows.Count > 0)
            {
                LBL_ID.Text = tableP.Rows[0][0].ToString();
                TBxNome.Text = tableP.Rows[0][1].ToString();
                TBxNIF.Text = tableP.Rows[0][2].ToString();
                TBxSaldo.Text = tableP.Rows[0][3].ToString();
                if (Global.tipocliente == 1)
                {
                    TBxExtra.Text = tableP.Rows[0][4].ToString();
                }
                else if(Global.tipocliente == 2)
                {
                    TBxExtra.Text = tableP.Rows[0][5].ToString();
                }
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (BtnAdicionar.Text == "Adicionar")
            {
                BtnAdicionar.Text = "Cancelar";
                TBxNome.Text = "";
                TBxNIF.Text = "";
                TBxSaldo.Text = "";
                TBxExtra.Text = "";
                LBL_ID.Text = "";
                TBxNome.ReadOnly = false;
                TBxNIF.ReadOnly = false;
                TBxSaldo.ReadOnly = false;
                TBxExtra.ReadOnly = false;
                typeact = 1;
                BtnConfirma.Visible = true;
                BtnAdicionar.ForeColor = Color.Red;
            }
            else
            {
                BtnAdicionar.Text = "Adicionar";
                typeact = 0;
                BtnConfirma.Visible = false;
                BtnAdicionar.ForeColor = Color.White;
            }
        }

        private void BtnAtualiza_Click(object sender, EventArgs e)
        {
            if (BtnAtualiza.Text == "Atualizar")
            {
                BtnAtualiza.Text = "Cancelar";
                TBxNome.ReadOnly = false;
                TBxNIF.ReadOnly = false;
                TBxSaldo.ReadOnly = false;
                TBxExtra.ReadOnly = false;
                typeact = 2;
                BtnConfirma.Visible = true;
                BtnAtualiza.ForeColor = Color.Red;
            }
            else
            {
                BtnAtualiza.Text = "Atualizar";
                typeact = 0;
                BtnConfirma.Visible = false;
                BtnAtualiza.ForeColor = Color.White;
            }
        }

        private void BtnElimina_Click(object sender, EventArgs e)
        {
            if (BtnElimina.Text == "Eliminar")
            {
                BtnElimina.Text = "Cancelar";
                TBxNome.ReadOnly = false;
                TBxNIF.ReadOnly = false;
                TBxSaldo.ReadOnly = false;
                TBxExtra.ReadOnly = false;
                typeact = 3;
                BtnConfirma.Visible = true;
                BtnElimina.ForeColor = Color.Red;
            }
            else
            {
                BtnElimina.Text = "Eliminar";
                typeact = 0;
                BtnConfirma.Visible = false;
                BtnElimina.ForeColor = Color.White;
            }
        }

        private void BtnConfirma_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            int idcliente = 0;

            if(LBL_ID.Text != "")
            {
                idcliente = Int32.Parse(LBL_ID.Text);
            }

            switch (typeact)
            {
                case 1:
                    if (Global.tipocliente == 1)
                    {
                        if (TBxNome.Text == "")
                        {
                            MessageBox.Show("Erro, Nome vazio, preencha a caixa de texto");
                        }
                        else if (TBxNIF.Text == "")
                        {
                            MessageBox.Show("Erro, NIF invalida, preencha a caixa de texto");
                        }
                        else if (TBxSaldo.Text == "")
                        {
                            MessageBox.Show("Erro, Saldo alido, preencha a caixa de texto");
                        }
                        else if (TBxExtra.Text == "")
                        {
                            MessageBox.Show("Erro, Email invalido, preencha a caixa de texto");
                        }
                        else
                        {

                            MySqlCommand sqlins = new MySqlCommand("INSERT INTO clientes (ClienteNome,ClienteNIF,ClienteSaldo,ClienteEmail,ClienteTipo) VALUES (@ClienteNome,@ClienteNIF,@ClienteSaldo,@ClienteEmail,@ClienteTipo)", connection);
                            sqlins.Parameters.AddWithValue("@ClienteNome", TBxNome.Text);
                            sqlins.Parameters.AddWithValue("@ClienteNIF", TBxNIF.Text);
                            sqlins.Parameters.AddWithValue("@ClienteSaldo", TBxSaldo.Text);
                            sqlins.Parameters.AddWithValue("@ClienteEmail", TBxExtra.Text);
                            sqlins.Parameters.AddWithValue("@ClienteTipo", Global.tipocliente);

                            sqlins.ExecuteNonQuery();

                            MessageBox.Show("Professor inserido com sucesso !!!");
                            criacliente();
                            reload();
                        }                        
                    }
                    else if (Global.tipocliente == 2)
                    {
                        if (TBxNome.Text == "")
                        {
                            MessageBox.Show("Erro, Nome vazio, preencha a caixa de texto");
                        }
                        else if (TBxNIF.Text == "")
                        {
                            MessageBox.Show("Erro, NIF invalida, preencha a caixa de texto");
                        }
                        else if (TBxSaldo.Text == "")
                        {
                            MessageBox.Show("Erro, Saldo invalido, preencha a caixa de texto");
                        }
                        else if (TBxExtra.Text == "")
                        {
                            MessageBox.Show("Erro, Numero invalido, preencha a caixa de texto");
                        }
                        else
                        {

                            MySqlCommand sqlins = new MySqlCommand("INSERT INTO clientes (ClienteNome,ClienteNIF,ClienteSaldo,ClienteNumEs,ClienteTipo) VALUES (@ClienteNome,@ClienteNIF,@ClienteSaldo,@ClienteNumEs,@ClienteTipo)", connection);
                            sqlins.Parameters.AddWithValue("@ClienteNome", TBxNome.Text);
                            sqlins.Parameters.AddWithValue("@ClienteNIF", TBxNIF.Text);
                            sqlins.Parameters.AddWithValue("@ClienteSaldo", TBxSaldo.Text);
                            sqlins.Parameters.AddWithValue("@ClienteNumEs", TBxExtra.Text);
                            sqlins.Parameters.AddWithValue("@ClienteTipo", Global.tipocliente);

                            sqlins.ExecuteNonQuery();

                            MessageBox.Show("Aluno inserido com sucesso !!!");
                            criacliente();
                            reload();
                        }
                    }
                    break;
                case 2:

                    if(LBL_ID.Text == "")
                    {
                        MessageBox.Show("Primeiro tem que escolher o cliente que quer atualizar");
                    }
                    else
                    {                      
                        if (Global.tipocliente == 1)
                        {
                            MySqlCommand update_command = new MySqlCommand("UPDATE clientes SET ClienteNome=@ClienteNome,ClienteNIF=@ClienteNIF,ClienteSaldo=@ClienteSaldo,ClienteEmail=@ClienteEmail,ClienteTipo=@ClienteTipo WHERE ClienteID=@ClienteID", connection);
                            update_command.Parameters.Add("@ClienteID", MySqlDbType.Int32).Value = idcliente;
                            update_command.Parameters.Add("@ClienteNome", MySqlDbType.VarChar).Value = TBxNome.Text;
                            update_command.Parameters.Add("@ClienteNIF", MySqlDbType.VarChar).Value = TBxNIF.Text;
                            update_command.Parameters.Add("@ClienteSaldo", MySqlDbType.VarChar).Value = TBxSaldo.Text;
                            update_command.Parameters.Add("@ClienteEmail", MySqlDbType.VarChar).Value = TBxExtra.Text;
                            update_command.Parameters.Add("@ClienteTipo", MySqlDbType.Int32).Value = Global.tipocliente;
                            update_command.ExecuteNonQuery();

                            MessageBox.Show("Professor atualizado com sucesso !!!");
                            criacliente();
                            reload();
                        }
                        else if (Global.tipocliente == 2)
                        {
                            MySqlCommand update_command = new MySqlCommand("UPDATE clientes SET ClienteNome=@ClienteNome,ClienteNIF=@ClienteNIF,ClienteSaldo=@ClienteSaldo,ClienteNumEs=@ClienteNumEs,ClienteTipo=@ClienteTipo WHERE ClienteID=@ClienteID", connection);
                            update_command.Parameters.Add("@ClienteID", MySqlDbType.Int32).Value = idcliente;
                            update_command.Parameters.Add("@ClienteNome", MySqlDbType.VarChar).Value = TBxNome.Text;
                            update_command.Parameters.Add("@ClienteNIF", MySqlDbType.VarChar).Value = TBxNIF.Text;
                            update_command.Parameters.Add("@ClienteSaldo", MySqlDbType.VarChar).Value = TBxSaldo.Text;
                            update_command.Parameters.Add("@ClienteNumEs", MySqlDbType.VarChar).Value = TBxExtra.Text;
                            update_command.Parameters.Add("@ClienteTipo", MySqlDbType.Int32).Value = Global.tipocliente;
                            update_command.ExecuteNonQuery();

                            MessageBox.Show("Estudante atualizado com sucesso !!!");
                            criacliente();
                            reload();
                        }

                    }
                    break;
                case 3:

                    if (LBL_ID.Text == "")
                    {
                        MessageBox.Show("Primeiro tem que escolher o prato que quer eliminar");
                    }
                    else
                    {                        
                        string query = "DELETE FROM clientes WHERE ClienteID=@ClienteID";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@ClienteID", idcliente);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente eliminado com sucesso !!!");
                        criacliente();
                        reload();
                    }
                    break;
            }
        }

        public void reload()
        {            
            FormPrincipal frmmm = new FormPrincipal();
            frmmm.Show();
            this.Hide();
            frmmm.clicacliente();
        }

        private void BtnProfessor_Click(object sender, EventArgs e)
        {
            BtnProfessor.ForeColor = Color.Red;
            BtnEstudante.ForeColor = Color.White;
            Global.tipocliente = 1;
            criacliente();
            reload();           
        }

        private void BtnEstudante_Click(object sender, EventArgs e)
        {

            BtnEstudante.ForeColor = Color.Red;
            BtnProfessor.ForeColor = Color.White;
            Global.tipocliente = 2;
            criacliente();
            reload();
        }
    }
}
