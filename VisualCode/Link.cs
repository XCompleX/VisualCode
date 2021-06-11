using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualCode {
    public partial class Link : System.Windows.Forms.UserControl { //связь для последовательного соединения блоков в схеме
        public Link elem;
        public Space WorkSpace;
        public Link() {
            InitializeComponent();
        }

        private void Link_Load(object sender, EventArgs e) {
            if(Parent.Parent.GetType() == typeof(Space))
                WorkSpace = (Space)Parent.Parent;
        }
    }
}
