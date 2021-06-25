using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class Oferta
    {
        public String id;
        public String titulo;
        public String vagas;
        public String localizacao;
        public String data;
        public String idEmpresa;
        public String idRecrt;
        public String nivelHabil;
        public String tipo;

        public Oferta()
        {
        }

        public Oferta(String id, String titulo, String vagas, String localizacao, String data, String idEmpresa, String idRecrt, String nivelHabil, String tipo = "") {
            this.id = id.ToString();
            this.titulo = titulo;
            this.vagas = vagas.ToString();
            this.localizacao = localizacao;
            this.data = data.ToString();
            this.idEmpresa = idEmpresa.ToString();
            this.idRecrt = idRecrt.ToString();
            this.nivelHabil = nivelHabil.ToString();
            this.tipo = tipo;
        }

        public String getId() {
            return this.id;
        }

        public String getTipo() {
            return tipo;
        }

        public String getIdEmp()
        {
            return idEmpresa;
        }

        public String getIdRec()
        {
            return idRecrt;
        }

        public override String ToString() {
            return titulo + "".PadRight(50 - titulo.Length) + vagas + "".PadRight(20 - vagas.Length) + localizacao + "".PadRight(30 - localizacao.Length) + data;
        }
    }
}
