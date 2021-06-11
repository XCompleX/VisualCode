using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class LinkInput : VisualCode.Link { //вход для связи
        public bool InputLinkConnection = false;
        public LinkInput() {
            InitializeComponent();
        }
        private void mouseDown(object sender, MouseEventArgs e) {//отображение контекстного меню
            if (e.Button == MouseButtons.Right) {
                if(elem != null)
                    showWorkSpaceContextMenu(e.Location);
            }
        }
        private void mouseEnter(object sender, EventArgs e) {
            if (!InputLinkConnection)
                BackgroundImage = Properties.Resources.triangleLinkHover;
        }
        private void mouseLeave(object sender, EventArgs e) {
            if (!InputLinkConnection)
                BackgroundImage = Properties.Resources.triangleLink;
        }
        public void deleteLink(object sender, EventArgs e) {
            delete();
        }
        public void delete() { //удаление связи
            if (elem != null) {
                ((LinkOutput)elem).resetLink();
                resetLink();
                elem.elem = null;
                elem = null;
                WorkSpace.Invalidate();
            }
        }
        public void resetLink() { //сброс параметров дло нач состояния
            InputLinkConnection = false;
            BackgroundImage = Properties.Resources.triangleLink;
        }
        private void showWorkSpaceContextMenu(Point MousePosition) { //генерация контекстного меню
            ToolStripMenuItem[] tsmi = new ToolStripMenuItem[] {
                new ToolStripMenuItem("Удалить связь", null)
            };
            tsmi[0].Click += new EventHandler(deleteLink);

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmi);
            cms.Show(this, MousePosition);
        }
    }
}
