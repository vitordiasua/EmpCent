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
    public partial class ClienteHabAca : Form
    {
        public Habilitacao hab;


        public Habilitacao getHab()
        {
            return this.hab;
        }

        public ClienteHabAca()
        {
            InitializeComponent();
        }

        private void ClienteHabAca_Load(object sender, EventArgs e)
        {
            loadHabilitationsLevels();
            for (int i = 1950; i <= 2021; i++)
            {
                comboBox5.Items.Add(i);
            }

            comboBox5.SelectedIndex = 71;
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
                String lvl = reader["descricaoNivel"].ToString();

                comboBox4.Items.Add(lvl);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String nome = comboBox4.SelectedItem.ToString();
            int tempNivel = comboBox4.SelectedIndex + 1;
            String nivel = tempNivel.ToString();
            String curso = textBox14.Text;
            String inst = textBox13.Text;
            String ano = comboBox5.SelectedItem.ToString();
            String nota = textBox12.Text;

            this.hab = new Habilitacao(nome, ano, curso, inst, nota, nivel);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
