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
        private String id;
        private String emp;

        public register_comp(String empresa = null)
        {
            InitializeComponent();

            if (empresa != null) {
                if (!Connection.verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Empresa WHERE nome = @nome", Connection.cn);
                cmd.Parameters.AddWithValue("@nome", empresa);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader["idEmpresa"].ToString();
                    String nome = reader["nome"].ToString();
                    String localizacao = reader["localizacao"].ToString();
                    String descricao = reader["descricao"].ToString();
                    textBox1.Text = nome;
                    textBox2.Text = localizacao;
                    textBox3.Text = descricao;
                }

                Connection.cn.Close();
                Connection.tableIndex = 0;

                button6.Text = "Alterar";

                emp = empresa;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (emp == null)
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
                    MessageBox.Show("Empresa Registada");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Connection.cn.Close();
            }
            else
            {
                if (!Connection.verifySGBDConnection())
                    return;

                String nome = textBox1.Text;
                String local = textBox2.Text;
                String descricao = textBox3.Text;

                SqlCommand cmd = new SqlCommand("UPDATE projeto.Empresa SET nome =  @nome, localizacao = @local, descricao = @descricao WHERE idEmpresa = @id", Connection.cn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@local", local);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                var parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = Int32.Parse(id);
                cmd.Parameters.Add(parameter);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Informação Alterada");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Connection.cn.Close();

            }
        }
    }
}
