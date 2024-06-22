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
    public partial class FormMulta : Form
    {
        int typeact;

        public FormMulta()
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
            criafuncionario();
        }

        void criafuncionario()
        {
            TBxNome.Text = "";
            TBxHora.Text = "";
            LBL_ID.Text = "";
            TBxNome.ReadOnly = true;
            TBxHora.ReadOnly = true;
            TBxPreco.ReadOnly = true;

            int x, i;
            int altura = 35;

            MySqlConnection connectionsize = new MySqlConnection();
            connectionsize.ConnectionString = Global.connectionString;

            string querysize = "SELECT * FROM multa ORDER BY MultaID DESC";

            MySqlCommand search_commandsize = new MySqlCommand(querysize, connectionsize);

            MySqlDataAdapter adaptersize = new MySqlDataAdapter(search_commandsize);
            DataTable tablesize = new DataTable();

            adaptersize.Fill(tablesize);

            x = tablesize.Rows.Count;

            if (x > 0)
            {
                for (i = 0; i < x; i++)
                { 

                    System.Windows.Forms.Button btnNome = new System.Windows.Forms.Button();
                    btnNome.Text = tablesize.Rows[i][1].ToString();
                    btnNome.Location = new System.Drawing.Point(0, altura);
                    btnNome.Size = new System.Drawing.Size(300, 35);
                    btnNome.Click += new System.EventHandler(btnNome_Click);
                    btnNome.Tag = tablesize.Rows[i][0];
                    btnNome.Cursor = Cursors.Hand;
                    btnNome.Font = new Font("Modern No. 20", 14);
                    btnNome.BackColor = Color.White;
                    btnNome.TextAlign = ContentAlignment.MiddleLeft;
                    btnNome.FlatStyle = FlatStyle.Flat;
                    btnNome.FlatAppearance.BorderSize = 1;

                    System.Windows.Forms.Label LblHora = new System.Windows.Forms.Label();
                    LblHora.Text = tablesize.Rows[i][2].ToString();
                    LblHora.Location = new System.Drawing.Point(300, altura);
                    LblHora.Font = new Font("Modern No. 20", 14);
                    LblHora.BackColor = Color.White;
                    LblHora.AutoSize = false;
                    LblHora.Size = new Size(300, 35);
                    LblHora.TextAlign = ContentAlignment.MiddleLeft;
                    LblHora.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                    LblPreco.Text = tablesize.Rows[i][3].ToString();
                    LblPreco.Location = new System.Drawing.Point(450, altura);
                    LblPreco.Font = new Font("Modern No. 20", 14);
                    LblPreco.BackColor = Color.White;
                    LblPreco.AutoSize = false;
                    LblPreco.Size = new Size(150, 35);
                    LblPreco.TextAlign = ContentAlignment.MiddleLeft;
                    LblPreco.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Button btnitems = new System.Windows.Forms.Button();
                    btnitems.Text = "Ver Items";
                    btnitems.Location = new System.Drawing.Point(600, altura);
                    btnitems.Size = new System.Drawing.Size(150, 35);
                    btnitems.Click += new System.EventHandler(btnitem_Click);
                    btnitems.Tag = tablesize.Rows[i][0];
                    btnitems.Cursor = Cursors.Hand;
                    btnitems.Font = new Font("Modern No. 20", 14);
                    btnitems.BackColor = Color.White;
                    btnitems.TextAlign = ContentAlignment.MiddleLeft;
                    btnitems.FlatStyle = FlatStyle.Flat;
                    btnitems.FlatAppearance.BorderSize = 1;

                    Panelitems.Controls.Add(LblPreco);
                    Panelitems.Controls.Add(LblHora);
                    Panelitems.Controls.Add(btnNome);
                    Panelitems.Controls.Add(btnitems);

                    altura += 35;
                }

            }


        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            int Nometag;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            Nometag = Int32.Parse(converte);

            MySqlConnection connectionP = new MySqlConnection();
            connectionP.ConnectionString = Global.connectionString;

            string queryP = "SELECT * FROM funcionario WHERE FuncionarioID=@FuncionarioID";

            MySqlCommand search_commandP = new MySqlCommand(queryP, connectionP);

            search_commandP.Parameters.AddWithValue("FuncionarioID", Nometag);

            MySqlDataAdapter adapterP = new MySqlDataAdapter(search_commandP);
            DataTable tableP = new DataTable();

            adapterP.Fill(tableP);

            if (tableP.Rows.Count > 0)
            {
                LBL_ID.Text = tableP.Rows[0][0].ToString();
                TBxNome.Text = tableP.Rows[0][1].ToString();
                TBxHora.Text = tableP.Rows[0][2].ToString();
                TBxPreco.Text = tableP.Rows[0][3].ToString();
            }
        }

        private void btnitem_Click(object sender, EventArgs e)
        {
            string itemtag;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            itemtag = btn.Tag.ToString();

            Global.multaid = itemtag;
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (BtnAdicionar.Text == "Adicionar")
            {
                BtnAdicionar.Text = "Cancelar";
                TBxNome.Text = "";
                TBxHora.Text = "";
                LBL_ID.Text = "";
                TBxNome.ReadOnly = false;
                TBxHora.ReadOnly = false;
                TBxPreco.ReadOnly = false;
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
                TBxHora.ReadOnly = false;
                TBxPreco.ReadOnly = false;
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
                TBxHora.ReadOnly = false;
                TBxPreco.ReadOnly = false;
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

            int idartigo = 0;

            if(LBL_ID.Text != "")
            {
                idartigo = Int32.Parse(LBL_ID.Text);
            }

            switch (typeact)
            {
                case 1:
                    if(TBxNome.Text == "")
                    {
                        MessageBox.Show("Erro, Nome vazio, preencha a caixa de texto");
                    }
                    else if(TBxHora.Text == "")
                    {
                        MessageBox.Show("Erro, Hora invalida, preencha a caixa de texto");
                    }
                    else if (TBxPreco.Text == "")
                    {
                        MessageBox.Show("Erro, Preco invalido, preencha a caixa de texto");
                    }
                    else
                    {
                        string itms = "-";
                        

                        MySqlCommand sqlins = new MySqlCommand("INSERT INTO multa (MultaNome,MultaHora,MultaPreco,MultaItems) VALUES (@MultaNome,@MultaHora,@MultaPreco,@MultaItems)", connection);
                        sqlins.Parameters.AddWithValue("@MultaNome", TBxNome.Text);
                        sqlins.Parameters.AddWithValue("@MultaHora", TBxHora.Text);
                        sqlins.Parameters.AddWithValue("@MultaPreco", TBxPreco.Text);
                        sqlins.Parameters.AddWithValue("@MultaItems", itms);

                        sqlins.ExecuteNonQuery();

                        MessageBox.Show("multa inserida com sucesso !!!");
                        criafuncionario();
                        reload();
                    }
                    break;
                case 2:
                    if(LBL_ID.Text == "")
                    {
                        MessageBox.Show("Primeiro tem que escolher a multa que quer atualizar");
                    }
                    else
                    {                      

                        MySqlCommand update_command = new MySqlCommand("UPDATE multa SET MultaNome=@MultaNome,MultaHora=@MultaHora WHERE MultaID=@MultaID", connection);
                        update_command.Parameters.Add("@MultaID", MySqlDbType.Int32).Value = idartigo;
                        update_command.Parameters.Add("@MultaNome", MySqlDbType.VarChar).Value = TBxNome.Text;
                        update_command.Parameters.Add("@MultaHora", MySqlDbType.VarChar).Value = TBxHora.Text;
                        update_command.ExecuteNonQuery();

                        MessageBox.Show("Multa atualizada com sucesso !!!");
                        criafuncionario();
                        reload();
                    }
                    break;
                case 3:

                    if (LBL_ID.Text == "")
                    {
                        MessageBox.Show("Primeiro tem que escolher a multa que quer eliminar");
                    }
                    else
                    {                        
                        string query = "DELETE FROM multa WHERE MultaID=@MultaID";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@MultaID", idartigo);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Multa eliminada com sucesso !!!");
                        criafuncionario();
                        reload();
                    }
                    break;
            }
        }

        public void reload()
        {            
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            this.Hide();
            frm.clicamulta();
        }
    }
}
