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
    public partial class FormPratos : Form
    {
        int typeact;

        public FormPratos()
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
            criapratos();
        }

        void criapratos()
        {
            TBxNome.Text = "";
            TBxQuantidade.Text = "";
            TBxPreco.Text = "";
            TBxDesc.Text = "";
            LBL_ID.Text = "";
            TBxNome.ReadOnly = true;
            TBxQuantidade.ReadOnly = true;
            TBxPreco.ReadOnly = true;
            TBxDesc.ReadOnly = true;
            RadNao.Enabled = false;
            RadSim.Enabled = false;
            RadVeg.Enabled = false;
            RadCarne.Enabled = false;
            RadPeixe.Enabled = false;

            int x, i;
            int altura = 35;

            MySqlConnection connectionsize = new MySqlConnection();
            connectionsize.ConnectionString = Global.connectionString;

            string querysize = "SELECT * FROM prato ORDER BY IDPrato DESC";

            MySqlCommand search_commandsize = new MySqlCommand(querysize, connectionsize);

            MySqlDataAdapter adaptersize = new MySqlDataAdapter(search_commandsize);
            DataTable tablesize = new DataTable();

            adaptersize.Fill(tablesize);

            x = tablesize.Rows.Count;

            if (x > 0)
            {
                for (i = 0; i < x; i++)
                { 

                    System.Windows.Forms.Button btnprato = new System.Windows.Forms.Button();
                    btnprato.Text = tablesize.Rows[i][1].ToString();
                    btnprato.Location = new System.Drawing.Point(0, altura);
                    btnprato.Size = new System.Drawing.Size(275, 35);
                    btnprato.Click += new System.EventHandler(btnartigo_Click);
                    btnprato.Tag = tablesize.Rows[i][0];
                    btnprato.Cursor = Cursors.Hand;
                    btnprato.Font = new Font("Modern No. 20", 14);
                    btnprato.BackColor = Color.White;
                    btnprato.TextAlign = ContentAlignment.MiddleLeft;
                    btnprato.FlatStyle = FlatStyle.Flat;
                    btnprato.FlatAppearance.BorderSize = 1;

                    System.Windows.Forms.Label LblQuantidade = new System.Windows.Forms.Label();
                    LblQuantidade.Text = tablesize.Rows[i][2].ToString();
                    LblQuantidade.Location = new System.Drawing.Point(275, altura);
                    LblQuantidade.Font = new Font("Modern No. 20", 14);
                    LblQuantidade.BackColor = Color.White;
                    LblQuantidade.AutoSize = false;
                    LblQuantidade.Size = new Size(150, 35);
                    LblQuantidade.TextAlign = ContentAlignment.MiddleLeft;
                    LblQuantidade.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                    LblPreco.Text = tablesize.Rows[i][3].ToString();
                    LblPreco.Location = new System.Drawing.Point(425, altura);
                    LblPreco.Font = new Font("Modern No. 20", 14);
                    LblPreco.BackColor = Color.White;
                    LblPreco.AutoSize = false;
                    LblPreco.Size = new Size(150, 35);
                    LblPreco.TextAlign = ContentAlignment.MiddleLeft;
                    LblPreco.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblAtivo = new System.Windows.Forms.Label();
                    LblAtivo.Text = tablesize.Rows[i][5].ToString();
                    LblAtivo.Location = new System.Drawing.Point(575, altura);
                    LblAtivo.Font = new Font("Modern No. 20", 14);
                    LblAtivo.BackColor = Color.White;
                    LblAtivo.AutoSize = false;
                    LblAtivo.Size = new Size(150, 35);
                    LblAtivo.TextAlign = ContentAlignment.MiddleLeft;
                    LblAtivo.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblTipo = new System.Windows.Forms.Label();
                    LblTipo.Text = tablesize.Rows[i][6].ToString();
                    LblTipo.Location = new System.Drawing.Point(725, altura);
                    LblTipo.Font = new Font("Modern No. 20", 14);
                    LblTipo.BackColor = Color.White;
                    LblTipo.AutoSize = false;
                    LblTipo.Size = new Size(148, 35);
                    LblTipo.TextAlign = ContentAlignment.MiddleLeft;
                    LblTipo.BorderStyle = BorderStyle.FixedSingle;

                    Panelitems.Controls.Add(LblPreco);
                    Panelitems.Controls.Add(LblQuantidade);
                    Panelitems.Controls.Add(btnprato);
                    Panelitems.Controls.Add(LblAtivo);
                    Panelitems.Controls.Add(LblTipo);

                    altura += 35;
                }

            }


        }

        private void btnartigo_Click(object sender, EventArgs e)
        {
            int artigotag;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            artigotag = Int32.Parse(converte);

            MySqlConnection connectionP = new MySqlConnection();
            connectionP.ConnectionString = Global.connectionString;

            string queryP = "SELECT * FROM prato WHERE IDPrato=@IDPrato";

            MySqlCommand search_commandP = new MySqlCommand(queryP, connectionP);

            search_commandP.Parameters.AddWithValue("IDPrato", artigotag);

            MySqlDataAdapter adapterP = new MySqlDataAdapter(search_commandP);
            DataTable tableP = new DataTable();

            adapterP.Fill(tableP);

            if (tableP.Rows.Count > 0)
            {
                LBL_ID.Text = tableP.Rows[0][0].ToString();
                TBxNome.Text = tableP.Rows[0][1].ToString();
                TBxQuantidade.Text = tableP.Rows[0][2].ToString();
                TBxPreco.Text = tableP.Rows[0][3].ToString();
                TBxDesc.Text = tableP.Rows[0][4].ToString();

                string ativotipo = "";

                ativotipo = tableP.Rows[0][5].ToString();

                if (ativotipo == "Sim")
                {
                    RadSim.Checked = true;
                }
                else if(ativotipo == "Nao")
                {
                    RadNao.Checked = true;
                }

                string pratotipo = "";

                pratotipo = tableP.Rows[0][6].ToString(); 

                if (pratotipo == "Vegetariano")
                {
                    RadVeg.Checked = true;
                }
                else if (pratotipo == "Carne")
                {
                    RadCarne.Checked = true;
                }
                else if (pratotipo == "Peixe")
                {
                    RadPeixe.Checked = true;
                }
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (BtnAdicionar.Text == "Adicionar")
            {
                BtnAdicionar.Text = "Cancelar";
                TBxNome.Text = "";
                TBxQuantidade.Text = "";
                TBxPreco.Text = "";
                TBxDesc.Text = "";
                LBL_ID.Text = "";
                TBxNome.ReadOnly = false;
                TBxQuantidade.ReadOnly = false;
                TBxPreco.ReadOnly = false;
                TBxDesc.ReadOnly = false;
                RadNao.Enabled = true;
                RadSim.Enabled = true;
                RadVeg.Enabled = true;
                RadCarne.Enabled = true;
                RadPeixe.Enabled = true;
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
                TBxQuantidade.ReadOnly = false;
                TBxPreco.ReadOnly = false;
                TBxDesc.ReadOnly = false;
                RadNao.Enabled = true;
                RadSim.Enabled = true;
                RadVeg.Enabled = true;
                RadCarne.Enabled = true;
                RadPeixe.Enabled = true;
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
                TBxQuantidade.ReadOnly = false;
                TBxPreco.ReadOnly = false;
                TBxDesc.ReadOnly = false;
                RadNao.Enabled = true;
                RadSim.Enabled = true;
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
            string desc = "-";

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
                    else if(TBxQuantidade.Text == "")
                    {
                        MessageBox.Show("Erro, Quantidade invalida, preencha a caixa de texto");
                    }
                    else if(TBxPreco.Text == "")
                    {
                        MessageBox.Show("Erro, Preco Invalido, preencha a caixa de texto");
                    }
                    else if(RadNao.Checked == false && RadSim.Checked == false)
                    {
                        MessageBox.Show("Erro, Selecione a ativadade do prato");
                    }
                    else if (RadCarne.Checked == false && RadVeg.Checked == false && RadPeixe.Checked == false)
                    {
                        MessageBox.Show("Erro, Selecione o tipo do prato");
                    }
                    else
                    {
                        if(TBxDesc.Text == "")
                        {
                            desc = "-";
                        }
                        else
                        {
                            desc = TBxDesc.Text;
                        }

                        string check = "";                      

                        if (RadSim.Checked == true)
                        {
                            check = "Sim";
                        }
                        else if (RadNao.Checked == true)
                        {
                            check = "Nao";
                        }

                        string pratotipo = "";

                        if (RadVeg.Checked == true)
                        {
                            pratotipo = "Vegetariano";
                        }
                        else if (RadCarne.Checked == true)
                        {
                            pratotipo = "Carne";
                        }
                        else if (RadPeixe.Checked == true)
                        {
                            pratotipo = "Peixe";
                        }

                        MySqlCommand sqlins = new MySqlCommand("INSERT INTO prato (NomePrato,QuanPrato,PrecoPrato,DescPrato,AtivoPrato,TipoPrato) VALUES (@NomePrato,@QuanPrato,@PrecoPrato,@DescPrato,@AtivoPrato,@TipoPrato)", connection);
                        sqlins.Parameters.AddWithValue("@NomePrato", TBxNome.Text);
                        sqlins.Parameters.AddWithValue("@QuanPrato", TBxQuantidade.Text);
                        sqlins.Parameters.AddWithValue("@PrecoPrato", TBxPreco.Text);
                        sqlins.Parameters.AddWithValue("@DescPrato", desc);
                        sqlins.Parameters.AddWithValue("@AtivoPrato", check);
                        sqlins.Parameters.AddWithValue("@TipoPrato", pratotipo);

                        sqlins.ExecuteNonQuery();

                        MessageBox.Show("Artigo inserido com sucesso !!!");
                        criapratos();
                        reload();
                    }
                    break;
                case 2:
                    if(LBL_ID.Text == "")
                    {
                        MessageBox.Show("Primeiro tem que escolher o prato que quer atualizar");
                    }
                    else
                    {
                        if (RadNao.Checked == false && RadSim.Checked == false)
                        {
                            MessageBox.Show("Erro, Selecione a ativadade do prato");
                        }
                        else
                        {
                            if (TBxDesc.Text == "")
                            {
                                desc = "-";
                            }
                            else
                            {
                                desc = TBxDesc.Text;
                            }

                            string check = "";

                            if (RadSim.Checked == true)
                            {
                                check = "Sim";
                            }
                            else if (RadNao.Checked == true)
                            {
                                check = "Nao";
                            }

                            string pratotipo = "";

                            if (RadVeg.Checked == true)
                            {
                                pratotipo = "Vegetariano";
                            }
                            else if (RadCarne.Checked == true)
                            {
                                pratotipo = "Carne";
                            }
                            else if (RadPeixe.Checked == true)
                            {
                                pratotipo = "Peixe";
                            }

                            MySqlCommand update_command = new MySqlCommand("UPDATE prato SET NomePrato=@NomePrato,QuanPrato=@QuanPrato,PrecoPrato=@PrecoPrato,DescPrato=@DescPrato,AtivoPrato=@AtivoPrato,TipoPrato=@TipoPrato WHERE IDPrato=@IDPrato", connection);
                            update_command.Parameters.Add("@IDPrato", MySqlDbType.Int32).Value = idartigo;
                            update_command.Parameters.Add("@NomePrato", MySqlDbType.VarChar).Value = TBxNome.Text;
                            update_command.Parameters.Add("@QuanPrato", MySqlDbType.VarChar).Value = TBxQuantidade.Text;
                            update_command.Parameters.Add("@PrecoPrato", MySqlDbType.VarChar).Value = TBxPreco.Text;
                            update_command.Parameters.Add("@DescPrato", MySqlDbType.VarChar).Value = desc;
                            update_command.Parameters.Add("@AtivoPrato",MySqlDbType.VarChar).Value =  check;
                            update_command.Parameters.Add("@TipoPrato", MySqlDbType.VarChar).Value = pratotipo;
                            update_command.ExecuteNonQuery();

                            MessageBox.Show("Artigo atualizado com sucesso !!!");
                            criapratos();
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
                        string query = "DELETE FROM prato WHERE IDPrato=@IDPrato";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@IDPrato", idartigo);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Artigo eliminado com sucesso !!!");
                        criapratos();
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
            frm.clicabutao();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
