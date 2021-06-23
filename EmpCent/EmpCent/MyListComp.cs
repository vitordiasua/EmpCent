using Microsoft.VisualBasic;
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
    public partial class MyListComp : Form
    {
        public MyListComp()
        {

            String empresa = Interaction.InputBox("Insira o nome da sua empresa.", "Login", "Techine");

            InitializeComponent();

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.RecolherOfertasDeEmpresa ( @empresa )", Connection.cn);
            cmd.Parameters.AddWithValue("@empresa", empresa);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idOferta"].ToString();
                String idRec = reader["idRecrutador"].ToString();
                String titulo = reader["titulo"].ToString();
                String numVagas = reader["numVagas"].ToString();
                String localizacao = reader["localizacao"].ToString();
                String data = reader["dataPublicacao"].ToString();
                String idEmp = reader["idEmpresa"].ToString();
                String nivelHabil = reader["nivelHabilitacao"].ToString();
                Oferta o = new Oferta(id, titulo, numVagas, localizacao, data, idEmp, idRec, nivelHabil);

                listBox1.Items.Add(o);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oferta of = (Oferta)listBox1.SelectedItem;
            if (of != null) {
                MoreInfo mi = new MoreInfo("recrutador", of.getId());
                mi.ShowDialog();            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Oferta of = (Oferta)listBox1.SelectedItem;
            if (of != null)
            {
                CheckCandidates cc = new CheckCandidates(of.getId());
                cc.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
