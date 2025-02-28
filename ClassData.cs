using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;


namespace Hotel
{
    internal class ClassData
    {

        public string connStr;
        public MySqlConnection conn;
        public string msgError;
        public string conec = "Server=localhost;Database=hotel;User Id=root;Password=12345678;SslMode=none;";

        public ClassData()
        {

            try
            {
                conn = new MySqlConnection(conec);
            }
            catch (Exception ex)
            {
                msgError = "Erro Conexão " + ex.Message + "Erro";

            }


        }

        public MySqlConnection GetConnection()
        {
            return conn;
        }

        public void openConn()
        {
            try
            {
                conn.Open();                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar" + ex.Message);
            }
        }

        public void closeConn()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Desconectar" + ex.Message);
            }
        }


        public string TestarConexao()
        {
            try
            {
                conn.Open();
                return "Conectado";
            }
            catch (Exception ex)
            {
                return "Erro ao conectar";
            }
            finally
            {
                conn.Close();
                
            }
        }



    }
}
