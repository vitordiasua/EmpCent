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
    public partial class Mylist_rec : Form
    {
        private String email;
        public Mylist_rec()
        {
            email = Interaction.InputBox("Insira o seu e-mail.", "Login", "fdportas@sapo.pt");

            InitializeComponent();

            loadOfertas();
        }

        public void loadOfertas() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.RecolherEmpregosDeRecrutador ( @email )", Connection.cn);
            cmd.Parameters.AddWithValue("@email", email);
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

                Oferta o = new Oferta(id, titulo, numVagas, localizacao, data, idEmp, idRec, nivelHabil, "emprego");

                listBox1.Items.Add(o);
            }

            Connection.cn.Close();

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM projeto.RecolherEstagiosDeRecrutador ( @email )", Connection.cn);
            cmd2.Parameters.AddWithValue("@email", email);
            SqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                String id = reader2["idOferta"].ToString();
                String idRec = reader2["idRecrutador"].ToString();
                String titulo = reader2["titulo"].ToString();
                String numVagas = reader2["numVagas"].ToString();
                String localizacao = reader2["localizacao"].ToString();
                String data = reader2["dataPublicacao"].ToString();
                String idEmp = reader2["idEmpresa"].ToString();
                String nivelHabil = reader2["nivelHabilitacao"].ToString();

                Oferta o = new Oferta(id, titulo, numVagas, localizacao, data, idEmp, idRec, nivelHabil, "estagio");

                listBox1.Items.Add(o);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Oferta r = (Oferta)listBox1.SelectedItem;
            if (r != null)
            {
                if (!Connection.verifySGBDConnection())
                    return;
                if (r.tipo.Equals("emprego"))
                {

                    SqlCommand cmd = new SqlCommand("DELETE FROM projeto.Emprego WHERE idOferta = @id", Connection.cn);
                    cmd.Parameters.AddWithValue("@id", r.getId());
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (r.tipo.Equals("estagio"))
                {

                    SqlCommand cmd = new SqlCommand("DELETE FROM projeto.Estagio WHERE idOferta = @id", Connection.cn);
                    cmd.Parameters.AddWithValue("@id", r.getId());
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                Connection.cn.Close();

                loadOfertas();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oferta id = (Oferta)listBox1.SelectedItem;
            if (id != null)
            {
                MoreInfo mi = new MoreInfo("recrutador", id.getId());
                mi.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Oferta id = (Oferta)listBox1.SelectedItem;
            if (id != null)
            {
                CheckCandidates cc = new CheckCandidates(id.getId());
                cc.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Oferta of = (Oferta)listBox1.SelectedItem;
            if (of != null)
            {
                Oferta_regist or = new Oferta_regist(of.getId(), of);
                or.ShowDialog();
            }
        }
    }
}
