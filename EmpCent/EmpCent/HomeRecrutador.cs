using Microsoft.VisualBasic;
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
    public partial class HomeRecrutador : Form
    {
        public HomeRecrutador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register_recruiter client = new register_recruiter();
            client.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String email = Interaction.InputBox("Insira o seu e-mail.", "Login", "example@example.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lista_ofertas lo = new lista_ofertas("recrutador");
            lo.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home client = new Home();
            client.ShowDialog();
            this.Close();
        }

        private void desempregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeClient client = new HomeClient();
            client.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mylist_rec ml = new Mylist_rec();
            ml.ShowDialog();
        }
    }
}
