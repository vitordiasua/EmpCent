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
    public partial class HomeComp : Form
    {
        public HomeComp()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home client = new Home();
            client.ShowDialog();
            this.Close();
        }

        private void recrutadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeRecrutador rec = new HomeRecrutador();
            rec.ShowDialog();
            this.Close();
        }

        private void desempregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeClient cl = new HomeClient();
            cl.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register_comp rg = new register_comp();
            rg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyRecruiters mr = new MyRecruiters();
            mr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyListComp cml = new MyListComp();
            cml.ShowDialog();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
