using Microsoft.VisualBasic;
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
    public partial class Oferta_regist : Form
    {
        public Oferta_regist()
        {
            String email = Interaction.InputBox("Insira o seu e-mail.", "Login", "fdportas@sapo.pt");

            InitializeComponent();

            loadHabilitacoes();
        }

        public void loadHabilitacoes() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Nivel_Habilitacao", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox2.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idNivel"].ToString();
                String lvl = reader["descricaoNivel"].ToString();
                ComboBoxItem itm = new ComboBoxItem(id, lvl);
                comboBox2.Items.Add(itm);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void Oferta_regist_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                DateTime today = DateTime.Today;
                if (!Connection.verifySGBDConnection())
                    return;

                String titulo = textBox1.Text;
                String vagas = textBox2.Text;
                String local = textBox3.Text;
                String duracao = textBox4.Text;
                String observacoes = textBox5.Text;
                String l1 = textBox6.Text;
                String l2 = comboBox1.SelectedItem.ToString();
                Habilitacao l3 = (Habilitacao)comboBox2.SelectedItem;



                SqlCommand cmd = new SqlCommand("EXEC insertEstagio @nome, @local, @descricao", Connection.cn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome",l1);
                cmd.Parameters.AddWithValue("@local", local);
                cmd.Parameters.AddWithValue("@descricao", l2);
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
            else if (radioButton2.Checked) {
                DateTime today = DateTime.Today;
                if (!Connection.verifySGBDConnection())
                    return;

                String nome = textBox1.Text;
                String local = textBox2.Text;
                String descricao = textBox3.Text;

                SqlCommand cmd = new SqlCommand("EXEC insertEmprego @nome, @local, @descricao", Connection.cn);
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label6.Visible = true;
                textBox4.Visible = true;
                label7.Visible = true;
                textBox5.Visible = true;
                label6.Text = "Duração";
                label7.Text = "Observações";
                label8.Visible = false;
                textBox6.Visible = false;
                label9.Visible = false;
                comboBox1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label6.Visible = true;
                textBox4.Visible = true;
                label7.Visible = true;
                textBox5.Visible = true;
                label6.Text = "Salário";
                label7.Text = "Descrição do Emprego";
                label8.Visible = true;
                textBox6.Visible = true;
                label9.Visible = true;
                comboBox1.Visible = true;
            }
        }
    }
}
