using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class FrmLogin : Form
    {

        ClassData db = new ClassData();
        MySqlCommand cmd = new MySqlCommand();
        string SqlString;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

            ConfigBtn(btnEntrar, "#e8175d");
            ConfigBtn(btnSair, "#e8175d");


        }

        private void ConfigBtn(Button botao, string corHex)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 2;
            botao.FlatAppearance.BorderColor = ColorTranslator.FromHtml(corHex);
            botao.FlatAppearance.MouseOverBackColor = btnEntrar.BackColor;
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Replace(" ", "").Trim();
            string pass = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Digite o LOGIN!", "Campos Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogin.Focus();
                return;
            }

            try
            {
                db.openConn();
                SqlString = "SELECT name_login, pass_login FROM login WHERE name_login=@name_login and pass_login=@pass_login";
                cmd = new MySqlCommand(SqlString, db.GetConnection());

                cmd.Parameters.AddWithValue("@name_login", login);
                cmd.Parameters.AddWithValue("@pass_login", pass);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows) 
                    {
                        FrmMenu frmMenu = new FrmMenu();                        
                        frmMenu.ShowDialog();
                        
                        txtLogin.Clear();
                        txtPass.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou Senha Inválidos!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPass.Clear();
                    }
                }

                db.closeConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Abrir Conexão" + ex.Message);
            }



        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
