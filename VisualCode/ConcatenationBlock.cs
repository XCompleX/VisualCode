using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VisualCode {
    public partial class ConcatenationBlock : VisualCode.AriphmeticBlock {
        public ConcatenationBlock() {
            Name = "ConcatenationBlock";
            InitializeComponent();
            varLinkInput1.setType(4);
            varLinkInput2.setType(4);
            varLinkOutput.setType(4);
        }

        public override void showWorkSpaceContextMenu(VarLinkInput vl, Point location) { //генерация контекстного меню
            ToolStripMenuItem[] tsmiTypes = new ToolStripMenuItem[] {
                new ToolStripMenuItem("char",  typeImage32[1], setTypeCounter),
                new ToolStripMenuItem("string",  typeImage32[4], setTypeCounter),
            };

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmiTypes);
            cms.Show(vl, location);
        }

        public override void setTypeCounter(object sender, EventArgs e) { //изменение типа связи
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip cms = (ContextMenuStrip)(tsmi).Owner;
            VarLinkInput vli = ((VarLinkInput)(cms.SourceControl));
            int type = cms.Items.IndexOf(tsmi) == 0 ? 1 : 4;
            vli.setType(type);
            foreach (List<object> l in elems) {
                if (l.Contains(vli)) {
                    ((TextBox)l[1]).Text = "";
                    if (vli.type == 1)
                        ((TextBox)l[1]).MaxLength = 2;
                    else
                        ((TextBox)l[1]).MaxLength = 32767;
                }
            }
            varLinkOutput.deleteAll();
        }

        public override void addConditionButton_Click(object sender, EventArgs e) { //добавление пользователем связей на блок
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height + 28);
                VarLinkInput vli = new VarLinkInput();
                vli.setType(4);
                vli.MouseDown += new MouseEventHandler(varLinkMouseDown);
                vli.BackgroundImageChanged += new EventHandler(changeInputValue);
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
                Controls.Add(tb);
                Controls.Add(subButton);
                elems.Add(new List<object> { vli, tb, subButton });
                vli.Location = addConditionButton.Location;
                tb.Location = new Point(vli.Location.X + 24, vli.Location.Y);
                subButton.Location = new Point(tb.Location.X + 70, tb.Location.Y + 5);
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y + 28);
                varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y + 28);

                subButton.MouseEnter += subConditionButton_MouseEnter;
                subButton.MouseLeave += subConditionButton_MouseLeave;
                subButton.Click += subConditionButton_MouseClick;
                ((Space)Parent).Invalidate();
            }
        }
        public override void subConditionButton_MouseClick(object sender, EventArgs e) { //удаление пользователем связей на блоке
            if (((Space)Parent).holdingLink == null) {
                this.Size = new Size(Size.Width, Size.Height - 28);
                if (((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).link != null)
                    ((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]).delete();
                Controls.Remove((VarLinkInput)elems[int.Parse(((PictureBox)sender).Name)][0]);
                Controls.Remove((TextBox)elems[int.Parse(((PictureBox)sender).Name)][1]);
                Controls.Remove((PictureBox)sender);
                for (int i = int.Parse(((PictureBox)sender).Name); i < elems.Count; i++) {
                    VarLinkInput vli = (VarLinkInput)elems[i][0];
                    TextBox tb = (TextBox)elems[i][1];
                    PictureBox sb = (PictureBox)elems[i][2];
                    vli.Location = new Point(vli.Location.X, vli.Location.Y - 28);
                    tb.Location = new Point(tb.Location.X, tb.Location.Y - 28);
                    sb.Location = new Point(sb.Location.X, sb.Location.Y - 28);
                }
                elems.Remove(elems[int.Parse(((PictureBox)sender).Name)]);
                addConditionButton.Location = new Point(addConditionButton.Location.X, addConditionButton.Location.Y - 28);
                varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y - 28);
                ((Space)Parent).Invalidate();
            }
        }
        public override void changeInputValue(object sender, EventArgs e) { //значение вводит пользователем или оно указано линией связи
            VarLinkInput vli = (VarLinkInput)sender;

            foreach (List<object> l in elems) {
                if (l.Contains(vli)) {
                    ((TextBox)l[1]).Visible = vli.link == null;
                }
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e) { //фильтрация вводимых значений пользователем
            TextBox tb = (TextBox)sender;
            VarLinkInput vli = (tb == textBox1 ? varLinkInput1 : varLinkInput2);
            if (vli.type == 1) {
                if (tb.TextLength > 0 && !Regex.Match(tb.Text, @"^\\{1}.$|^.$").Success) {
                    tb.Text = "" + tb.Text[0];
                }
            }
        }
    }
}
