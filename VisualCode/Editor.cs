using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace VisualCode {
    public partial class Editor : Form {
        MediaPlayer GraphicCalibr = new MediaPlayer(); //при создании этого объекта форма отображается более четко
        StreamWriter sw;

        String counterName = "_a";
        int Error = 0;
        int Warning = 0;
        bool innerLoop = false;

        Point mousePosForSizeChanged = new Point(0,0);

        string[] types = new string[]{ //типы данных
            "bool",
            "char",
            "int",
            "float",
            "string",
        };

        public class Variable { //класс длях структурирования информации о созданных пользователем переменных
            public int type;
            public string name;
            public string value;
            public int size;

            public Variable() {
                type = 0;
                name = "var";
                value = "false";
                size = 1;
            }
        };

        public List<Variable> variables = new List<Variable>(); //список созданных пользователем переменных

        startBlock startProgramm;
        
        int nesting = 1;
        public bool codeGenMenu = false;

        Image[] typeImage = new Image[] { // изображения типов данных
            Properties.Resources.boolean_capsule_32,
            Properties.Resources.char_capsule_32,
            Properties.Resources.integer_capsule_32,
            Properties.Resources.float_capsule_32,
            Properties.Resources.string_capsule_32,
            Properties.Resources.boolArray,
            Properties.Resources.charArray,
            Properties.Resources.intArray,
            Properties.Resources.floatArray,
            Properties.Resources.stringArray,
        };

        Code code;

        public Editor() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            startProgramm = new startBlock();
            WorkSpace.Controls.Add(startProgramm);
        }
        private void Variables_AddButton_MouseEnter(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.circle;
            ((PictureBox)sender).Image = Properties.Resources.plus_black;
        }
        private void Variables_AddButton_MouseLeave(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = null;
            ((PictureBox)sender).Image = Properties.Resources.plus;
        }
        private void Variables_AddButton_Click(object sender, EventArgs e) { //добавление пользователем новой переменной
            ((PictureBox)sender).Focus();
            Variable a = new Variable();
            a.value = "false";
            for (int i = 0; ; i++) {
                string name = (i == 0 ? "var" : "var" + i.ToString());
                if (variables.Find(x => x.name == name) == null) {
                    a.name = name;
                    a.type = 0;
                    break;
                }
            }
            variables.Add(a);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Size = new Size(250, 25);
            panel.BackColor = System.Drawing.Color.Gray;
            panel.Name = a.name;

            PictureBox buttonType = new PictureBox();
            buttonType.Image = Properties.Resources.boolean_capsule;
            buttonType.Size = new Size(25, 22);
            buttonType.SizeMode = PictureBoxSizeMode.Zoom;
            buttonType.BackgroundImageLayout = ImageLayout.Zoom;
            buttonType.Click += new EventHandler(Variables_TypeButton_Click);
            buttonType.MouseEnter += new EventHandler(Variables_TypeButton_MouseEnter);
            buttonType.MouseLeave += new EventHandler(Variables_TypeButton_MouseLeave);
            panel.Controls.Add(buttonType);

            Label nameVariable = new Label();
            nameVariable.ForeColor = System.Drawing.Color.Black;
            nameVariable.Size = new Size(160, 22);//185
            nameVariable.Text = a.name;
            nameVariable.TextAlign = ContentAlignment.MiddleCenter;
            nameVariable.Font = new Font("GenericSansSerif", 8, FontStyle.Bold);
            nameVariable.DoubleClick += new EventHandler(Variables_nameBox_DoubleClick);
            panel.Controls.Add(nameVariable);

            TextBox nameVariableBox = new TextBox();
            nameVariableBox.ForeColor = System.Drawing.Color.Black;
            nameVariableBox.Size = new Size(160, 22);
            nameVariableBox.Text = a.name;
            nameVariableBox.Name = "nameVariableBox";
            nameVariableBox.BackColor = System.Drawing.Color.DarkGray;
            nameVariableBox.BorderStyle = BorderStyle.Fixed3D;
            nameVariableBox.TextAlign = HorizontalAlignment.Center;
            nameVariableBox.Font = new Font("GenericSansSerif", 8, FontStyle.Bold);
            nameVariableBox.Visible = false;
            nameVariableBox.LostFocus += new EventHandler(Variables_nameBox_LostFocus);
            nameVariableBox.Leave += new EventHandler(Variables_nameBox_LostFocus);
            nameVariableBox.CursorChanged += new EventHandler(Variables_nameBox_LostFocus);
            nameVariableBox.KeyDown += new KeyEventHandler(Variables_nameBox_Enter);
            panel.Controls.Add(nameVariableBox);

            TextBox sizeVariableArrayBox = new TextBox();
            sizeVariableArrayBox.ForeColor = System.Drawing.Color.Black;
            sizeVariableArrayBox.Size = new Size(25, 22);
            sizeVariableArrayBox.Text = "1";
            sizeVariableArrayBox.Name = "sizeVariableArrayBox";
            sizeVariableArrayBox.BackColor = System.Drawing.Color.DarkGray;
            sizeVariableArrayBox.BorderStyle = BorderStyle.Fixed3D;
            sizeVariableArrayBox.TextAlign = HorizontalAlignment.Center;
            sizeVariableArrayBox.Font = new Font("GenericSansSerif", 8, FontStyle.Bold);
            sizeVariableArrayBox.Visible = false;
            sizeVariableArrayBox.LostFocus += new EventHandler(Variables_sizeArrayBox_LostFocus);
            sizeVariableArrayBox.KeyDown += new KeyEventHandler(Variables_sizeArrayBox_Enter);
            sizeVariableArrayBox.KeyPress += new KeyPressEventHandler(Variables_sizeArrayBox_KeyPress);
            panel.Controls.Add(sizeVariableArrayBox);

            PictureBox buttonDel = new PictureBox();
            buttonDel.Image = Properties.Resources.minus;
            buttonDel.Size = new Size(15, 22);
            buttonDel.SizeMode = PictureBoxSizeMode.Zoom;
            buttonDel.BackgroundImageLayout = ImageLayout.Zoom;
            buttonDel.MouseEnter += new EventHandler(Variables_SubButton_MouseEnter);
            buttonDel.MouseLeave += new EventHandler(Variables_SubButton_MouseLeave);
            buttonDel.Click += new EventHandler(Variables_SubButton_Click);
            panel.Controls.Add(buttonDel);

            Variables_List.Controls.Add(panel);
        }
        private void Variables_sizeArrayBox_KeyPress(object sender, KeyPressEventArgs e) { //фильтрация значений размеров для масива
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
        private void Variables_sizeArrayBox_Enter(object sender, KeyEventArgs e) { //подтверждение изменения размера массива
            if (e.KeyCode == Keys.Enter) {
                WorkSpace.Focus();
            }
        }
        private void Variables_sizeArrayBox_LostFocus(object sender, EventArgs e) { //изменение блоков(массивы) добавленных на Space при изменении размера
            TextBox tbindex = (TextBox)sender;
            TextBox tbname = (TextBox)tbindex.Parent.Controls.Find("nameVariableBox", false)[0];
            if (tbindex.Text == "" || int.Parse(tbindex.Text) == 0)
                tbindex.Text = "1";
            variables.Find(x => x.name == tbname.Text).size = int.Parse(tbindex.Text);
            foreach (object elem in WorkSpace.Controls) {
                if (elem.GetType() == typeof(setElem) && ((setElem)elem).Name == tbname.Text) {
                    setElem se = (setElem)elem;
                    se.setSize(int.Parse(tbindex.Text));
                }
                else if (elem.GetType() == typeof(getElem) && ((getElem)elem).Name == tbname.Text) {
                    getElem ge = (getElem)elem;
                    ge.setSize(int.Parse(tbindex.Text));
                }
                else if (elem.GetType() == typeof(initArray) && ((initArray)elem).Name == tbname.Text) {
                    initArray ia = (initArray)elem;
                    ia.setSize(int.Parse(tbindex.Text));
                }
            }
        }
        private void Variables_SubButton_MouseEnter(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.circle;
            ((PictureBox)sender).Image = Properties.Resources.minus_black;
        }
        private void Variables_SubButton_MouseLeave(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = null;
            ((PictureBox)sender).Image = Properties.Resources.minus;
        }
        private void Variables_SubButton_Click(object sender, EventArgs e) { //удаление переменной пользователем
            ((PictureBox)sender).Focus();
            variables.Remove(variables.Find(x => x.name == ((PictureBox)sender).Parent.Name));
            Variables_List.Controls.Remove(((PictureBox)sender).Parent);
            Control[] removeElems = WorkSpace.Controls.Find(((PictureBox)sender).Parent.Name, false);
            for (int i = 0; i < removeElems.Length; i++) {
                ((Block)removeElems[i]).delete();
            }
        }
        private void Variables_ToggleButton_Click(object sender, EventArgs e) {
            Variables_List.Visible = !Variables_List.Visible;
            Variables_Panel.Height = Variables_List.Visible ? 221 : 34;
            ((PictureBox)sender).Focus();
        }
        private void Variables_TypeButton_Click(object sender, EventArgs e) { //генерация контестного меню для изменения типа переменной
            ContextMenuStrip m = new ContextMenuStrip();
            ToolStripMenuItem[] tsmi = new ToolStripMenuItem[] {
                new ToolStripMenuItem("bool",   typeImage[0]),
                new ToolStripMenuItem("char",   typeImage[1]),
                new ToolStripMenuItem("int",    typeImage[2]),
                new ToolStripMenuItem("float",  typeImage[3]),
                new ToolStripMenuItem("string", typeImage[4]),
                new ToolStripMenuItem("bool array",   typeImage[5]),
                new ToolStripMenuItem("char array",   typeImage[6]),
                new ToolStripMenuItem("int array",    typeImage[7]),
                new ToolStripMenuItem("float array",  typeImage[8]),
                new ToolStripMenuItem("string array", typeImage[9]),
            };
            for (int i = 0; i < tsmi.Length; i++) {
                tsmi[i].ImageTransparentColor = System.Drawing.Color.Black;
                tsmi[i].BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
                tsmi[i].ForeColor = System.Drawing.Color.White;
                tsmi[i].Name = ((PictureBox)sender).Parent.Name;
                tsmi[i].Click += new EventHandler(setVariableTypeEvent);
                m.Items.Add(tsmi[i]);
            }
            ((PictureBox)sender).Focus();
            m.Show(this, new Point(((PictureBox)sender).Parent.Location.X + 25, ((PictureBox)sender).Parent.Location.Y + 70));
        }
        private void Variables_TypeButton_MouseEnter(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = ((PictureBox)sender).Image;
            if ((variables.Find(x => x.name == ((PictureBox)sender).Parent.Name)).type < 5)
                ((PictureBox)sender).Image = Properties.Resources.hover_capsule;
            else
                ((PictureBox)sender).Image = Properties.Resources.Array_hover;
        }
        private void Variables_TypeButton_MouseLeave(object sender, EventArgs e) {
            ((PictureBox)sender).Image = ((PictureBox)sender).BackgroundImage;
            ((PictureBox)sender).BackgroundImage = null;
        }
        private void Variables_nameBox_DoubleClick(object sender, EventArgs e) { //вывод поля для изменения имени переменной пользователем
            Label nameBox = ((Label)sender);
            TextBox nameVariableBox = (TextBox)nameBox.Parent.Controls.Find("nameVariableBox", false)[0];
            nameBox.Visible = false;
            nameVariableBox.Visible = true;
            nameVariableBox.Focus();
        }
        private void Variables_nameBox_LostFocus(object sender, EventArgs e) {
            setVariableName(((TextBox)sender), ((Label)((TextBox)sender).Parent.Controls[1]));
        }
        private void Variables_nameBox_Enter(object sender, KeyEventArgs e) { //подтверждение изменения имени переменной
            if (e.KeyCode == Keys.Enter) {
                setVariableName(((TextBox)sender), ((Label)((TextBox)sender).Parent.Controls[1]));
            }
        }
        private void Variables_Panel_Click(object sender, EventArgs e) {
            ((Panel)sender).Focus();
        }
        private void Variables_List_Click(object sender, EventArgs e) {
            ((FlowLayoutPanel)sender).Focus();
        }
        private void ToggleButton_MouseEnter(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.triangle_hover;
        }
        private void ToggleButton_MouseLeave(object sender, EventArgs e) {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.triangle;
        }
        private void flowLayoutPanel1_Click(object sender, EventArgs e) {
            ((FlowLayoutPanel)sender).Focus();
        }
        private void setVariableName(TextBox textBox, Label label) {//Поиск и изменение имени блока(переменные-массивы) при изменении имени переменной
            foreach (object elem in WorkSpace.Controls) {
                if (elem.GetType() == typeof(getVariable)) {
                    if (((getVariable)elem).Name == textBox.Parent.Name) {
                        ((getVariable)elem).Name = textBox.Text;
                        ((getVariable)elem).setName(textBox.Text);
                    }
                }
                else if (elem.GetType() == typeof(setVariable)) {
                    if (((setVariable)elem).Name == textBox.Parent.Name) {
                        ((setVariable)elem).Name = textBox.Text;
                        ((setVariable)elem).setName(textBox.Text);
                    }
                }
                else if (elem.GetType() == typeof(setElem)) {
                    if (((setElem)elem).Name == textBox.Parent.Name) {
                        ((setElem)elem).Name = textBox.Text;
                        ((setElem)elem).setName(textBox.Text);
                    }
                }
                else if (elem.GetType() == typeof(getElem)) {
                    if (((getElem)elem).Name == textBox.Parent.Name) {
                        ((getElem)elem).Name = textBox.Text;
                        ((getElem)elem).setName(textBox.Text);
                    }
                }
                else if (elem.GetType() == typeof(initArray)) {
                    if (((initArray)elem).Name == textBox.Parent.Name) {
                        ((initArray)elem).Name = textBox.Text;
                        ((initArray)elem).setName(textBox.Text);
                    }
                }
            }

            textBox.Visible = false;
            textBox.Parent.Controls[1].Visible = true;
            variables.Find(x => x.name == textBox.Parent.Name).name = textBox.Text;
            textBox.Parent.Name = textBox.Text;
            label.Parent.Controls[1].Text = textBox.Text;
            
        }
        private void setVariableTypeEvent(object sender, EventArgs e) { //изменение типа переменной
            string[] defaultValue = new string[] { "false", "\'\'", "0", "0.0", "\"\"", "{false}", "{\'\'}", "{0}", "{0.0}", "{\"\"}" };
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            Control c = Variables_List.Controls.Find((tsmi).Name, false)[0];
            TextBox tbIndex = (TextBox)c.Controls.Find("sizeVariableArrayBox", false)[0];

            int index = tsmi.GetCurrentParent().Items.IndexOf(tsmi);
            if (index > 4) {
                tbIndex.Visible = true;
                tbIndex.Text = "1";
            }
            else 
                tbIndex.Visible = false;

            variables.Find(x => x.name == tsmi.Name).type = index;
            variables.Find(x => x.name == tsmi.Name).value = defaultValue[index];
            PictureBox Button = (PictureBox)c.Controls[0];
            Button.Image = typeImage[index];

            for (int i = 0; i < WorkSpace.Controls.Count; i++) {
                object elem = WorkSpace.Controls[i];
                if (elem.GetType() == typeof(setElem)) {
                    setElem se = (setElem)elem;
                    if (se.Name == tsmi.Name) {
                        if (index < 5) {
                            foreach (object obj in se.Controls) {
                                if (obj.GetType() == typeof(VarLinkInput))
                                    ((VarLinkInput)obj).delete();
                            }
                            se.varLinkOutput.deleteAll();
                            WorkSpace.Controls.Remove(se);
                            i--;
                        }
                        else {
                            se.varLinkInput.setType(index % 5);
                            se.varLinkOutput.setType(index % 5);
                            se.varLinkInput.delete();
                            se.varLinkOutput.deleteAll();

                            if (index % 5 == 0) {
                                se.checkBox1.Visible = true;
                                se.InputValue.Visible = false;
                            }
                            else {
                                se.checkBox1.Visible = false;
                                se.InputValue.Visible = true;
                            }
                        }
                    }
                }
                else if (elem.GetType() == typeof(getElem)) {
                    getElem ge = (getElem)elem;
                    if (ge.Name == tsmi.Name) {
                        if (index < 5) {
                            foreach (object obj in ge.Controls) {
                                if (obj.GetType() == typeof(VarLinkInput))
                                    ((VarLinkInput)obj).delete();
                            }
                            ge.varLinkOutput.deleteAll();
                            WorkSpace.Controls.Remove(ge);
                            i--;
                        }
                        else {
                            ge.varLinkOutput.setType(index % 5);
                            ge.varLinkOutput.deleteAll();
                        }
                    }
                }
                else if (elem.GetType() == typeof(getVariable)) {
                    getVariable gv = (getVariable)elem;
                    if (gv.Name == tsmi.Name) {
                        gv.setType(index);
                        VarLinkOutput vlo = gv.varLinkOutput;
                        vlo.deleteAll();
                    }
                }
                else if (elem.GetType() == typeof(setVariable)) {
                    setVariable sv = (setVariable)elem;
                    if (sv.Name == tsmi.Name) {
                        sv.setType(index);
                        VarLinkOutput vlo = sv.varLinkOutput;
                        VarLinkInput vli = (VarLinkInput)sv.Controls.Find("varLinkInput", false)[0];
                        vlo.deleteAll();
                        vli.delete();
                        sv.InputValue.Text = "";
                        sv.checkBox1.Checked = false;
                    }
                }
                else if (elem.GetType() == typeof(initArray)) {
                    initArray ia = (initArray)elem;
                    if (ia.Name == tsmi.Name) {
                        if (index < 5) {
                            foreach (object obj in ia.Controls) {
                                if (obj.GetType() == typeof(VarLinkInput))
                                    ((VarLinkInput)obj).delete();
                            }
                            ia.linkInput.delete();
                            ia.linkOutput.delete();
                            WorkSpace.Controls.Remove(ia);
                            i--;
                        }
                    }
                }
            }
            WorkSpace.Invalidate();
        }
        public Point PointSubstract(Point a1, Point a2) {
            a1.X -= a2.X;
            a1.Y -= a2.Y;
            return a1;
        }
        public Point PointAddition(Point a1, Point a2) {
            a1.X += a2.X;
            a1.Y += a2.Y;
            return a1;
        }
        public Point PointDivision(Point a1, int a2) {
            a1.X /= a2;
            a1.Y /= a2;
            return a1;
        }
        private void собратьToolStripMenuItem1_Click(object sender, EventArgs e) { //трансляция схемы, собранной пользователем на язык c++ и сохранение в файл
            richTextBox1.Text = "";
            Error = 0;
            Warning = 0;
            sw = new StreamWriter(Application.StartupPath + "/MinGW64/bin/program.cpp", false, Encoding.GetEncoding(1251));

            sw.WriteLine(
                "#include <iostream>\n" +
                "#include <string>\n" +
                "#include <stdlib.h>\n" +
                "#include <sstream>\n" +
                "using namespace std;\n" +
                "string to_str(bool b) {\n" +
                "    ostringstream ss;\n" +
                "    ss << b;\n" +
                "    return ss.str();\n" +
                "}\n" +
                "string to_str(char b) {\n" +
                "    ostringstream ss;\n" +
                "    ss << b;\n" +
                "    return ss.str();\n" +
                "}\n" +

                "string to_str(int b) {\n" +
                "    ostringstream ss;\n" +
                "    ss << b;\n" +
                "    return ss.str();\n" +
                "}\n" +
                "string to_str(float b) {\n" +
                "    ostringstream ss;\n" +
                "    ss << b;\n" +
                "    return ss.str();\n" +
                "}\n" +
                "int main() {\n" +
                "    setlocale(LC_ALL, \"Russian\");\n" +
                "    string read;"
            );
            foreach (Variable v in variables) {
                if (v.type < 5)
                    sw.WriteLine($"    {types[v.type]} _{v.name} = {v.value};");
                else {
                    string type = types[v.type % 5];
                    for (int i = 0; i < v.size; i++)
                        type += "*";
                    sw.WriteLine($"    {type} _{v.name};");
                }
            }

            blockPassage(startProgramm);
            
            sw.WriteLine(
                "    system(\"pause\");\n" +
                "    return 0;\n" +
                "}"
            );

            sw.Close();

            richTextBox1.Text += "\nРезультат компиляции...\n";
            richTextBox1.Text += "--------\n";
            richTextBox1.Text += $"- Ошибки: {Error}\n";
            richTextBox1.Text += $"- Предупреждения: {Warning}\n";

            if(codeGenMenu)
                code.update();
        }
        private void собратьИЗапуститьToolStripMenuItem_Click(object sender, EventArgs e) { //сборка и запуск собираемого файла
            собратьToolStripMenuItem1_Click(sender, e);
            if (Error == 0) {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/MinGW64/bin & compile.bat";
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            else {
                richTextBox1.Text += "--------\n";
                richTextBox1.Text += "Запуск невозможен! Устраните ошибки!\n";
            }
            if(codeGenMenu)
                code.update();
        }
        void blockPassage(Block b) { // проход по собранной схеме через связи, генерация кода для определенных блоков, проверка корректной сборки схемы
            Console.WriteLine(nesting);
            LinkOutput lo;
            Block nextElem = b;
            while (true) {
                if (nextElem.GetType() == typeof(print)) {
                    print p = (print)nextElem;
                    string value;
                    if (p.varLinkInput.link != null)

                        value = $"cout << {inputValuePassage(p.varLinkInput, p)};";
                    else {
                        if (p.InputValue.TextLength == 0) {
                            richTextBox1.Text += $"Предупреждение: в Print нет входного аргумента!\n";
                            Warning++;
                        }
                        value = $"cout << \"{p.InputValue.Text}\";";
                    }
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine(value);
                }
                if (nextElem.GetType() == typeof(initArray)) {
                    initArray p = (initArray)nextElem;
                    string value = "";
                    Variable v = variables.Find(x => x.name == p.Name);
                    foreach (List<object> l in p.elems) {
                        VarLinkInput vli = (VarLinkInput)l[0];
                        TextBox tb = (TextBox)l[1];
                        if (vli.link == null && tb.TextLength == 0) {
                            richTextBox1.Text += $"Ошибка: не все элементы initArray имеют значение!\n";
                            Error++;
                            break;
                        }
                    }
                    int k = 0;
                    string[] sizes = new string[v.size];
                    foreach (List<object> l in p.elems) {
                        VarLinkInput vli = (VarLinkInput)l[0];
                        TextBox tb = (TextBox)l[1];
                        if (vli.link == null && tb.Text != "")
                            sizes[k] = tb.Text;
                        else if (vli.link != null) {
                            sizes[k] = inputValuePassage(vli, p);
                        }
                        k++;
                    }
                    for (int i = 0; i < sizes.Length; i++) {
                        value += $"_{p.Name}";
                        string variable = "";
                        for (int l = 0; l < i; l++) {
                            variable += "a";
                            value += $"[{variable}]";
                        }
                        value += $" = new {types[v.type % 5]}";
                        for (int j = sizes.Length-(i+1); j > 0; j--) value += "*";
                        value += $"[{sizes[i]}];\n";

                        variable = "";
                        for (int l = 0; l < i+1; l++)
                            variable += "a";
                        if (i == sizes.Length - 1) break;
                        value += $"for(int {variable} = 0; {variable} < {sizes[i]}; {variable}++)";
                        value += "{\n";
                    }
                    for (int i = 0; i < sizes.Length-1; i++) {
                        value += "}\n";
                    }
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine(value);
                }
                if (nextElem.GetType() == typeof(setVariable)) {
                    setVariable sv = (setVariable)nextElem;
                    string value;
                    if (sv.varLinkInput.link != null)
                        value = $"_{sv.nameVariable.Text} = {inputValuePassage(sv.varLinkInput, sv)};";
                    else {
                        if (sv.varLinkInput.type != 0 && sv.InputValue.TextLength == 0) {
                            richTextBox1.Text += $"Ошибка: в Set _{sv.nameVariable.Text} не указан входной аргумент!\n";
                            Error++;
                        }
                        if (sv.varLinkInput.type == 0)
                            value = $"_{sv.nameVariable.Text} = {(sv.checkBox1.Checked ? "true" : "false")};";
                        else if (sv.varLinkInput.type == 1)
                            value = $"_{sv.nameVariable.Text} = {$"\'{sv.InputValue.Text}\'"};";
                        else if (sv.varLinkInput.type == 4)
                            value = $"_{sv.nameVariable.Text} = {$"\"{sv.InputValue.Text}\""};";
                        else
                            value = $"_{sv.nameVariable.Text} = {sv.InputValue.Text};";
                    }
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine(value);
                }
                if (nextElem.GetType() == typeof(For)) {
                    For f = (For)nextElem;
                    f.nameCounter = counterName;
                    if (f.linkOutput2.elem == null) {
                        richTextBox1.Text += $"Предупреждение: в For нет тела цикла!\n";
                        Warning++;
                    }
                    if (f.textBox2.TextLength == 0 && f.varLinkInput2.link == null) {
                        richTextBox1.Text += $"Ошибка: в For не указано начальное значение счетчика!\n";
                        Error++;
                    }
                    if (f.textBox1.TextLength == 0 && f.varLinkInput3.link == null) {
                        richTextBox1.Text += $"Ошибка: в For не указан шаг счетчика!\n";
                        Error++;
                    }
                    if (f.linkOutput2.elem != null) {
                        string condition;
                        string counter = types[f.varLinkOutput.type] + " " + counterName + " = ";
                        string changeCounter = $"{counterName} += ";

                        if (f.varLinkInput2.link == null)
                            counter += (f.varLinkOutput.type == 4 ? $"\"{f.textBox2.Text}\"" : f.textBox2.Text);
                        else 
                            counter += inputValuePassage(f.varLinkInput2, f);

                        if (f.varLinkInput1.link != null)
                            condition = inputValuePassage(f.varLinkInput1, f);
                        else
                            condition = f.checkBox1.Checked ? "true" : "false";


                        if (f.varLinkInput3.link == null) {
                            switch (f.varLinkOutput.type) {
                                case 2:
                                case 3:
                                    changeCounter += f.textBox1.Text;
                                    break;
                                case 4:
                                    changeCounter += $"\"{f.textBox1.Text}\"";
                                    break;
                            }
                        }
                        else
                            changeCounter += inputValuePassage(f.varLinkInput3, f);

                        for (int i = 0; i < nesting; i++) sw.Write("    ");
                        sw.WriteLine($"for({counter}; {condition}; {changeCounter}) " + "{");
                        counterName += "a";
                        bool check = innerLoop;
                        if(!check) innerLoop = true;
                        nesting++;
                        blockPassage((Block)f.linkOutput2.elem.Parent);
                        nesting--;
                        if(!check) innerLoop = false;
                        counterName = "_a";
                        for (int i = 0; i < nesting; i++) sw.Write("    ");
                        sw.WriteLine("}");
                    }
                }
                if (nextElem.GetType() == typeof(While)) {
                    While w = (While)nextElem;
                    string condition;
                    if (w.linkOutput2.elem == null) {
                        richTextBox1.Text += $"Предупреждение: в While нет тела цикла!\n";
                        Warning++;
                    }
                    if (w.varLinkInput.link != null)
                        condition = inputValuePassage(w.varLinkInput, w);
                    else
                        condition = w.checkBox1.Checked ? "true" : "false";
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine($"while({condition}) " + "{");
                    if (w.linkOutput2.elem != null) {
                        bool check = innerLoop;
                        if (!check) innerLoop = true;
                        nesting++;
                        blockPassage((Block)w.linkOutput2.elem.Parent);
                        nesting--;
                        if (!check) innerLoop = false;
                    }
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine("}");
                }
                if (nextElem.GetType() == typeof(DoWhile)) {
                    DoWhile dw = (DoWhile)nextElem;
                    if (dw.linkOutput2.elem == null) {
                        richTextBox1.Text += $"Предупреждение: в Do While нет тела цикла!\n";
                        Warning++;
                    }
                    string condition;
                    if (dw.varLinkInput.link != null)
                        condition = inputValuePassage(dw.varLinkInput, dw);
                    else
                        condition = dw.checkBox1.Checked ? "true" : "false";
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine("do{");
                    if (dw.linkOutput2.elem != null) {
                        bool check = innerLoop;
                        if (!check) innerLoop = true;
                        nesting++;
                        blockPassage((Block)dw.linkOutput2.elem.Parent);
                        nesting--;
                        if (!check) innerLoop = false;
                    }
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine("}" + $"while({condition});");
                }
                if (nextElem.GetType() == typeof(If)) {
                    bool checkElseif = false;
                    If f = (If)nextElem;
                    string condition;

                    if (f.varLinkInput.link != null)
                        condition = inputValuePassage(f.varLinkInput, f);
                    else
                        condition = f.checkBox1.Checked ? "true" : "false";
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine($"if({condition})" + "{");
                    if (f.linkOutputIf.elem != null) {
                        nesting++;
                        blockPassage((Block)f.linkOutputIf.elem.Parent);
                        nesting--;
                    }
                    for (int i = 0; i < nesting; i++) sw.Write("    ");
                    sw.WriteLine("}");

                    foreach (object o in f.Controls) {
                        if (o.GetType() == typeof(LinkOutput) && ((LinkOutput)o).Name == "linkOutputElseIf" && ((LinkOutput)o).elem != null) {
                            LinkOutput loe = (LinkOutput)o;
                            foreach (List<object> l in f.elems) {
                                if (l.Contains(o)) {
                                    VarLinkInput vli = (VarLinkInput)f.elems[f.elems.IndexOf(l)][0];
                                    if (vli.link != null) {
                                        condition = inputValuePassage(vli, f);
                                    }
                                    else {
                                        CheckBox cb = (CheckBox)f.elems[f.elems.IndexOf(l)][3];
                                        condition = cb.Checked ? "true" : "false";
                                    }
                                }
                            }
                            for (int i = 0; i < nesting; i++) sw.Write("    ");
                            sw.WriteLine($"else if({condition})" + "{");
                            nesting++;
                            blockPassage((Block)((Link)o).elem.Parent);
                            nesting--;
                            checkElseif = true;
                            for (int i = 0; i < nesting; i++) sw.Write("    ");
                            sw.WriteLine("}");
                        }
                    }

                    if (f.linkOutputElse.elem != null) {
                        for (int i = 0; i < nesting; i++) sw.Write("    ");
                        sw.WriteLine("else {");
                        nesting++;
                        blockPassage((Block)f.linkOutputElse.elem.Parent);
                        nesting--;
                        for (int i = 0; i < nesting; i++) sw.Write("    ");
                        sw.WriteLine("}");
                    }
                    if (f.linkOutputIf.elem == null && f.linkOutputElse.elem != null || checkElseif) {
                        richTextBox1.Text += $"Ошибка: в IF...ELSE не указано тело для if!\n";
                        Error++;
                    }
                    else if (f.linkOutputIf.elem == null) {
                        richTextBox1.Text += $"Предупреждение: в IF...ELSE не указано тело для if!\n";
                        Warning++;
                    }
                }
                if (nextElem.GetType() == typeof(setElem)) {
                    setElem se = (setElem)nextElem;
                    if (!checkInitArrayBlock(se,se.nameVariable.Text)) {
                        richTextBox1.Text += $"Ошибка: Нельзя использовать Set _{se.nameVariable.Text} без предварительной инициализации массива!\n";
                        Error++;
                    }
                    string value = $"_{se.nameVariable.Text}";
                    string[] index = new string[se.elems.Count];
                    for (int i = 0; i < se.elems.Count; i++) {
                        VarLinkInput vli = (VarLinkInput)se.elems[i][0];
                        TextBox tb = (TextBox)se.elems[i][1];
                        if (vli.link != null)
                            index[i] = inputValuePassage(vli, se);
                        else {
                            if (tb.TextLength == 0) {
                                richTextBox1.Text += $"Ошибка: в Set _{se.nameVariable.Text} указаны не все индексы элемента!\n";
                                Error++;
                                break;
                            }
                            index[i] = tb.Text;
                        }
                        value += $"[{index[i]}]";
                    }
                    if (se.varLinkInput.link != null)
                        value += $" = {inputValuePassage(se.varLinkInput, se)};";
                    else {
                        if (se.varLinkInput.type != 0 && se.InputValue.TextLength == 0) {
                            richTextBox1.Text += $"Ошибка: в Set _{se.nameVariable.Text} не указан входной аргумент!\n";
                            Error++;
                        }
                        if (se.varLinkInput.type == 0)
                            value += $" = {(se.checkBox1.Checked ? "true" : "false")};";
                        else if (se.varLinkInput.type == 1)
                            value += $" = {$"\'{se.InputValue.Text}\'"};";
                        else if (se.varLinkInput.type == 4)
                            value += $" = {$"\"{se.InputValue.Text}\""};";
                        else
                            value += $" = {se.InputValue.Text};";
                    }
                    sw.WriteLine(value);
                }
                if (nextElem.GetType() == typeof(Continue)) {
                    if (!innerLoop) {
                        richTextBox1.Text += $"Ошибка: блок Continue находится вне цикла!\n";
                        Error++;
                    }
                    sw.WriteLine("continue;");
                }
                if (nextElem.GetType() == typeof(Break)) {
                    if (!innerLoop) {
                        richTextBox1.Text += $"Ошибка: блок Break находится вне цикла!\n";
                        Error++;
                    }
                    sw.WriteLine("break;");
                }
                if (nextElem.Controls.Find("LinkOutput", false).Length > 0) {
                    lo = (LinkOutput)nextElem.Controls.Find("LinkOutput", false)[0];
                    if (lo.elem != null)
                        nextElem = (Block)lo.elem.Parent;
                    else
                        break;
                }
                else
                    break;

            }
        }
        String inputValuePassage(VarLinkInput vli, Block parent) { //генерация кода значений блоков, берущихся по связи, валидация блоков в схеме
            Block getValue = (Block)vli.link.Parent;
            if (getValue.GetType() == typeof(CommingBlock)) {
                CommingBlock cb = (CommingBlock)getValue;
                string value = inputValuePassage(cb.varLinkInput, parent);
                if (cb.varLinkInput.type == 4) {
                    if (cb.varLinkOutput.type == 0)
                        value = $"({value})[0] == \'t\' || {value}[0] == \'T\'";
                    else if (cb.varLinkOutput.type == 1)
                        value = $"({value}).c_str()[0]";
                    else if (cb.varLinkOutput.type == 2)
                        value = $"atoi(({value}).c_str())";
                    else if (cb.varLinkOutput.type == 3)
                        value = $"atof(({value}).c_str())";
                }
                else if (cb.varLinkOutput.type == 4) {
                    value = $"to_str({value})";
                }
                else {
                    if (cb.varLinkOutput.type == 0)
                        value = $"(int){value}";
                    if (cb.varLinkOutput.type == 1)
                        value = $"(char){value}";
                    if (cb.varLinkOutput.type == 2)
                        value = $"(int){value}";
                    if (cb.varLinkOutput.type == 3)
                        value = $"(float){value}";
                }
                return value;
            }
            if (getValue.GetType() == typeof(ConcatenationBlock)) {
                ConcatenationBlock cb = (ConcatenationBlock)getValue;
                String logic = "";
                int i = 0;
                foreach (List<object> l in cb.elems) {
                    VarLinkInput vlie = (VarLinkInput)l[0];
                    if (vlie.link != null)
                        logic += ((i > 0 ? "+" : "") + inputValuePassage(vlie, parent));
                    else {
                        TextBox tb = (TextBox)l[1];
                        if (tb.TextLength == 0) {
                            richTextBox1.Text += $"Ошибка: в Concatenation не указан входной аргумент № {cb.elems.IndexOf(l) + 1}!\n";
                            Error++;
                        }
                        logic += (i > 0 ? "+" : "");
                        if (vlie.type == 1)
                            logic += $"string(1,\'{tb.Text}\')";
                        else
                            logic += $"(string)\"{tb.Text}\"";
                    }
                    i++;
                }
                return logic;
            }
            if (getValue.GetType() == typeof(AriphmeticBlock)) {
                String[] lo = new String[] { " + ", " - ", " / ", " * ", " % " };
                AriphmeticBlock ab = (AriphmeticBlock)getValue;
                String logic = "";
                int i = 0;
                foreach (List<object> l in ab.elems) {
                    VarLinkInput vlie = (VarLinkInput)l[0];
                    if (vlie.link != null)
                        logic += ((i > 0 ? lo[ab.comboBox1.SelectedIndex] : "") + inputValuePassage(vlie, parent));
                    else {
                        TextBox tb = (TextBox)l[1];
                        CheckBox cb = (CheckBox)l[2];
                        logic += (i > 0 ? lo[ab.comboBox1.SelectedIndex] : "");
                        if (vlie.type == 0)
                            logic += cb.Checked ? "true" : "false";
                        else {
                            if (tb.TextLength == 0) {
                                richTextBox1.Text += $"Ошибка: в Ariphmetic не указан входной аргумент №{ab.elems.IndexOf(l) + 1}!\n";
                                Error++;
                            }
                            logic += vlie.type == 1 ? $"\'{tb.Text}\'" : tb.Text;
                        }
                    }
                    i++;
                }
                return logic;
            }
            if (getValue.GetType() == typeof(LogicBlock)) {
                String[] lo = new String[] { " && ", " || " };
                LogicBlock lb = (LogicBlock)getValue;
                String logic = "";
                int i = 0;
                foreach (List<object> l in lb.elems) {
                    VarLinkInput vlie = (VarLinkInput)l[0];
                    if (vlie.link != null)
                        logic += ((i > 0 ? lo[lb.comboBox1.SelectedIndex] : "") + inputValuePassage(vlie, parent));
                    else {
                        CheckBox cb = (CheckBox)l[1];
                        logic += ((i > 0 ? lo[lb.comboBox1.SelectedIndex] : "") + (cb.Checked ? "true" : "false"));
                    }
                    i++;
                }
                return $"({logic})";
            }
            if (getValue.GetType() == typeof(ComparisonBlock)) {
                String[] co = new String[] { " == ", "!=" ," <= ", " >= ", " < ", " > " };
                ComparisonBlock cb = (ComparisonBlock)getValue;
                String comparison = "";
                if (cb.varLinkInput1.type == 1 && cb.textBox1.TextLength == 0 && cb.varLinkInput1.link == null) {
                    richTextBox1.Text += "Ошибка: в Comparison Numeric не указан первый входной аргумент!\n";
                    Error++;
                }
                if (cb.varLinkInput2.type == 1 && cb.textBox2.TextLength == 0 && cb.varLinkInput2.link == null) {
                    richTextBox1.Text += "Ошибка: в Comparison Numeric не указан второй входной аргумент!\n";
                    Error++;
                }
                if (cb.varLinkInput1.link != null)
                    comparison += (inputValuePassage(cb.varLinkInput1, parent));
                else
                    comparison += ((cb.varLinkInput1.type == 0 ? (cb.checkBox1.Checked ? "true" : "false") : cb.textBox1.Text));

                comparison += co[cb.comboBox1.SelectedIndex];

                if (cb.varLinkInput2.link != null)
                    comparison += (inputValuePassage(cb.varLinkInput2, parent));
                else
                    comparison += (cb.varLinkInput2.type == 0 ? (cb.checkBox2.Checked ? "true" : "false") : cb.textBox2.Text);

                return $"({comparison})";
            }
            if (getValue.GetType() == typeof(ComparisionStringBlock)) {
                String[] co = new String[] { " == ", "!=", " <= ", " >= ", " < ", " > " };
                ComparisionStringBlock cb = (ComparisionStringBlock)getValue;
                String comparison = "";
                if (cb.textBox1.TextLength == 0 && cb.varLinkInput1.link == null) {
                    richTextBox1.Text += "Ошибка: в Comparison String не указан первый входной аргумент!\n";
                    Error++;
                }
                if (cb.textBox2.TextLength == 0 && cb.varLinkInput2.link == null) {
                    richTextBox1.Text += "Ошибка: в Comparison String не указан второй входной аргумент!\n";
                    Error++;
                }
                if (cb.varLinkInput1.link != null)
                    comparison += (inputValuePassage(cb.varLinkInput1, parent));
                else
                    comparison += (cb.varLinkInput1.type == 4 ? $"string(1,\'{cb.textBox1.Text}\')" : $"\"{cb.textBox1.Text}\"");

                comparison += co[cb.comboBox1.SelectedIndex];

                if (cb.varLinkInput2.link != null)
                    comparison += (inputValuePassage(cb.varLinkInput2, parent));
                else
                    comparison += (cb.varLinkInput2.type == 4 ? $"string(1,\'{cb.textBox2.Text}\')" : $"\"{cb.textBox2.Text}\"");
                return $"({comparison})";
            }
            if (getValue.GetType() == typeof(read)) {
                sw.WriteLine("getline(cin,read);");
                return "read";
            }
            if (getValue.GetType() == typeof(getVariable)) {
                getVariable gv = (getVariable)getValue;
                return $"_{gv.nameVariable.Text}";
            }
            if (getValue.GetType() == typeof(setVariable)) {
                setVariable sv = (setVariable)getValue;
                return $"_{sv.nameVariable.Text}";
            }
            if (getValue.GetType() == typeof(getElem)) {
                getElem ge = (getElem)getValue;
                string value = $"_{ge.nameVariable.Text}";
                if (!checkInitArrayBlock(parent, ge.nameVariable.Text)) {
                    richTextBox1.Text += $"Ошибка: Невозможно получить значение! Нельзя использовать Get _{ge.nameVariable.Text} без предварительной инициализации массива!\n";
                    Error++;
                }
                for (int i = 0; i < ge.elems.Count; i++) {
                    VarLinkInput vlie = (VarLinkInput)ge.elems[i][0];
                    TextBox tb = (TextBox)ge.elems[i][1];
                    if (vlie.link != null)
                         value += $"[{inputValuePassage(vlie, parent)}]";
                    else {
                        if (tb.TextLength == 0) {
                            richTextBox1.Text += $"Ошибка: Невозможно получить значение! В Get _{ge.nameVariable.Text} указаны не все индексы элемента!\n";
                            Error++;
                            break;
                        }
                        value += $"[{tb.Text}]";
                    }
                }
                return value;
            }
            if (getValue.GetType() == typeof(setElem)) {
                setElem se = (setElem)getValue;
                string value = $"_{se.nameVariable.Text}";
                if (!checkInitArrayBlock(parent, se.nameVariable.Text)) {
                    richTextBox1.Text += $"Ошибка: Невозможно получить значение! Нельзя использовать Set _{se.nameVariable.Text} без предварительной инициализации массива!\n";
                    Error++;
                }
                for (int i = 0; i < se.elems.Count; i++) {
                    VarLinkInput vlie = (VarLinkInput)se.elems[i][0];
                    TextBox tb = (TextBox)se.elems[i][1];
                    if (vlie.link != null)
                        value += $"[{inputValuePassage(vlie, parent)}]";
                    else {
                        if (tb.TextLength == 0) {
                            richTextBox1.Text += $"Ошибка: Невозможно получить значение! В Set _{se.nameVariable.Text} указаны не все индексы элемента!\n";
                            Error++;
                            break;
                        }
                        value += $"[{tb.Text}]";
                    }
                }
                return value;
            }
            if (getValue.GetType() == typeof(For)) {
                For f = (For)getValue;
                if (f.linkOutput2.elem == null || !checkBlockInside(f.linkOutput2, parent) && parent != f) {
                    richTextBox1.Text += $"Ошибка: в For взятие счетчика, вне цикла!\n";
                    Error++;
                }
                return (f.nameCounter);
            }
            return "";
        }
        bool checkBlockInside(LinkOutput l, Block parent) { //проверка нахождения счетчика внутри For
            if (l.elem.Parent == parent) return true;
            bool check = false;
            foreach (object elems in l.elem.Parent.Controls) {
                if (elems.GetType() == typeof(LinkOutput) && ((LinkOutput)elems).elem != null && !check) {
                    check = check ||  checkBlockInside((LinkOutput)elems, parent);
                }
            }
            return check;       
        }
        bool checkInitArrayBlock(Block behindBlock, string name) { //Проверка присутствия в схеме блока инициализации массива, перед его использованием
            bool check = false;
            while (true) {
                if (behindBlock.GetType() == typeof(startBlock)) {
                    break;
                }
                else if (behindBlock.GetType() == typeof(initArray)) {
                    initArray ia = (initArray)behindBlock;
                    if(ia.name.Text == name)
                        check = true;
                    break;
                }
                else {
                    foreach (object items in behindBlock.Controls) {
                        if (items.GetType() == typeof(LinkInput)) {
                            LinkInput li = (LinkInput)items;
                            behindBlock = (Block)li.elem.Parent;
                        }
                    }
                }
            }
            return check;
        }
        private void debuggingPanel_MouseMove(object sender, MouseEventArgs e) { //растягивание панели отладки
            Point mousePos = PointToScreen(Cursor.Position);
            if (e.Location.Y < 5) {
                debuggingPanel.Cursor = Cursors.SizeNS;
            }
            else {
                debuggingPanel.Cursor = Cursors.Arrow;
            }
            if (mousePosForSizeChanged != new Point(0, 0) && mousePos.Y < Height && mousePos.Y > Height/2) {
                int s = PointSubstract(e.Location, mousePosForSizeChanged).Y;
                debuggingPanel.Height -= s;
                richTextBox1.Height -= s;
                WorkSpace.Height += s;
                debuggingPanel.Location = new Point(debuggingPanel.Location.X, debuggingPanel.Location.Y + s);
                richTextBox1.Location = new Point(richTextBox1.Location.X, richTextBox1.Location.Y + s);
            }
        }
        private void debuggingPanel_MouseLeave(object sender, EventArgs e) {
            mousePosForSizeChanged = new Point(0, 0);
        }
        private void debuggingPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Location.Y < 5) {
                mousePosForSizeChanged = e.Location;
            }
        }
        private void debuggingPanel_MouseUp(object sender, MouseEventArgs e) {
            mousePosForSizeChanged = new Point(0, 0);
        }

        private void сгенерированныйКодToolStripMenuItem_Click(object sender, EventArgs e) {
            if(!codeGenMenu)
                code = new Code(this);
            code.Show();
        }
    }
}
