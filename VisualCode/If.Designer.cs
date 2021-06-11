
namespace VisualCode {
    partial class If {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(If));
            this.IfLabel = new System.Windows.Forms.Label();
            this.ElseLabel = new System.Windows.Forms.Label();
            this.nameBlock = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.addConditionButton = new System.Windows.Forms.PictureBox();
            this.linkOutputElse = new VisualCode.LinkOutput();
            this.linkOutputIf = new VisualCode.LinkOutput();
            this.varLinkInput = new VisualCode.VarLinkInput();
            this.linkOutput = new VisualCode.LinkOutput();
            this.linkInput = new VisualCode.LinkInput();
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).BeginInit();
            this.SuspendLayout();
            // 
            // IfLabel
            // 
            this.IfLabel.AutoSize = true;
            this.IfLabel.BackColor = System.Drawing.Color.Transparent;
            this.IfLabel.ForeColor = System.Drawing.Color.White;
            this.IfLabel.Location = new System.Drawing.Point(138, 42);
            this.IfLabel.Name = "IfLabel";
            this.IfLabel.Size = new System.Drawing.Size(19, 17);
            this.IfLabel.TabIndex = 5;
            this.IfLabel.Text = "IF";
            // 
            // ElseLabel
            // 
            this.ElseLabel.AutoSize = true;
            this.ElseLabel.BackColor = System.Drawing.Color.Transparent;
            this.ElseLabel.ForeColor = System.Drawing.Color.White;
            this.ElseLabel.Location = new System.Drawing.Point(124, 80);
            this.ElseLabel.Name = "ElseLabel";
            this.ElseLabel.Size = new System.Drawing.Size(43, 17);
            this.ElseLabel.TabIndex = 6;
            this.ElseLabel.Text = "ELSE";
            // 
            // nameBlock
            // 
            this.nameBlock.BackColor = System.Drawing.Color.Transparent;
            this.nameBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBlock.ForeColor = System.Drawing.Color.Black;
            this.nameBlock.Location = new System.Drawing.Point(26, 0);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(141, 30);
            this.nameBlock.TabIndex = 9;
            this.nameBlock.Text = "IF...ELSE";
            this.nameBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // addConditionButton
            // 
            this.addConditionButton.BackColor = System.Drawing.Color.Transparent;
            this.addConditionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addConditionButton.Image = global::VisualCode.Properties.Resources.plus;
            this.addConditionButton.Location = new System.Drawing.Point(0, 79);
            this.addConditionButton.Name = "addConditionButton";
            this.addConditionButton.Size = new System.Drawing.Size(20, 20);
            this.addConditionButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addConditionButton.TabIndex = 7;
            this.addConditionButton.TabStop = false;
            this.addConditionButton.Click += new System.EventHandler(this.addConditionButton_Click);
            this.addConditionButton.MouseEnter += new System.EventHandler(this.addConditionButton_MouseEnter);
            this.addConditionButton.MouseLeave += new System.EventHandler(this.addConditionButton_MouseLeave);
            // 
            // linkOutputElse
            // 
            this.linkOutputElse.BackColor = System.Drawing.Color.Transparent;
            this.linkOutputElse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutputElse.BackgroundImage")));
            this.linkOutputElse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutputElse.Location = new System.Drawing.Point(167, 72);
            this.linkOutputElse.Name = "linkOutputElse";
            this.linkOutputElse.Size = new System.Drawing.Size(24, 30);
            this.linkOutputElse.TabIndex = 4;
            // 
            // linkOutputIf
            // 
            this.linkOutputIf.BackColor = System.Drawing.Color.Transparent;
            this.linkOutputIf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutputIf.BackgroundImage")));
            this.linkOutputIf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutputIf.Location = new System.Drawing.Point(167, 36);
            this.linkOutputIf.Name = "linkOutputIf";
            this.linkOutputIf.Size = new System.Drawing.Size(24, 30);
            this.linkOutputIf.TabIndex = 3;
            // 
            // varLinkInput
            // 
            this.varLinkInput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput.BackgroundImage")));
            this.varLinkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput.Location = new System.Drawing.Point(0, 40);
            this.varLinkInput.Name = "varLinkInput";
            this.varLinkInput.Size = new System.Drawing.Size(18, 22);
            this.varLinkInput.TabIndex = 2;
            this.varLinkInput.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            // 
            // linkOutput
            // 
            this.linkOutput.BackColor = System.Drawing.Color.Transparent;
            this.linkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutput.BackgroundImage")));
            this.linkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutput.Location = new System.Drawing.Point(167, 0);
            this.linkOutput.Name = "linkOutput";
            this.linkOutput.Size = new System.Drawing.Size(24, 30);
            this.linkOutput.TabIndex = 1;
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
            // If
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.addConditionButton);
            this.Controls.Add(this.ElseLabel);
            this.Controls.Add(this.IfLabel);
            this.Controls.Add(this.linkOutputElse);
            this.Controls.Add(this.linkOutputIf);
            this.Controls.Add(this.varLinkInput);
            this.Controls.Add(this.linkOutput);
            this.Controls.Add(this.linkInput);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "If";
            this.Size = new System.Drawing.Size(194, 105);
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkInput linkInput;
        private LinkOutput linkOutput;
        private System.Windows.Forms.Label IfLabel;
        private System.Windows.Forms.Label ElseLabel;
        private System.Windows.Forms.PictureBox addConditionButton;
        private System.Windows.Forms.Label nameBlock;
        public LinkOutput linkOutputIf;
        public LinkOutput linkOutputElse;
        public VarLinkInput varLinkInput;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}
