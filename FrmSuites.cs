using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class FrmSuites : Form
    {

        ClassData db = new ClassData();
        MySqlCommand cmd = new MySqlCommand();

        string sqlString;
        string suiteAntigo, status;
        string idLogin = "";
        public FrmSuites()
        {
            InitializeComponent();
            GridList();
            enebBtn(false);
            btnSave.Enabled = true;
        }


        private void FormatGrid()
        {
            gridClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridClient.Columns[0].HeaderText = "Id";
            gridClient.Columns[1].HeaderText = "Suite";
            gridClient.Columns[2].HeaderText = "Descrição";
            gridClient.Columns[3].HeaderText = "Valor";
            gridClient.Columns[4].HeaderText = "Imagem";
            gridClient.Columns[5].HeaderText = "Status";

            gridClient.Columns[0].Visible = false;
            gridClient.Columns[2].Visible = false;
            gridClient.Columns[3].Visible = false;
            gridClient.Columns[4].Visible = false;


        }

        private void GridList()
        {
            db.openConn();
            sqlString = "SELECT * FROM suite ORDER BY name_suite ASC limit 10";
            cmd = new MySqlCommand(sqlString, db.GetConnection());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            gridClient.DataSource = dt;

            db.closeConn();

            FormatGrid();
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidaSuite();
            GridList();
        }

        private void FrmSuites_Load(object sender, EventArgs e)
        {
            ConfigBtn(btnCancel, "#e8175d");
            ConfigBtn(btnSave, "#e8175d");
            ConfigBtn(btnDisp, "#e8175d");
            ConfigBtn(btnIndispo, "#e8175d");
            ConfigBtn(btnAlter, "#e8175d");
        }

        private void ConfigBtn(Button botao, string corHex)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 2;
            botao.FlatAppearance.BorderColor = ColorTranslator.FromHtml(corHex);
            botao.FlatAppearance.MouseOverBackColor = btnCancel.BackColor;
            botao.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml(corHex);

            botao.MouseDown += btn_Down;
            botao.MouseUp += btn_Up;
        }

        private void btn_Down(object sender, MouseEventArgs e)
        {
            var botao = (Button)sender;
            botao.ForeColor = ColorTranslator.FromHtml("#474747");
            botao.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#e8175d");
        }
        private void btn_Up(object sender, MouseEventArgs e)
        {
            var botao = (Button)sender;
            botao.ForeColor = ColorTranslator.FromHtml("#e8175d");
            botao.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#e8175d");
        }



        private void ValidaSuite()
        {
            string suiteName = txtName.Text.Replace(" ", "").Trim();
            string suiteDesc = txtDescricao.Text.Trim();
            string suiteValue = mtbValue.Text;
            

            if (string.IsNullOrWhiteSpace(suiteName))
            {
                MessageBox.Show("Digite o Nome da Suite!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
                return;
            }else if (suiteName != suiteAntigo)
            {
                if (VerificaSuite(suiteName))
                {
                    MessageBox.Show("Suite já Cadastrada!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Clear();
                    txtName.Focus();
                    return;
                }
            }


            if (string.IsNullOrWhiteSpace(suiteDesc))
            {
                MessageBox.Show("Digite a Descrição!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescricao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(suiteValue) )
            {
                MessageBox.Show("Digite o Valor!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mtbValue.Focus();
                return;
            }

            SaveSuite(txtName.Text, suiteDesc, suiteValue);

        }


        private void SaveSuite(string suiteNome, string suiteDesc, string suiteValue)
        {
            db.openConn();
            sqlString = "INSERT INTO suite(name_suite, desc_suite, price_suite, image_suite) value (@name_suite, @desc_suite, @price_suite, @image_suite)";
            cmd = new MySqlCommand(sqlString, db.GetConnection());
            cmd.Parameters.AddWithValue("@name_suite", suiteNome);
            cmd.Parameters.AddWithValue("@desc_suite", suiteDesc);
            cmd.Parameters.AddWithValue("@price_suite", suiteValue);
            cmd.Parameters.AddWithValue("@image_suite", null);

            cmd.ExecuteNonQuery();
            db.closeConn();

            MessageBox.Show("Suite Criada !", "Cadastro Suite", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearFilds();
        }

        private bool VerificaSuite(string suiteName)
        {
            db.openConn();
            sqlString = "SELECT name_suite from suite WHERE name_suite=@name_suite";
            cmd = new MySqlCommand(sqlString, db.GetConnection());
            cmd.Parameters.AddWithValue("@name_suite", suiteName);

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            db.closeConn();

            return dt.Rows.Count > 0;

        }

        private void clearFilds()
        {
            foreach (Control controle in this.Controls)
            {
                if (controle is TextBox || controle is MaskedTextBox)
                {
                    controle.Text = "";
                    
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearFilds();
            enebBtn(false);
            btnSave.Enabled = true;
            btnAlter.Enabled = false;

        }

        private void enebBtn(bool value)
        {
            btnDisp.Enabled = value;
            btnIndispo.Enabled = value;
            btnAlter.Enabled = value;
            
        }

        private void btnIndispo_Click(object sender, EventArgs e)
        {
            string statusSuite = "Indisponivel";
            try
            {
                db.openConn();
                sqlString = "UPDATE suite SET status_suite=@statusSuite WHERE id_suite=@id_suite";
                MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());

                cmd.Parameters.AddWithValue("@statusSuite", statusSuite);
                cmd.Parameters.AddWithValue("@id_suite", idLogin);

                cmd.ExecuteNonQuery();
                db.closeConn();

                GridList();
                clearFilds();
                enebBtn(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Promover usuário " + ex.Message);
            }
        }

        private void btnDisp_Click(object sender, EventArgs e)
        {
            string statusSuite = "Disponivel";
            try
            {
                db.openConn();
                sqlString = "UPDATE suite SET status_suite=@statusSuite WHERE id_suite=@id_suite";
                MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());

                cmd.Parameters.AddWithValue("@statusSuite", statusSuite);
                cmd.Parameters.AddWithValue("@id_suite", idLogin);

                cmd.ExecuteNonQuery();
                db.closeConn();

                GridList();
                clearFilds();
                enebBtn(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Promover usuário " + ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FindName(txtFind.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Buscar cliente! ", ex.Message);
            }
        }

        private void FindName(string value)
        {
            try
            {
                db.openConn();
                sqlString = "SELECT * FROM suite where name_suite LIKE @name_suite ORDER BY name_suite ASC";
                MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());

                cmd.Parameters.AddWithValue("@name_suite", value + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                gridClient.DataSource = dt;
                db.closeConn();


                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Buscar Usuário no Banco! ", ex.Message);
            }
        }

        private void gridClient_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                enebBtn(true);
                btnSave.Enabled = false;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = gridClient.Rows[e.RowIndex];

                    if (row.Cells[0].Value != null)
                    {
                        idLogin = row.Cells[0].Value.ToString();
                        txtName.Text = row.Cells[1].Value.ToString();
                        txtDescricao.Text = row.Cells[2].Value.ToString();
                        mtbValue.Text = row.Cells[3].Value.ToString();
                        status = row.Cells[5].Value.ToString();
                        suiteAntigo = row.Cells[1].Value.ToString();

                        if (status == "Disponivel")
                        {
                            enebBtn(true);
                            btnDisp.Enabled = false;
                        }
                        else if (status == "Indisponivel")
                        {
                            enebBtn(true);
                            btnIndispo.Enabled = false;
                        }


                    }

                }

            }
            else return;
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            string suite = txtName.Text.Replace(" ", "").Trim();
            string suiteDesc = txtDescricao.Text.Trim();
            string suiteValue = mtbValue.Text;

            if (string.IsNullOrWhiteSpace(suite))
            {
                MessageBox.Show("Digite o Nome da Suite!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
                return;
            }

            if (suite != suiteAntigo)
            {
                if (VerificaSuite(suite))
                {
                    MessageBox.Show("Suite já Cadastrado!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Clear();
                    txtName.Focus();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(suiteDesc))
            {
                MessageBox.Show("Digite a Descrição!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescricao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(suiteValue))
            {
                MessageBox.Show("Digite o Valor!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mtbValue.Focus();
                return;
            }


            UpdateSuite(txtName.Text, suiteDesc, suiteValue);
            clearFilds();
            enebBtn(false);
            btnAlter.Enabled = false;
            GridList();
            MessageBox.Show("Suite atualizada!", "Alteração Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void UpdateSuite(string suite, string desc, string value)
        {
            db.openConn();
            sqlString = "UPDATE suite SET name_suite=@name_suite, desc_suite=@desc_suite, price_suite=@price_suite WHERE id_suite=@id";
            cmd = new MySqlCommand(sqlString, db.GetConnection());
            cmd.Parameters.AddWithValue("@name_suite", suite);
            cmd.Parameters.AddWithValue("@desc_suite", desc);
            cmd.Parameters.AddWithValue("@price_suite", value);
            cmd.Parameters.AddWithValue("@id", idLogin);
            cmd.ExecuteNonQuery();
            db.closeConn();
        }

        private void gridClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }




    }
}
