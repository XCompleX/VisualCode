
namespace VisualCode {
    partial class getElem {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getElem));
            this.varLinkInputIndex = new VisualCode.VarLinkInput();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameVariable
            // 
            this.nameVariable.Location = new System.Drawing.Point(63, 10);
            this.nameVariable.Size = new System.Drawing.Size(115, 22);
            // 
            // varLinkInputIndex
            // 
            this.varLinkInputIndex.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInputIndex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInputIndex.BackgroundImage")));
            this.varLinkInputIndex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInputIndex.Location = new System.Drawing.Point(0, 10);
            this.varLinkInputIndex.Name = "varLinkInputIndex";
            this.varLinkInputIndex.Size = new System.Drawing.Size(18, 22);
            this.varLinkInputIndex.TabIndex = 2;
            this.varLinkInputIndex.BackgroundImageChanged += new System.EventHandler(this.varLinkInput1_BackgroundImageChanged);
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(23, 10);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(34, 22);
            this.indexTextBox.TabIndex = 3;
            this.indexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // getElem
            // 
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.varLinkInputIndex);
            this.Name = "getElem";
            this.Size = new System.Drawing.Size(203, 43);
            this.Controls.SetChildIndex(this.varLinkOutput, 0);
            this.Controls.SetChildIndex(this.nameVariable, 0);
            this.Controls.SetChildIndex(this.varLinkInputIndex, 0);
            this.Controls.SetChildIndex(this.indexTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox indexTextBox;
        public VarLinkInput varLinkInputIndex;
    }
}
