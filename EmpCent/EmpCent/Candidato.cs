using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class Candidato
    {
        private String idClient,  pNome,  meioNome,  uNome,
                 data,  tele,  idade,  email,  rua,
                 zipCode,  localidade,  descr,  lingua,  nacio;
        public Candidato(String idClient, String pNome, String meioNome, String uNome,
                String data, String tele, String idade, String email, String rua,
                String zipCode, String localidade, String descr, String lingua, String nacio) {
            this.idClient = idClient;
            this.pNome = pNome;
            this.meioNome = meioNome;
            this.uNome = uNome;
            this.data = data;
            this.tele = tele;
            this.idade = idade;
            this.email = email;
            this.rua = rua;
            this.zipCode = zipCode;
            this.localidade = localidade;
            this.descr = descr;
            this.lingua = lingua;
            this.nacio = nacio;
        }

        public String getId(){ return idClient; }
        public String getNome() { return pNome + " " + meioNome + " " + uNome; }
        public String getData() { return data; }
        public String getTele() { return tele; }
        public String getIdade() { return idade; }
        public String getEmail() { return email; }
        public String getRua() { return rua; }
        public String getZip() { return zipCode; }
        public String getLocal() { return localidade; }
        public String getDescr() { return descr; }
        public String getLingua() { return lingua; }
        public String getNacio() { return nacio; }

        public override String ToString() {
            return pNome + " " + uNome + "\t" + tele + "\t" + idade + "\t" + email + "\t" + lingua;
        }


    }
}
