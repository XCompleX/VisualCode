using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualCode {
    public partial class Block : UserControl {

        public Color[] typesColors = new Color[] { //цвета "назначения" блоков
            Color.Red,
            Color.Purple,
            Color.LightBlue,
            Color.LightGreen,
            Color.Pink,
        };                    

        public List<object> connElem;

        public bool holding = false;
        public bool move = false;
        public bool holdingLinks = false;

        public Block() {
            InitializeComponent();
        }

        public Point PointSubstract(Point a1, Point a2) {
            a1.X -= a2.X;
            a1.Y -= a2.Y;
            return a1;
        }
        public Point PointAddition(Point a1, Point a2) {
            a1.X += a2.X;
            a1.Y += a2.Y;
            return a1;
        }
        public Point PointDivision(Point a1, int a2) {
            a1.X /= a2;
            a1.Y /= a2;
            return a1;
        }

        public void mouseEnter(object sender, EventArgs e) {
            //if (!Focused)
            //    BackgroundImage = backFocus;
        }
        public void mouseLeave(object sender, EventArgs e) {
           // if (!Focused)
           //     BackgroundImage = backUnFocus;
        }
        public void enter(object sender, EventArgs e) {
           // BackgroundImage = backFocus;
        }
        public void leave(object sender, EventArgs e) {
            //BackgroundImage = backUnFocus;
        }

        public void mouseDown(object sender, MouseEventArgs e) { //Удержание элемента
            if (e.Button == MouseButtons.Left) {
                holding = true;
                Focus();
            }
        }
        public void mouseUp(object sender, MouseEventArgs e) { //остановка перемещения элемента или вызов контекстного меню
            holding = false;
            if (move) {
                move = false;
                timer1.Stop();
            }
            else if(e.Button == MouseButtons.Right && GetType() != typeof(startBlock)) {
                showWorkSpaceContextMenu(e.Location);
            }
        }
        public void mouseMove(object sender, MouseEventArgs e) { //начало перемещения
            if (holding && !move) {
                move = true;
                timer1.Start();
            }
        }
        public void timer1_Tick(object sender, EventArgs e) { //следование за курсором (плавно) по таймеру
            if (move) {
                Point MousePosition = Parent.PointToClient(Cursor.Position);
                Point newPosition = new Point(MousePosition.X - Width / 2, MousePosition.Y - Height / 2);
                Location = newPosition;
                Parent.Invalidate();
            }
            if (holdingLinks) {
                Parent.Invalidate();
            }
        }
        public void deleteBlock(object sender, EventArgs e) {
            delete();
        }
        public void delete() { //удаление блока и всех его связей
            Control[] lis = Controls.Find("linkInput", false);
            foreach (LinkInput li in lis) {
                li.delete();
            }
            foreach (object elem in Controls) {
                if (elem.GetType() == typeof(LinkOutput)) {
                    ((LinkOutput)elem).delete();
                }
            }
            foreach (object elem in Controls) {
                if (elem.GetType() == typeof(VarLinkInput)) {
                    ((VarLinkInput)elem).delete();
                }
            }
            Control[] vlos = Controls.Find("varLinkOutput", false);
            foreach (VarLinkOutput vlo in vlos) {
                vlo.deleteAll();
            }
            ((Space)Parent).Controls.Remove(this);
        }
        private void showWorkSpaceContextMenu(Point MousePosition) { //генерация контекстного меню
            ToolStripMenuItem[] tsmi = new ToolStripMenuItem[] {
                new ToolStripMenuItem("Удалить блок", null)
            };
            tsmi[0].Click += new EventHandler(deleteBlock);

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmi);
            cms.Show(this, MousePosition);
        }

        public virtual void paint(object sender, PaintEventArgs e) { //отрисовка блока
            BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
