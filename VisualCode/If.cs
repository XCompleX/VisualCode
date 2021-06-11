using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class If : VisualCode.Block {
        public List<List<object>> elems = new List<List<object>>();
        public If() {
            InitializeComponent();
            Name = "If";
            initEvents();
            initLinks();
        }
        private void initLinks() { //инициализация связи
            varLinkInput.setType(0);
        }
        public void changeInputValue(object sender, EventArgs e) { //значение вводит пользователь или через связь
            VarLinkInput vli = (VarLinkInput)sender;
            if (vli == varLinkInput)
                checkBox1.Visible = vli.link == null;
            else {
                foreach (List<object> l in elems) {
                    if (l.Contains(vli)) {
                        ((CheckBox)l[3]).Visible = vli.link == null;
                    }
                }
            }
        }
        private void initEvents() { // привязка событий элементам блока
            MouseEnter += new EventHandler(mouseEnter);
            IfLabel.MouseEnter += new EventHandler(mouseEnter);
            ElseLabel.MouseEnter += new EventHandler(mouseEnter);
            nameBlock.MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);
            IfLabel.MouseLeave += new EventHandler(mouseLeave);
            ElseLabel.MouseLeave += new EventHandler(mouseLeave);
            nameBlock.MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);
            IfLabel.Enter += new EventHandler(enter);
            ElseLabel.Enter += new EventHandler(enter);
            nameBlock.Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);
            IfLabel.Leave += new EventHandler(leave);
            ElseLabel.Leave += new EventHandler(leave);
            nameBlock.Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);
            IfLabel.MouseDown += new MouseEventHandler(mouseDown);
            ElseLabel.MouseDown += new MouseEventHandler(mouseDown);
            nameBlock.MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);
            IfLabel.MouseUp += new MouseEventHandler(mouseUp);
            ElseLabel.MouseUp += new MouseEventHandler(mouseUp);
            nameBlock.MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);
            IfLabel.MouseMove += new MouseEventHandler(mouseMove);
            ElseLabel.MouseMove += new MouseEventHandler(mouseMove);
            nameBlock.MouseMove += new MouseEventHandler(mouseMove);

            timer1.Tick += timer1_Tick;
        }

        private void addConditionButton_MouseEnter(object sender, EventArgs e) {
            addConditionButton.BackgroundImage = Properties.Resources.circle;
            addConditionButton.Image = Properties.Resources.plus_black;
        }

        private void addConditionButton_MouseLeave(object sender, EventArgs e) {
            addConditionButton.BackgroundImage = null;
            addConditionButton.Image = Properties.Resources.plus;
        }

        private void addConditionButton_Click(object sender, EventArgs e) { //добавление связей условий для else if
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height + 30);
                VarLinkInput vli = new VarLinkInput();
                vli.setType(0);
                vli.BackgroundImageChanged += new EventHandler(changeInputValue);
                CheckBox cb = new CheckBox();
                cb.Text = "";
                cb.AutoSize = false;
                cb.Size = new Size(18, 18);
                Label l = new Label();
                l.Text = "ELSE IF";
                l.AutoSize = true;
                l.ForeColor = Color.White;
                l.BackColor = Color.Transparent;
                LinkOutput lo = new LinkOutput();
                lo.Name = "linkOutputElseIf";
                PictureBox subButton = new PictureBox();
                subButton.Image = Properties.Resources.minus;
                subButton.SizeMode = PictureBoxSizeMode.Zoom;
                subButton.BackgroundImageLayout = ImageLayout.Zoom;
                subButton.BackColor = Color.Transparent;
                subButton.Width = 30;
                subButton.Height = 15;
                subButton.Name = elems.Count.ToString();
                Controls.Add(vli);
                Controls.Add(l);
                Controls.Add(lo);
                Controls.Add(subButton);
                Controls.Add(cb);
                elems.Add(new List<object> { vli, l, lo, cb, subButton});
                vli.Location = addConditionButton.Location;
                cb.Location = new Point(vli.Location.X + 20, vli.Location.Y);
                l.Location = new Point(ElseLabel.Location.X - 15, ElseLabel.Location.Y - 3);
                l.TextAlign = ContentAlignment.MiddleRight;
                lo.Location = linkOutputElse.Location;
                subButton.Location = new Point(l.Location.X - 30, l.Location.Y);
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y + 30);
                linkOutputElse.Location = new Point(linkOutputElse.Location.X, linkOutputElse.Location.Y + 30);
                ElseLabel.Location = new Point(ElseLabel.Location.X, ElseLabel.Location.Y + 30);

                subButton.MouseEnter += subConditionButton_MouseEnter;
                subButton.MouseLeave += subConditionButton_MouseLeave;
                subButton.Click += subConditionButton_MouseClick;
                ((Space)Parent).Invalidate();
            }
        }

        private void subConditionButton_MouseEnter(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.circle;
            ((PictureBox)sender).Image = Properties.Resources.minus_black;
        }

        private void subConditionButton_MouseLeave(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = null;
            ((PictureBox)sender).Image = Properties.Resources.minus;
        }
        private void subConditionButton_MouseClick(object sender, EventArgs e) { //удаление условий связей для else if
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height - 30);
                if (((LinkOutput)elems[int.Parse(((PictureBox)sender).Name)][2]).elem != null) {
                    ((LinkOutput)elems[int.Parse(((PictureBox)sender).Name)][2]).delete();
                }
                if (((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).link != null)
                    ((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).delete();
                Controls.Remove((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]);
                Controls.Remove((Label)elems[int.Parse(((PictureBox)sender).Name)][1]);
                Controls.Remove((LinkOutput)elems[int.Parse(((PictureBox)sender).Name)][2]);
                Controls.Remove((CheckBox)elems[int.Parse(((PictureBox)sender).Name)][3]);
                Controls.Remove((PictureBox)sender);
                for (int i = int.Parse(((PictureBox)sender).Name); i < elems.Count; i++) {
                    VarLinkInput vli = (VarLinkInput)elems[i][0];
                    Label l = (Label)elems[i][1];
                    LinkOutput lo = (LinkOutput)elems[i][2];
                    CheckBox cb = (CheckBox)elems[i][3];
                    PictureBox sb = (PictureBox)elems[i][4];
                    vli.Location = new Point(vli.Location.X, vli.Location.Y - 30);
                    l.Location = new Point(l.Location.X, l.Location.Y - 30);
                    lo.Location = new Point(lo.Location.X, lo.Location.Y - 30);
                    sb.Location = new Point(sb.Location.X, sb.Location.Y - 30);
                    cb.Location = new Point(cb.Location.X, cb.Location.Y - 30);
                }
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y - 30);
                linkOutputElse.Location = new Point(linkOutputElse.Location.X, linkOutputElse.Location.Y - 30);
                ElseLabel.Location = new Point(ElseLabel.Location.X, ElseLabel.Location.Y - 30);
                ((Space)Parent).Invalidate();
            }
        }
        public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(192, 192, 192), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }
    }
}
