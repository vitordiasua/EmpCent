using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    class ExpTrb
    {
        private String empresa, locl, descricao, inicio, fim;
        public ExpTrb(String empresa, String locl, String descricao, String inicio, String fim) {
            this.empresa = empresa;
            this.locl = locl;
            this.descricao = descricao;
            this.inicio = inicio;
            this.fim = fim;
        }
    }
}
