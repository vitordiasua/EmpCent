using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class Recrutador
    {
        private String id, pNome, mNome, uNome, data, tele, sexo, idade, email, metodo;

        public Recrutador(String id, String pNome, String mNome, String uNome, String data, String tele, String sexo, String idade, String email, String metodo) {
            this.pNome = pNome;
            this.mNome = mNome;
            this.uNome = uNome;
            this.data = data;
            this.tele = tele;
            if (sexo == "0")
                this.sexo = "M";
            else
                this.sexo = "F";
            this.idade = idade;
            this.email = email;
            this.metodo = metodo;
        }

        public String getId() { return id; }
        public String getNome() { return pNome + " " + mNome + " " + uNome; }
        public String getData() { return data; }
        public String getTele() { return tele; }
        public String getSexo() { return sexo; }
        public String getIdade() { return idade; }
        public String getEmail() { return email; }
        public String getMetodo() { return metodo; }

        public override String ToString() {
            return pNome + " " + uNome + "\t" + tele + "\t\t" + email;
        }
    }
}
