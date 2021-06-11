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
    public partial class getVariable : Block {

        int varType;
        public getVariable(string varName = "var", int varType = 0) {
            InitializeComponent();
            connElem = new List<object>();
            Name = varName;
            this.varType = varType;
            nameVariable.Text = Name;
            initEvents();
        }
        private getVariable() {
            InitializeComponent();
            initEvents();
        }
        private void initEvents() { //присвоение событий элементам блока
            MouseEnter += new EventHandler(mouseEnter);
            nameVariable.MouseEnter += new EventHandler(mouseEnter);

            MouseLeave += new EventHandler(mouseLeave);
            nameVariable.MouseLeave += new EventHandler(mouseLeave);

            Enter += new EventHandler(enter);
            nameVariable.Enter += new EventHandler(enter);

            Leave += new EventHandler(leave);
            nameVariable.Leave += new EventHandler(leave);

            MouseDown += new MouseEventHandler(mouseDown);
            nameVariable.MouseDown += new MouseEventHandler(mouseDown);

            MouseUp += new MouseEventHandler(mouseUp);
            nameVariable.MouseUp += new MouseEventHandler(mouseUp);

            MouseMove += new MouseEventHandler(mouseMove);
            nameVariable.MouseMove += new MouseEventHandler(mouseMove);

            timer1.Tick += timer1_Tick;
        }
        public void setName(string name) { //изменение имени блока при изменении имени переменной
            nameVariable.Text = Name;
            Name = name;
        }
        public void setType(int varType) { //изменение типа блока при изменении типа переменной
            this.varType = varType;
            varLinkOutput.setType(varType);
        }
        public override void paint(object sender, PaintEventArgs e) { //отрисовка/перерисовка блока
            base.paint(sender, e);
            LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 0, 255), Color.FromArgb(105, 105, 105), 360);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, Height));
            brush.Dispose();
        }
    }
}
