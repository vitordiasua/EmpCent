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
        private String email;
        public Oferta_regist()
        {
            email = Interaction.InputBox("Insira o seu e-mail.", "Login", "fdportas@sapo.pt");

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
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Recrutador JOIN projeto.Pessoa ON Recrutador.numRegisto = Pessoa.numRegisto WHERE email = @email", Connection.cn);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            String idRecr = reader["numRegisto"].ToString();
            String idEmpr = reader["idEmpresa"].ToString();

            Connection.cn.Close();


            if (radioButton1.Checked)
            {

                if (!Connection.verifySGBDConnection())
                    return;

                DateTime today = DateTime.Today;

                String titulo = textBox1.Text;
                String vagas = textBox2.Text;
                String local = textBox3.Text;
                String duracao = textBox4.Text;
                String observacoes = textBox5.Text;
                ComboBoxItem hab = (ComboBoxItem)comboBox2.SelectedItem;



                SqlCommand cmd2 = new SqlCommand("EXEC insertEstagio @titulo, @vagas, @local, @idEmpresa, @idRecrutador, @habil, @duracao, @obsrv", Connection.cn);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@titulo", titulo);
                cmd2.Parameters.AddWithValue("@vagas", vagas);
                cmd2.Parameters.AddWithValue("@local", local);
                cmd2.Parameters.AddWithValue("@idEmpresa", idEmpr);
                cmd2.Parameters.AddWithValue("@idRecrutador", idRecr);
                cmd2.Parameters.AddWithValue("@habil", hab.getId());
                cmd2.Parameters.AddWithValue("@duracao", duracao);
                cmd2.Parameters.AddWithValue("@obsrv", observacoes);
                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Connection.cn.Close();
            }
            else if (radioButton2.Checked)
            {
                if (!Connection.verifySGBDConnection())
                    return;

                DateTime today = DateTime.Today;

                String nome = textBox1.Text;
                String local = textBox2.Text;
                String descricao = textBox3.Text;

                SqlCommand cmd2 = new SqlCommand("EXEC insertEmprego @nome, @local, @descricao", Connection.cn);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@nome", nome);
                cmd2.Parameters.AddWithValue("@local", local);
                cmd2.Parameters.AddWithValue("@descricao", descricao);
                try
                {
                    cmd2.ExecuteNonQuery();
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
