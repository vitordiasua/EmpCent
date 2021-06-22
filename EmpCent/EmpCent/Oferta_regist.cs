using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            InitializeComponent();
        }

        private void Oferta_regist_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            DateTime today = DateTime.Today;

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
