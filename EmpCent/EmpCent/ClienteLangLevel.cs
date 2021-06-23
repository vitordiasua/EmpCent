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
    public partial class ClienteLangLevel : Form
    {

        public LangLevels langLevels;
        private Dictionary<String, String> lvls = new Dictionary<string, string>();

        public LangLevels GetLangLevels()
        {
            return this.langLevels;
        }
        
        public ClienteLangLevel()
        {
            InitializeComponent();

            loadLanguageLevels();
            loadLanguages();
        }

        private void loadLanguages()
        {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Lingua ORDER BY projeto.Lingua.nomeLingua", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idLingua"].ToString();
                String lang = reader["nomeLingua"].ToString();

                comboBox1.Items.Add(lang);
                lvls.Add(lang, id);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void loadLanguageLevels()
        {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Nivel_Lingua", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();

            while (reader.Read())
            {
                String descr = reader["descricaoNivel"].ToString();

                comboBox3.Items.Add(descr);
                comboBox4.Items.Add(descr);
                comboBox5.Items.Add(descr);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            String id = lvls[comboBox1.SelectedItem.ToString()];
            String lang = comboBox1.SelectedItem.ToString();
            int tempWrite = comboBox3.SelectedIndex + 1;
            String write = tempWrite.ToString();
            int tempRead = comboBox4.SelectedIndex + 1;
            String read = tempRead.ToString();
            int tempOral = comboBox5.SelectedIndex + 1;
            String oral = tempOral.ToString();

            this.langLevels = new LangLevels(lang, write, read, oral, "", id);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
