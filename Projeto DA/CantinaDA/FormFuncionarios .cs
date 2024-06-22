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
    public partial class FormFuncionarios : Form
    {
        int typeact;

        public FormFuncionarios()
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
            TBxNIF.Text = "";
            LBL_ID.Text = "";
            TBxNome.ReadOnly = true;
            TBxNIF.ReadOnly = true;

            int x, i;
            int altura = 35;

            MySqlConnection connectionsize = new MySqlConnection();
            connectionsize.ConnectionString = Global.connectionString;

            string querysize = "SELECT * FROM funcionario ORDER BY FuncionarioID DESC";

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
                    btnNome.Size = new System.Drawing.Size(325, 35);
                    btnNome.Click += new System.EventHandler(btnNome_Click);
                    btnNome.Tag = tablesize.Rows[i][0];
                    btnNome.Cursor = Cursors.Hand;
                    btnNome.Font = new Font("Modern No. 20", 14);
                    btnNome.BackColor = Color.White;
                    btnNome.TextAlign = ContentAlignment.MiddleLeft;
                    btnNome.FlatStyle = FlatStyle.Flat;
                    btnNome.FlatAppearance.BorderSize = 1;

                    System.Windows.Forms.Label LblNIF = new System.Windows.Forms.Label();
                    LblNIF.Text = tablesize.Rows[i][2].ToString();
                    LblNIF.Location = new System.Drawing.Point(325, altura);
                    LblNIF.Font = new Font("Modern No. 20", 14);
                    LblNIF.BackColor = Color.White;
                    LblNIF.AutoSize = false;
                    LblNIF.Size = new Size(273, 35);
                    LblNIF.TextAlign = ContentAlignment.MiddleLeft;
                    LblNIF.BorderStyle = BorderStyle.FixedSingle;


                    Panelitems.Controls.Add(LblNIF);
                    Panelitems.Controls.Add(btnNome);

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
                TBxNIF.Text = tableP.Rows[0][2].ToString();
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (BtnAdicionar.Text == "Adicionar")
            {
                BtnAdicionar.Text = "Cancelar";
                TBxNome.Text = "";
                TBxNIF.Text = "";
                LBL_ID.Text = "";
                TBxNome.ReadOnly = false;
                TBxNIF.ReadOnly = false;
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
                    else if(TBxNIF.Text == "")
                    {
                        MessageBox.Show("Erro, NIF invalido, preencha a caixa de texto");
                    }
                    else
                    {
                        string atv = "Nao";

                        MySqlCommand sqlins = new MySqlCommand("INSERT INTO funcionario (FuncionarioNome,FuncionarioNIF,FuncSelect) VALUES (@FuncionarioNome,@FuncionarioNIF,@FuncSelect)", connection);
                        sqlins.Parameters.AddWithValue("@FuncionarioNome", TBxNome.Text);
                        sqlins.Parameters.AddWithValue("@FuncionarioNIF", TBxNIF.Text);
                        sqlins.Parameters.AddWithValue("@FuncSelect", atv);

                        sqlins.ExecuteNonQuery();

                        MessageBox.Show("Fucionario inserido com sucesso !!!");
                        criafuncionario();
                        reload();
                    }
                    break;
                case 2:
                    if(LBL_ID.Text == "")
                    {
                        MessageBox.Show("Primeiro tem que escolher o funcionario que quer atualizar");
                    }
                    else
                    {                      

                        MySqlCommand update_command = new MySqlCommand("UPDATE Funcionario SET FuncionarioNome=@FuncionarioNome,FuncionarioNIF=@FuncionarioNIF WHERE FuncionarioID=@FuncionarioID", connection);
                        update_command.Parameters.Add("@FuncionarioID", MySqlDbType.Int32).Value = idartigo;
                        update_command.Parameters.Add("@FuncionarioNome", MySqlDbType.VarChar).Value = TBxNome.Text;
                        update_command.Parameters.Add("@FuncionarioNIF", MySqlDbType.VarChar).Value = TBxNIF.Text;
                        update_command.ExecuteNonQuery();

                        MessageBox.Show("Funcionario atualizado com sucesso !!!");
                        criafuncionario();
                        reload();
                    }
                    break;
                case 3:

                    if (LBL_ID.Text == "")
                    {
                        MessageBox.Show("Primeiro tem que escolher o funcionario que quer eliminar");
                    }
                    else
                    {                        
                        string query = "DELETE FROM funcionario WHERE FuncionarioID=@FuncionarioID";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@FuncionarioID", idartigo);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Funcionario eliminado com sucesso !!!");
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
            frm.clicafuncionario();
        }
    }
}
