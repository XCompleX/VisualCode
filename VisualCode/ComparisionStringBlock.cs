using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VisualCode {
    public partial class ComparisionStringBlock : VisualCode.ComparisonBlock {
        public ComparisionStringBlock() {
            InitializeComponent();
            initLinks();
        }

        public override void initLinks() {
            varLinkInput1.setType(4);
            varLinkInput2.setType(4);
            varLinkOutput.setType(0);
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

        public override void setTypeCounter(object sender, EventArgs e) { //изменение типов связей
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip cms = (ContextMenuStrip)(tsmi).Owner;

            VarLinkInput vli = ((VarLinkInput)(cms.SourceControl));
            int type = cms.Items.IndexOf(tsmi) == 0 ? 1 : 4;
            vli.setType(type);
            if (vli == varLinkInput1) {
                if (vli.type == 1)
                    textBox1.MaxLength = 2;
                else
                    textBox1.MaxLength = 32767;
            }
            else if (vli == varLinkInput2) {
                if (vli.type == 1)
                    textBox2.MaxLength = 2;
                else
                    textBox2.MaxLength = 32767;
            }
        }

        public override void textBox_TextChanged(object sender, EventArgs e) { //фильтрация введеных пользователем значений
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
