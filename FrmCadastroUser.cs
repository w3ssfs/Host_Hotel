using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hotel
{
    public partial class FrmCadastroUser : Form
    {


        ClassData db = new ClassData();
        MySqlCommand cmd = new MySqlCommand(); 

        string sqlString;
        string loginAntigo = "";
        string idLogin, role;

        public FrmCadastroUser()
        {
            InitializeComponent();
            GridList();
            disableBtn();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCadastroUser_Load(object sender, EventArgs e)
        {
            ConfigBtn(btnCancel, "#e8175d");
            ConfigBtn(btnSave, "#e8175d");
            ConfigBtn(btnAlter, "#e8175d");
            ConfigBtn(BtnExcluir, "#e8175d");
            ConfigBtn(btnPromo, "#e8175d");
            ConfigBtn(btnCola, "#e8175d");
        }

        private void FormatGrid()
        {
            gridClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridClient.Columns[0].HeaderText = "Id";
            gridClient.Columns[1].HeaderText = "Login";
            gridClient.Columns[2].HeaderText = "Senha";
            gridClient.Columns[3].HeaderText = "Cargo";

            gridClient.Columns[0].Visible = false;
            gridClient.Columns[2].Visible= false;

        }

        private void GridList()
        {
            db.openConn();
            sqlString = "SELECT * FROM login ORDER BY name_login ASC limit 10";
            cmd = new MySqlCommand(sqlString, db.GetConnection());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            gridClient.DataSource = dt;

            db.closeConn();

            FormatGrid();
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCadastro();
            cleanFild();
            GridList();
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            cleanFild();
            disableBtn();
        }

              
        private void FindName(string value)
        {
            try
            {
                db.openConn();
                sqlString = "SELECT * FROM login where name_login LIKE @name_login ORDER BY name_login ASC";
                MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());

                cmd.Parameters.AddWithValue("@name_login", value + "%");

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



        private void SaveCadastro()
        {
            string login = txtLogin.Text.Replace(" ","").Trim();
            string pass = txtSenha.Text.Trim();
            string pass2 = txtSenha2.Text.Trim();

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Digite o LOGIN!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogin.Focus();
                return;
            }

            if (login != loginAntigo)
            {
                if (LoginCadastrado(login))
                {
                    MessageBox.Show("LOGIN já Cadastrado!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLogin.Clear();
                    txtLogin.Focus();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(pass)) {

                MessageBox.Show("Digite a SENHA!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
                return;
            }
            if(pass != pass2)
            {
                MessageBox.Show("SENHAS devem ser IGUAIS !", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
                return;
            }

            SaveLogin(login, pass);

        }

        private bool LoginCadastrado(string login)
        {
            db.openConn();

            sqlString = "SELECT name_login from login WHERE name_login=@name_login";
            cmd = new MySqlCommand(sqlString, db.GetConnection());
            cmd.Parameters.AddWithValue("@name_login", login);

            MySqlDataAdapter data = new MySqlDataAdapter();
            data.SelectCommand = cmd;
            DataTable dt = new DataTable();
            data.Fill(dt);

            db.closeConn();

            return dt.Rows.Count > 0;
        }


        private void SaveLogin(string login, string senha)
        {
            db.openConn();
            string sqlString = "INSERT INTO login(name_login, pass_login) VALUES(@name_login, @pass_login)";
            MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());
            cmd.Parameters.AddWithValue("@name_login", login);
            cmd.Parameters.AddWithValue("@pass_login", senha);
            cmd.ExecuteNonQuery();
            db.closeConn();
            MessageBox.Show("Usuário Criado !", "Cadastro Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateLogin(string login)
        {
            db.openConn();
            sqlString = "UPDATE login SET name_login=@name_login WHERE id_login=@id_login";
            cmd = new MySqlCommand(sqlString, db.GetConnection());
            cmd.Parameters.AddWithValue("@name_login", login);
            cmd.Parameters.AddWithValue("@id_login", idLogin);
            cmd.ExecuteNonQuery();
            db.closeConn();
        }

        private void disableBtn()
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnAlter.Enabled = false;
            btnCola.Enabled = false;
            btnPromo.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void enebBtn()
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = false;
            btnAlter.Enabled = true;
            btnCola.Enabled = true;
            btnPromo.Enabled = true;
            BtnExcluir.Enabled = true;
        }



        private void cleanFild()
        {
            foreach (Control controle in this.Controls)
            {
                if (controle is TextBox)
                {
                    controle.Text = "";
                }

            }
        }


        private void ConfigBtn(Button botao, string corHex)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 2;
            botao.FlatAppearance.BorderColor = ColorTranslator.FromHtml(corHex);
            botao.FlatAppearance.MouseOverBackColor = btnCola.BackColor;
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

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void btnAlter_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Replace(" ", "").Trim();
           
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Digite o LOGIN!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogin.Focus();
                return;
            }

            if (login != loginAntigo)
            {
                if (LoginCadastrado(login))
                {
                    MessageBox.Show("LOGIN já Cadastrado!", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLogin.Clear();
                    txtLogin.Focus();
                    return;
                }
            }
            
            
                UpdateLogin(login);
                cleanFild();
                disableBtn();
                GridList();
                MessageBox.Show("Usuário atualizado!", "Alteração Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
             

        }

        private void gridClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                enebBtn();

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = gridClient.Rows[e.RowIndex];

                    if (row.Cells[0].Value != null)
                    {
                        idLogin = row.Cells[0].Value.ToString();
                        txtLogin.Text = row.Cells[1].Value.ToString();
                        role = row.Cells[3].Value.ToString();

                        if (role == "Colaborador")
                        {
                            enebBtn();
                            btnCola.Enabled = false;
                        }else if (role == "Supervisor")
                        {
                            enebBtn();
                            btnPromo.Enabled = false;
                        }


                    }

                }

            }
            else return;
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var quest = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(quest == DialogResult.Yes)
            {
                try
                {
                    db.openConn();
                    sqlString = "DELETE FROM login WHERE id_login=@id_login";
                    MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());

                    cmd.Parameters.AddWithValue("@id_login", idLogin);
                    cmd.ExecuteNonQuery();
                    db.closeConn();

                    GridList();
                    cleanFild();
                    disableBtn();

                    MessageBox.Show("Usuário Excluido com Sucesso!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir usuário " + ex.Message);
                }
            }
        }

        private void btnCola_Click(object sender, EventArgs e)
        {
            string roles = "Colaborador";
            try
            {
                db.openConn();
                sqlString = "UPDATE login SET role_login=@role WHERE id_login=@id_login";
                MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());

                cmd.Parameters.AddWithValue("@role", roles);
                cmd.Parameters.AddWithValue("@id_login", idLogin);

                cmd.ExecuteNonQuery();
                db.closeConn();

                GridList();
                cleanFild();
                disableBtn();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Promover usuário " + ex.Message);
            }
        }

        private void btnPromo_Click(object sender, EventArgs e)
        {
            string roles = "Supervisor";
            try
            { 
                db.openConn();
                sqlString = "UPDATE login SET role_login=@role WHERE id_login=@id_login";
                MySqlCommand cmd = new MySqlCommand(sqlString, db.GetConnection());

                cmd.Parameters.AddWithValue("@role", roles);
                cmd.Parameters.AddWithValue("@id_login", idLogin);

                cmd.ExecuteNonQuery();
                db.closeConn();

                GridList();
                cleanFild();
                disableBtn();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Promover usuário " + ex.Message);
            }
        }
    }
}
