
namespace VisualCode {
    partial class For {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(For));
            this.linkInput = new VisualCode.LinkInput();
            this.linkOutput = new VisualCode.LinkOutput();
            this.nameBlock = new System.Windows.Forms.Label();
            this.varLinkInput1 = new VisualCode.VarLinkInput();
            this.linkOutput2 = new VisualCode.LinkOutput();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelCounter = new System.Windows.Forms.Label();
            this.labelStep = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.varLinkInput2 = new VisualCode.VarLinkInput();
            this.varLinkInput3 = new VisualCode.VarLinkInput();
            this.SuspendLayout();
            // 
            // linkInput
            // 
            this.linkInput.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.linkInput.BackColor = System.Drawing.Color.Transparent;
            this.linkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkInput.BackgroundImage")));
            this.linkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkInput.Location = new System.Drawing.Point(3, 0);
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
            this.nameBlock.Location = new System.Drawing.Point(26, 0);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(131, 30);
            this.nameBlock.TabIndex = 2;
            this.nameBlock.Text = "FOR";
            this.nameBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // varLinkInput1
            // 
            this.varLinkInput1.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput1.BackgroundImage")));
            this.varLinkInput1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput1.Location = new System.Drawing.Point(0, 36);
            this.varLinkInput1.Name = "varLinkInput1";
            this.varLinkInput1.Size = new System.Drawing.Size(16, 16);
            this.varLinkInput1.TabIndex = 3;
            this.varLinkInput1.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            // 
            // linkOutput2
            // 
            this.linkOutput2.BackColor = System.Drawing.Color.Transparent;
            this.linkOutput2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutput2.BackgroundImage")));
            this.linkOutput2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutput2.Location = new System.Drawing.Point(163, 28);
            this.linkOutput2.Name = "linkOutput2";
            this.linkOutput2.Size = new System.Drawing.Size(24, 30);
            this.linkOutput2.TabIndex = 4;
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.BackColor = System.Drawing.Color.Transparent;
            this.labelBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBody.ForeColor = System.Drawing.Color.White;
            this.labelBody.Location = new System.Drawing.Point(116, 36);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(45, 17);
            this.labelBody.TabIndex = 7;
            this.labelBody.Text = "Тело";
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCounter.ForeColor = System.Drawing.Color.White;
            this.labelCounter.Location = new System.Drawing.Point(102, 89);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(70, 17);
            this.labelCounter.TabIndex = 10;
            this.labelCounter.Text = "Cчетчик";
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.BackColor = System.Drawing.Color.Transparent;
            this.labelStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStep.ForeColor = System.Drawing.Color.White;
            this.labelStep.Location = new System.Drawing.Point(61, 89);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(35, 17);
            this.labelStep.TabIndex = 12;
            this.labelStep.Text = "Шаг";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(22, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 22);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.InputValue_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(171, 89);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(16, 16);
            this.varLinkOutput.TabIndex = 14;
            this.varLinkOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.varLinkOutputMouseDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(22, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(33, 22);
            this.textBox2.TabIndex = 16;
            this.textBox2.TextChanged += new System.EventHandler(this.InputValue_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "нач. значение";
            // 
            // varLinkInput2
            // 
            this.varLinkInput2.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput2.BackgroundImage")));
            this.varLinkInput2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput2.Location = new System.Drawing.Point(0, 60);
            this.varLinkInput2.Name = "varLinkInput2";
            this.varLinkInput2.Size = new System.Drawing.Size(16, 16);
            this.varLinkInput2.TabIndex = 18;
            // 
            // varLinkInput3
            // 
            this.varLinkInput3.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput3.BackgroundImage")));
            this.varLinkInput3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput3.Location = new System.Drawing.Point(0, 89);
            this.varLinkInput3.Name = "varLinkInput3";
            this.varLinkInput3.Size = new System.Drawing.Size(16, 16);
            this.varLinkInput3.TabIndex = 19;
            // 
            // For
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.varLinkInput3);
            this.Controls.Add(this.varLinkInput2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.labelCounter);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.linkOutput2);
            this.Controls.Add(this.varLinkInput1);
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.linkOutput);
            this.Controls.Add(this.linkInput);
            this.DoubleBuffered = true;
            this.Name = "For";
            this.Size = new System.Drawing.Size(190, 123);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkInput linkInput;
        private LinkOutput linkOutput;
        private System.Windows.Forms.Label nameBlock;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelCounter;
        private System.Windows.Forms.Label labelStep;
        public LinkOutput linkOutput2;
        public VarLinkInput varLinkInput1;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox textBox1;
        public VarLinkOutput varLinkOutput;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        public VarLinkInput varLinkInput2;
        public VarLinkInput varLinkInput3;
    }
}
