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
    public partial class lang_level : Form
    {

        public static Dictionary<String, String> langLevels = new Dictionary<string, string>();
        public static List<LangLevels> selected = new List<LangLevels>();
        
        public lang_level(List<String> lang)
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            foreach (var h in lang) {
                comboBox1.Items.Add(h);
            }

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Nivel_Lingua", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            langLevels.Clear();

            while (reader.Read())
            {
                String id = reader["idNivel"].ToString();
                String descr = reader["descricaoNivel"].ToString();

                comboBox3.Items.Add(descr);
                comboBox4.Items.Add(descr);
                comboBox5.Items.Add(descr);
                langLevels.Add(descr, id);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            String lang = comboBox1.Text;
            String write = comboBox3.Text;
            String read = comboBox4.Text;
            String oral = comboBox5.Text;
            String cv = comboBox5.Text;
            LangLevels toRemove = null;
            foreach (var h in selected)
            {
                if (h.getLang().Equals(lang))
                {
                   toRemove = h;
                }
            }
            if (toRemove != null)
                selected.Remove(toRemove);
            selected.Add(new LangLevels(lang, write, read, oral, cv));
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }

        public static List<LangLevels> getSelected() {
            return selected;
        }
    }
}
