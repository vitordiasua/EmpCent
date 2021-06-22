using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class LangLevels
    {
        public String lang, write, read, oral, certf;

        public LangLevels(String lang, String write, String read, String oral , String certf) {
            this.lang = lang;
            this.write = write;
            this.read = read;
            this.oral = oral;
            this.certf = certf;
        }

        public String getLang() {
            return this.lang;
        }
    }
}
