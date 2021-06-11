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
    public partial class AriphmeticBlock : VisualCode.Block {
        protected Image[] typeImage32 = new Image[] { //изображения типов данных
            Properties.Resources.boolean_capsule_32,
            Properties.Resources.char_capsule_32,
            Properties.Resources.integer_capsule_32,
            Properties.Resources.float_capsule_32,
            Properties.Resources.string_capsule_32,
        };
        public List<List<object>> elems = new List<List<object>>(); //Список источников "связей" и их обозначений, доб/удал пользователем

        public AriphmeticBlock() {
            Name = "AriphmeticBlock";
            InitializeComponent();
            initEvents();
            initLinks();
            elems.Add(new List<object> { varLinkInput1, textBox1, checkBox1 });
            elems.Add(new List<object> { varLinkInput2, textBox2, checkBox2 });
            textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
        }
        private void initLinks() { //Инициализация источников "связей"
            varLinkInput1.setType(2);
            varLinkInput2.setType(2);
            varLinkOutput.setType(2);
        }
        public virtual void changeInputValue(object sender, EventArgs e) { //Проверка как указано значение "связи" (вручную / линией)
            VarLinkInput vli = (VarLinkInput)sender;
            
            foreach (List<object> l in elems) {
                if (l.Contains(vli)) {
                    if (vli.link == null) {
                        if (vli.type == 0) {
                            ((CheckBox)l[2]).Visible = true;
                            ((TextBox)l[1]).Visible = false;
                        }
                        else {
                            ((CheckBox)l[2]).Visible = false;
                            ((TextBox)l[1]).Visible = true;
                        }
                    }
                    else {
                        ((CheckBox)l[2]).Visible = false;
                        ((TextBox)l[1]).Visible = false;
                    }
                }
            }
        }
        protected void varLinkMouseDown(object sender, MouseEventArgs e) { //контекстное меню при клике на блок
            if (e.Button == MouseButtons.Right && ((Space)Parent).holdingLink == null)
                showWorkSpaceContextMenu((VarLinkInput)sender, e.Location);
        }
        private void initEvents() { //привязка событий, элементам блока
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

        protected void textBox_KeyPress(object sender, KeyPressEventArgs e) { //фильтрация вводимых значений пользователем во время ввода
            TextBox tb = (TextBox)sender;
            VarLinkInput vli = null;
            foreach (List<object> list in elems) {
                if (list.Contains(tb)) {
                    vli = (VarLinkInput)list[0];
                    break;
                }
            }
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
        private void textBox_TextChanged(object sender, EventArgs e) { //фильтрация вводимых значений пользователем после ввода
            foreach (List<object> l in elems) {
                TextBox tb = (TextBox)sender;
                if (l.Contains(tb)) {
                    VarLinkInput vli = (VarLinkInput)l[0];
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
                    if (vli.type == 3 || vli.type == 2){
                        if (Regex.Match(tb.Text, @"^0[0-9]").Success)
                            tb.Text = tb.Text.TrimStart('0');
                        if (Regex.Match(tb.Text, @"[0-9]-").Success)
                            tb.Text = tb.Text.Trim('-');
                        if (Regex.Match(tb.Text, @"[0-9]-[0-9]").Success)
                            tb.Text = tb.Text.Replace("-",string.Empty);
                    }
                }
            }
        }
        public virtual void showWorkSpaceContextMenu(VarLinkInput vl, Point location) { //генерация контекстного меню
            ToolStripMenuItem[] tsmiTypes = new ToolStripMenuItem[] {
                new ToolStripMenuItem("bool",   typeImage32[0], setTypeCounter),
                new ToolStripMenuItem("char",   typeImage32[1], setTypeCounter),
                new ToolStripMenuItem("int",    typeImage32[2], setTypeCounter),
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
            int i = 2;
            foreach (object obj in Controls) {
                if (obj.GetType() == typeof(VarLinkInput)) {
                    if (i < 3 && ((VarLinkInput)obj).type == 3)
                        i = 3;
                }
            }
            varLinkOutput.setType(i);
            foreach (List<object> l in elems) {
                if (l.Contains(vli)) {
                    ((CheckBox)l[2]).Visible = type == 0;
                    ((TextBox)l[1]).Visible = type != 0;
                    ((CheckBox)l[2]).Checked = false;
                    ((TextBox)l[1]).Text = "";
                    if (vli.type == 1)
                        ((TextBox)l[1]).MaxLength = 2;
                    else
                        ((TextBox)l[1]).MaxLength = 32767;
                }
            }
            bool checkFloat = false;
            foreach (List<object> l in elems) {
                VarLinkInput vlie = (VarLinkInput)l[0];
                if (vlie.type == 3)
                    checkFloat = true;
            }
            if (checkFloat) {
                if (comboBox1.Items.Count == 5) {
                    comboBox1.Items.RemoveAt(4);
                    comboBox1.SelectedIndex = 0;
                }
            }
            else {
                if (comboBox1.Items.Count < 5)
                    comboBox1.Items.Add("%");
            }
            varLinkOutput.deleteAll();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) { //запрет на редактирование арифметических операторов
            e.Handled = true;
        }

        private void addConditionButton_MouseEnter(object sender, EventArgs e) {
            addConditionButton.BackgroundImage = Properties.Resources.circle;
            addConditionButton.Image = Properties.Resources.plus_black;
        }

        private void addConditionButton_MouseLeave(object sender, EventArgs e) {
            addConditionButton.BackgroundImage = null;
            addConditionButton.Image = Properties.Resources.plus;
        }

        public virtual void addConditionButton_Click(object sender, EventArgs e) { //добавление новых связей для блока пользователем
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height + 28);
                VarLinkInput vli = new VarLinkInput();
                vli.setType(2);
                vli.MouseDown += new MouseEventHandler(varLinkMouseDown);
                vli.BackgroundImageChanged += new EventHandler(changeInputValue);
                CheckBox cb = new CheckBox();
                cb.Text = "";
                cb.AutoSize = true;
                cb.Visible = false;
                TextBox tb = new TextBox();
                tb.AutoSize = true;
                tb.Width = 70;
                tb.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
                tb.TextChanged += new EventHandler(textBox_TextChanged);
                PictureBox subButton = new PictureBox();
                subButton.Image = Properties.Resources.minus;
                subButton.SizeMode = PictureBoxSizeMode.Zoom;
                subButton.BackgroundImageLayout = ImageLayout.Zoom;
                subButton.Width = 30;
                subButton.Height = 15;
                subButton.Name = elems.Count.ToString();
                Controls.Add(vli);
                Controls.Add(cb);
                Controls.Add(tb);
                Controls.Add(subButton);
                elems.Add(new List<object> { vli, tb, cb, subButton });
                vli.Location = addConditionButton.Location;
                tb.Location = new Point(vli.Location.X + 24, vli.Location.Y);
                cb.Location = new Point(vli.Location.X + 24, vli.Location.Y);
                subButton.Location = new Point(tb.Location.X + 70, tb.Location.Y + 5);
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y + 28);
                varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y + 28);

                subButton.MouseEnter += subConditionButton_MouseEnter;
                subButton.MouseLeave += subConditionButton_MouseLeave;
                subButton.Click += subConditionButton_MouseClick;
                ((Space)Parent).Invalidate();
            }
        }

        protected void subConditionButton_MouseEnter(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.circle;
            ((PictureBox)sender).Image = Properties.Resources.minus_black;
        }

        protected void subConditionButton_MouseLeave(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = null;
            ((PictureBox)sender).Image = Properties.Resources.minus;
        }
        public virtual void subConditionButton_MouseClick(object sender, EventArgs e) { //удаление связей для блока
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height - 28);
                if (((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).link != null)
                    ((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).delete();
                Controls.Remove((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]);
                Controls.Remove((TextBox)elems[int.Parse(((PictureBox)sender).Name)][1]);
                Controls.Remove((CheckBox)elems[int.Parse(((PictureBox)sender).Name)][2]);
                Controls.Remove((PictureBox)sender);
                for (int i = int.Parse(((PictureBox)sender).Name); i < elems.Count; i++) {
                    VarLinkInput vli = (VarLinkInput)elems[i][0];
                    TextBox tb = (TextBox)elems[i][1];
                    CheckBox cb = (CheckBox)elems[i][2];
                    PictureBox sb = (PictureBox)elems[i][3];
                    vli.Location = new Point(vli.Location.X, vli.Location.Y - 28);
                    cb.Location = new Point(cb.Location.X, cb.Location.Y - 28);
                    tb.Location = new Point(tb.Location.X, tb.Location.Y - 28);
                    sb.Location = new Point(sb.Location.X, sb.Location.Y - 28);
                }
                elems.Remove(elems[int.Parse(((PictureBox)sender).Name)]);
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y - 28);
                varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y - 28);
                ((Space)Parent).Invalidate();
            }
        }

        public override void paint(object sender, PaintEventArgs e) { //отрисовка элемента
            base.paint(sender,e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(192, 192, 192), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }
    }
}
