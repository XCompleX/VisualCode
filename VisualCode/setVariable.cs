using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualCode {
    public partial class setVariable : Block {

        protected int varType;
        public setVariable(string varName = "var", int varType = 0) {
            InitializeComponent();
            connElem = new List<object>();
            Name = varName;
            this.varType = varType;
            nameVariable.Text = Name;
            initEvents();
        }
        private setVariable() {
            InitializeComponent();
            initEvents();
        }
        public void changeInputValue(object sender, EventArgs e) { //значения вводит пользователь или по связи
            if (varLinkInput.link == null) {
                if (varType == 0) {
                    checkBox1.Visible = true;
                    InputValue.Visible = false;
                }
                else {
                    checkBox1.Visible = false;
                    InputValue.Visible = true;
                }
            }
            else {
                checkBox1.Visible = false;
                InputValue.Visible = false;
            }
        }
        private void initEvents() { //добавление событий элементам блока
            MouseEnter += new EventHandler(mouseEnter);
            BlockName.MouseEnter += new EventHandler(mouseEnter);
            nameVariable.MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);
            BlockName.MouseLeave += new EventHandler(mouseLeave);
            nameVariable.MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);
            BlockName.Enter += new EventHandler(enter);
            nameVariable.Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);
            BlockName.Leave += new EventHandler(leave);
            nameVariable.Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);
            BlockName.MouseDown += new MouseEventHandler(mouseDown);
            nameVariable.MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);
            BlockName.MouseUp += new MouseEventHandler(mouseUp);
            nameVariable.MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);
            BlockName.MouseMove += new MouseEventHandler(mouseMove);
            nameVariable.MouseMove += new MouseEventHandler(mouseMove);

            varLinkInput.BackgroundImageChanged += new EventHandler(changeInputValue);

            timer1.Tick += timer1_Tick;
        }
        public void setName(string name) { //изменеие имени, при изменении имени переменной
            nameVariable.Text = Name;
            Name = name;
        }
        public void setType(int varType) { //изменене типа, при изменении типа переменной
            this.varType = varType;
            varLinkOutput.setType(varType);
            varLinkInput.setType(varType);
            if (varType == 1)
                InputValue.MaxLength = 2;
            else
                InputValue.MaxLength = 32767;
        }

        public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 0, 255), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }

        private void InputValue_KeyPress(object sender, KeyPressEventArgs e) { //валидация вводимых значений пользователем
            if (varLinkInput.type == 3) {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.') && (e.KeyChar != '-')) {
                    e.Handled = true;
                }
                if (e.KeyChar == '-' && (InputValue.Text.IndexOf('-') > -1))
                    e.Handled = true;
                if ((e.KeyChar == '.') && (InputValue.Text.IndexOf('.') > -1)) {
                    e.Handled = true;
                }
            }
            else if (varLinkInput.type == 2) {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '-')) {
                    e.Handled = true;
                }
                if (e.KeyChar == '-' && (InputValue.Text.IndexOf('-') > -1))
                    e.Handled = true;
            }
        }

        private void InputValue_TextChanged(object sender, EventArgs e) { //валидация введенных значений пользователем
            if (varLinkInput.type == 3) {
                if (Regex.Match(InputValue.Text, @"-\.|\.-").Success) {
                    InputValue.Text = InputValue.Text.Replace("-", string.Empty); ;
                }
                else if (Regex.Match(InputValue.Text, @"^\.").Success) {
                    InputValue.Text = "";
                }
                if (Regex.Match(InputValue.Text, @"^-0[0-9]").Success)
                    InputValue.Text = InputValue.Text.Replace("0", string.Empty); ;
            }
            if (varLinkInput.type == 2) {
                if (Regex.Match(InputValue.Text, @"-0").Success)
                    InputValue.Text = InputValue.Text.Remove(InputValue.Text.IndexOf("0"), 1);
            }
            if (varLinkInput.type == 1) {
                if (InputValue.TextLength > 0 && !Regex.Match(InputValue.Text, @"^\\{1}.$|^.$").Success) {
                    InputValue.Text = "" + InputValue.Text[0];
                }
            }
            if (varLinkInput.type == 3 || varLinkInput.type == 2) {
                if (Regex.Match(InputValue.Text, @"^0[0-9]").Success)
                    InputValue.Text = InputValue.Text.TrimStart('0');
                if (Regex.Match(InputValue.Text, @"[0-9]-").Success)
                    InputValue.Text = InputValue.Text.Trim('-');
                if (Regex.Match(InputValue.Text, @"[0-9]-[0-9]").Success)
                    InputValue.Text = InputValue.Text.Replace("-", string.Empty);
            }
        }
    }
}
