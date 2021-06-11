
namespace VisualCode {
    partial class print {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(print));
            this.blockName = new System.Windows.Forms.Label();
            this.varLinkInput = new VisualCode.VarLinkInput();
            this.InputValue = new System.Windows.Forms.TextBox();
            this.linkInput = new VisualCode.LinkInput();
            this.linkOutput = new VisualCode.LinkOutput();
            this.SuspendLayout();
            // 
            // blockName
            // 
            this.blockName.BackColor = System.Drawing.Color.Transparent;
            this.blockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blockName.ForeColor = System.Drawing.Color.Black;
            this.blockName.Location = new System.Drawing.Point(3, 0);
            this.blockName.Name = "blockName";
            this.blockName.Size = new System.Drawing.Size(181, 32);
            this.blockName.TabIndex = 0;
            this.blockName.Text = "PRINT";
            this.blockName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // varLinkInput
            // 
            this.varLinkInput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput.BackgroundImage")));
            this.varLinkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput.Location = new System.Drawing.Point(0, 48);
            this.varLinkInput.Name = "varLinkInput";
            this.varLinkInput.Size = new System.Drawing.Size(18, 22);
            this.varLinkInput.TabIndex = 1;
            // 
            // InputValue
            // 
            this.InputValue.Location = new System.Drawing.Point(24, 48);
            this.InputValue.Name = "InputValue";
            this.InputValue.Size = new System.Drawing.Size(143, 22);
            this.InputValue.TabIndex = 2;
            // 
            // linkInput
            // 
            this.linkInput.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.linkInput.BackColor = System.Drawing.Color.Transparent;
            this.linkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkInput.BackgroundImage")));
            this.linkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkInput.Location = new System.Drawing.Point(0, 0);
            this.linkInput.Name = "linkInput";
            this.linkInput.Size = new System.Drawing.Size(24, 30);
            this.linkInput.TabIndex = 3;
            // 
            // linkOutput
            // 
            this.linkOutput.BackColor = System.Drawing.Color.Transparent;
            this.linkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutput.BackgroundImage")));
            this.linkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutput.Location = new System.Drawing.Point(163, 0);
            this.linkOutput.Name = "linkOutput";
            this.linkOutput.Size = new System.Drawing.Size(24, 30);
            this.linkOutput.TabIndex = 4;
            // 
            // print
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.linkOutput);
            this.Controls.Add(this.linkInput);
            this.Controls.Add(this.InputValue);
            this.Controls.Add(this.varLinkInput);
            this.Controls.Add(this.blockName);
            this.DoubleBuffered = true;
            this.Name = "print";
            this.Size = new System.Drawing.Size(190, 89);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label blockName;
        private LinkInput linkInput;
        private LinkOutput linkOutput;
        public VarLinkInput varLinkInput;
        public System.Windows.Forms.TextBox InputValue;
    }
}
