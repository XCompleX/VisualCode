
namespace VisualCode {
    partial class setElem {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setElem));
            this.varLinkInput1 = new VisualCode.VarLinkInput();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.Location = new System.Drawing.Point(171, 91);
            // 
            // varLinkInput
            // 
            this.varLinkInput.Location = new System.Drawing.Point(0, 91);
            // 
            // InputValue
            // 
            this.InputValue.Location = new System.Drawing.Point(22, 88);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(86, 88);
            // 
            // varLinkInput1
            // 
            this.varLinkInput1.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput1.BackgroundImage")));
            this.varLinkInput1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput1.Location = new System.Drawing.Point(0, 63);
            this.varLinkInput1.Name = "varLinkInput1";
            this.varLinkInput1.Size = new System.Drawing.Size(18, 22);
            this.varLinkInput1.TabIndex = 13;
            this.varLinkInput1.BackgroundImageChanged += new System.EventHandler(this.varLinkInput1_BackgroundImageChanged);
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(22, 64);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(34, 22);
            this.indexTextBox.TabIndex = 14;
            this.indexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // setElem
            // 
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.varLinkInput1);
            this.Name = "setElem";
            this.Size = new System.Drawing.Size(190, 126);
            this.Controls.SetChildIndex(this.linkOutput, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.nameVariable, 0);
            this.Controls.SetChildIndex(this.varLinkOutput, 0);
            this.Controls.SetChildIndex(this.varLinkInput, 0);
            this.Controls.SetChildIndex(this.InputValue, 0);
            this.Controls.SetChildIndex(this.varLinkInput1, 0);
            this.Controls.SetChildIndex(this.indexTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox indexTextBox;
        public VarLinkInput varLinkInput1;
    }
}
