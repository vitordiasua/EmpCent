using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class LangLevels
    {
        public String lang, write, read, oral, certf, id;

        public LangLevels(String lang, String write, String read, String oral , String certf, String id) {
            this.lang = lang;
            this.write = write;
            this.read = read;
            this.oral = oral;
            this.certf = certf;
            this.id = id;
        }

        public String getLang() {
            return this.lang;
        }

        public String getId()
        {
            return this.id;
        }
    }
}
