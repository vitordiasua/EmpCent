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
    public partial class ClienteExpTrab : Form
    {
        public ExpTrb exp;

        public ExpTrb getExp()
        {
            return this.exp;
        }

        public ClienteExpTrab()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String empresa = textBox16.Text;
            String startDate = dateTimePicker2.Value.ToString();
            String endDate = dateTimePicker3.Value.ToString();
            String localizacao = textBox17.Text;
            String titulo = textBox15.Text;

            this.exp = new ExpTrb(titulo, empresa, localizacao, startDate, endDate);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ClienteExpTrab_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy-MM-dd";
        }
    }
}
