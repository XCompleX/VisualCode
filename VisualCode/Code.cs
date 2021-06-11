using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VisualCode {
    public partial class Code : Form {

        Editor editor;

        public Code() {
            InitializeComponent();
            update();
        }
        public Code(Editor editor) : this(){
            this.editor = editor;
            editor.codeGenMenu = true;
        }

        private void Code_Load(object sender, EventArgs e) {
            codeText.StyleResetDefault();
            codeText.Styles[ScintillaNET.Style.Default].Font = "Courier new";
            codeText.Styles[ScintillaNET.Style.Default].Size = 9;
            codeText.StyleClearAll();
            codeText.Styles[ScintillaNET.Style.Cpp.Default].ForeColor = Color.Silver;
            codeText.Styles[ScintillaNET.Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            codeText.Styles[ScintillaNET.Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            codeText.Styles[ScintillaNET.Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            codeText.Styles[ScintillaNET.Style.Cpp.Number].ForeColor = Color.Olive;
            codeText.Styles[ScintillaNET.Style.Cpp.Word].ForeColor = Color.Blue;
            codeText.Styles[ScintillaNET.Style.Cpp.Word2].ForeColor = Color.Blue;
            codeText.Styles[ScintillaNET.Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            codeText.Styles[ScintillaNET.Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            codeText.Styles[ScintillaNET.Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            codeText.Styles[ScintillaNET.Style.Cpp.StringEol].BackColor = Color.Pink;
            codeText.Styles[ScintillaNET.Style.Cpp.Operator].ForeColor = Color.Purple;
            codeText.Styles[ScintillaNET.Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            codeText.Lexer = ScintillaNET.Lexer.Cpp;
            codeText.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            codeText.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
        }

        public void update() {
            codeText.ReadOnly = false;
            StreamReader sr = new StreamReader(Application.StartupPath + "/MinGW64/bin/program.cpp", Encoding.GetEncoding(1251), false);
            string line;
            codeText.Text = "";
            while ((line = sr.ReadLine()) != null) {
                codeText.Text += line + Environment.NewLine;
            }
            sr.Close();
            codeText.ReadOnly = true;
        }

        private void Code_FormClosed(object sender, FormClosedEventArgs e) {
            editor.codeGenMenu = false;
        }
    }
}
