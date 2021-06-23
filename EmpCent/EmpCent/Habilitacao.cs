using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class Habilitacao
    {
        public String nivel, ano, curso, local, nota, nome;
        public Habilitacao(String nome, String ano, String curso, String local, String nota, String nivel)
        {
            this.nivel = nivel;
            this.ano = ano;
            this.curso = curso;
            this.local = local;
            this.nota = nota;
            this.nome = nome;

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
