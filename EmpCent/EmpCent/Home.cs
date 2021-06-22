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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            new Connection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeClient client = new HomeClient();
            client.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeComp emp = new HomeComp();
            emp.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void desempregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeClient cl = new HomeClient();
            cl.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeRecrutador rec = new HomeRecrutador();
            rec.ShowDialog();
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void recrutadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeRecrutador rec = new HomeRecrutador();
            rec.ShowDialog();
            this.Close();
        }
    }
}
