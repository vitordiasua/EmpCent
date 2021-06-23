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
    public partial class register_client : Form
    {
        private List<Habilitacao> habl = new List<Habilitacao>();
        private List<ExpTrb> exprTrb = new List<ExpTrb>();
        private List<LangLevels> langLevels = new List<LangLevels>();
        private Dictionary<String,String> countries = new Dictionary<string, string>();
        private Dictionary<String, String> languages = new Dictionary<string, string>();

        public register_client()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            loadNationality();
            loadLanguages();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
   
        private void loadLanguages() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Lingua ORDER BY projeto.Lingua.nomeLingua", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox3.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idLingua"].ToString();
                String lang = reader["nomeLingua"].ToString();

                languages.Add(lang, id);

                comboBox3.Items.Add(lang);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void loadNationality() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Nacionalidade ORDER BY projeto.Nacionalidade.nomeNacionalidade", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox2.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idNacionalidade"].ToString();
                String nac = reader["nomeNacionalidade"].ToString();

                comboBox2.Items.Add(nac);
                countries.Add(nac, id);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Title = "Open CV";
            openFileDialog1.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Title = "Open CV";
            openFileDialog1.ShowDialog();
            //textBox6.Text = openFileDialog1.SafeFileName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var form = new ClienteExpTrab())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ExpTrb exp = form.getExp();
                    this.exprTrb.Add(exp);
                    listBox3.Items.Add(exp.getEmpresa());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var form = new ClienteHabAca())
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    Habilitacao hab = form.getHab();
                    this.habl.Add(hab);
                    listBox1.Items.Add(hab.nome);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var form = new ClienteLangLevel())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LangLevels langLevels = form.GetLangLevels();
                    this.langLevels.Add(langLevels);
                    listBox2.Items.Add(langLevels.getLang());
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Title = "Open CV";
            openFileDialog1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Connection.verifySGBDConnection())
                return;

            int numRegisto = 0;

            SqlCommand cmd;

            cmd = new SqlCommand("insertDesempregado", Connection.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@primeiroNome", textBox1.Text);
            cmd.Parameters.AddWithValue("@nomesMeio", textBox2.Text);
            cmd.Parameters.AddWithValue("@ultimoNome", textBox3.Text);
            SqlParameter dataNascimento = cmd.Parameters.Add("@dataNascimento", SqlDbType.Date);
            dataNascimento.Value = dateTimePicker1.Value;
            cmd.Parameters.AddWithValue("@telefone", textBox4.Text);
            cmd.Parameters.AddWithValue("@sexo", comboBox1.SelectedIndex);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.Parameters.AddWithValue("@idLinguaMaterna", languages[comboBox3.SelectedItem.ToString()]);
            cmd.Parameters.AddWithValue("@rua", textBox7.Text);
            cmd.Parameters.AddWithValue("@codigoPostal", textBox8.Text);
            cmd.Parameters.AddWithValue("@localidade", textBox9.Text);
            cmd.Parameters.AddWithValue("@descricao", textBox10.Text);
            cmd.Parameters.AddWithValue("@idNacionalidade", countries[comboBox2.SelectedItem.ToString()]);

            SqlParameter returnValue = new SqlParameter("@numRegisto", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnValue);
            cmd.ExecuteNonQuery();
            
            numRegisto = (int)cmd.Parameters["@numRegisto"].Value;
            

            foreach(Habilitacao hab in habl){
                cmd = new SqlCommand("exec insertHabilitacaoAcademica @numRegisto, @nomeCurso, @estabelecimentoEnsino, @idNivelHabilitacao, @anoConclusao, @notaFinal", Connection.cn);
                cmd.Parameters.AddWithValue("@numRegisto", numRegisto);
                cmd.Parameters.AddWithValue("@nomeCurso", hab.curso);
                cmd.Parameters.AddWithValue("@estabelecimentoEnsino", hab.local);
                cmd.Parameters.AddWithValue("@idNivelHabilitacao", hab.nivel);
                cmd.Parameters.AddWithValue("@anoConclusao", hab.ano);
                cmd.Parameters.AddWithValue("@notaFinal", hab.nota);

                cmd.ExecuteNonQuery();

            }
            SqlParameter dataInicio, dataFim;
            foreach (ExpTrb exp in exprTrb)
            {
                cmd = new SqlCommand("exec insertExperienciaTrabalho @numRegisto, @titulo, @dataInicio, @dataFim, @localizacao, @empresa", Connection.cn);
                cmd.Parameters.AddWithValue("@numRegisto", numRegisto);
                cmd.Parameters.AddWithValue("@titulo", exp.titulo);
                dataInicio = cmd.Parameters.Add("@dataInicio", SqlDbType.Date);
                dataInicio.Value = exp.inicio;
                dataFim = cmd.Parameters.Add("@dataFim", SqlDbType.Date);
                dataFim.Value = exp.fim;
                cmd.Parameters.AddWithValue("@localizacao", exp.locl);
                cmd.Parameters.AddWithValue("@empresa", exp.empresa);

                cmd.ExecuteNonQuery();

            }

            foreach (LangLevels lang in langLevels)
            {
                cmd = new SqlCommand("exec insertFala @numRegisto, @nomeLingua, @nivelLeitura, @nivelEscrita, @nivelOral", Connection.cn);
                cmd.Parameters.AddWithValue("@numRegisto", numRegisto);
                cmd.Parameters.AddWithValue("@nomeLingua", lang.lang);
                cmd.Parameters.AddWithValue("@nivelLeitura", lang.read);
                cmd.Parameters.AddWithValue("@nivelEscrita", lang.write);
                cmd.Parameters.AddWithValue("@nivelOral", lang.oral);

                cmd.ExecuteNonQuery();
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }
    }
}
