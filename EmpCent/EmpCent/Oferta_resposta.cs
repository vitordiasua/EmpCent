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
    public partial class Oferta_resposta : Form
    {
        public String ofId;
        public Oferta_resposta(String id)
        {
            InitializeComponent();
            ofId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;

            if (!Connection.verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("exec insertCandidatura @email, @idOferta ", Connection.cn);
            cmd.Parameters.AddWithValue("@idOferta", ofId);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();


            this.Close();
        }
    }
}
