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
    public partial class VarLink : VisualCode.Link { //связь для значений

        Image[] linkImage = new Image[] { //изображение не подключенных связей
            Properties.Resources.booleanLink,
            Properties.Resources.charLink,
            Properties.Resources.integerLink,
            Properties.Resources.floatLink,
            Properties.Resources.stringLink,
            Properties.Resources.boolArray,
            Properties.Resources.charArray,
            Properties.Resources.intArray,
            Properties.Resources.floatArray,
            Properties.Resources.stringArray
        };
        Image[] linkImageConnection = new Image[] { //изображение подключенных связей
            Properties.Resources.booleanLinkConnection,
            Properties.Resources.charLinkConnection,
            Properties.Resources.integerLinkConnection,
            Properties.Resources.floatLinkConnection,
            Properties.Resources.stringLinkConnection,
            Properties.Resources.boolArrayConnection,
            Properties.Resources.charArrayConnection,
            Properties.Resources.intArrayConnection,
            Properties.Resources.floatArrayConnection,
            Properties.Resources.stringArrayConnection,
        };

        public int type = 0;
        public bool active = false;
        public VarLink() {
            InitializeComponent();
        }

        public void mouseHover(object sender, EventArgs e) {
            if (!((Block)Parent).holdingLinks) {
                if (active)
                    BackgroundImage = Properties.Resources.hoverLinkConnection;
                else
                    BackgroundImage = Properties.Resources.hoverLink;
            }
        }
        public void mouseLeave(object sender, EventArgs e) {//сброс связи
            setActive(active);
        }
        public void setType(int type) { //измение типа связи при изменении переменной или пользователем 
            this.type = type;
            if (active)
                BackgroundImage = linkImageConnection[type];
            else
                BackgroundImage = linkImage[type];
        }
        public void setActive(bool active) { //активация свяхи при её создании
            this.active = active;
            if (active) 
                BackgroundImage = linkImageConnection[type];
            else
                BackgroundImage = linkImage[type];
        }
    }
}
