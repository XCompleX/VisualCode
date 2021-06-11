using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VisualCode {
    public partial class setElem : VisualCode.setVariable {
        public List<List<object>> elems = new List<List<object>>();
        public setElem(string varName = "var", int varType = 0, int size = 1)
            : base(varName,varType) {
            InitializeComponent();
            elems.Add(new List<object> { varLinkInput1, indexTextBox });
            varLinkInput1.setType(2);
            setSize(size);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { //валидация значений индексов вводимых пользователем
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void varLinkInput1_BackgroundImageChanged(object sender, EventArgs e) {
            VarLinkInput vli = (VarLinkInput)sender;
            TextBox tb = new TextBox();
            for (int i = 0; i < elems.Count; i++) {
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

        public void setSize(int size) { //измение количества связей индексов в зависимости от размера массива
            if (elems.Count > size) {
                for (int i = elems.Count - 1; i >= size; i--) {
                    ((VarLinkInput)elems[i][0]).delete();
                    Controls.Remove((VarLinkInput)elems[i][0]);
                    Controls.Remove((TextBox)elems[i][1]);
                    InputValue.Location = new Point(InputValue.Location.X, InputValue.Location.Y - 25);
                    checkBox1.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y - 25);
                    varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y - 25);
                    varLinkInput.Location = new Point(varLinkInput.Location.X, varLinkInput.Location.Y - 25);
                    elems.RemoveAt(i);
                    Height -= 25;
                }
            }
            else {
                for (int i = elems.Count; i < size; i++) {
                    VarLinkInput vli = new VarLinkInput();
                    vli.Location = new Point(varLinkInput1.Location.X, varLinkInput.Location.Y);
                    vli.BackgroundImageChanged += new EventHandler(varLinkInput1_BackgroundImageChanged);
                    vli.setType(2);
                    TextBox tb = new TextBox();
                    tb.Size = new Size(34, 22);
                    tb.Location = new Point(indexTextBox.Location.X, InputValue.Location.Y);
                    checkBox1.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + 25);
                    InputValue.Location = new Point(InputValue.Location.X, InputValue.Location.Y + 25);
                    varLinkOutput.Location = new Point(varLinkOutput.Location.X, varLinkOutput.Location.Y + 25);
                    varLinkInput.Location = new Point(varLinkInput.Location.X, varLinkInput.Location.Y + 25);
                    Controls.Add(tb);
                    Controls.Add(vli);
                    elems.Add(new List<object> { vli, tb });
                }
            }
        }
    }
}
