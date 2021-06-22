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
    public partial class CheckCandidates : Form
    {
        public CheckCandidates(String idOferta)
        {
            InitializeComponent();

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * " +
                "FROM ( SELECT Desempregado_Candidato_Oferta.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, rua , codigoPostal, localidade, descricao, nomeLingua, idNacionalidade " +
                        "FROM (projeto.Desempregado_Candidato_Oferta JOIN ( SELECT Pessoa.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, idLinguaMaterna, rua , codigoPostal, localidade, descricao, idNacionalidade " +
                                                                            "FROM projeto.Pessoa JOIN projeto.Desempregado ON Pessoa.numRegisto = Desempregado.numRegisto) AS Candidate ON Desempregado_Candidato_Oferta.numRegisto = Candidate.numRegisto ) " +
                                                                                    "JOIN projeto.Lingua ON idLinguaMaterna = idLingua " +
                        "WHERE idOferta = " + idOferta + " ) AS plusLanguage " +
                "JOIN projeto.Nacionalidade ON plusLanguage.idNacionalidade = Nacionalidade.idNacionalidade ", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                String idClient = reader["numRegisto"].ToString();
                String pNome = reader["primeiroNome"].ToString();
                String meioNome = reader["nomesMeio"].ToString();
                String uNome = reader["ultimoNome"].ToString();
                String data = reader["dataNascimento"].ToString();
                String tele = reader["telefone"].ToString();
                String idade = reader["idade"].ToString();
                String email = reader["email"].ToString();
                String rua = reader["rua"].ToString();
                String zipCode = reader["codigoPostal"].ToString();
                String localidade = reader["localidade"].ToString();
                String descr = reader["descricao"].ToString();
                String lingua = reader["nomeLingua"].ToString();
                String nacio = reader["nomeNacionalidade"].ToString();
                Candidato c = new Candidato(idClient, pNome, meioNome, uNome, data, tele, idade, email, rua, zipCode, localidade, descr, lingua, nacio);

                listBox1.Items.Add(c);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0; 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Candidato cand = (Candidato)listBox1.SelectedItem;
            if (cand != null) {
                MoreInfo mi = new MoreInfo("candidato", cand.getId(), cand);
                mi.ShowDialog();
            }
        }
    }
}
