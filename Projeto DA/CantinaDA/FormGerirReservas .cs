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
using System.Diagnostics.Contracts;
using System.Globalization;

namespace CantinaDA
{
    public partial class FormGerirReservas : Form
    {
        int btnreg = 0;
        public FormGerirReservas()
        {
            InitializeComponent();
        }
        private void FormReservas_Load(object sender, EventArgs e)
        {
            carregareservas();
        }

        void reload()
        {
            FormReserva frm = new FormReserva();
            frm.Show();
            frm.carregager();
            this.Hide();
        }

        void carregareservas()
        {
            int x, i, cv;
            int idpessoa,idbutao;
            string convertep = "";
            int altura = 30;
            string contacto = "";
            string convertefunc = "";
            string converteid = "";         

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;

            string querysize = "SELECT * FROM reservas ORDER BY ReservaID DESC";

            MySqlCommand search_commandsize = new MySqlCommand(querysize, connection);

            MySqlDataAdapter adaptersize = new MySqlDataAdapter(search_commandsize);
            DataTable tablesize = new DataTable();

            adaptersize.Fill(tablesize);

            x = tablesize.Rows.Count;

            if (x > 0)
            {
                for (i = 0; i < x; i++)
                {
                    convertep = tablesize.Rows[i][1].ToString();
                    idpessoa = Int32.Parse(convertep);
                    converteid = tablesize.Rows[i][0].ToString();
                    idbutao = Int32.Parse(converteid);

                    string query = "SELECT ClienteNome,ClienteEmail,ClienteNumEs FROM clientes WHERE ClienteID=@ClienteID";

                    MySqlCommand search_command = new MySqlCommand(query, connection);

                    search_command.Parameters.AddWithValue("@ClienteID", idpessoa);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    System.Windows.Forms.Button btnNome = new System.Windows.Forms.Button();
                    btnNome.Text = table.Rows[0][0].ToString();
                    btnNome.Location = new System.Drawing.Point(0, altura);
                    btnNome.Size = new System.Drawing.Size(200, 35);
                    btnNome.Click += new System.EventHandler(btnNome_Click);
                    btnNome.Tag = tablesize.Rows[i][0];
                    btnNome.Cursor = Cursors.Hand;
                    btnNome.Font = new Font("Modern No. 20", 14);
                    btnNome.BackColor = Color.White;
                    btnNome.TextAlign = ContentAlignment.MiddleLeft;
                    btnNome.FlatStyle = FlatStyle.Flat;
                    btnNome.FlatAppearance.BorderSize = 1;

                    if(Global.btnres == idbutao)
                    {
                        btnNome.ForeColor = Color.Red;
                    }
                    else
                    {
                        btnNome.ForeColor = Color.Black;
                    }

                    contacto = table.Rows[0][1].ToString();
                    if (contacto == "")
                    {
                        contacto = table.Rows[0][2].ToString();
                    }

                    System.Windows.Forms.Label LblContacto = new System.Windows.Forms.Label();
                    LblContacto.Text = contacto;
                    LblContacto.Location = new System.Drawing.Point(200, altura);
                    LblContacto.Font = new Font("Modern No. 20", 14);
                    LblContacto.BackColor = Color.White;
                    LblContacto.AutoSize = false;
                    LblContacto.Size = new Size(200, 35);
                    LblContacto.TextAlign = ContentAlignment.MiddleLeft;
                    LblContacto.BorderStyle = BorderStyle.FixedSingle;

                    convertefunc = tablesize.Rows[i][2].ToString();
                    cv = Int32.Parse(convertefunc);

                    string querynf = "SELECT FuncionarioNome FROM funcionario WHERE FuncionarioID";

                    MySqlCommand search_commandnf = new MySqlCommand(querynf, connection);

                    search_commandnf.Parameters.AddWithValue("@Funcionario", cv);

                    MySqlDataAdapter adapternf = new MySqlDataAdapter(search_commandnf);
                    DataTable tablenf = new DataTable();

                    adapternf.Fill(tablenf);

                    System.Windows.Forms.Label LblNomeFunc = new System.Windows.Forms.Label();
                    LblNomeFunc.Text = tablenf.Rows[0][0].ToString();
                    LblNomeFunc.Location = new System.Drawing.Point(400, altura);
                    LblNomeFunc.Font = new Font("Modern No. 20", 14);
                    LblNomeFunc.BackColor = Color.White;
                    LblNomeFunc.AutoSize = false;
                    LblNomeFunc.Size = new Size(200, 35);
                    LblNomeFunc.TextAlign = ContentAlignment.MiddleLeft;
                    LblNomeFunc.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                    LblPreco.Text = tablesize.Rows[i][5].ToString();
                    LblPreco.Location = new System.Drawing.Point(600, altura);
                    LblPreco.Font = new Font("Modern No. 20", 14);
                    LblPreco.BackColor = Color.White;
                    LblPreco.AutoSize = false;
                    LblPreco.Size = new Size(200, 35);
                    LblPreco.TextAlign = ContentAlignment.MiddleLeft;
                    LblPreco.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblData = new System.Windows.Forms.Label();
                    LblData.Text = tablesize.Rows[i][6].ToString();
                    LblData.Location = new System.Drawing.Point(800, altura);
                    LblData.Font = new Font("Modern No. 20", 14);
                    LblData.BackColor = Color.White;
                    LblData.AutoSize = false;
                    LblData.Size = new Size(200, 35);
                    LblData.TextAlign = ContentAlignment.MiddleLeft;
                    LblData.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblEstado = new System.Windows.Forms.Label();
                    LblEstado.Text = tablesize.Rows[i][7].ToString();
                    LblEstado.Location = new System.Drawing.Point(1000, altura);
                    LblEstado.Font = new Font("Modern No. 20", 14);
                    LblEstado.BackColor = Color.White;
                    LblEstado.AutoSize = false;
                    LblEstado.Size = new Size(100, 35);
                    LblEstado.TextAlign = ContentAlignment.MiddleLeft;
                    LblEstado.BorderStyle = BorderStyle.FixedSingle;

                    PanelFechaReserva.Controls.Add(btnNome);
                    PanelFechaReserva.Controls.Add(LblPreco);
                    PanelFechaReserva.Controls.Add(LblContacto);
                    PanelFechaReserva.Controls.Add(LblData);
                    PanelFechaReserva.Controls.Add(LblNomeFunc);
                    PanelFechaReserva.Controls.Add(LblEstado);

                    altura += 35;
                }

            }

        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            int Nometag;
            int artigoid;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();

            if(btn.ForeColor == Color.Black)
            {                 
                artigoid = Int32.Parse(converte);
                Global.btnres = artigoid;
                reload();
            }
            else if(btn.ForeColor == Color.Red)
            {
                artigoid = 0;
                reload();
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            FormReserva frm = new FormReserva();
            frm.Show();
            this.Close();
        }

        private void BtnFecha_Click(object sender, EventArgs e)
        {
            string folderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\CantinaDA\\faturas\\";
            string filename = "";
            string fat = "";
            string mensagem = "Quer Salvar a fatura ?";
            string titulo = "Utilizar Reserva";
            fat = fatura();
            MessageBox.Show(fat, "Fatura");
            if(Global.btnres != 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult resultado = MessageBox.Show(mensagem, titulo, buttons);
                if (resultado == DialogResult.Yes)
                {
                    filename = "Fatura" + Global.btnres.ToString()+".txt";
                    string fullPath = Path.Combine(folderPath, filename);
                    File.WriteAllText(fullPath, fat);
                    utilizareserva();
                    reload();
                }
                else
                {
                    utilizareserva();
                    reload();
                }
            }
            else
            {
                MessageBox.Show("Para Utilizar uma reserva tem que selecionar a reserva que quer utilizar");
            }
        }

        void utilizareserva()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            MySqlCommand update_commandr = new MySqlCommand("UPDATE reservas SET ReservaEstado=@ReservaEstado WHERE ReservaID=@ReservaID", connection);
            update_commandr.Parameters.Add("@ReservaID", MySqlDbType.VarChar).Value = Global.btnres;
            update_commandr.Parameters.Add("@ReservaEstado", MySqlDbType.VarChar).Value = "Nao";
            update_commandr.ExecuteNonQuery();
            MessageBox.Show("Reserva Utilizada com sucesso, reserva fechada");
        }

        string fatura()
        {
            int artigoid = Global.btnres;
            int x, y, pesquisaid;
            string final = "";
            string converteid;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;

            string query1 = "SELECT * From reservas Where ReservaID=@ReservaID";

            MySqlCommand search_command1 = new MySqlCommand(query1, connection);

            search_command1.Parameters.AddWithValue("@ReservaID", artigoid);

            MySqlDataAdapter adapter1= new MySqlDataAdapter(search_command1);
            DataTable table1 = new DataTable();

            adapter1.Fill(table1);

            x = table1.Rows.Count;

            if (x != 0)
            {
                final += "------------------------------------------------------------------------------------------" + Environment.NewLine +
                             "Fatura Nº ____" + "                                    " + Environment.NewLine +
                             "------------------------------------------------------------------------------------------" + Environment.NewLine +
                             table1.Rows[0][6].ToString() + Environment.NewLine +
                             "ICantina LDA" + Environment.NewLine +
                             "R. Fonte do Moleiro" + Environment.NewLine +
                             "3780-400  Aveiro" + Environment.NewLine +
                             "Telefone : 916222333" + Environment.NewLine + "ICantina@gmail.com" + Environment.NewLine;

                converteid = table1.Rows[0][2].ToString();
                pesquisaid = Int32.Parse(converteid);

                string query2 = "SELECT FuncionarioNome From funcionario Where FuncionarioID=@FuncionarioID";

                MySqlCommand search_command2 = new MySqlCommand(query2, connection);

                search_command2.Parameters.AddWithValue("@FuncionarioID", pesquisaid);

                MySqlDataAdapter adapter2 = new MySqlDataAdapter(search_command2);
                DataTable table2 = new DataTable();

                adapter2.Fill(table2);

                y = table2.Rows.Count;

                if (y != 0)
                {
                    final += "Nome Do Funcionario : " + table2.Rows[0][0].ToString() + "  |  ID do Funcionario : " + pesquisaid + Environment.NewLine;
                }

                converteid = table1.Rows[0][1].ToString();
                pesquisaid = Int32.Parse(converteid);

                string query3 = "SELECT ClienteNome From clientes Where ClienteID=@ClienteID";

                MySqlCommand search_command3 = new MySqlCommand(query3, connection);

                search_command3.Parameters.AddWithValue("@ClienteID", pesquisaid);

                MySqlDataAdapter adapter3 = new MySqlDataAdapter(search_command3);
                DataTable table3 = new DataTable();

                adapter3.Fill(table3);

                y = table3.Rows.Count;

                if (y != 0)
                {
                    final += "Nome Do Cliente : " + table3.Rows[0][0].ToString() + "  |  ID do Cliente : " + pesquisaid + Environment.NewLine;
                }
                final += "------------------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine;

                string input = table1.Rows[0][3].ToString();

                int commaIndex = input.IndexOf(',');

                if (commaIndex != -1)
                {
                    string numberString = input.Substring(0, commaIndex);
                    pesquisaid = Int32.Parse(numberString);
                }

                string query4 = "SELECT * From prato Where IDPrato=@IDPrato";

                MySqlCommand search_command4 = new MySqlCommand(query4, connection);

                search_command4.Parameters.AddWithValue("@IDPrato", pesquisaid);

                MySqlDataAdapter adapter4 = new MySqlDataAdapter(search_command4);
                DataTable table4 = new DataTable();

                adapter4.Fill(table4);

                y = table4.Rows.Count;

                if (y != 0)
                {
                    final += table4.Rows[0][1] + " - " + table4.Rows[0][3].ToString() + "€" + Environment.NewLine + Environment.NewLine;
                }

                final += "------------------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine;

                string input2 = table1.Rows[0][4].ToString();

                string[] numbers = input2.Split(',');

                foreach (string number in numbers)
                {
                    if (int.TryParse(number.Trim(), out int result))
                    {
                        string query5 = "SELECT * From extras Where ExtrasID=@ExtrasID";

                        MySqlCommand search_command5 = new MySqlCommand(query5, connection);

                        search_command5.Parameters.AddWithValue("@ExtrasID", result);

                        MySqlDataAdapter adapter5 = new MySqlDataAdapter(search_command5);
                        DataTable table5 = new DataTable();

                        adapter5.Fill(table5);

                        y = table5.Rows.Count;

                        if (y != 0)
                        {
                            final += table5.Rows[0][1] + " - " + table5.Rows[0][3].ToString() + "€" + Environment.NewLine;
                        }
                    }
                    else
                    {

                    }
                }

                string convertettl = "";
                float ttliva = 0;
                float IVA = 0;

                convertettl = table1.Rows[0][5].ToString();

                float.TryParse(convertettl, NumberStyles.Float, CultureInfo.InvariantCulture, out float ttl);

                if(ttl>0)
                {
                    ttliva = ttl * 1.13F;
                    IVA = ttliva - ttl;
                }

                final +=Environment.NewLine;
                final += "------------------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine;
                final += "IVA %13:" + Environment.NewLine+ Environment.NewLine;
                final += "Total Sem IVA : " + ttl + "€" + Environment.NewLine;             
                final += "IVA: " + IVA + "€" + Environment.NewLine;
                final += "Total Com IVA : " + ttliva + "€" + Environment.NewLine + Environment.NewLine;
                final += "------------------------------------------------------------------------------------------";


            }
            return final;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fat = "";
            fat = fatura();
        }
    }
}
