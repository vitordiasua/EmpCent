using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpCent
{
    public partial class register_comp : Form
    {
        public register_comp()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Connection.verifySGBDConnection())
                return;

            String nome = textBox1.Text;
            String local = textBox2.Text;
            String descricao = textBox3.Text;

            SqlCommand cmd = new SqlCommand("EXEC insertEmpresa @nome, @local, @descricao", Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@local", local);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
               
            Connection.cn.Close();
        }
    }
}
