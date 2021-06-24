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
    public partial class Oferta_regist : Form
    {
        private String email;
        public Oferta_regist(String id = null, Oferta o = null)
        {
            email = Interaction.InputBox("Insira o seu e-mail.", "Login", "fdportas@sapo.pt");

            InitializeComponent();

            loadHabilitacoes();

            loadTipos();

            if (id != null) {
                radioButton1.Visible = false;
                radioButton2.Visible = false;

                if (!Connection.verifySGBDConnection())
                    return;

                SqlCommand cmd;

                if (o.tipo.Equals("estagio"))
                {
                    radioButton1.Checked = true;
                    cmd = new SqlCommand("SELECT Oferta.idOferta,titulo,numVagas,localizacao,idEmpresa,idRecrutador,nivelHabilitacao,duracao,observacoes FROM projeto.Oferta JOIN projeto.Estagio ON Estagio.idOferta = Oferta.idOferta WHERE Oferta.idOferta = @id", Connection.cn);
               
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        String titulo = reader["titulo"].ToString();
                        String vagas = reader["numVagas"].ToString();
                        String local = reader["localizacao"].ToString();
                        String idEmpresa = reader["idEmpresa"].ToString();
                        String idRecrutador = reader["idRecrutador"].ToString();
                        String habil = reader["nivelHabilitacao"].ToString();
                        String duracao = reader["duracao"].ToString();
                        String obsrv = reader["observacoes"].ToString();

                        textBox1.Text = titulo;
                        textBox2.Text = vagas;
                        textBox3.Text = local;
                        textBox4.Text = duracao;
                        textBox5.Text = obsrv;
                        comboBox2.SelectedIndex = Int32.Parse(habil) - 1;
                    }

                    Connection.cn.Close();
                    Connection.tableIndex = 0;

                    button6.Text = "Alterar";
                }


                else if (o.tipo.Equals("emprego"))
                {
                    radioButton2.Checked = true;
                    cmd = new SqlCommand("SELECT Oferta.idOferta,titulo,numVagas,localizacao,idEmpresa,idRecrutador,nivelHabilitacao,salario,tipoContrato,experienciaNecessaria,descricaoEmprego FROM projeto.Oferta JOIN projeto.Emprego ON Emprego.idOferta = Oferta.idOferta WHERE Oferta.idOferta = @id", Connection.cn);

                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        String titulo = reader["titulo"].ToString();
                        String vagas = reader["numVagas"].ToString();
                        String local = reader["localizacao"].ToString();
                        String idEmpresa = reader["idEmpresa"].ToString();
                        String idRecrutador = reader["idRecrutador"].ToString();
                        String habil = reader["nivelHabilitacao"].ToString();
                        String salario = reader["salario"].ToString();
                        String tipoContrato = reader["tipoContrato"].ToString();
                        String experienciaNecessaria = reader["experienciaNecessaria"].ToString();
                        String descricaoEmprego = reader["descricaoEmprego"].ToString();


                        textBox1.Text = titulo;
                        textBox2.Text = vagas;
                        textBox3.Text = local;
                        textBox4.Text = salario;
                        textBox5.Text = experienciaNecessaria;
                        textBox6.Text = descricaoEmprego;
                        comboBox2.SelectedIndex = Int32.Parse(habil) - 1;
                        comboBox1.SelectedIndex = Int32.Parse(tipoContrato) - 1;
                    }

                    Connection.cn.Close();
                    Connection.tableIndex = 0;

                    button6.Text = "Alterar";
                }
            }
        }

        public void loadTipos() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Tipo_Contrato", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idTipoContrato"].ToString();
                String descricaoTipoContrato = reader["descricaoTipoContrato"].ToString();
                ComboBoxItem itm = new ComboBoxItem(id, descricaoTipoContrato);
                comboBox1.Items.Add(itm);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        public void loadHabilitacoes() {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Nivel_Habilitacao", Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox2.Items.Clear();

            while (reader.Read())
            {
                String id = reader["idNivel"].ToString();
                String lvl = reader["descricaoNivel"].ToString();
                ComboBoxItem itm = new ComboBoxItem(id, lvl);
                comboBox2.Items.Add(itm);
            }

            Connection.cn.Close();
            Connection.tableIndex = 0;
        }

        private void Oferta_regist_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.Recrutador JOIN projeto.Pessoa ON Recrutador.numRegisto = Pessoa.numRegisto WHERE email = @email", Connection.cn);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            String idRecr = reader["numRegisto"].ToString();
            String idEmpr = reader["idEmpresa"].ToString();

            Connection.cn.Close();


            if (radioButton1.Checked)
            {

                if (!Connection.verifySGBDConnection())
                    return;


                String titulo = textBox1.Text;
                String vagas = textBox2.Text;
                String local = textBox3.Text;
                String duracao = textBox4.Text;
                String observacoes = textBox5.Text;
                ComboBoxItem hab = (ComboBoxItem)comboBox2.SelectedItem;



                SqlCommand cmd2 = new SqlCommand("EXEC insertEstagio @titulo, @vagas, @local, @idEmpresa, @idRecrutador, @habil, @duracao, @obsrv", Connection.cn);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@titulo", titulo);
                cmd2.Parameters.AddWithValue("@vagas", vagas);
                cmd2.Parameters.AddWithValue("@local", local);
                cmd2.Parameters.AddWithValue("@idEmpresa", idEmpr);
                cmd2.Parameters.AddWithValue("@idRecrutador", idRecr);
                cmd2.Parameters.AddWithValue("@habil", hab.getId());
                cmd2.Parameters.AddWithValue("@duracao", duracao);
                cmd2.Parameters.AddWithValue("@obsrv", observacoes);
                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Oferta Criada");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    comboBox2.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Connection.cn.Close();
            }
            else if (radioButton2.Checked)
            {
                if (!Connection.verifySGBDConnection())
                    return;

                String titulo = textBox1.Text;
                String vagas = textBox2.Text;
                String local = textBox3.Text;
                String salario = textBox4.Text;
                String descr = textBox5.Text;
                String expNec = textBox6.Text;
                ComboBoxItem cb2 = (ComboBoxItem)comboBox1.SelectedItem;
                String tipoContr = cb2.getId();
                MessageBox.Show(tipoContr);
                ComboBoxItem hab = (ComboBoxItem)comboBox2.SelectedItem;

                SqlCommand cmd2 = new SqlCommand("EXEC insertEmprego @titulo, @vagas, @local, @idEmpresa, @idRecrutador, @habil, @sal, @tipoCont, @exp, @descr", Connection.cn);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@titulo", titulo);
                cmd2.Parameters.AddWithValue("@vagas", vagas);
                cmd2.Parameters.AddWithValue("@local", local);
                cmd2.Parameters.AddWithValue("@idEmpresa", idEmpr);
                cmd2.Parameters.AddWithValue("@idRecrutador", idRecr);
                cmd2.Parameters.AddWithValue("@habil", hab.getId());
                /*var parameter = new SqlParameter();
                parameter.ParameterName = "@sal";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = Int32.Parse(salario);
                cmd2.Parameters.Add(parameter);
                cmd2.Parameters.AddWithValue("@descr", descr);
                cmd2.Parameters.AddWithValue("@exp", expNec);
                var parameter2 = new SqlParameter();
                parameter2.ParameterName = "@tipoCont";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = Int32.Parse(tipoContr);
                cmd2.Parameters.Add(parameter2);
                */
                cmd2.Parameters.AddWithValue("@sal", salario);
                cmd2.Parameters.AddWithValue("@descr", descr);
                cmd2.Parameters.AddWithValue("@exp", expNec);
                cmd2.Parameters.AddWithValue("@tipoCont", tipoContr);

                try
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Oferta Criada");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    comboBox2.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Connection.cn.Close();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label6.Visible = true;
                textBox4.Visible = true;
                label7.Visible = true;
                textBox5.Visible = true;
                label6.Text = "Duração";
                label7.Text = "Observações";
                label8.Visible = false;
                textBox6.Visible = false;
                label9.Visible = false;
                comboBox1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label6.Visible = true;
                textBox4.Visible = true;
                label7.Visible = true;
                textBox5.Visible = true;
                label6.Text = "Salário";
                label7.Text = "Descrição do Emprego";
                label8.Visible = true;
                textBox6.Visible = true;
                label9.Visible = true;
                comboBox1.Visible = true;
            }
        }
    }
}
