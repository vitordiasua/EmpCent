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
    public partial class Mylist_client : Form
    {
        public Mylist_client()
        {
            String email = Interaction.InputBox("Insira o seu e-mail.", "Login", "pedrobantunes95@gmail.com");

            InitializeComponent();

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.RecolherCandidaturasDeDesempregado ( @email )", Connection.cn);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idOferta"].ToString();
                String idClient = reader["numRegisto"].ToString();
                String titulo = reader["titulo"].ToString();
                String numVagas = reader["numVagas"].ToString();
                String localizacao = reader["localizacao"].ToString();
                String data = reader["dataPublicacao"].ToString();
                String idEmp = reader["idEmpresa"].ToString();
                String idRecrt = reader["idRecrutador"].ToString();
                String nivelHabil = reader["nivelHabilitacao"].ToString();
                Oferta o = new Oferta(id, titulo, numVagas, localizacao, data, idEmp, idRecrt, nivelHabil);

                listBox1.Items.Add(o);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oferta id = (Oferta)listBox1.SelectedItem;
            if (id != null)
            {
                MoreInfo mi = new MoreInfo("cliente", id.getId());
                mi.ShowDialog();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
