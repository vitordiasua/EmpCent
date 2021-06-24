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
    public partial class HomeClient : Form
    {
        public HomeClient()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            register_client client = new register_client();
            client.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClienteUpdate client = new ClienteUpdate();
            client.ShowDialog();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void desempregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void recrutadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeRecrutador rec = new HomeRecrutador();
            rec.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lista_ofertas lo = new lista_ofertas("cliente");
            lo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClienteCand ml = new ClienteCand();
            ml.ShowDialog();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeComp rec = new HomeComp();
            rec.ShowDialog();
            this.Close();
        }
    }
}
