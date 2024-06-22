using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CantinaDA
{
    public partial class FormReserva : Form
    {
        float taxa = 1;
        public FormReserva()
        {
            InitializeComponent();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            this.Hide();
        }

        private void BtnProfessor_Click(object sender, EventArgs e)
        {
            if (BtnProfessor.ForeColor == Color.Black)
            {
                BtnAluno.ForeColor = Color.Black;
                BtnProfessor.ForeColor = Color.Red;
                Global.tiporeserva = 1;
                Global.reservaitems = "";
                Global.reservaextra = "";
                Global.tipopratoreserva = 0;
                Global.comecoureserva = 0;
                LblCodCliente.Text = "Email";
                iniciamenu();
                reload();
            }
        }

        public void carregager()
        {
            FormGerirReservas frm = new FormGerirReservas();
            frm.Show();
            this.Hide();
        }

        private void FormReserva_Load(object sender, EventArgs e)
        {
            if (Global.tiporeserva == 1)
            {
                BtnProfessor.ForeColor = Color.Red;
            }
            else if (Global.tiporeserva == 2)
            {
                BtnAluno.ForeColor = Color.Red;
            }

            if(BtnAluno.ForeColor == Color.Red)
            {
                LblCodCliente.Text = "Numero Es.";
            }
            else if(BtnProfessor.ForeColor == Color.Red)
            {
                LblCodCliente.Text = "Email";
            }

            if(Global.comecoureserva == 1)
            {
                BtnComeca.ForeColor = Color.Red;
                BtnComeca.Text = "Concluir";
                BtnCancelar.Visible = true;
            }
            else
            {
                BtnComeca.ForeColor = Color.Black;
                BtnComeca.Text = "Começar Reserva";
                BtnCancelar.Visible = false;
            }

            TBxCodCliente.Text = Global.reservacod;
            TBxNomeCliente.Text = Global.reservanome;

            iniciamenu();
            iniciakart();
        }

        private void BtnAluno_Click(object sender, EventArgs e)
        {
            if (BtnAluno.ForeColor == Color.Black)
            {
                BtnProfessor.ForeColor = Color.Black;
                BtnAluno.ForeColor = Color.Red;
                Global.tiporeserva = 2;
                Global.reservaitems = "";
                Global.reservaextra = "";
                Global.tipopratoreserva = 0;
                Global.comecoureserva = 0;
                LblCodCliente.Text = "Numero Es.";
                iniciamenu();
                reload();
            }
        }

        private void BtnComeca_Click(object sender, EventArgs e)
        {
            if (BtnComeca.ForeColor == Color.Black)
            {
                if(BtnAluno.ForeColor == Color.Red)
                {
                    Global.tiporeserva = 2;
                }
                else if (BtnProfessor.ForeColor == Color.Red)
                {
                    Global.tiporeserva = 1;
                }
                confirmauser();                
            }
            else if (BtnComeca.ForeColor == Color.Red)
            {
                terminareserva();
            }
        }

        void terminareserva()
        {
            int idpessoa, idfunc;
            string idconvertep;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            if(Global.tiporeserva == 1)
            {
                string query = "SELECT * FROM clientes WHERE ClienteEmail=@ClienteEmail And ClienteNome=@ClienteNome";

                MySqlCommand search_command = new MySqlCommand(query, connection);

                search_command.Parameters.AddWithValue("ClienteNome", TBxNomeCliente.Text);
                search_command.Parameters.AddWithValue("ClienteEmail", TBxCodCliente.Text);

                MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    idconvertep = table.Rows[0][0].ToString();
                    idpessoa = Int32.Parse(idconvertep);

                    idfunc = Int32.Parse(Global.funcsec);

                    MySqlCommand sqlins = new MySqlCommand("INSERT INTO reservas (ReservaClienteID,ReservaFunc,ReservaPratos,ReservaExtras,ReservaTotal,ReservaData,ReservaEstado) VALUES (@ReservaClienteID,@ReservaFunc,@ReservaPratos,@ReservaExtras,@ReservaTotal,@ReservaData,@ReservaEstado)", connection);
                    sqlins.Parameters.AddWithValue("@ReservaClienteID", idpessoa);
                    sqlins.Parameters.AddWithValue("@ReservaFunc", idfunc);
                    sqlins.Parameters.AddWithValue("@ReservaPratos", Global.reservaitems);
                    sqlins.Parameters.AddWithValue("@ReservaExtras", Global.reservaextra);
                    sqlins.Parameters.AddWithValue("@ReservaTotal", Global.totalreserva);
                    sqlins.Parameters.AddWithValue("@ReservaData", datapicker.Text);
                    sqlins.Parameters.AddWithValue("@ReservaEstado", "Sim");

                    Global.reservaitems = "";
                    Global.reservaextra = "";
                    Global.comecoureserva = 0;

                    BtnCancelar.Visible = false;

                    MessageBox.Show("Reserva concluida");

                    iniciakart();
                    iniciamenu();
                    reload();

                    sqlins.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Erro cliente invalido");
                }
            }
            else if (Global.tiporeserva == 2)
            {
                string query = "SELECT * FROM clientes WHERE ClienteNumEs=@ClienteNumEs And ClienteNome=@ClienteNome";

                MySqlCommand search_command = new MySqlCommand(query, connection);

                search_command.Parameters.AddWithValue("ClienteNome", TBxNomeCliente.Text);
                search_command.Parameters.AddWithValue("ClienteNumEs", TBxCodCliente.Text);

                MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    idconvertep = table.Rows[0][0].ToString();
                    idpessoa = Int32.Parse(idconvertep);

                    idfunc = Int32.Parse(Global.funcsec);

                    MySqlCommand sqlins = new MySqlCommand("INSERT INTO reservas (ReservaClienteID,ReservaFunc,ReservaPratos,ReservaExtras,ReservaTotal,ReservaData) VALUES (@ReservaClienteID,@ReservaFunc,@ReservaPratos,@ReservaExtras,@ReservaTotal,@ReservaData)", connection);
                    sqlins.Parameters.AddWithValue("@ReservaClienteID", idpessoa);
                    sqlins.Parameters.AddWithValue("@ReservaFunc", idfunc);
                    sqlins.Parameters.AddWithValue("@ReservaPratos", Global.reservaitems);
                    sqlins.Parameters.AddWithValue("@ReservaExtras", Global.reservaextra);
                    sqlins.Parameters.AddWithValue("@ReservaTotal", Global.totalreserva);
                    sqlins.Parameters.AddWithValue("@ReservaData", datapicker.Text);

                    Global.reservaitems = "";
                    Global.reservaextra = "";

                    BtnCancelar.Visible = false;

                    MessageBox.Show("Reserva concluida");

                    iniciakart();
                    iniciamenu();
                    reload();

                    sqlins.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Erro cliente invalido");
                }
            }
        }

        void confirmauser()
        {
            if (TBxCodCliente.Text == "" && Global.tiporeserva == 1)
            {
                MessageBox.Show("Digite o email do professor");
            }
            else if (TBxCodCliente.Text == "" && Global.tiporeserva == 2)
            {
                MessageBox.Show("Digite o numero de estudante do aluno");
            }
            else if (TBxNomeCliente.Text == "")
            {
                MessageBox.Show("Digite o nome do cliente");
            }
            else
            {
                if (Global.tiporeserva == 1)
                {
                    MySqlConnection connection = new MySqlConnection();
                    connection.ConnectionString = Global.connectionString;
                    connection.Open();

                    string query = "SELECT * FROM clientes WHERE ClienteEmail=@ClienteEmail And ClienteNome=@ClienteNome";

                    MySqlCommand search_command = new MySqlCommand(query, connection);

                    search_command.Parameters.AddWithValue("ClienteNome", TBxNomeCliente.Text);
                    search_command.Parameters.AddWithValue("ClienteEmail", TBxCodCliente.Text);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Reserva iniciada");
                        BtnComeca.ForeColor = Color.Red;
                        BtnComeca.Text = "Concluir";
                        Global.comecoureserva = 1;
                        BtnCancelar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Erro, nao foi encontrado nenhum professor com os respetivos dados");
                    }
                }
                else if (Global.tiporeserva == 2)
                {
                    MySqlConnection connection = new MySqlConnection();
                    connection.ConnectionString = Global.connectionString;
                    connection.Open();

                    string query = "SELECT * FROM clientes WHERE ClienteNumEs=@ClienteNumEs And ClienteNome=@ClienteNome";

                    MySqlCommand search_command = new MySqlCommand(query, connection);

                    search_command.Parameters.AddWithValue("ClienteNome", TBxNomeCliente.Text);
                    search_command.Parameters.AddWithValue("ClienteNumEs", TBxCodCliente.Text);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Reserva iniciada");
                        BtnComeca.ForeColor = Color.Red;
                        BtnComeca.Text = "Concluir";
                        Global.comecoureserva = 1;
                        BtnCancelar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Erro, nao foi encontrado nenhum aluno com os respetivos dados");
                    }
                }
            }
        }

        void reload()
        {
            Global.reservanome = TBxNomeCliente.Text;
            Global.reservacod = TBxCodCliente.Text;
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            frm.clicareserva();
            this.Hide();
        }

        void iniciamenu()
        {
            if (Global.tiporeserva == 1)
            {
                taxa = 1.2F;
            }
            else if (Global.tiporeserva == 2)
            {
                taxa = 1;
            }

            int x, x2;
            int altura = 0;
            float preco;
            string precocv = "";

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            string query = "SELECT MenuPratos FROM menus WHERE MenuData=@MenuData";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@MenuData", datapicker.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            x = table.Rows.Count;

            if (x > 0)
            {
                if (table.Rows[0][0].ToString() != "-")
                {
                    System.Windows.Forms.Label lblpratotitulo = new System.Windows.Forms.Label();
                    lblpratotitulo.Text = "Pratos";
                    lblpratotitulo.Location = new System.Drawing.Point(0, altura);
                    lblpratotitulo.Font = new Font("Modern No. 20", 16);
                    lblpratotitulo.BackColor = Color.White;
                    lblpratotitulo.AutoSize = false;
                    lblpratotitulo.Size = new Size(448, 35);
                    lblpratotitulo.TextAlign = ContentAlignment.MiddleCenter;
                    lblpratotitulo.BorderStyle = BorderStyle.FixedSingle;

                    PanelMenu.Controls.Add(lblpratotitulo);
                    altura += 35;
                }
                string input = table.Rows[0][0].ToString();

                string[] numbers = input.Split(',');

                foreach (string number in numbers)
                {
                    if (int.TryParse(number.Trim(), out int result))
                    {
                        string query3 = "SELECT * FROM prato WHERE IDPrato=@IDPrato";

                        MySqlCommand search_command3 = new MySqlCommand(query3, connection);

                        search_command3.Parameters.AddWithValue("@IDPrato", result);

                        MySqlDataAdapter adapter3 = new MySqlDataAdapter(search_command3);
                        DataTable table3 = new DataTable();

                        adapter3.Fill(table3);

                        System.Windows.Forms.Button BtnNome = new System.Windows.Forms.Button();
                        BtnNome.Text = table3.Rows[0][1].ToString();
                        BtnNome.Location = new System.Drawing.Point(0, altura);
                        BtnNome.Font = new Font("Modern No. 20", 14);
                        BtnNome.ForeColor = Color.Black;
                        BtnNome.BackColor = Color.White;
                        BtnNome.AutoSize = false;
                        BtnNome.Size = new Size(300, 35);
                        BtnNome.TextAlign = ContentAlignment.MiddleLeft;
                        BtnNome.FlatStyle = FlatStyle.Flat;
                        BtnNome.FlatAppearance.BorderSize = 0;
                        BtnNome.Tag = table3.Rows[0][0].ToString();
                        BtnNome.Click += new System.EventHandler(btnartigo_Click);

                        System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                        LblPreco.Location = new System.Drawing.Point(300, altura);
                        LblPreco.Font = new Font("Modern No. 20", 14);
                        LblPreco.BackColor = Color.White;
                        LblPreco.AutoSize = false;
                        LblPreco.Size = new Size(148, 35);
                        LblPreco.TextAlign = ContentAlignment.MiddleLeft;

                        precocv = table3.Rows[0][3].ToString();
                        preco = float.Parse(precocv) * taxa;

                        LblPreco.Text = preco.ToString() + "€";

                        PanelMenu.Controls.Add(LblPreco);
                        PanelMenu.Controls.Add(BtnNome);

                        altura += 35;
                    }
                    else
                    {

                    }
                }
            }


            string query2 = "SELECT MenuExtras FROM menus WHERE MenuData=@MenuData";

            MySqlCommand search_command2 = new MySqlCommand(query2, connection);

            search_command2.Parameters.AddWithValue("@MenuData", datapicker.Text);

            MySqlDataAdapter adapter2 = new MySqlDataAdapter(search_command2);
            DataTable table2 = new DataTable();

            adapter2.Fill(table2);

            x = table2.Rows.Count;

            if (x > 0)
            {
                if (table2.Rows[0][0].ToString() != "-")
                {
                    System.Windows.Forms.Label lblextratitulo = new System.Windows.Forms.Label();
                    lblextratitulo.Text = "Extras";
                    lblextratitulo.Location = new System.Drawing.Point(0, altura);
                    lblextratitulo.Font = new Font("Modern No. 20", 16);
                    lblextratitulo.BackColor = Color.White;
                    lblextratitulo.AutoSize = false;
                    lblextratitulo.Size = new Size(448, 35);
                    lblextratitulo.TextAlign = ContentAlignment.MiddleCenter;
                    lblextratitulo.BorderStyle = BorderStyle.FixedSingle;

                    PanelMenu.Controls.Add(lblextratitulo);
                    altura += 35;
                }
                string input = table2.Rows[0][0].ToString();

                string[] numbers = input.Split(',');

                foreach (string number in numbers)
                {
                    if (int.TryParse(number.Trim(), out int result))
                    {
                        string query3 = "SELECT * FROM extras WHERE ExtrasID=@ExtrasID";

                        MySqlCommand search_command3 = new MySqlCommand(query3, connection);

                        search_command3.Parameters.AddWithValue("@ExtrasID", result);

                        MySqlDataAdapter adapter3 = new MySqlDataAdapter(search_command3);
                        DataTable table3 = new DataTable();

                        adapter3.Fill(table3);

                        System.Windows.Forms.Button BtnNome = new System.Windows.Forms.Button();
                        BtnNome.Text = table3.Rows[0][1].ToString();
                        BtnNome.Location = new System.Drawing.Point(0, altura);
                        BtnNome.Font = new Font("Modern No. 20", 14);
                        BtnNome.BackColor = Color.White;
                        BtnNome.AutoSize = false;
                        BtnNome.Size = new Size(300, 35);
                        BtnNome.TextAlign = ContentAlignment.MiddleLeft;
                        BtnNome.FlatStyle = FlatStyle.Flat;
                        BtnNome.FlatAppearance.BorderSize = 0;
                        BtnNome.Tag = table3.Rows[0][0].ToString();
                        BtnNome.Click += new System.EventHandler(btnextra_Click);

                        System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                        LblPreco.Location = new System.Drawing.Point(300, altura);
                        LblPreco.Font = new Font("Modern No. 20", 14);
                        LblPreco.BackColor = Color.White;
                        LblPreco.AutoSize = false;
                        LblPreco.Size = new Size(148, 35);
                        LblPreco.TextAlign = ContentAlignment.MiddleLeft;

                        precocv = table3.Rows[0][3].ToString();
                        preco = float.Parse(precocv) * taxa;

                        LblPreco.Text = preco.ToString() + "€";

                        PanelMenu.Controls.Add(LblPreco);
                        PanelMenu.Controls.Add(BtnNome);

                        altura += 35;
                    }
                    else
                    {

                    }
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

            if (BtnComeca.ForeColor == Color.Red)
            {
                Global.comecoureserva = 1;
            }

            if (Global.comecoureserva == 0)
            {
                MessageBox.Show("comeca a reserva para selecionar produtos");
            }
            else if (Global.comecoureserva == 1)
            {
                if (Global.tipopratoreserva == 0)
                {
                    Global.reservaitems += artigotag + ",";
                    Global.tipopratoreserva = 1;
                    iniciakart();
                    reload();                    

                }
                else
                {
                    MessageBox.Show("So se pode escolher um prato por reseva");
                }
            }
        }

        private void btnextra_Click(object sender, EventArgs e)
        {
            int artigotag;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            artigotag = Int32.Parse(converte);

            if (BtnComeca.ForeColor == Color.Red)
            {
                Global.comecoureserva = 1;
            }

            if (Global.comecoureserva == 0)
            {
                MessageBox.Show("comeca a reserva para selecionar produtos");
            }
            else if (Global.comecoureserva == 1)
            {
                Global.reservaextra += artigotag + ",";
                iniciakart();
                reload();
                LblTotal.Text = "Total : " + Global.totalreserva + " €";
            }
        }


        void iniciakart()
        {
            Global.totalreserva = 0;
            int salvaaltura;
            int x, x2;
            int altura = 0;
            float preco;
            string precocv = "";

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            if (Global.reservaitems != "")
            {
                System.Windows.Forms.Label lblpratotitulo = new System.Windows.Forms.Label();
                lblpratotitulo.Text = "Pratos";
                lblpratotitulo.Location = new System.Drawing.Point(0, altura);
                lblpratotitulo.Font = new Font("Modern No. 20", 16);
                lblpratotitulo.BackColor = Color.White;
                lblpratotitulo.AutoSize = false;
                lblpratotitulo.Size = new Size(448, 35);
                lblpratotitulo.TextAlign = ContentAlignment.MiddleCenter;
                lblpratotitulo.BorderStyle = BorderStyle.FixedSingle;

                PanelReserva.Controls.Add(lblpratotitulo);
                altura += 35;
                string input = Global.reservaitems;

                string[] numbers = input.Split(',');

                foreach (string number in numbers)
                {
                    if (int.TryParse(number.Trim(), out int result))
                    {
                        string query3 = "SELECT * FROM prato WHERE IDPrato=@IDPrato";

                        MySqlCommand search_command3 = new MySqlCommand(query3, connection);

                        search_command3.Parameters.AddWithValue("@IDPrato", result);

                        MySqlDataAdapter adapter3 = new MySqlDataAdapter(search_command3);
                        DataTable table3 = new DataTable();

                        adapter3.Fill(table3);

                        System.Windows.Forms.Button BtnNome = new System.Windows.Forms.Button();
                        BtnNome.Text = table3.Rows[0][1].ToString();
                        BtnNome.Location = new System.Drawing.Point(0, altura);
                        BtnNome.Font = new Font("Modern No. 20", 14);
                        BtnNome.ForeColor = Color.Black;
                        BtnNome.BackColor = Color.White;
                        BtnNome.AutoSize = false;
                        BtnNome.Size = new Size(300, 35);
                        BtnNome.TextAlign = ContentAlignment.MiddleLeft;
                        BtnNome.FlatStyle = FlatStyle.Flat;
                        BtnNome.FlatAppearance.BorderSize = 0;
                        BtnNome.Tag = table3.Rows[0][0].ToString();
                        BtnNome.Click += new System.EventHandler(btnitemkart_Click);

                        System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                        LblPreco.Location = new System.Drawing.Point(300, altura);
                        LblPreco.Font = new Font("Modern No. 20", 14);
                        LblPreco.BackColor = Color.White;
                        LblPreco.AutoSize = false;
                        LblPreco.Size = new Size(98, 35);
                        LblPreco.TextAlign = ContentAlignment.MiddleLeft;

                        precocv = table3.Rows[0][3].ToString();
                        preco = float.Parse(precocv) * taxa;

                        LblPreco.Text = preco.ToString() + "€";

                        Global.totalreserva += preco;

                        PanelReserva.Controls.Add(LblPreco);
                        PanelReserva.Controls.Add(BtnNome);

                        altura += 35;
                    }
                    else
                    {

                    }
                }
            }
            if (Global.reservaextra != "")
            {
                System.Windows.Forms.Label lblpratotitulo = new System.Windows.Forms.Label();
                lblpratotitulo.Text = "Extra";
                lblpratotitulo.Location = new System.Drawing.Point(0, altura);
                lblpratotitulo.Font = new Font("Modern No. 20", 16);
                lblpratotitulo.BackColor = Color.White;
                lblpratotitulo.AutoSize = false;
                lblpratotitulo.Size = new Size(448, 35);
                lblpratotitulo.TextAlign = ContentAlignment.MiddleCenter;
                lblpratotitulo.BorderStyle = BorderStyle.FixedSingle;

                PanelReserva.Controls.Add(lblpratotitulo);
                altura += 35;
                string input = Global.reservaextra;

                string[] numbers = input.Split(',');

                foreach (string number in numbers)
                {
                    if (int.TryParse(number.Trim(), out int result))
                    {
                        string query3 = "SELECT * FROM extras WHERE ExtrasID=@ExtrasID";

                        MySqlCommand search_command3 = new MySqlCommand(query3, connection);

                        search_command3.Parameters.AddWithValue("@ExtrasID", result);

                        MySqlDataAdapter adapter3 = new MySqlDataAdapter(search_command3);
                        DataTable table3 = new DataTable();

                        adapter3.Fill(table3);

                        System.Windows.Forms.Button BtnNome = new System.Windows.Forms.Button();
                        BtnNome.Text = table3.Rows[0][1].ToString();
                        BtnNome.Location = new System.Drawing.Point(0, altura);
                        BtnNome.Font = new Font("Modern No. 20", 14);
                        BtnNome.ForeColor = Color.Black;
                        BtnNome.BackColor = Color.White;
                        BtnNome.AutoSize = false;
                        BtnNome.Size = new Size(300, 35);
                        BtnNome.TextAlign = ContentAlignment.MiddleLeft;
                        BtnNome.FlatStyle = FlatStyle.Flat;
                        BtnNome.FlatAppearance.BorderSize = 0;
                        BtnNome.Tag = table3.Rows[0][0].ToString();
                        BtnNome.Click += new System.EventHandler(btnextrakart_Click);

                        System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                        LblPreco.Location = new System.Drawing.Point(300, altura);
                        LblPreco.Font = new Font("Modern No. 20", 14);
                        LblPreco.BackColor = Color.White;
                        LblPreco.AutoSize = false;
                        LblPreco.Size = new Size(98, 35);
                        LblPreco.TextAlign = ContentAlignment.MiddleLeft;

                        precocv = table3.Rows[0][3].ToString();
                        preco = float.Parse(precocv) * taxa;

                        Global.totalreserva += preco;

                        LblPreco.Text = preco.ToString() + "€";

                        PanelReserva.Controls.Add(LblPreco);
                        PanelReserva.Controls.Add(BtnNome);

                        altura += 35;
                    }
                    else
                    {

                    }
                }
            }
            LblTotal.Text = "Total : " + Global.totalreserva + " €";
        }

        private void btnitemkart_Click(object sender, EventArgs e)
        {
            string newitem;
            int artigotag;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            artigotag = Int32.Parse(converte);

            newitem = RemoveSpecificNumber(Global.reservaitems, artigotag);
            Global.reservaitems = newitem;
            if (newitem == "")
            {
                Global.tipopratoreserva = 0;
            }

            iniciakart();
            reload();
        }

        private void btnextrakart_Click(object sender, EventArgs e)
        {
            string newitem;
            int artigotag;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            artigotag = Int32.Parse(converte);

            newitem = RemoveSpecificNumber(Global.reservaextra, artigotag);
            Global.reservaextra = newitem;

            iniciakart();
            reload();
        }

        static string RemoveSpecificNumber(string input, int numberToRemove)
        {
            var numbers = input.Split(',');

            var filteredNumbers = numbers.Where(n => n != numberToRemove.ToString());

            return string.Join(",", filteredNumbers);
        }

        private void BtnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicar no nome do produto para o adicionar a reserva ou remover");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Global.reservaitems = "";
            Global.reservaextra = "";
            Global.tipopratoreserva = 0;
            Global.comecoureserva = 0;
            Global.totalreserva = 0;
            Global.reservacod = "";
            Global.reservanome = "";
            TBxCodCliente.Text = "";
            TBxNomeCliente.Text = "";
            reload();
        }

        private void BtnGerir_Click(object sender, EventArgs e)
        {
            FormGerirReservas frm = new FormGerirReservas();
            frm.Show();
            this.Hide();
        }
    }
}
