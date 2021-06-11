using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class VarLinkInput : VisualCode.VarLink { //связь для входных значений

        public VarLinkOutput link;

        public VarLinkInput() {
            InitializeComponent();
            initEvents();
        }
        void initEvents() { //добавление событий
            MouseHover += new EventHandler(mouseHover);
            MouseLeave += new EventHandler(mouseLeave);
        }
        private void mouseUp(object sender, MouseEventArgs e) {//отображение контекстного меню
            if (e.Button == MouseButtons.Right) {
                if (link != null) {
                    showWorkSpaceContextMenu(e.Location);
                }
            }
        }
        public void deleteLink(object sender, EventArgs e) {
            delete();
        }
        public void delete() { //удаление связи
            if (link != null) {
                link.links.Remove(this);
                if (link.links.Count == 0)
                    link.setActive(false);
                link = null;
                setActive(false);
                Parent.Parent.Invalidate();
            }
        }
        private void showWorkSpaceContextMenu(Point MousePosition) { //генерация контекстного меню
            ToolStripMenuItem[] tsmi = new ToolStripMenuItem[] {
                new ToolStripMenuItem($"Удалить связь с {link.Parent.Name}", null, deleteLink),
            };
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmi);
            cms.Show(this, MousePosition);
        }
    }
}
