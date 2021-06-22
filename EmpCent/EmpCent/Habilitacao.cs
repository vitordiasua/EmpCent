using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    class Habilitacao
    {
        private String nivel, ano, curso, local, nota;
        public Habilitacao(String nivel, String ano, String curso, String local,  String nota) {
            this.nivel = nivel;
            this.ano = ano;
            this.curso = curso;
            this.local = local;
            this.nota = nota;

        }

        public String getNivel() {
            return this.nivel;
        }
    }
}
