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
    public partial class MoreInfo : Form
    {
        private String entity, id;
        public MoreInfo(String entity, String id,  Object o = null)
        {
            this.entity = entity;
            this.id = id;

            InitializeComponent();

            if (entity.Equals("cliente") || entity.Equals("recrutador"))
                loadInfoOfertas();
            else if (entity.Equals("candidato"))
                loadInfoCandidato((Candidato)o);
            else if (entity.Equals("empresa")) {
                loadInfoRecrutador((Recrutador)o);
            }
        }

        public void loadInfoOfertas() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.RecolherInfoDeOferta (@idOferta)", Connection.cn);
            cmd.Parameters.AddWithValue("@idOferta", Int32.Parse(id));
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            String titulo = reader["titulo"].ToString();
            String vagas = reader["numVagas"].ToString();
            String localizacao = reader["localizacao"].ToString();
            String data = reader["dataPublicacao"].ToString();
            String empresa = reader["nome"].ToString();
            String localEmp = reader["empLocal"].ToString();
            String descricaoEmp = reader["descricao"].ToString();
            String descricaoNivel = reader["descricaoNivel"].ToString();



            Connection.cn.Close();
            Connection.tableIndex = 0;

            label1.Text = "Título:";
            label2.Text = "Nº de Vagas:";
            label3.Text = "Localização:";
            label4.Text = "Data Publicação:";
            label5.Text = "Nome da Empresa:";
            label6.Text = "Localização:";
            label7.Text = "Descrição:";
            label8.Text = "Habilitação Necessária:";
            label9.Visible = false ;
            label10.Visible = false;
            label11.Text = titulo;
            label12.Text = vagas;
            label13.Text = localizacao;
            label14.Text = data;
            label15.Text = empresa;
            label16.Text = localEmp;
            label17.Text = descricaoEmp;
            label18.Text = descricaoNivel;
            label19.Visible = false;
            label20.Visible = false;
        }

        public void loadInfoCandidato(Candidato cand) {
            label1.Text = "Nome:";
            label2.Text = "Data de Nascimento:";
            label3.Text = "Nº de telefone:";
            label4.Text = "Idade:";
            label5.Text = "e-mail:";
            label6.Text = "Rua:";
            label7.Text = "Código Postal:";
            label8.Text = "Localidade:";
            label9.Visible = true;
            label10.Visible = true;
            label9.Text = "Nacionalidade | Língua Materna:";
            label10.Text = "Descrição:";
            label11.Text = cand.getNome();
            label12.Text = cand.getData();
            label13.Text = cand.getTele();
            label14.Text = cand.getIdade();
            label15.Text = cand.getEmail();
            label16.Text = cand.getRua();
            label17.Text = cand.getZip();
            label18.Text = cand.getLocal();
            label19.Visible = true;
            label20.Visible = true;
            label19.Text = cand.getNacio() + " | " + cand.getLingua();
            label20.Text = cand.getDescr();
        }

        public void loadInfoRecrutador(Recrutador rc)
        {

            label1.Text = "Nome:";
            label2.Text = "Data de Nascimento:";
            label3.Text = "Telefone:";
            label4.Text = "Sexo:";
            label5.Text = "Idade:";
            label6.Text = "e-mail:";
            label7.Text = "Metodo de Seleção:";
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Text = rc.getNome();
            label12.Text = rc.getData();
            label13.Text = rc.getTele();
            label14.Text = rc.getSexo();
            label15.Text = rc.getIdade();
            label16.Text = rc.getEmail();
            label17.Text = rc.getMetodo();
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
        }
    }
}
