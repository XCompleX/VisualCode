using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class VarLinkOutput : VisualCode.VarLink { //связь для взятия значения

        public List<VarLinkInput> links = new List<VarLinkInput>();

        public VarLinkOutput() {
            InitializeComponent();
            initEvents();
        }
        private void mouseDown(object sender, MouseEventArgs e) { //начало создания свзяи
            if (e.Button == MouseButtons.Left) {
                ((Space)Parent.Parent).holdingLink = this;
                ((Block)Parent).holdingLinks = true;
                setActive(true);
                timer1.Start();
            }
        }

        private void mouseUp(object sender, MouseEventArgs e) { //отображение контекстного меню
            if (e.Button == MouseButtons.Right) {
                if (links.Count != 0) {
                    showWorkSpaceContextMenu(e.Location);
                }
            }
        }
        private void lostFocus(object sender, EventArgs e) { //создание связи, в случае если фокус попал на "связь для входных значений"
            if (((Block)Parent).holdingLinks) {
                VarLinkInput nextElem = null;
                foreach (Block elems in Parent.Parent.Controls) {
                    foreach (object childElems in elems.Controls) {
                        if (childElems.GetType() == typeof(VarLinkInput) && ((VarLinkInput)childElems).Focused == true) {
                            nextElem = (VarLinkInput)childElems;
                        }
                    }
                }
                if (nextElem != null && nextElem.type < 5 && type < 5) {
                    if (nextElem.link != null) {
                        nextElem.delete();
                    }
                    if ((nextElem.type == 4 || type == 4) && nextElem.type != type) {
                        CommingBlock cb = new CommingBlock(type,nextElem.type);
                        int LocationX = (Parent.Location.X + Location.X + nextElem.Parent.Location.X + nextElem.Location.X) / 2 - cb.Width / 2;
                        int LocationY = (Parent.Location.Y + Location.Y + nextElem.Parent.Location.Y + nextElem.Location.Y) / 2 - cb.Height / 2;
                        cb.Location = new Point(LocationX, LocationY);
                        WorkSpace.Controls.Add(cb);
                        cb.varLinkOutput.links.Add(nextElem);
                        nextElem.link = cb.varLinkOutput;
                        cb.varLinkInput.link = this;
                        links.Add(cb.varLinkInput);
                        cb.varLinkInput.setActive(true);
                        cb.varLinkOutput.setActive(true);
                        nextElem.setActive(true);
                        setActive(true);
                    }
                    else {
                        nextElem.link = this;
                        links.Add(nextElem);
                        nextElem.setActive(true);
                    }
                }
                else if (links.Count == 0) {
                    setActive(false);
                }
                ((Space)Parent.Parent).holdingLink = null;
                ((Block)Parent).holdingLinks = false;
                timer1.Stop();
                Parent.Parent.Invalidate();
            }
        }
        public void timer1_Tick(object sender, EventArgs e) {//обновление Space
            Parent.Parent.Invalidate();
        }
        public void deleteLink(object sender, EventArgs e) {
            delete((VarLinkInput)sender);
        }
        public void delete(VarLinkInput vli) { //удаление выбранной связи
            links.Remove(vli);
            if (links.Count == 0)
                setActive(false);
            vli.link = null;
            vli.setActive(false);
            Parent.Parent.Invalidate();
        }
        public void deleteAll() { //удаление всех связей
            foreach (VarLinkInput vli in links) {
                vli.link = null;
                vli.setActive(false);
            }
            links.Clear();
            setActive(false);
            Parent.Parent.Invalidate();
        }
        private void showWorkSpaceContextMenu(Point MousePosition) { //генерация контекстного меню
            ToolStripMenuItem[] tsmi = new ToolStripMenuItem[links.Count];
            for (int i = 0; i < tsmi.Length; i++) {
                VarLinkInput vli = links[i];
                tsmi[i] = new ToolStripMenuItem($"Удалить связь с {vli.Parent.Name}", null);
                tsmi[i].Click += (sender, e) => deleteLink(vli, e);
            }

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmi);
            cms.Show(this, MousePosition);
        }
        void initEvents() {
            MouseHover += new EventHandler(mouseHover);
            MouseLeave += new EventHandler(mouseLeave);
        }
    }
}
