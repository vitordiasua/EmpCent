using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class Habilitacao
    {
        public String nivel, ano, curso, local, nota, nome, idDados, numRegisto;
        public Habilitacao(String nome, String ano, String curso, String local, String nota, String nivel)
        {
            this.nivel = nivel;
            this.ano = ano;
            this.curso = curso;
            this.local = local;
            this.nota = nota;
            this.nome = nome;
            this.idDados = null;
            this.numRegisto = null;
        }

        public void setID(String idDados, String numRegisto)
        {
            this.idDados = idDados;
            this.numRegisto = numRegisto;
        }

        public String getNivel()
        {
            return this.nivel;

        }
        public String getNome()
        {
            return this.nome;
        }
    }
}
