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
    public partial class LogicBlock : VisualCode.Block {
        public LogicBlock() {
            InitializeComponent();
            initEvents();
            initLinks();
            elems.Add(new List<object> { varLinkInput1, checkBox1 });
            elems.Add(new List<object> { varLinkInput2, checkBox2 });
        }

        public List<List<object>> elems = new List<List<object>>();
        private void initLinks() { //инициализация связей
            varLinkInput1.setType(0);
            varLinkInput2.setType(0);
            varLinkOutput.setType(0);
        }

        public void changeInputValue(object sender, EventArgs e) { //значение вводит пользователь или по связи
            VarLinkInput vli = (VarLinkInput)sender;
            foreach (List<object> l in elems) {
                if (l.Contains(vli)) {
                    ((CheckBox)l[1]).Visible = vli.link == null;
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) { //запрет на изменение пользователем логических операторов
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

        private void addConditionButton_Click(object sender, EventArgs e) { //добавление входных связей для создания сложного условия
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height + 28);
                VarLinkInput vli = new VarLinkInput();
                vli.setType(0);
                vli.BackgroundImageChanged += new EventHandler(changeInputValue);
                CheckBox cb = new CheckBox();
                cb.Text = "";
                cb.AutoSize = false;
                cb.Size = new Size(18, 18);
                PictureBox subButton = new PictureBox();
                subButton.Image = Properties.Resources.minus;
                subButton.SizeMode = PictureBoxSizeMode.Zoom;
                subButton.BackgroundImageLayout = ImageLayout.Zoom;
                subButton.Width = 30;
                subButton.Height = 15;
                subButton.Name = elems.Count.ToString();
                Controls.Add(vli);
                Controls.Add(cb);
                Controls.Add(subButton);
                elems.Add(new List<object> { vli, cb, subButton });
                vli.Location = addConditionButton.Location;
                cb.Location = new Point(vli.Location.X + 24, vli.Location.Y);
                subButton.Location = new Point(cb.Location.X + 20, cb.Location.Y + 2);
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y + 28);
                varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y + 28);

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
        private void subConditionButton_MouseClick(object sender, EventArgs e) {// удаление входных связей
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height - 28);
                if (((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).link != null)
                    ((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).delete();
                Controls.Remove((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]);
                Controls.Remove((CheckBox)elems[int.Parse(((PictureBox)sender).Name)][1]);
                Controls.Remove((PictureBox)sender);
                for (int i = int.Parse(((PictureBox)sender).Name); i < elems.Count; i++) {
                    VarLinkInput vli = (VarLinkInput)elems[i][0];
                    CheckBox cb = (CheckBox)elems[i][1];
                    PictureBox sb = (PictureBox)elems[i][2];
                    vli.Location = new Point(vli.Location.X, vli.Location.Y - 28);
                    cb.Location = new Point(cb.Location.X, cb.Location.Y - 28);
                    sb.Location = new Point(sb.Location.X, sb.Location.Y - 28);
                }
                elems.Remove(elems[int.Parse(((PictureBox)sender).Name)]);
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y - 28);
                varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y - 28);
                ((Space)Parent).Invalidate();
            }
        }

        public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(192, 192, 192), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
            brush.Dispose();
        }
        private void initEvents() { //присвоение событий элементам блока 
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
    }
}
