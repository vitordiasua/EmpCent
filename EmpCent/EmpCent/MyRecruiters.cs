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
    public partial class MyRecruiters : Form
    {
        private String nome;
        public MyRecruiters()
        {
            nome = Interaction.InputBox("Insira o nome da sua empresa.", "Login","Techine");

            InitializeComponent();

            loadRecruiters();
        }

        public void loadRecruiters() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.RecolherRecrutadores(\'" + nome + "\')", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();

            listBox1.Items.Clear();

            while (reader.Read())
            {
                String id = reader["numRegisto"].ToString();
                String pNome = reader["primeiroNome"].ToString();
                String mNome = reader["nomesMeio"].ToString();
                String uNome = reader["ultimoNome"].ToString();
                String data = reader["dataNascimento"].ToString();
                String tele = reader["telefone"].ToString();
                String sexo = reader["sexo"].ToString();
                String idade = reader["idade"].ToString();
                String email = reader["email"].ToString();
                String metodo = reader["metodoDeSelecao"].ToString();
                Recrutador rc = new Recrutador(id, pNome,  mNome,  uNome,  data,  tele,  sexo,  idade,  email,metodo);

                listBox1.Items.Add(rc);
            }


            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recrutador rc = (Recrutador)listBox1.SelectedItem;
            if (rc != null) {
                MoreInfo mi = new MoreInfo("empresa", rc.getId(), rc);
                mi.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recrutador r = (Recrutador)listBox1.SelectedItem;
            if (r != null) {
                if (!Connection.verifySGBDConnection())
                    return;
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM projeto.Empresa WHERE nome = @nome", Connection.cn);
                cmd2.Parameters.AddWithValue("@nome", nome);
                SqlDataReader reader = cmd2.ExecuteReader();
                String id = null;
                while (reader.Read())
                {
                    id = reader["idEmpresa"].ToString();
                }
                Connection.cn.Close();

                if (!Connection.verifySGBDConnection())
                    return;
                SqlCommand cmd = new SqlCommand("DELETE FROM projeto.Recrutador WHERE numRegisto = @idRec", Connection.cn);
                cmd.Parameters.AddWithValue("@idRec", r.getId());
                cmd.Parameters.AddWithValue("@idEmp", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Connection.cn.Close();

                loadRecruiters();
            }
        }
    }
}
