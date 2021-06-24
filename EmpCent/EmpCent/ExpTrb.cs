using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class ExpTrb
    {
        public String titulo, empresa, locl, inicio, fim, numRegisto, idDados;
        public ExpTrb(String titulo, String empresa, String locl, String inicio, String fim) {
            this.empresa = empresa;
            this.locl = locl;
            this.titulo = titulo;
            this.inicio = inicio;
            this.fim = fim;
            this.idDados = null;
            this.numRegisto = null;
        }

        public void setID(String idDados, String numRegisto)
        {
            this.idDados = idDados;
            this.numRegisto = numRegisto;
        }

        public String getEmpresa()
        {
            return this.empresa;
        }
    }
}
