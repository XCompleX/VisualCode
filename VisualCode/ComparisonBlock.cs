using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VisualCode {
    public partial class ComparisonBlock : VisualCode.Block {
        public Image[] typeImage32 = new Image[] { //изображение типов данных
            Properties.Resources.boolean_capsule_32,
            Properties.Resources.char_capsule_32,
            Properties.Resources.integer_capsule_32,
            Properties.Resources.float_capsule_32,
            Properties.Resources.string_capsule_32
        };
        public ComparisonBlock() {
            InitializeComponent();
            initEvents();
            initLinks();
            Name = "Comparision";
            textBox1.KeyPress += (sender, e) => textBox_KeyPress(sender, e);
            textBox2.KeyPress += (sender, e) => textBox_KeyPress(sender, e);
        }
        public virtual void initLinks() { //иниициализация "связей"
            varLinkInput1.setType(0);
            varLinkInput2.setType(0);
            varLinkOutput.setType(0);
        }
        public void changeInputValue(object sender, EventArgs e) { // входное значение укзано пользоватлем или с помощью связи
            VarLinkInput vli = (VarLinkInput)sender;
            if (vli == varLinkInput1) {
                if (varLinkInput1.type == 0)
                    checkBox1.Visible = vli.link == null;
                else
                    textBox1.Visible = vli.link == null;
            }
            if (vli == varLinkInput2) {
                if (varLinkInput2.type == 0)
                    checkBox2.Visible = vli.link == null;
                else
                    textBox2.Visible = vli.link == null;
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) { //запрет на изменеие пользователем операторов сравнения
            e.Handled = true;
        }
        private void initEvents() { //привязка событий элементам блока
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
        private void varLinkMouseDown(object sender, MouseEventArgs e) { //отображение контекстного меню
            if (e.Button == MouseButtons.Right && ((Space)Parent).holdingLink == null)
                showWorkSpaceContextMenu((VarLinkInput)sender, e.Location);
        }
        public virtual void showWorkSpaceContextMenu(VarLinkInput vl, Point location) { //генерация контекстного меню
            ToolStripMenuItem[] tsmiTypes = new ToolStripMenuItem[] {
                new ToolStripMenuItem("bool",  typeImage32[0], setTypeCounter),
                new ToolStripMenuItem("char",  typeImage32[1], setTypeCounter),
                new ToolStripMenuItem("int",  typeImage32[2], setTypeCounter),
                new ToolStripMenuItem("float",  typeImage32[3], setTypeCounter),
            };

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmiTypes);
            cms.Show(vl, location);
        }

        public virtual void setTypeCounter(object sender, EventArgs e) { //изменение типа связи
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip cms = (ContextMenuStrip)(tsmi).Owner;

            VarLinkInput vli = ((VarLinkInput)(cms.SourceControl));
            int type = cms.Items.IndexOf(tsmi);
            vli.setType(type);
            if (vli == varLinkInput1) {
                if (type == 0) {
                    checkBox1.Checked = false;
                    checkBox1.Visible = true;
                    textBox1.Visible = false;
                }
                else {
                    textBox1.Text = "";
                    checkBox1.Visible = false;
                    textBox1.Visible = true;
                }
                if (vli.type == 1)
                    textBox1.MaxLength = 2;
                else
                    textBox1.MaxLength = 32767;
            }
            else if (vli == varLinkInput2) {
                if (type == 0) {
                    checkBox2.Checked = false;
                    checkBox2.Visible = true;
                    textBox2.Visible = false;
                }
                else {
                    textBox2.Text = "";
                    checkBox2.Visible = false;
                    textBox2.Visible = true;
                }
                if (vli.type == 1)
                    textBox2.MaxLength = 2;
                else
                    textBox2.MaxLength = 32767;
            }
        }
        public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка блока 
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(192, 192, 192), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }
        protected void textBox_KeyPress(object sender, KeyPressEventArgs e) { //фильтрация вводимых значений пользователем
            TextBox tb = (TextBox)sender;

            VarLinkInput vli = (tb == textBox1 ? varLinkInput1 : varLinkInput2);
            if (vli.type == 3) {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.') && (e.KeyChar != '-')) {
                    e.Handled = true;
                }
                if (e.KeyChar == '-' && ((sender as TextBox).Text.IndexOf('-') > -1))
                    e.Handled = true;
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                    e.Handled = true;
                }
            }
            else if (vli.type == 2) {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '-')) {
                    e.Handled = true;
                }
                if (e.KeyChar == '-' && ((sender as TextBox).Text.IndexOf('-') > -1))
                    e.Handled = true;
            }
        }
        public virtual void textBox_TextChanged(object sender, EventArgs e) { //фильтрация введеных значений пользователем
            TextBox tb = (TextBox)sender;
            VarLinkInput vli = (tb == textBox1 ? varLinkInput1 : varLinkInput2);
            if (vli.type == 3) {
                if (Regex.Match(tb.Text, @"-\.|\.-").Success) {
                    tb.Text = tb.Text.Replace("-", string.Empty); ;
                }
                else if (Regex.Match(tb.Text, @"^\.").Success) {
                    tb.Text = "";
                }
                if (Regex.Match(tb.Text, @"^-0[0-9]").Success)
                    tb.Text = tb.Text.Replace("0", string.Empty); ;
            }
            if (vli.type == 2) {
                if (Regex.Match(tb.Text, @"-0").Success)
                    tb.Text = tb.Text.Remove(tb.Text.IndexOf("0"), 1);
            }
            if (vli.type == 1) {
                if (tb.TextLength > 0 && !Regex.Match(tb.Text, @"^\\{1}.$|^.$").Success) {
                    tb.Text = "" + tb.Text[0];
                }
            }
            if (vli.type == 3 || vli.type == 2) {
                if (Regex.Match(tb.Text, @"^0[0-9]").Success)
                    tb.Text = tb.Text.TrimStart('0');
                if (Regex.Match(tb.Text, @"[0-9]-").Success)
                    tb.Text = tb.Text.Trim('-');
                if (Regex.Match(tb.Text, @"[0-9]-[0-9]").Success)
                    tb.Text = tb.Text.Replace("-", string.Empty);
            }
        }
    }
}
