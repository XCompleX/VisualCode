using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class Continue : VisualCode.Block {
        public Continue() {
            InitializeComponent();
            initEvents();
        }
        private void initEvents() { //привязка событий
            MouseEnter += new EventHandler(mouseEnter);
            nameBlock.MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);
            nameBlock.MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);
            nameBlock.Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);
            nameBlock.Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);
            nameBlock.MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);
            nameBlock.MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);
            nameBlock.MouseMove += new MouseEventHandler(mouseMove);

            timer1.Tick += timer1_Tick;
        }
        public override void paint(object sender, PaintEventArgs e) { //отрисовка блока
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(192, 192, 192), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, Height));
            brush.Dispose();
        }
    }
}
