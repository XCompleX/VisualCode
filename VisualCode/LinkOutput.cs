using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class LinkOutput : VisualCode.Link {
        public LinkOutput() {
            InitializeComponent();
        }

        private void mouseDown(object sender, MouseEventArgs e) { //отображение контекстного меню или процесс создания связи
            if (e.Button == MouseButtons.Left) {
                setLinkOutput(true);
                timer1.Start();
                WorkSpace.holdingLink = this;
                ((Block)Parent).holdingLinks = true;
            }
            else if (e.Button == MouseButtons.Right) {
                if(elem != null)
                    showWorkSpaceContextMenu(e.Location);
            }
        }
        private void mouseEnter(object sender, EventArgs e) {
            BackgroundImage = Properties.Resources.triangleLinkHover;
        }
        private void mouseLeave(object sender, EventArgs e) {
            if (WorkSpace.holdingLink != this && elem == null)
                BackgroundImage = Properties.Resources.triangleLink;
            else
                BackgroundImage = Properties.Resources.triangleLinkFocus;
        }
        private void lostFocus(object sender, EventArgs e) { //создание связи если фокус перешел на "вход связи" другого блока, прекращение создания если фокус перешел на что-то другое 
            if (WorkSpace.holdingLink == this) {
                Link nextElem = null;
                foreach (Block elems in WorkSpace.Controls) {
                    foreach (object childElems in elems.Controls) {
                        if (childElems.GetType() == typeof(LinkInput) && ((LinkInput)childElems).Focused == true) {
                            nextElem = (LinkInput)childElems;
                        }
                    }
                }

                if (nextElem != null) {
                    if (elem != null)
                        delete();
                    if (nextElem.elem != null)
                        ((LinkOutput)nextElem.elem).delete();
                    nextElem.elem = this;
                    elem = nextElem;
                    nextElem.BackgroundImage = Properties.Resources.triangleLinkFocus;
                    ((LinkInput)nextElem).InputLinkConnection = true;
                }


                WorkSpace.holdingLink = null;
                ((Block)Parent).holdingLinks = false;
                setLinkOutput(elem != null);
                timer1.Stop();
                WorkSpace.Invalidate();
            }
        }
        public void deleteLink(object sender, EventArgs e) {
            delete();
        }
        public void delete(bool check = true) { //удаление всех исходящих связей
            if (elem != null) {
                ((LinkInput)elem).resetLink();
                resetLink();
                elem.elem = null;
                elem = null;
                WorkSpace.Invalidate();
            }
        }
        public void setLinkOutput(bool en) {
            if (en) {
                BackgroundImage = Properties.Resources.triangleLinkFocus;
                Focus();
            }
            else
                BackgroundImage = Properties.Resources.triangleLink;
        }

        public void timer1_Tick(object sender, EventArgs e) {
            Parent.Parent.Invalidate();
        }
        public void resetLink() { //сброс до нач состояния параметров
            ((Block)Parent).holdingLinks = false;
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
