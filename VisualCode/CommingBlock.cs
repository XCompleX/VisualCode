using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class CommingBlock : VisualCode.Block {

        Image[] typeImage32 = new Image[] { //изображения типов
            Properties.Resources.boolean_capsule_32,
            Properties.Resources.char_capsule_32,
            Properties.Resources.integer_capsule_32,
            Properties.Resources.float_capsule_32,
            Properties.Resources.string_capsule_32
        };

        Color[] color = new Color[] { //цвета типов
            Color.FromArgb(150, 255, 0, 0),
            Color.FromArgb(150, 255, 20, 147),
            Color.FromArgb(150, 127, 255, 212),
            Color.FromArgb(150, 0, 255, 0),
            Color.FromArgb(150, 255, 0, 255),
        };
        
        public CommingBlock(int inputType, int outputType) {
            InitializeComponent();
            initEvents();
            varLinkInput.setType(inputType);
            varLinkOutput.setType(outputType);
            Invalidate();
        }
        private void initEvents() { //привязка событий блоку
            MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);

            timer1.Tick += timer1_Tick;
        }
        private void varLinkMouseDown(object sender, MouseEventArgs e) { //отображение контекстного меню
            if (e.Button == MouseButtons.Right && ((Space)Parent).holdingLink == null)
                showWorkSpaceContextMenu((VarLink)sender, e.Location);
        }

        private void showWorkSpaceContextMenu(VarLink vl, Point location) { //генерация контекстного меню
            ToolStripMenuItem[] tsmiTypes = new ToolStripMenuItem[] {
                new ToolStripMenuItem("bool",  typeImage32[0], setTypeCounter),
                new ToolStripMenuItem("char",  typeImage32[1], setTypeCounter),
                new ToolStripMenuItem("int",  typeImage32[2], setTypeCounter),
                new ToolStripMenuItem("float",  typeImage32[3], setTypeCounter),
                new ToolStripMenuItem("string",  typeImage32[4], setTypeCounter),
            };

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmiTypes);
            cms.Show(vl, location);
        }

        private void setTypeCounter(object sender, EventArgs e) { //изменение типов связей блока
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip cms = (ContextMenuStrip)(tsmi).Owner;
            int type = cms.Items.IndexOf(tsmi);
            if (cms.SourceControl.GetType() == typeof(VarLinkInput)) {
                VarLinkInput vli = (VarLinkInput)cms.SourceControl;
                vli.setType(type);
                vli.delete();
            }
            else {
                VarLinkOutput vlo = (VarLinkOutput)cms.SourceControl;
                vlo.setType(type);
                vlo.deleteAll();
            }
            Invalidate();
        }

        public override void paint(object sender, PaintEventArgs e) { //отрисовка блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, color[varLinkInput.type], color[varLinkOutput.type], 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }
    }
}
