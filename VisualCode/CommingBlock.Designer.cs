
namespace VisualCode {
    partial class CommingBlock {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommingBlock));
            this.varLinkInput = new VisualCode.VarLinkInput();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.SuspendLayout();
            // 
            // varLinkInput
            // 
            this.varLinkInput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput.BackgroundImage")));
            this.varLinkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput.Location = new System.Drawing.Point(0, 3);
            this.varLinkInput.Name = "varLinkInput";
            this.varLinkInput.Size = new System.Drawing.Size(18, 22);
            this.varLinkInput.TabIndex = 0;
            this.varLinkInput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.varLinkMouseDown);
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(97, 3);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(18, 22);
            this.varLinkOutput.TabIndex = 1;
            this.varLinkOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.varLinkMouseDown);
            // 
            // CommingBlock
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.varLinkInput);
            this.DoubleBuffered = true;
            this.Name = "CommingBlock";
            this.Size = new System.Drawing.Size(118, 30);
            this.ResumeLayout(false);

        }

        #endregion

        public VarLinkInput varLinkInput;
        public VarLinkOutput varLinkOutput;
    }
}
