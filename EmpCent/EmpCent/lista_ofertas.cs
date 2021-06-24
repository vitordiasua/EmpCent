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
    public partial class lista_ofertas : Form
    {
        public String ent;
        public lista_ofertas(String entity)
        {
            ent = entity;
            
            InitializeComponent();

            loadOfertas();

        }

        public void loadOfertas(String op = "") {
            if (ent.Equals("cliente"))
            {
                button2.Text = "Candidatar a Oferta";
            }
            else if (ent.Equals("recrutador"))
                button2.Text = "Adicionar Oferta";

            if (!Connection.verifySGBDConnection())
                return;

            String order = "";
            if (!op.Equals("")) {
                order = "ORDER BY " + op;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Oferta " + order, Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idOferta"].ToString();
                String titulo = reader["titulo"].ToString();
                String vagas = reader["numVagas"].ToString();
                String localizacao = reader["localizacao"].ToString();
                String data = reader["dataPublicacao"].ToString();
                String idEmpresa = reader["idEmpresa"].ToString();
                String idRecrt = reader["idRecrutador"].ToString();
                String nivelHabil = reader["nivelHabilitacao"].ToString();
                Oferta o = new Oferta(id, titulo, vagas, localizacao, data, idEmpresa, idRecrt, nivelHabil);

                listBox1.Items.Add(o);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ent.Equals("cliente"))
            {
                Oferta of = (Oferta) listBox1.SelectedItem;
                if (of != null)
                {
                    Oferta_resposta form = new Oferta_resposta(of.id);
                    form.ShowDialog();
                }
            }
            else if (ent.Equals("recrutador")) {
                Oferta_regist form = new Oferta_regist();
                form.ShowDialog();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oferta id = (Oferta)listBox1.SelectedItem;
            if (id != null)
            {
                MoreInfo mi = new MoreInfo(ent, id.getId());
                mi.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ordem = (String)comboBox1.SelectedItem;
            switch (ordem) {
                case "Nome":
                    loadOfertas("titulo");
                    break;
                case "Data":
                    loadOfertas("dataPublicacao");
                    break;
                case "Vagas":
                    loadOfertas("numVagas");
                    break;
                default:
                    break;

            }
        }
    }
}
