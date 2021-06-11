
namespace VisualCode {
    partial class While {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(While));
            this.linkInput = new VisualCode.LinkInput();
            this.linkOutput = new VisualCode.LinkOutput();
            this.nameBlock = new System.Windows.Forms.Label();
            this.varLinkInput = new VisualCode.VarLinkInput();
            this.labelBody = new System.Windows.Forms.Label();
            this.linkOutput2 = new VisualCode.LinkOutput();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            this.linkInput.TabIndex = 0;
            // 
            // linkOutput
            // 
            this.linkOutput.BackColor = System.Drawing.Color.Transparent;
            this.linkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutput.BackgroundImage")));
            this.linkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutput.Location = new System.Drawing.Point(163, 0);
            this.linkOutput.Name = "linkOutput";
            this.linkOutput.Size = new System.Drawing.Size(24, 30);
            this.linkOutput.TabIndex = 1;
            // 
            // nameBlock
            // 
            this.nameBlock.BackColor = System.Drawing.Color.Transparent;
            this.nameBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBlock.ForeColor = System.Drawing.Color.Black;
            this.nameBlock.Location = new System.Drawing.Point(21, 0);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(136, 23);
            this.nameBlock.TabIndex = 2;
            this.nameBlock.Text = "WHILE";
            this.nameBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // varLinkInput
            // 
            this.varLinkInput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput.BackgroundImage")));
            this.varLinkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput.Location = new System.Drawing.Point(0, 44);
            this.varLinkInput.Name = "varLinkInput";
            this.varLinkInput.Size = new System.Drawing.Size(16, 16);
            this.varLinkInput.TabIndex = 3;
            this.varLinkInput.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.BackColor = System.Drawing.Color.Transparent;
            this.labelBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBody.ForeColor = System.Drawing.Color.White;
            this.labelBody.Location = new System.Drawing.Point(112, 44);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(45, 17);
            this.labelBody.TabIndex = 5;
            this.labelBody.Text = "Тело";
            // 
            // linkOutput2
            // 
            this.linkOutput2.BackColor = System.Drawing.Color.Transparent;
            this.linkOutput2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutput2.BackgroundImage")));
            this.linkOutput2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutput2.Location = new System.Drawing.Point(163, 36);
            this.linkOutput2.Name = "linkOutput2";
            this.linkOutput2.Size = new System.Drawing.Size(24, 30);
            this.linkOutput2.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // While
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.linkOutput2);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.varLinkInput);
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.linkOutput);
            this.Controls.Add(this.linkInput);
            this.DoubleBuffered = true;
            this.Name = "While";
            this.Size = new System.Drawing.Size(190, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkInput linkInput;
        private LinkOutput linkOutput;
        private System.Windows.Forms.Label labelBody;
        protected System.Windows.Forms.Label nameBlock;
        public LinkOutput linkOutput2;
        public VarLinkInput varLinkInput;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}
