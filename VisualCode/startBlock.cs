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
    public partial class startBlock : Block {
        public startBlock() {
            InitializeComponent();
            initEvents();
        }
        private void initEvents() { //добавление событий блоку
            MouseEnter += new EventHandler(mouseEnter);
            name.MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);
            name.MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);
            name.Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);
            name.Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);
            name.MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);
            name.MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);
            name.MouseMove += new MouseEventHandler(mouseMove);

            timer1.Tick += timer1_Tick;
        }

        public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 0, 0), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }
    }
}
