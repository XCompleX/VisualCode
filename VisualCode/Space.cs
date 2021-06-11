using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualCode {
    public partial class Space : PictureBox {

        public Link holdingLink;

        Image[] typeImage32 = new Image[] { //изображение типов данных
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

        Point MousePositionStart = new Point();
        Point MousePositionNow = new Point();
        Point shift = new Point();
        Point[] elemPos;

        bool holdingElements;
        bool move;

        public Space() {
            InitializeComponent();
            holdingLink = null;
        }

        private void WorkSpace_MouseDown(object sender, MouseEventArgs e) { //определения положения курсора при нажатии правой кнопки мыши
            if (e.Button == MouseButtons.Right) {
                MousePositionStart = Cursor.Position;
                holdingElements = true;
            }
        }
        private void WorkSpace_MouseUp(object sender, MouseEventArgs e) { //вызов контекстного меню если не было движения мыши или начало перемещения всех элементов если движение было
            if (e.Button == MouseButtons.Right) {
                holdingElements = false;
                if (!move) {
                    Point MousePosition = PointToClient(Cursor.Position);
                    showWorkSpaceContextMenu(MousePosition);
                }
                if (move) {
                    move = false;
                    timer1.Stop();
                }
            }
        }
        private void WorkSpace_Click(object sender, EventArgs e) { //передача фокуса 
            Focus();
        }
        private void WorkSpace_MouseMove(object sender, MouseEventArgs e) { //запоминание позиции элементов на Space при начале их перемещения
            if (holdingElements && !move) {
                elemPos = new Point[Controls.Count];
                int j = 0;
                foreach (var child in Controls.OfType<Control>())
                    elemPos[j++] = child.Location;
                move = true;
                timer1.Start();
            }
        }
        private void WorkSpace_Paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка связей
            Pen pen = new Pen(Brushes.White, 2.5f);
            foreach (Block elem in Controls) {
                if (elem.Controls.Find("linkOutput", false).Length > 0) {
                    foreach (object obj in elem.Controls) {
                        if (obj.GetType() == typeof(LinkOutput)) {
                            LinkOutput lo = (LinkOutput)obj;
                            if (lo.elem != null) {
                                LinkInput li = ((LinkInput)lo.elem.Parent.Controls.Find("linkInput", false)[0]);
                                Point LinkOutputLocation = new Point(lo.Location.X + lo.Width, lo.Location.Y + lo.Height / 2);
                                Point LinkInputLocation = new Point(li.Location.X, li.Location.Y + li.Height / 2);
                                e.Graphics.DrawLine(pen, PointAddition(lo.Parent.Location, LinkOutputLocation),
                                                         PointAddition(li.Parent.Location, LinkInputLocation));
                            }
                        }
                    }
                }
                if (elem.Controls.Find("varLinkOutput", false).Length > 0 && ((VarLinkOutput)elem.Controls.Find("varLinkOutput", false)[0]).links.Count != 0) {
                    VarLinkOutput vlo = ((VarLinkOutput)elem.Controls.Find("varLinkOutput", false)[0]);
                    Point varLinkOutputLocation = new Point(vlo.Location.X + vlo.Width, vlo.Location.Y + vlo.Height / 2);
                    foreach (VarLinkInput vli in vlo.links) {
                        Point varLinkInputLocation = new Point(vli.Location.X, vli.Location.Y + vli.Height / 2);
                        e.Graphics.DrawLine(pen, PointAddition(elem.Location, varLinkOutputLocation),
                                                 PointAddition(vli.Parent.Location, varLinkInputLocation));
                    }
                }
            }
            if (holdingLink != null) {
                Point MousePosition = PointToClient(Cursor.Position);
                Point link = new Point(holdingLink.Parent.Location.X + holdingLink.Location.X + holdingLink.Width,
                                       holdingLink.Parent.Location.Y + holdingLink.Location.Y + holdingLink.Height / 2);
                e.Graphics.DrawLine(pen, link, MousePosition);
            }
        }
        private void showWorkSpaceContextMenu(Point MousePosition) { //генерация контекстного меню
            ToolStripMenuItem[] tsmiVariable = new ToolStripMenuItem[((Editor)Parent).variables.Count];
            for (int i = 0; i < ((Editor)Parent).variables.Count; i++) {
                ToolStripMenuItem[] tsmiVariableMethods;
                if (((Editor)Parent).variables[i].type == 4) {
                    tsmiVariableMethods = new ToolStripMenuItem[] {
                        new ToolStripMenuItem("Get", null, setWorkSpaceGetVariable),
                        new ToolStripMenuItem("Set", null, setWorkSpaceSetVariable),
                        new ToolStripMenuItem("GetElem", null, setWorkSpaceGetElem),
                        new ToolStripMenuItem("SetElem", null, setWorkSpaceSetElem),
                    };
                }
                else if (((Editor)Parent).variables[i].type < 5) {
                    tsmiVariableMethods = new ToolStripMenuItem[] {
                        new ToolStripMenuItem("Get", null, setWorkSpaceGetVariable),
                        new ToolStripMenuItem("Set", null, setWorkSpaceSetVariable),
                    };
                }
                else {
                    tsmiVariableMethods = new ToolStripMenuItem[] {
                        new ToolStripMenuItem("GetElem", null, setWorkSpaceGetElem),
                        //new ToolStripMenuItem("GetArray", null, setWorkSpaceGetVariable),
                        new ToolStripMenuItem("SetElem", null, setWorkSpaceSetElem),
                        new ToolStripMenuItem("Init", null, setWorkSpaceInitArray),
                        //new ToolStripMenuItem("SetArray", null, setWorkSpaceSetVariable),
                    };
                }
                tsmiVariable[i] = new ToolStripMenuItem(((Editor)Parent).variables[i].name, typeImage32[((Editor)Parent).variables[i].type], tsmiVariableMethods);
            }
            /*********************генерация подразделов контекстного меню****************/
            ToolStripMenuItem[] tsmiFunction = new ToolStripMenuItem[] {
                new ToolStripMenuItem("Print", null, setWorkSpacePrint),
                new ToolStripMenuItem("Read", null, setWorkSpaceRead),
            };

            ToolStripMenuItem[] tsmiOperatorsControls = new ToolStripMenuItem[] {
                new ToolStripMenuItem("Continue", null, setWorkSpaceContinue),
                new ToolStripMenuItem("Break", null, setWorkSpaceBreak),
            };

            ToolStripMenuItem[] tsmiOperatorsLoop = new ToolStripMenuItem[] {
                new ToolStripMenuItem("While", null, setWorkSpaceWhile),
                new ToolStripMenuItem("Do While", null, setWorkSpaceDoWhile),
                new ToolStripMenuItem("For", null, setWorkSpaceFor),
            };

            ToolStripMenuItem[] tsmiOperatorsСomparision = new ToolStripMenuItem[] {
                new ToolStripMenuItem("Числовые", null, setWorkSpaceComparision),
                new ToolStripMenuItem("Строковые", null, setWorkSpaceComparisionString),
            };

            ToolStripMenuItem[] tsmiOperators = new ToolStripMenuItem[] {
                new ToolStripMenuItem("if...else", null, setWorkSpaceIF),
                new ToolStripMenuItem("Управляющие", null, tsmiOperatorsControls),
                new ToolStripMenuItem("Циклические", null, tsmiOperatorsLoop),
                new ToolStripMenuItem("Cравнительные", null, tsmiOperatorsСomparision),
                new ToolStripMenuItem("Арифметические", null, setWorkSpaceAriphmetic),
                new ToolStripMenuItem("Конкатенация", null, setWorkSpaceConcatenation),
                new ToolStripMenuItem("Логические", null, setWorkSpaceLogic),
                new ToolStripMenuItem("Приведения типов", null, setWorkSpaceComming),
            };

            ToolStripMenuItem[] tsmi = new ToolStripMenuItem[] {
                new ToolStripMenuItem("Переменные", null, tsmiVariable),
                new ToolStripMenuItem("Функции", null, tsmiFunction),
                new ToolStripMenuItem("Операторы", null, tsmiOperators),
            };

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.AddRange(tsmi);
            cms.Show(this, MousePosition);
            /*********************генерация подразделов контекстного меню****************/
        }

        /********************** добавление блоков на Space *********************/
        private void setWorkSpaceInitArray(object sender, EventArgs e) {
            String varName = ((ToolStripMenuItem)sender).OwnerItem.Text;
            int varType = ((Editor)Parent).variables.Find(x => x.name == varName).type;
            FlowLayoutPanel flp = (FlowLayoutPanel)((Editor)Parent).Variables_List.Controls.Find(varName, false)[0];
            int size = varType == 4 ? 1 : int.Parse(((TextBox)flp.Controls.Find("sizeVariableArrayBox", false)[0]).Text);
            initArray iA = new initArray(varName, varType % 5, size);

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - iA.Width / 2, MousePosition.Y - iA.Height / 2);

            Controls.Add(iA);

            iA.Location = newPosition;
        }

        private void setWorkSpaceGetVariable(object sender, EventArgs e) {
            String varName = ((ToolStripMenuItem)sender).OwnerItem.Text;
            int varType = ((Editor)Parent).variables.Find(x => x.name == varName).type;
            getVariable variable = new getVariable(varName, varType);

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - variable.Width / 2, MousePosition.Y - variable.Height / 2);

            Controls.Add(variable);

            variable.Location = newPosition;
            variable.setType(varType);
        }
        private void setWorkSpaceSetVariable(object sender, EventArgs e) {
            String varName = ((ToolStripMenuItem)sender).OwnerItem.Text;
            int varType = ((Editor)Parent).variables.Find(x => x.name == varName).type;
            setVariable variable = new setVariable(varName, varType);

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - variable.Width / 2, MousePosition.Y - variable.Height / 2);

            Controls.Add(variable);

            variable.Location = newPosition;
            variable.setType(varType);
        }
        private void setWorkSpaceGetElem(object sender, EventArgs e) {
            String varName = ((ToolStripMenuItem)sender).OwnerItem.Text;
            int varType = ((Editor)Parent).variables.Find(x => x.name == varName).type;
            FlowLayoutPanel flp = (FlowLayoutPanel)((Editor)Parent).Variables_List.Controls.Find(varName, false)[0];
            int size = varType == 4 ? 1 : int.Parse(((TextBox)flp.Controls.Find("sizeVariableArrayBox", false)[0]).Text);
            if (varType == 4) varType = 1;
            else varType = varType % 5;
            getElem variable = new getElem(varName, varType, size);
            variable.Name = varName;
            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - variable.Width / 2, MousePosition.Y - variable.Height / 2);

            Controls.Add(variable);

            variable.Location = newPosition;
            variable.setType(varType);
        }
        private void setWorkSpaceSetElem(object sender, EventArgs e) {
            String varName = ((ToolStripMenuItem)sender).OwnerItem.Text;
            int varType = ((Editor)Parent).variables.Find(x => x.name == varName).type;
            FlowLayoutPanel flp = (FlowLayoutPanel)((Editor)Parent).Variables_List.Controls.Find(varName, false)[0];
            int size = varType == 4 ? 1 : int.Parse(((TextBox)flp.Controls.Find("sizeVariableArrayBox",false)[0]).Text);
            if (varType == 4) varType = 1;
            else varType = varType % 5;
            setElem variable = new setElem(varName, varType, size);
            variable.Name = varName;
            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - variable.Width / 2, MousePosition.Y - variable.Height / 2);

            Controls.Add(variable);

            variable.Location = newPosition;
            variable.setType(varType);
        }
        private void setWorkSpacePrint(object sender, EventArgs e) {
            print function = new print();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - function.Width / 2, MousePosition.Y - function.Height / 2);

            Controls.Add(function);

            function.Location = newPosition;
        }
        private void setWorkSpaceRead(object sender, EventArgs e) {
            read function = new read();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - function.Width / 2, MousePosition.Y - function.Height / 2);

            Controls.Add(function);

            function.Location = newPosition;
        }
        private void setWorkSpaceIF(object sender, EventArgs e) {
            If operators = new If();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceWhile(object sender, EventArgs e) {
            While operators = new While();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceDoWhile(object sender, EventArgs e) {
            DoWhile operators = new DoWhile();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceFor(object sender, EventArgs e) {
            For operators = new For();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceBreak(object sender, EventArgs e) {
            Break operators = new Break();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceContinue(object sender, EventArgs e) {
            Continue operators = new Continue();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceAriphmetic(object sender, EventArgs e) {
            AriphmeticBlock operators = new AriphmeticBlock();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceLogic(object sender, EventArgs e) {
            LogicBlock operators = new LogicBlock();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceComparision(object sender, EventArgs e) {
            ComparisonBlock operators = new ComparisonBlock();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceComparisionString(object sender, EventArgs e) {
            ComparisionStringBlock operators = new ComparisionStringBlock();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceComming(object sender, EventArgs e) {
            CommingBlock operators = new CommingBlock(0,0);

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        private void setWorkSpaceConcatenation(object sender, EventArgs e) {
            ConcatenationBlock operators = new ConcatenationBlock();

            Point MousePosition = PointToClient(Cursor.Position);
            Point newPosition = new Point(MousePosition.X - operators.Width / 2, MousePosition.Y - operators.Height / 2);

            Controls.Add(operators);

            operators.Location = newPosition;
        }
        /********************** добавление блоков на Space *********************/
        private void timer1_Tick(object sender, EventArgs e) {// смещение всех блоков пропорционально смещению мыши, в случае её движения
            if (holdingElements && move) {
                int i = 0;
                MousePositionNow = Cursor.Position;
                shift = PointDivision(PointSubstract(MousePositionNow, MousePositionStart), 2);
                foreach (var child in Controls.OfType<Control>())
                    child.Invoke((MethodInvoker)(() => child.Location = new Point(PointAddition(elemPos[i], shift).X, PointAddition(elemPos[i++], shift).Y)));
                Invalidate();
            }
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
    }
}
