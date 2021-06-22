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
        private List<String> ling = new List<string>();
        private Dictionary<String,String> countries = new Dictionary<string, string>();
        private Dictionary<String, String> languages = new Dictionary<string, string>();
        private Dictionary<String, String> habLvl  = new Dictionary<string, string>();

        public register_client()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 1950; i <= 2021; i++)
            {
                comboBox5.Items.Add(i);
            }

            comboBox5.SelectedIndex = 71;

            loadNationality();
            loadLanguages();
            loadHabilitationsLevels();
        }

        private void loadLanguages() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Lingua ORDER BY projeto.Lingua.nomeLingua", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox3.Items.Clear();
            comboBox6.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idLingua"].ToString();
                String lang = reader["nomeLingua"].ToString();

                comboBox3.Items.Add(lang);
                comboBox6.Items.Add(lang);
                languages.Add(lang, id);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void loadHabilitationsLevels()
        {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Nivel_Habilitacao", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox4.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idNivel"].ToString();
                String lvl = reader["descricaoNivel"].ToString();

                comboBox4.Items.Add(lvl);
                habLvl.Add(lvl, id);
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Title = "Open CV";
            openFileDialog1.ShowDialog();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Title = "Open CV";
            openFileDialog1.ShowDialog();
            //textBox6.Text = openFileDialog1.SafeFileName;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lang_level client = new lang_level(ling);
            client.ShowDialog();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            String empresa = textBox16.Text;
            String lcz = textBox17.Text;
            String descr = textBox15.Text;
            DateTime start = dateTimePicker2.Value;
            DateTime end = dateTimePicker2.Value;
            this.exprTrb.Add(new ExpTrb(empresa, lcz, descr, start.ToString(), end.ToString()));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String nivel = comboBox4.SelectedItem.ToString();
            String ano = comboBox5.SelectedItem.ToString();
            String curso = textBox14.Text;
            String local = textBox13.Text;
            String nota = textBox12.Text;
            Habilitacao toRemove = null;
            foreach (var h in habl) {
                if (h.getNivel().Equals(nivel)) {
                    toRemove = h;
                }
            }
            if (toRemove != null)
                habl.Remove(toRemove);

            this.habl.Add(new Habilitacao(nivel, ano, curso, local, nota));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!ling.Contains(comboBox6.Text))
                ling.Add(comboBox6.Text);
        }
    }
}
