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

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Categoria_Emprego ", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox2.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idCategoria"].ToString();
                String cat = reader["nomeCategoria"].ToString();
                ComboBoxItem cb = new ComboBoxItem(id, cat);

                comboBox2.Items.Add(cb);
            }

            Connection.cn.Close();
            //Connection.tableIndex = 0;

            loadOfertas();

        }

        public void loadOfertas(String op = null, String category = null) {
            if (ent.Equals("cliente"))
            {
                button2.Text = "Candidatar a Oferta";
            }
            else if (ent.Equals("recrutador"))
                button2.Text = "Adicionar Oferta";

            if (!Connection.verifySGBDConnection())
                return;

            String whr = "";
            if (category != null)
            {
                whr = "JOIN projeto.Area_Oferta ON Oferta.idOferta = Area_Oferta.idOferta WHERE idCategoria = " + category;
            }

            String order = "";
            if (op != null) {
                order = "ORDER BY " + op;
            }

            SqlCommand cmd = new SqlCommand("SELECT Oferta.idOferta as idOferta, titulo, numVagas, localizacao, dataPublicacao, idEmpresa,idRecrutador, nivelHabilitacao FROM projeto.Oferta " + whr + order, Connection.cn);
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
            //Connection.tableIndex = 0;
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
         /*   String ordem = (String)comboBox1.SelectedItem;
            if (comboBox1.SelectedIndex < 0)
            {
                switch (ordem)
                {
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
            else {
                ComboBoxItem cb = (ComboBoxItem)comboBox2.SelectedItem;
                switch (ordem)
                {
                    case "Nome":
                        loadOfertas("titulo", cb.getId());
                        break;
                    case "Data":
                        loadOfertas("dataPublicacao", cb.getId());
                        break;
                    case "Vagas":
                        loadOfertas("numVagas", cb.getId());
                        break;
                    default:
                        break;
                }
            }*/
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*ComboBoxItem cb = (ComboBoxItem)comboBox2.SelectedItem;

            if (comboBox1.SelectedIndex > -1)
            {
                cb = (ComboBoxItem)comboBox2.SelectedItem;
                loadOfertas(null, cb.getId());
            }
            else
            {
                String ordem = (String)comboBox1.SelectedItem;
                switch (ordem)
                {
                    case "Nome":
                        loadOfertas("titulo", cb.getId());
                        break;
                    case "Data":
                        loadOfertas("dataPublicacao", cb.getId());
                        break;
                    case "Vagas":
                        loadOfertas("numVagas", cb.getId());
                        break;
                    default:
                        break;
                }
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            String ordem = (String)comboBox1.SelectedItem;
            ComboBoxItem cb = (ComboBoxItem)comboBox2.SelectedItem;
            String ans = null;
            switch (ordem)
            {
                case "Nome":
                    ans = "titulo";
                    break;
                case "Data":
                    ans = "dataPublicacao";
                    break;
                case "Vagas":
                    ans = "numVagas";
                    break;
                default:
                    break;
            }
            if(cb != null)
                loadOfertas(ans, cb.getId());
            else
                loadOfertas(ans, null);
        }
    }
}
