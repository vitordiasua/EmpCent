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
    public partial class register_recruiter : Form
    {
        private String idRec = null;

        public register_recruiter(String email = null)
        {
            InitializeComponent();

            loadEmpresas();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            if (email != null) {
                if (!Connection.verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand("SELECT Pessoa.numRegisto as numRegisto, primeiroNome, nomesMeio, ultimoNome, dataNascimento, telefone, sexo, email, metodoDeSelecao, idEmpresa " + 
                    "FROM projeto.Pessoa JOIN projeto.Recrutador ON Pessoa.numRegisto = Recrutador.numRegisto", Connection.cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    String idRec = reader["numRegisto"].ToString();
                    String primeiroNome = reader["primeiroNome"].ToString();
                    String nomesMeio = reader["nomesMeio"].ToString();
                    String ultimoNome = reader["ultimoNome"].ToString();
                    dateTimePicker1.Value = (DateTime)reader["dataNascimento"].ToString();
                    String telefone = reader["telefone"].ToString();
                    String sexo = reader["sexo"].ToString();
                    String metodoDeSelecao = reader["metodoDeSelecao"].ToString();
                    String idEmpresa = reader["idEmpresa"].ToString();

                    textBox1.Text = primeiroNome;
                    textBox2.Text = nomesMeio;
                    textBox3.Text = ultimoNome;
                    textBox4.Text = telefone;
                    textBox5.Text = emailAns;
                    textBox6.Text = metodoDeSelecao;
                    comboBox1.SelectedIndex = Int32.Parse(sexo);
                    comboBox3.SelectedIndex = Int32.Parse(idEmpresa);

                    button6.Text = "Atualizar";
                }
  
                Connection.cn.Close();
            }
        }

        public void loadEmpresas() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Empresa", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox3.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idEmpresa"].ToString();
                String nome = reader["nome"].ToString();
                ComboBoxItem cb = new ComboBoxItem(id, nome);
                comboBox3.Items.Add(cb);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Connection.verifySGBDConnection())
                return;

            if (idRec == null)
            {

                int numRegisto = 0;

                SqlCommand cmd = new SqlCommand("EXEC insertRecrutador @primeiroNome, @nomesMeio, @ultimoNome, @data, @tele, @sexo, @email, @metodoDeSelecao, @idEmpresa", Connection.cn);
                cmd.Parameters.AddWithValue("@primeiroNome", textBox1.Text);
                cmd.Parameters.AddWithValue("@nomesMeio", textBox2.Text);
                cmd.Parameters.AddWithValue("@ultimoNome", textBox3.Text);
                SqlParameter dataNascimento = cmd.Parameters.Add("@data", SqlDbType.Date);
                dataNascimento.Value = dateTimePicker1.Value;
                cmd.Parameters.AddWithValue("@tele", textBox4.Text);
                cmd.Parameters.AddWithValue("@sexo", comboBox1.SelectedIndex);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@metodoDeSelecao", textBox6.Text);
                cmd.Parameters.AddWithValue("@idEmpresa", comboBox3.SelectedIndex + 1);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recrutador adicionado");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    comboBox1.Text = "";
                    comboBox3.Text = "";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { 
            
            }

            Connection.cn.Close();
        }

        private void register_recruiter_Load(object sender, EventArgs e)
        {

        }
    }
}
