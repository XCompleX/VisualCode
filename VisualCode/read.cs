using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class read : VisualCode.Block {
        public read() {
            InitializeComponent();
            initEvents();
            initLinks();
        }
        private void initLinks() { //инициализация связи
            varLinkOutput.setType(4);
        }
        private void initEvents() { //присвоение событий элементам блока
            MouseEnter += new EventHandler(mouseEnter);
            blockName.MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);
            blockName.MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);
            blockName.Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);
            blockName.Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);
            blockName.MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);
            blockName.MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);
            blockName.MouseMove += new MouseEventHandler(mouseMove);

            timer1.Tick += timer1_Tick;
        }
        public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисвока блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 255, 0), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, Height));
            brush.Dispose();
        }
    }
}
