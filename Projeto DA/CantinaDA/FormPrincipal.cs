using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CantinaDA
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Global.connectionString = "server=localhost;port=3306;database=databaseda;user=root;password=";
            carregafunc();
        }

        public void carregafunc()
        {
            int x, i;
            int altura = 0;

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
                    btnNome.Size = new System.Drawing.Size(198, 35);
                    btnNome.Click += new System.EventHandler(btnNome_Click);
                    btnNome.Tag = tablesize.Rows[i][0];
                    btnNome.Cursor = Cursors.Hand;
                    btnNome.Font = new Font("Modern No. 20", 14);
                    btnNome.BackColor = Color.White;
                    btnNome.TextAlign = ContentAlignment.MiddleCenter;
                    btnNome.FlatStyle = FlatStyle.Flat;
                    btnNome.FlatAppearance.BorderSize = 0;
                    if (tablesize.Rows[i][3].ToString() == "Sim")
                    {
                        btnNome.ForeColor = Color.Red;
                        Global.funcsec = tablesize.Rows[i][0].ToString();
                    }
                    else
                    {
                        btnNome.ForeColor = Color.Black;
                    }

                    PanelFuncionarios.Controls.Add(btnNome);

                    altura += 35;
                }

            }
        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            int antigoid;
            int novoid;
            string converte = "";
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;


            converte = btn.Tag.ToString();
            novoid = Int32.Parse(converte);

            if (btn.ForeColor == Color.Black)
            {
                MySqlConnection connectionP = new MySqlConnection();
                connectionP.ConnectionString = Global.connectionString;
                connectionP.Open();

                string queryP = "SELECT FuncionarioID FROM funcionario WHERE FuncSelect=@FuncSelect";

                MySqlCommand search_commandP = new MySqlCommand(queryP, connectionP);

                search_commandP.Parameters.AddWithValue("FuncSelect", "Sim");

                MySqlDataAdapter adapterP = new MySqlDataAdapter(search_commandP);
                DataTable tableP = new DataTable();

                adapterP.Fill(tableP);

                if (tableP.Rows.Count > 0)
                {
                    converte = tableP.Rows[0][0].ToString();
                    antigoid = Int32.Parse(converte);


                    MySqlCommand update_command = new MySqlCommand("UPDATE funcionario SET FuncSelect=@FuncSelect WHERE FuncionarioID=@FuncionarioID", connectionP);
                    update_command.Parameters.Add("@FuncionarioID", MySqlDbType.Int32).Value = antigoid;
                    update_command.Parameters.Add("@FuncSelect", MySqlDbType.VarChar).Value = "Nao";
                    update_command.ExecuteNonQuery();

                    MySqlCommand update_command2 = new MySqlCommand("UPDATE funcionario SET FuncSelect=@FuncSelect WHERE FuncionarioID=@FuncionarioID", connectionP);
                    update_command2.Parameters.Add("@FuncionarioID", MySqlDbType.Int32).Value = novoid;
                    update_command2.Parameters.Add("@FuncSelect", MySqlDbType.VarChar).Value = "Sim";
                    update_command2.ExecuteNonQuery();

                    Global.funcsec = novoid.ToString();

                    FormMenu frm = new FormMenu();
                    frm.Show();
                    frm.carregafuncionario();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("erro, id nao econtrado");
                }

                btn.ForeColor = Color.Red;
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            string mensagem = "Tem a certeza que quer sair ?";
            string titulo = "Sair";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult resultado = MessageBox.Show(mensagem, titulo, buttons);
            if (resultado == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
            }
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            FormMenu frm = new FormMenu();
            frm.Show();
            this.Hide();
        }

        private void BtnReserva_Click(object sender, EventArgs e)
        {
            FormReserva frm = new FormReserva();
            frm.Show();
            this.Hide();
        }

        private void BtnPratos_Click(object sender, EventArgs e)
        {
            FormPratos frm = new FormPratos();
            frm.Show();
            this.Hide();
        }

        public void clicabutao()
        {
            BtnPratos.PerformClick();
        }
        public void clicafuncionario()
        {
            BtnFuncionarios.PerformClick();
        }
        public void clicacliente()
        {
            BtnClientes.PerformClick();
        }

        public void clicaextra()
        {
            BtnExtras.PerformClick();
        }

        public void clicamulta()
        {
            BtnMultas.PerformClick();
        }

        public void clicamenu()
        {
            BtnMenu.PerformClick();
        }

        public void clicareserva()
        {
            BtnReserva.PerformClick();
        }

        private void BtnFuncionarios_Click(object sender, EventArgs e)
        {
            FormFuncionarios frm = new FormFuncionarios();
            frm.Show();
            this.Hide();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FormCliente frm = new FormCliente();
            frm.Show();
            this.Hide();
        }

        private void BtnExtras_Click(object sender, EventArgs e)
        {
            FormExtras frm = new FormExtras();
            frm.Show();
            this.Hide();
        }

        private void BtnMultas_Click(object sender, EventArgs e)
        {
            FormMulta frm = new FormMulta();
            frm.Show();
            this.Hide();
        }
    }
}
