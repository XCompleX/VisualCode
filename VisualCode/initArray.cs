using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace VisualCode {
    public partial class initArray : VisualCode.Block {

            public List<List<object>> elems = new List<List<object>>();

            public initArray() {
                InitializeComponent();
                initEvents();
                elems.Add(new List<object> { varLinkInput1, indexTextBox });
                varLinkInput1.setType(2);
            }
            public initArray(string name, int type, int sizeArray = 1) : this() { //дополнительный конструктор для инициализации блока - "инициализация массива"
                this.name.Text = name;
                Name = name;
                setSize(sizeArray);
            }

            private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { //валидация количества элементов массива вводимых пользователем
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
            }
            public void setName(string name) { //изменение имени блока, при изменении имени массива
                this.name.Text = Name;
                Name = name;
            }

            private void varLinkInput1_BackgroundImageChanged(object sender, EventArgs e) {
                VarLinkInput vli = (VarLinkInput)sender;
                TextBox tb = new TextBox();
                for(int i = 0; i < elems.Count; i++) {
                    if (elems[i].Contains(vli)) {
                        tb = (TextBox)elems[i][1];
                            break;
                    }
                }
                if (vli.link == null)
                    tb.Visible = true;
                else
                    tb.Visible = false;
            }

            public void setSize(int size) { //изменение количества связей для указания количества элементов в массиве или многомерном массиве
                if (elems.Count > size) {
                    for (int i = elems.Count - 1; i >= size; i--) {
                        ((VarLinkInput)elems[i][0]).delete();
                        Controls.Remove((VarLinkInput)elems[i][0]);
                        Controls.Remove((TextBox)elems[i][1]);
                        elems.RemoveAt(i);
                        Height -= 25;
                    }
                }
                else {
                    for (int i = elems.Count - 1; i < size - 1; i++) {
                        VarLinkInput vli = new VarLinkInput();
                        vli.Location = new Point(varLinkInput1.Location.X, ((VarLinkInput)elems[i][0]).Location.Y + 25);
                        vli.BackgroundImageChanged += new EventHandler(varLinkInput1_BackgroundImageChanged);
                        vli.setType(2);
                        TextBox tb = new TextBox();
                        tb.Size = new Size(34, 22);
                        tb.Location = new Point(indexTextBox.Location.X, ((TextBox)elems[i][1]).Location.Y + 25);
                        Controls.Add(tb);
                        Controls.Add(vli);
                        elems.Add(new List<object> { vli, tb });
                    }
                }
            }

            private void initEvents() { //привязка событий
                MouseEnter += new EventHandler(mouseEnter);
                name.MouseEnter += new EventHandler(mouseEnter);
                nameBlock.MouseEnter += new EventHandler(mouseEnter);

                MouseLeave += new EventHandler(mouseLeave);
                name.MouseLeave += new EventHandler(mouseLeave);
                nameBlock.MouseLeave += new EventHandler(mouseLeave);

                Enter += new EventHandler(enter);
                name.Enter += new EventHandler(enter);
                nameBlock.Enter += new EventHandler(enter);

                Leave += new EventHandler(leave);
                name.Leave += new EventHandler(leave);
                nameBlock.Leave += new EventHandler(leave);

                MouseDown += new MouseEventHandler(mouseDown);
                name.MouseDown += new MouseEventHandler(mouseDown);
                nameBlock.MouseDown += new MouseEventHandler(mouseDown);

                MouseUp += new MouseEventHandler(mouseUp);
                name.MouseUp += new MouseEventHandler(mouseUp);
                nameBlock.MouseUp += new MouseEventHandler(mouseUp);

                MouseMove += new MouseEventHandler(mouseMove);
                name.MouseMove += new MouseEventHandler(mouseMove);
                nameBlock.MouseMove += new MouseEventHandler(mouseMove);

                timer1.Tick += timer1_Tick;
            }

            public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка блока
                base.paint(sender, e);
                LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 0, 255), Color.FromArgb(105, 105, 105), 360);
                e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, 30));
                brush.Dispose();
            }
        }
}
