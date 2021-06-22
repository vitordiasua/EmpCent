using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    class Oferta
    {
        private String id;
        private String titulo;
        private String vagas;
        private String localizacao;
        private String data;
        private String idEmpresa;
        private String idRecrt;
        private String nivelHabil;

        public Oferta()
        {
        }

        public Oferta(String id, String titulo, String vagas, String localizacao, String data, String idEmpresa, String idRecrt, String nivelHabil) {
            this.id = id.ToString();
            this.titulo = titulo;
            this.vagas = vagas.ToString();
            this.localizacao = localizacao;
            this.data = data.ToString();
            this.idEmpresa = idEmpresa.ToString();
            this.idRecrt = idRecrt.ToString();
            this.nivelHabil = nivelHabil.ToString();
        }

        public String getId() {
            return this.id;
        }

        public override String ToString() {
            return titulo + "\t" + localizacao + "\t" + vagas + "\t" + data;
        }
    }
}
