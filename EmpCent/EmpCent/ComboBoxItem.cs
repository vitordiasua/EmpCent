using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpCent
{
    public class ComboBoxItem
    {
        private String id, content;
        public ComboBoxItem(String id, String content) {
            this.id = id;
            this.content = content;
        }

        public String getId() { return this.id; }
    }
}
