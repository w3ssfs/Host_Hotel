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
    public partial class FrmLogin : Form
    {
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
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.ShowDialog();

            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
