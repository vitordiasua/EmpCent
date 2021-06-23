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
    public partial class ClienteCand : Form
    {
        public List<Oferta> offers = new List<Oferta>();

        public ClienteCand()
        {
            String email = Interaction.InputBox("Insira o seu e-mail.", "Login");

            InitializeComponent();

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.RecolherCandidaturasDeDesempregado ( @email )", Connection.cn);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            listBox1.Items.Add("Título" + "".PadRight(60 - "Título".Length) + "Nº Vagas" + "".PadRight(20 - "Nº Vagas".Length) + "Localização" + "".PadRight(40 - "Localização".Length));

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

                offers.Add(o);
                listBox1.Items.Add(o);
            }
            Connection.cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Oferta of = (Oferta) listBox1.SelectedItem;
            if (of != null)
            {
                MoreInfo mi = new MoreInfo("cliente", of.getId());
                mi.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Oferta of = (Oferta)listBox1.SelectedItem;
            if (of != null)
            {
                if (!Connection.verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand("delete from projeto.Desempregado_Candidato_Oferta where idOferta = @idOferta", Connection.cn);
                cmd.Parameters.AddWithValue("@idOferta", of.id);
                cmd.ExecuteNonQuery();
                listBox1.Items.Remove(of);
            }
                
        }
    }
}
