using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class FrmCadastro : Form
    {
        string sqlStg;
        string cpfClick;
        ClassData db = new ClassData();
        MySqlCommand cmd = new MySqlCommand();
        string idCliente;
        string img;
        string alterImg = "nao";
        public FrmCadastro()
        {
            InitializeComponent();

        }

        private void FormartarGrid()
        {
            gridClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
            gridClient.Columns[0].HeaderText = "Código";
            gridClient.Columns[1].HeaderText = "Nome";
            gridClient.Columns[2].HeaderText = "Endereço";
            gridClient.Columns[3].HeaderText = "CPF";
            gridClient.Columns[4].HeaderText = "Telefone";
            gridClient.Columns[5].HeaderText = "Imagem";

            gridClient.Columns[0].Visible = false;
            gridClient.Columns[5].Visible = false;  
        }

        private void ListGrid()
        {
            db.openConn();
            sqlStg = "SELECT * FROM cliente ORDER by name_cliente ASC limit 15";
            cmd = new MySqlCommand(sqlStg, db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridClient.DataSource = dt;

            db.closeConn();

            FormartarGrid();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnName_Click(object sender, EventArgs e)
        {
            cleanImag();
            clearFilds(true);
            disableEnable(true);
            txtName.Focus();
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cleanImag();
            ListGrid();

            ConfigBtn(btnCancel, "#e8175d");
            ConfigBtn(btnSave, "#e8175d");
            ConfigBtn(btnAlter, "#e8175d");
            ConfigBtn(btnDelete, "#e8175d");
            ConfigBtn(btnNew, "#e8175d");
            

        }

        private void btnDelete_Click(object sender, EventArgs e)

        {
            var quest = MessageBox.Show("Confirmar Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quest == DialogResult.Yes)
            {
                try
                { 
                    db.openConn();
                    sqlStg = "DELETE FROM cliente WHERE id_cliente=@id";
                    MySqlCommand cmd = new MySqlCommand(sqlStg, db.GetConnection());

                    cmd.Parameters.AddWithValue("@id", idCliente);
                    cmd.ExecuteNonQuery();
                    db.closeConn();
                                        
                    ListGrid();

                    cleanImag();
                    clearFilds(false);
                    disableEnable(false);

                    MessageBox.Show("Cliente Excluido! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir cliente " + ex.Message);
                }
            }           

            


            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearFilds(false);
            disableEnable(false);
            cleanImag();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string cpfcons = ConsCPF(txtCpf.Text);

            if (cpfcons == txtCpf.Text)
            {
                MessageBox.Show("CPF já Cadastrado!" , "Cadastro" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCpf.Focus();
                return;
            }

            if (txtName.Text.ToString().Trim() == "")
            {
                verific("Nome");
                txtName.Text = "";
                txtName.Focus();
                return;

            }else if (txtCpf.Text == "   .   .   -" || txtCpf.Text.Length < 14 )
            {
                verific("CPF");
                txtCpf.Focus();
                return;
            }
            else if(txtPhone.Text == "(   )      -" || txtPhone.Text.Length < 15)
            {
                verific("Telefone");
                txtPhone.Focus();
                return;
            }
            else
            {
                db.openConn();
                sqlStg = "insert into cliente (name_cliente, address_cliente, cpf_cliente, phone_cliente, image_cliente) values (@name_cliente, @address_cliente, @cpf_cliente, @phone_cliente, @image_cliente)";
                cmd = new MySqlCommand(sqlStg, db.GetConnection());
                cmd.Parameters.AddWithValue("@name_cliente", txtName.Text);
                cmd.Parameters.AddWithValue("@address_cliente", txtAddress.Text);
                cmd.Parameters.AddWithValue("@cpf_cliente", txtCpf.Text);
                cmd.Parameters.AddWithValue("@phone_cliente", txtPhone.Text);
                cmd.Parameters.AddWithValue("@image_cliente", sendImage());
                cmd.ExecuteNonQuery();
                db.closeConn();

                clearFilds(false);
                disableEnable(false);

                cleanImag();
                ListGrid();
                MessageBox.Show("Cliente Salvo com sucesso!", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            
        }

        // Limpa os Campos
        private void clearFilds(bool value)
        {
            foreach (Control controle in this.Controls)
            {
                if (controle is TextBox || controle is MaskedTextBox)
                {
                    controle.Text = "";
                    txtPhone.Enabled = value;
                    txtCpf.Enabled = value;
                    txtName.Enabled = value;
                    txtAddress.Enabled = value;
                }

            }
        }

        // Desabilita/Habilita Botões
        private void disableEnable(bool value)
        {
            if (value is false)
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAlter.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void AlterCancel(bool value)
        {
            if (value is false)
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAlter.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnAlter.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void verific(string value)
        {
            MessageBox.Show($"Obrigatório: {value}");
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {

            string cpfcons = ConsCPF(txtCpf.Text);

            if (cpfcons == txtCpf.Text && cpfClick != txtCpf.Text)
            {
                MessageBox.Show("CPF já Cadastrado!", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCpf.Focus();
                return;
            }

            if (txtName.Text.ToString().Trim() == "")
            {
                verific("Nome");
                txtName.Text = "";
                txtName.Focus();
                return;

            }
            else if (txtCpf.Text == "   .   .   -" || txtCpf.Text.Length < 14)
            {
                verific("CPF");
                txtCpf.Focus();
                return;
            }
            else if (txtPhone.Text == "(   )      -" || txtPhone.Text.Length < 15)
            {
                verific("Telefone");
                txtPhone.Focus();
                return;
            }
            else
            {

                db.openConn();

                if (alterImg == "sim")
                {
                    sqlStg = "UPDATE cliente SET name_cliente=@name_cliente, address_cliente=@address_cliente,\r\n cpf_cliente=@cpf_cliente, phone_cliente=@phone_cliente, image_cliente=@image_cliente where id_cliente = @id_cliente;";
                    cmd = new MySqlCommand(sqlStg, db.GetConnection());
                    cmd.Parameters.AddWithValue("@name_cliente", txtName.Text);
                    cmd.Parameters.AddWithValue("@address_cliente", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@cpf_cliente", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@phone_cliente", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@image_cliente", sendImage());
                }else if (alterImg == "nao")
                {
                    sqlStg = "UPDATE cliente SET name_cliente=@name_cliente, address_cliente=@address_cliente,\r\n cpf_cliente=@cpf_cliente, phone_cliente=@phone_cliente where id_cliente = @id_cliente;";
                    cmd = new MySqlCommand(sqlStg, db.GetConnection());
                    cmd.Parameters.AddWithValue("@name_cliente", txtName.Text);
                    cmd.Parameters.AddWithValue("@address_cliente", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@cpf_cliente", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@phone_cliente", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                }

                cmd.ExecuteNonQuery();
                db.closeConn();

                clearFilds(false);
                cleanImag();
                disableEnable(false);

                ListGrid();
                MessageBox.Show("Cliente Alterado com sucesso!","Alterado",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private string ConsCPF(string value)
        {
            string cpfFind = null;

            try
            {
                db.openConn();

                sqlStg = "select cpf_cliente from cliente where cpf_cliente = @cpf_cliente;";
                cmd = new MySqlCommand(sqlStg, db.GetConnection());
                cmd.Parameters.AddWithValue("@cpf_cliente", value);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    cpfFind = result.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro na consulta: " + ex.Message, "erro", MessageBoxButtons.OK);

            }
            finally { 
                db.closeConn();
            }

            return cpfFind;


        }

        private void gridClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.RowIndex > -1)
            {
                cleanImag();
                AlterCancel(true);
                txtPhone.Enabled = true;
                txtCpf.Enabled = true;
                txtName.Enabled = true;
                txtAddress.Enabled = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = gridClient.Rows[e.RowIndex];

                    if (row.Cells[0].Value != null)
                    {
                        idCliente = row.Cells[0].Value.ToString();
                        txtName.Text = row.Cells[1].Value.ToString();
                        txtAddress.Text = row.Cells[2].Value.ToString();
                        txtCpf.Text = row.Cells[3].Value.ToString();
                        cpfClick = row.Cells[3].Value.ToString();
                        txtPhone.Text = row.Cells[4].Value.ToString();

                        if (row.Cells[5].Value != null && row.Cells[5].Value != DBNull.Value)
                        {
                            try
                            {
                                byte[] image = (byte[])row.Cells[5].Value;

                                if (image.Length > 0)
                                {
                                    Console.WriteLine($"Tamanho da imagem: {image.Length} bytes");
                                    alterImg = "nao";

                                    using (MemoryStream ms = new MemoryStream(image))
                                    {
                                        try
                                        {
                                            pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show($"Erro ao converter imagem: {ex.Message}");
                                            pictureBox1.Image = Properties.Resources.Female_User;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Imagem vazia!");
                                    pictureBox1.Image = Properties.Resources.Female_User;
                                }
                            }
                            catch (InvalidCastException)
                            {
                                MessageBox.Show("Erro ao converter campo de imagem para byte[]");
                                pictureBox1.Image = Properties.Resources.Female_User;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro inesperado: {ex.Message}");
                                pictureBox1.Image = Properties.Resources.Female_User;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Campo de imagem nulo ou não preenchido.");
                            pictureBox1.Image = Properties.Resources.Female_User;
                        }

                    }
                }
            }
            else
            {
                return;
            }


            
            
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FindName(txtFind.Text);
            }catch (Exception ex)
            {
                MessageBox.Show("Erro ao Buscar cliente! ", ex.Message);
            }
        }

        private void FindName(string value)
        {
            try
            {
                db.openConn();
                sqlStg = "SELECT * FROM cliente where name_cliente LIKE @name_cliente ORDER BY name_cliente ASC";
                MySqlCommand cmd = new MySqlCommand(sqlStg, db.GetConnection());

                cmd.Parameters.AddWithValue("@name_cliente", value + "%");
 
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                gridClient.DataSource = dt;
                db.closeConn();

               
                FormartarGrid();
            }
            catch (Exception ex){
                MessageBox.Show("Erro ao Buscar cliente no Banco! ",ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            

            file.Filter = "Imagens(*.jpg; *.png;) | *.jpg; *.png";

            if(file.ShowDialog() == DialogResult.OK)
            {
                img = file.FileName.ToString();

                pictureBox1.ImageLocation = img;
                alterImg = "sim";

            }

        }

        private byte[] sendImage()
        {

            byte[] imgByte = null;

            if(img == "")
            {
                return null;
            }

            FileStream fs = new FileStream(img,FileMode.Open,FileAccess.Read);
            
            BinaryReader br = new BinaryReader(fs);
            
            imgByte = br.ReadBytes((int)fs.Length);

            return imgByte;
            

        }

        private void cleanImag()
        {
            pictureBox1.Image =  Properties.Resources.Female_User;
            img = "image/Female_User.png";
        }

        private void txtCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        private void ConfigBtn(Button botao, string corHex)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 2;
            botao.FlatAppearance.BorderColor = ColorTranslator.FromHtml(corHex);
            botao.FlatAppearance.MouseOverBackColor = btnAlter.BackColor;
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


    }
}
