using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
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
    public partial class FormMenu : Form
    {
        int pveg;
        int pcarne;
        int ppeixe;

        public FormMenu()
        {
            InitializeComponent();
        }

        public void carregafuncionario()
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            frm.carregafunc();
            this.Hide();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            this.Hide();
        }

        private void BtnMenuRight_Click(object sender, EventArgs e)
        {
            datapicker.Value = datapicker.Value.AddDays(1);
            Global.datamenu = datapicker.Text;
            if (Global.tipocliente == 1)
            {
                if (Global.pratotipo == "Vegetariano")
                {
                    BtnPratosVeg.ForeColor = Color.Red;
                }
                else if (Global.pratotipo == "Carne")
                {
                    BtnPratoCarne.ForeColor = Color.Red;
                }
                else if (Global.pratotipo == "Peixe")
                {
                    BtnPratosPeixe.ForeColor = Color.Red;
                }
            }
            else if (Global.tipocliente == 2)
            {
                carregaextra();
                BtnExtras.ForeColor = Color.Red;
            }
            reloadmenu();
            reload();
        }

        private void BtnMenuLeft_Click(object sender, EventArgs e)
        {
            datapicker.Value = datapicker.Value.AddDays(-1);
            Global.datamenu = datapicker.Text;
            if (Global.tipocliente == 1)
            {
                if (Global.pratotipo == "Vegetariano")
                {
                    BtnPratosVeg.ForeColor = Color.Red;
                }
                else if (Global.pratotipo == "Carne")
                {
                    BtnPratoCarne.ForeColor = Color.Red;
                }
                else if (Global.pratotipo == "Peixe")
                {
                    BtnPratosPeixe.ForeColor = Color.Red;
                }
            }
            else if (Global.tipocliente == 2)
            {
                carregaextra();
                BtnExtras.ForeColor = Color.Red;
            }
            reloadmenu();
            reload();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            if (Global.tipocliente == 1)
            {
                carregaprato();
                if (Global.pratotipo == "Vegetariano")
                {
                    BtnPratosVeg.ForeColor = Color.Red;
                }
                else if(Global.pratotipo == "Carne")
                {
                    BtnPratoCarne.ForeColor = Color.Red;
                }
                else if (Global.pratotipo == "Peixe")
                {
                    BtnPratosPeixe.ForeColor = Color.Red;
                }

            }
            else if (Global.tipocliente == 2)
            {
                carregaextra();
                BtnExtras.ForeColor = Color.Red;
            }
            reloadmenu();
        }

        void reload()
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            frm.clicamenu();
            this.Hide();
        }

        private void BtnPratos_Click(object sender, EventArgs e)
        {
            if (BtnPratosVeg.ForeColor == Color.Black)
            {
                BtnPratosVeg.ForeColor = Color.Red;
                BtnPratoCarne.ForeColor = Color.Black;
                BtnPratosPeixe.ForeColor = Color.Black;
                BtnExtras.ForeColor = Color.Black;
                Global.tipocliente = 1;
                Global.pratotipo = "Vegetariano";
                carregaprato();
                reload();
            }
        }
        void carregaprato()
        {
            datapicker.Text = Global.datamenu;

            int x, i, achanumero;
            string stringnumero, achanumeroconverte;
            string pratotipo;
            int altura = 35;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;

            string query = "SELECT * FROM prato WHERE AtivoPrato=@AtivoPrato And TipoPrato=@TipoPrato";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@AtivoPrato", "Sim");
            search_command.Parameters.AddWithValue("@TipoPrato", Global.pratotipo);

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            x = table.Rows.Count;

            if (x > 0)
            {
                for (i = 0; i < x; i++)
                {
                    System.Windows.Forms.Button btnprato = new System.Windows.Forms.Button();
                    btnprato.Text = table.Rows[i][1].ToString();
                    btnprato.Location = new System.Drawing.Point(0, altura);
                    btnprato.Size = new System.Drawing.Size(200, 35);
                    btnprato.Click += new System.EventHandler(btnaddprato_Click);
                    btnprato.Tag = table.Rows[i][0];
                    btnprato.Cursor = Cursors.Hand;
                    btnprato.Font = new Font("Modern No. 20", 14);
                    btnprato.BackColor = Color.White;
                    btnprato.TextAlign = ContentAlignment.MiddleLeft;
                    btnprato.FlatStyle = FlatStyle.Flat;
                    btnprato.FlatAppearance.BorderSize = 1;

                    pratotipo = table.Rows[i][6].ToString();

                    string query2 = "SELECT MenuPratos FROM menus WHERE MenuData=@MenuData";

                    MySqlCommand search_command2 = new MySqlCommand(query2, connection);

                    search_command2.Parameters.AddWithValue("@MenuData", datapicker.Text);

                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(search_command2);
                    DataTable table2 = new DataTable();

                    adapter2.Fill(table2);

                    if (table2.Rows.Count > 0)
                    {
                        stringnumero = table2.Rows[0][0].ToString();

                        achanumeroconverte = table.Rows[i][0].ToString();

                        achanumero = Int32.Parse(achanumeroconverte);

                        bool achounumero = FindNumberInString(stringnumero, achanumero);

                        if (achounumero)
                        {
                            if(pratotipo == "Vegetariano")
                            {
                                pveg = 1;
                            }
                            else if (pratotipo == "Carne")
                            {
                                pcarne = 1;
                            }
                            else if(pratotipo == "Peixe")
                            {
                                ppeixe = 1;
                            }
                            btnprato.ForeColor = Color.Red;

                        }
                        else
                        {
                            btnprato.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        btnprato.ForeColor = Color.Black;
                    }

                    System.Windows.Forms.Label LblQuantidade = new System.Windows.Forms.Label();
                    LblQuantidade.Text = table.Rows[i][2].ToString();
                    LblQuantidade.Location = new System.Drawing.Point(200, altura);
                    LblQuantidade.Font = new Font("Modern No. 20", 14);
                    LblQuantidade.BackColor = Color.White;
                    LblQuantidade.AutoSize = false;
                    LblQuantidade.Size = new Size(125, 35);
                    LblQuantidade.TextAlign = ContentAlignment.MiddleLeft;
                    LblQuantidade.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                    LblPreco.Text = table.Rows[i][3].ToString();
                    LblPreco.Location = new System.Drawing.Point(325, altura);
                    LblPreco.Font = new Font("Modern No. 20", 14);
                    LblPreco.BackColor = Color.White;
                    LblPreco.AutoSize = false;
                    LblPreco.Size = new Size(123, 35);
                    LblPreco.TextAlign = ContentAlignment.MiddleLeft;
                    LblPreco.BorderStyle = BorderStyle.FixedSingle;

                    PanelProdutos.Controls.Add(LblPreco);
                    PanelProdutos.Controls.Add(LblQuantidade);
                    PanelProdutos.Controls.Add(btnprato);

                    altura += 35;
                }
            }
        }
        static bool FindNumberInString(string numbers, int targetNumber)
        {
            string[] numberArray = numbers.Split(',');

            foreach (string numberStr in numberArray)
            {
                if (int.TryParse(numberStr, out int number) && number == targetNumber)
                {
                    return true;
                }
            }

            return false;
        }
        static string RemoveSpecificNumber(string input, int numberToRemove)
        {
            var numbers = input.Split(',');

            var filteredNumbers = numbers.Where(n => n != numberToRemove.ToString());

            return string.Join(",", filteredNumbers);
        }
        private void btnaddprato_Click(object sender, EventArgs e)
        {
            int artigotag;
            string converte;
            string tipo = "";
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            artigotag = Int32.Parse(converte);

            

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            string query = "SELECT TipoPrato FROM prato WHERE IDPrato=@IDPrato";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@IDPrato", artigotag);

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                tipo = table.Rows[0][0].ToString();
            }
            
            else if (btn.ForeColor == Color.Red)
            {
                removepratos(artigotag);
                btn.ForeColor = Color.Black;
            }
            Global.datamenu = datapicker.Text;

            if (tipo == "Vegetariano")
            {
                if (pveg == 1 && btn.ForeColor == Color.Black)
                {
                    MessageBox.Show("So se pode escolher um tipo de prato por menu");
                }
                else if (pveg == 0 && btn.ForeColor == Color.Black)
                {
                    pveg = 1;
                    addprato(artigotag);
                    btn.ForeColor = Color.Red;
                }
                else if (pveg == 1 && btn.ForeColor == Color.Red)
                {
                    pveg = 0;
                    removepratos(artigotag);
                    btn.ForeColor = Color.Black;
                }
            }
            else if (tipo == "Carne")
            {
                if (pcarne == 1 && btn.ForeColor == Color.Black)
                {
                    MessageBox.Show("So se pode escolher um tipo de prato por menu");
                }
                else if (pcarne == 0 && btn.ForeColor == Color.Black)
                {
                    pcarne = 1;
                    addprato(artigotag);
                    btn.ForeColor = Color.Red;
                }
                else if (pcarne == 1 && btn.ForeColor == Color.Red)
                {
                    pcarne = 0;
                    removepratos(artigotag);
                    btn.ForeColor = Color.Black;
                }
            }
            else if (tipo == "Peixe")
            {
                if (ppeixe == 1 && btn.ForeColor == Color.Black)
                {
                    MessageBox.Show("So se pode escolher um tipo de prato por menu");
                }
                else if (ppeixe == 0 && btn.ForeColor == Color.Black)
                {
                    ppeixe = 1;
                    addprato(artigotag);
                    btn.ForeColor = Color.Red;
                }
                else if (ppeixe == 1 && btn.ForeColor == Color.Red)
                {
                    ppeixe = 0;
                    removepratos(artigotag);
                    btn.ForeColor = Color.Black;
                }
            }
            reloadmenu();
            reload();
        }

        void addprato(int artigotag)
        {
            string pratosdefault = "";
            string pratosafter = "";

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            string query = "SELECT MenuPratos FROM menus WHERE MenuData=@MenuData";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@MenuData", datapicker.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                pratosdefault = table.Rows[0][0].ToString();

                if (pratosdefault == "-")
                {
                    pratosafter = artigotag + ",";
                }
                else
                {
                    pratosafter = pratosdefault + artigotag + ",";
                }

                MySqlCommand update_commandr = new MySqlCommand("UPDATE menus SET MenuPratos=@MenuPratos WHERE MenuData=@MenuData", connection);
                update_commandr.Parameters.Add("@MenuPratos", MySqlDbType.VarChar).Value = pratosafter;
                update_commandr.Parameters.Add("@MenuData", MySqlDbType.VarChar).Value = datapicker.Text;
                update_commandr.ExecuteNonQuery();

            }
            else
            {

                MySqlCommand sqlins = new MySqlCommand("INSERT INTO menus (MenuData,MenuPratos,MenuExtras) VALUES (@MenuData,@MenuPratos,@MenuExtras)", connection);
                sqlins.Parameters.AddWithValue("@MenuData", datapicker.Text);
                sqlins.Parameters.AddWithValue("@MenuPratos", artigotag + ",");
                sqlins.Parameters.AddWithValue("@MenuExtras", "-");

                sqlins.ExecuteNonQuery();
            }
        }

        void removepratos(int artigotag)
        {
            string pratosdefault = "";

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            string query = "SELECT MenuPratos FROM menus WHERE MenuData=@MenuData";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@MenuData", datapicker.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                pratosdefault = table.Rows[0][0].ToString();

                string pesquisapessoa = "";
                pesquisapessoa = RemoveSpecificNumber(pratosdefault, artigotag);
                if (pesquisapessoa == "")
                {
                    pesquisapessoa = "-";
                }

                MySqlCommand update_commandr = new MySqlCommand("UPDATE menus SET MenuPratos=@MenuPratos WHERE MenuData=@MenuData ", connection);
                update_commandr.Parameters.Add("@MenuPratos", MySqlDbType.VarChar).Value = pesquisapessoa;
                update_commandr.Parameters.Add("@MenuData", MySqlDbType.VarChar).Value = datapicker.Text;
                update_commandr.ExecuteNonQuery();
            }
        }

        private void BtnExtras_Click(object sender, EventArgs e)
        {
            if (BtnExtras.ForeColor == Color.Black)
            {
                BtnExtras.ForeColor = Color.Red;
                BtnPratosVeg.ForeColor = Color.Black;
                BtnPratoCarne.ForeColor = Color.Black;
                BtnPratosPeixe.ForeColor = Color.Black;
                Global.tipocliente = 2;
                carregaextra();
                reload();
            }
        }

        void carregaextra()
        {
            datapicker.Text = Global.datamenu;

            int x, i, achanumero;
            string stringnumero, achanumeroconverte;
            int altura = 35;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;

            string query = "SELECT * FROM extras WHERE ExtrasAtivo=@ExtrasAtivo";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@ExtrasAtivo", "Sim");

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            x = table.Rows.Count;

            if (x > 0)
            {
                for (i = 0; i < x; i++)
                {

                    System.Windows.Forms.Button btnprato = new System.Windows.Forms.Button();
                    btnprato.Text = table.Rows[i][1].ToString();
                    btnprato.Location = new System.Drawing.Point(0, altura);
                    btnprato.Size = new System.Drawing.Size(200, 35);
                    btnprato.Click += new System.EventHandler(btnaddextra_Click);
                    btnprato.Tag = table.Rows[i][0];
                    btnprato.Cursor = Cursors.Hand;
                    btnprato.Font = new Font("Modern No. 20", 14);
                    btnprato.BackColor = Color.White;
                    btnprato.TextAlign = ContentAlignment.MiddleLeft;
                    btnprato.FlatStyle = FlatStyle.Flat;
                    btnprato.FlatAppearance.BorderSize = 1;

                    string query2 = "SELECT MenuExtras FROM menus WHERE MenuData=@MenuData";

                    MySqlCommand search_command2 = new MySqlCommand(query2, connection);

                    search_command2.Parameters.AddWithValue("@MenuData", datapicker.Text);

                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(search_command2);
                    DataTable table2 = new DataTable();

                    adapter2.Fill(table2);

                    if (table2.Rows.Count > 0)
                    {
                        stringnumero = table2.Rows[0][0].ToString();

                        achanumeroconverte = table.Rows[i][0].ToString();

                        achanumero = Int32.Parse(achanumeroconverte);

                        bool achounumero = FindNumberInString(stringnumero, achanumero);

                        if (achounumero)
                        {
                            btnprato.ForeColor = Color.Red;

                        }
                        else
                        {
                            btnprato.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        btnprato.ForeColor = Color.Black;
                    }

                    System.Windows.Forms.Label LblQuantidade = new System.Windows.Forms.Label();
                    LblQuantidade.Text = table.Rows[i][2].ToString();
                    LblQuantidade.Location = new System.Drawing.Point(200, altura);
                    LblQuantidade.Font = new Font("Modern No. 20", 14);
                    LblQuantidade.BackColor = Color.White;
                    LblQuantidade.AutoSize = false;
                    LblQuantidade.Size = new Size(125, 35);
                    LblQuantidade.TextAlign = ContentAlignment.MiddleLeft;
                    LblQuantidade.BorderStyle = BorderStyle.FixedSingle;

                    System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                    LblPreco.Text = table.Rows[i][3].ToString();
                    LblPreco.Location = new System.Drawing.Point(325, altura);
                    LblPreco.Font = new Font("Modern No. 20", 14);
                    LblPreco.BackColor = Color.White;
                    LblPreco.AutoSize = false;
                    LblPreco.Size = new Size(123, 35);
                    LblPreco.TextAlign = ContentAlignment.MiddleLeft;
                    LblPreco.BorderStyle = BorderStyle.FixedSingle;

                    PanelProdutos.Controls.Add(LblPreco);
                    PanelProdutos.Controls.Add(LblQuantidade);
                    PanelProdutos.Controls.Add(btnprato);

                    altura += 35;
                }

            }
        }

        private void btnaddextra_Click(object sender, EventArgs e)
        {
            int artigotag;
            string converte;
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            converte = btn.Tag.ToString();
            artigotag = Int32.Parse(converte);
            if (btn.ForeColor == Color.Black)
            {
                addextra(artigotag);
                btn.ForeColor = Color.Red;
            }
            else if (btn.ForeColor == Color.Red)
            {
                removeextras(artigotag);
                btn.ForeColor = Color.Black;
            }
            Global.datamenu = datapicker.Text;
            reloadmenu();
            reload();
        }

        void addextra(int artigotag)
        {
            string extradefault = "";
            string extraafter = "";

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            string query = "SELECT MenuExtras FROM menus WHERE MenuData=@MenuData";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@MenuData", datapicker.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                extradefault = table.Rows[0][0].ToString();

                if (extradefault == "-")
                {
                    extraafter = artigotag + ",";
                }
                else
                {
                    extraafter = extradefault + artigotag + ",";
                }

                MySqlCommand update_commandr = new MySqlCommand("UPDATE menus SET MenuExtras=@MenuExtras WHERE MenuData=@MenuData", connection);
                update_commandr.Parameters.Add("@MenuExtras", MySqlDbType.VarChar).Value = extraafter;
                update_commandr.Parameters.Add("@MenuData", MySqlDbType.VarChar).Value = datapicker.Text;
                update_commandr.ExecuteNonQuery();

            }
            else
            {

                MySqlCommand sqlins = new MySqlCommand("INSERT INTO menus (MenuData,MenuPratos,MenuExtras) VALUES (@MenuData,@MenuPratos,@MenuExtras)", connection);
                sqlins.Parameters.AddWithValue("@MenuData", datapicker.Text);
                sqlins.Parameters.AddWithValue("@MenuPratos", "-");
                sqlins.Parameters.AddWithValue("@MenuExtras", artigotag + ",");

                sqlins.ExecuteNonQuery();
            }
        }
        void removeextras(int artigotag)
        {
            string extrasdefault = "";

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;
            connection.Open();

            string query = "SELECT MenuExtras FROM menus WHERE MenuData=@MenuData";

            MySqlCommand search_command = new MySqlCommand(query, connection);

            search_command.Parameters.AddWithValue("@MenuData", datapicker.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(search_command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                extrasdefault = table.Rows[0][0].ToString();

                string pesquisapessoa = "";
                pesquisapessoa = RemoveSpecificNumber(extrasdefault, artigotag);
                if (pesquisapessoa == "")
                {
                    pesquisapessoa = "-";
                }

                MySqlCommand update_commandr = new MySqlCommand("UPDATE menus SET MenuExtras=@MenuExtras WHERE MenuData=@MenuData ", connection);
                update_commandr.Parameters.Add("@MenuExtras", MySqlDbType.VarChar).Value = pesquisapessoa;
                update_commandr.Parameters.Add("@MenuData", MySqlDbType.VarChar).Value = datapicker.Text;
                update_commandr.ExecuteNonQuery();
            }
        }

        void reloadmenu()
        {
            int x, x2;
            int altura = 0;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;

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

                        System.Windows.Forms.Label LblNome = new System.Windows.Forms.Label();
                        LblNome.Text = table3.Rows[0][1].ToString();
                        LblNome.Location = new System.Drawing.Point(0, altura);
                        LblNome.Font = new Font("Modern No. 20", 14);
                        LblNome.BackColor = Color.White;
                        LblNome.AutoSize = false;
                        LblNome.Size = new Size(300, 35);
                        LblNome.TextAlign = ContentAlignment.MiddleLeft;

                        System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                        LblPreco.Text = table3.Rows[0][3].ToString() + "€";
                        LblPreco.Location = new System.Drawing.Point(300, altura);
                        LblPreco.Font = new Font("Modern No. 20", 14);
                        LblPreco.BackColor = Color.White;
                        LblPreco.AutoSize = false;
                        LblPreco.Size = new Size(148, 35);
                        LblPreco.TextAlign = ContentAlignment.MiddleLeft;

                        PanelMenu.Controls.Add(LblPreco);
                        PanelMenu.Controls.Add(LblNome);

                        altura += 35;
                    }
                    else
                    {

                    }
                }
            }

            MySqlConnection connection2 = new MySqlConnection();
            connection.ConnectionString = Global.connectionString;

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

                        System.Windows.Forms.Label LblNome = new System.Windows.Forms.Label();
                        LblNome.Text = table3.Rows[0][1].ToString();
                        LblNome.Location = new System.Drawing.Point(0, altura);
                        LblNome.Font = new Font("Modern No. 20", 14);
                        LblNome.BackColor = Color.White;
                        LblNome.AutoSize = false;
                        LblNome.Size = new Size(300, 35);
                        LblNome.TextAlign = ContentAlignment.MiddleLeft;

                        System.Windows.Forms.Label LblPreco = new System.Windows.Forms.Label();
                        LblPreco.Text = table3.Rows[0][3].ToString() + "€";
                        LblPreco.Location = new System.Drawing.Point(300, altura);
                        LblPreco.Font = new Font("Modern No. 20", 14);
                        LblPreco.BackColor = Color.White;
                        LblPreco.AutoSize = false;
                        LblPreco.Size = new Size(148, 35);
                        LblPreco.TextAlign = ContentAlignment.MiddleLeft;

                        PanelMenu.Controls.Add(LblPreco);
                        PanelMenu.Controls.Add(LblNome);

                        altura += 35;
                    }
                    else
                    {

                    }
                }
            }
        }

        private void datapicker_ValueChanged(object sender, EventArgs e)
        {

        }
        private void BtnPratoCarne_Click(object sender, EventArgs e)
        {
            if (BtnPratoCarne.ForeColor == Color.Black)
            {
                BtnPratoCarne.ForeColor = Color.Red;
                BtnPratosVeg.ForeColor = Color.Black;
                BtnPratosPeixe.ForeColor = Color.Black;
                BtnExtras.ForeColor = Color.Black;
                Global.tipocliente = 1;
                Global.pratotipo = "Carne";
                carregaprato();
                reload();
            }
        }

        private void BtnPratosPeixe_Click(object sender, EventArgs e)
        {
            if (BtnPratosPeixe.ForeColor == Color.Black)
            {
                BtnPratosPeixe.ForeColor = Color.Red;
                BtnPratosVeg.ForeColor = Color.Black;
                BtnPratoCarne.ForeColor = Color.Black;
                BtnExtras.ForeColor = Color.Black;
                Global.tipocliente = 1;
                Global.pratotipo = "Peixe";
                carregaprato();
                reload();
            }
        }

        private void BtnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicar no nome do produto para o adicionar ao menu ou remover");
        }
    }
}
