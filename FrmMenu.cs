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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void MenuCliente_Click(object sender, EventArgs e)
        {
            FrmCadastro frmCadastro = new FrmCadastro();   
            frmCadastro.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroUser frmCadastroUser = new FrmCadastroUser();
            frmCadastroUser.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
