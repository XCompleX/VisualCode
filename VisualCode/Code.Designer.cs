
namespace VisualCode {
    partial class Code {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.codeText = new ScintillaNET.Scintilla();
            this.SuspendLayout();
            // 
            // codeText
            // 
            this.codeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeText.Lexer = ScintillaNET.Lexer.Cpp;
            this.codeText.Location = new System.Drawing.Point(0, 0);
            this.codeText.Name = "codeText";
            this.codeText.ReadOnly = true;
            this.codeText.Size = new System.Drawing.Size(800, 450);
            this.codeText.TabIndex = 0;
            // 
            // Code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.codeText);
            this.Name = "Code";
            this.Text = "Сгенерированный код";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Code_FormClosed);
            this.Load += new System.EventHandler(this.Code_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNET.Scintilla codeText;
    }
}