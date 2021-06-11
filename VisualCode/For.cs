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
    public partial class For : VisualCode.Block {
        Image[] typeImage32 = new Image[] { //изображения типов данных
            Properties.Resources.integer_capsule_32,
            Properties.Resources.float_capsule_32,
            Properties.Resources.string_capsule_32
        };

        public String nameCounter;

        public For() {
            InitializeComponent();
            initEvents();
            initLinks();
        }

        private void initLinks() { //инициализация "связей"
            varLinkInput1.setType(0);
            varLinkOutput.setType(2);
            varLinkInput2.setType(2);
            varLinkInput3.setType(2);
        }
        public void changeInputValue(object sender, EventArgs e) { //вводимое значение указывается пользоватлем или по связи
            VarLinkInput vli = (VarLinkInput)sender;
            if (vli == varLinkInput1)
                checkBox1.Visible = vli.link == null;
            if (vli == varLinkInput2)
                textBox2.Visible = vli.link == null;
            if (vli == varLinkInput2)
                textBox1.Visible = vli.link == null;
        }
        private void varLinkOutputMouseDown(object sender, MouseEventArgs e) { //отображение контекстного меню
            if(e.Button == MouseButtons.Right && ((Space)Parent).holdingLink == null)
                showWorkSpaceContextMenu(varLinkOutput.Location);
        }
        private void initEvents() { //привязка событий
            MouseEnter += new EventHandler(mouseEnter);
            nameBlock.MouseEnter += new EventHandler(mouseEnter);
            labelBody.MouseEnter += new EventHandler(mouseEnter);
            labelCounter.MouseEnter += new EventHandler(mouseEnter);
            labelStep.MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);
            nameBlock.MouseLeave += new EventHandler(mouseLeave);
            labelBody.MouseLeave += new EventHandler(mouseLeave);
            labelCounter.MouseLeave += new EventHandler(mouseLeave);
            labelStep.MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);
            nameBlock.Enter += new EventHandler(enter);
            labelBody.Enter += new EventHandler(enter);
            labelCounter.Enter += new EventHandler(enter);
            labelStep.Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);
            nameBlock.Leave += new EventHandler(leave);
            labelBody.Leave += new EventHandler(leave);
            labelCounter.Leave += new EventHandler(leave);
            labelStep.Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);
            nameBlock.MouseDown += new MouseEventHandler(mouseDown);
            labelBody.MouseDown += new MouseEventHandler(mouseDown);
            labelCounter.MouseDown += new MouseEventHandler(mouseDown);
            labelStep.MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);
            nameBlock.MouseUp += new MouseEventHandler(mouseUp);
            labelBody.MouseUp += new MouseEventHandler(mouseUp);
            labelCounter.MouseUp += new MouseEventHandler(mouseUp);
            labelStep.MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);
            nameBlock.MouseMove += new MouseEventHandler(mouseMove);
            labelBody.MouseMove += new MouseEventHandler(mouseMove);
            labelCounter.MouseMove += new MouseEventHandler(mouseMove);
            labelStep.MouseMove += new MouseEventHandler(mouseMove);

            timer1.Tick += timer1_Tick;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { //валидация вводимых пользователем значений
            if (varLinkOutput.type != 4) {
                if (varLinkOutput.type == 3) {
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
                else if (varLinkOutput.type == 2) {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '-')) {
                        e.Handled = true;
                    }
                    if (e.KeyChar == '-' && ((sender as TextBox).Text.IndexOf('-') > -1))
                        e.Handled = true;
                }
            }
        }
        private void showWorkSpaceContextMenu(Point MousePosition) { //генерация контекстного меню
            ToolStripMenuItem[] tsmiTypes = new ToolStripMenuItem[] {
                new ToolStripMenuItem("int",  typeImage32[0], (sender, e) => setType(2, e)),
                new ToolStripMenuItem("float",  typeImage32[1], (sender, e) => setType(3, e)),
                new ToolStripMenuItem("string",  typeImage32[2], (sender, e) => setType(4, e)),
            };

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmiTypes);
            cms.Show(this, MousePosition);
        }
        private void setType(object sender, EventArgs e) { //изменение типа источников связей (тип счетчика)
            varLinkOutput.setType((int)sender);
            varLinkInput2.setType((int)sender);
            varLinkInput3.setType((int)sender);
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public override void paint(object sender, PaintEventArgs e) { //прорисовка/перерисовка блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(192, 192, 192), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }
        private void InputValue_TextChanged(object sender, EventArgs e) { //валидация введенных пользователем значений
            TextBox tb = (TextBox)sender;
            if (varLinkOutput.type == 3) {
                if (Regex.Match(tb.Text, @"-\.|\.-").Success) {
                    tb.Text = tb.Text.Replace("-", string.Empty); ;
                }
                else if (Regex.Match(tb.Text, @"^\.").Success) {
                    tb.Text = "";
                }
                if (Regex.Match(tb.Text, @"^-0[0-9]").Success)
                    tb.Text = tb.Text.Replace("0", string.Empty); ;
            }
            if (varLinkOutput.type == 2) {
                if (Regex.Match(tb.Text, @"-0").Success)
                    tb.Text = tb.Text.Remove(tb.Text.IndexOf("0"), 1);
            }
            if (varLinkOutput.type == 1) {
                if (tb.TextLength > 0 && !Regex.Match(tb.Text, @"^\\{1}.$|^.$").Success) {
                    tb.Text = "" + tb.Text[0];
                }
            }
            if (varLinkOutput.type == 3 || varLinkOutput.type == 2) {
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
