
namespace VisualCode {
    partial class AriphmeticBlock {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AriphmeticBlock));
            this.varLinkInput1 = new VisualCode.VarLinkInput();
            this.varLinkInput2 = new VisualCode.VarLinkInput();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.nameBlock = new System.Windows.Forms.Label();
            this.addConditionButton = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).BeginInit();
            this.SuspendLayout();
            // 
            // varLinkInput1
            // 
            this.varLinkInput1.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput1.BackgroundImage")));
            this.varLinkInput1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput1.Location = new System.Drawing.Point(0, 35);
            this.varLinkInput1.Name = "varLinkInput1";
            this.varLinkInput1.Size = new System.Drawing.Size(18, 18);
            this.varLinkInput1.TabIndex = 0;
            this.varLinkInput1.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            this.varLinkInput1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.varLinkMouseDown);
            // 
            // varLinkInput2
            // 
            this.varLinkInput2.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput2.BackgroundImage")));
            this.varLinkInput2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput2.Location = new System.Drawing.Point(0, 63);
            this.varLinkInput2.Name = "varLinkInput2";
            this.varLinkInput2.Size = new System.Drawing.Size(18, 18);
            this.varLinkInput2.TabIndex = 1;
            this.varLinkInput2.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            this.varLinkInput2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.varLinkMouseDown);
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(172, 91);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(18, 18);
            this.varLinkOutput.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.Items.AddRange(new object[] {
            "+",
            "-",
            "/",
            "*",
            "%"});
            this.comboBox1.Location = new System.Drawing.Point(110, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(46, 33);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "%";
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // nameBlock
            // 
            this.nameBlock.BackColor = System.Drawing.Color.Transparent;
            this.nameBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBlock.ForeColor = System.Drawing.Color.Black;
            this.nameBlock.Location = new System.Drawing.Point(30, -1);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(141, 30);
            this.nameBlock.TabIndex = 8;
            this.nameBlock.Text = "ARIPHMETIC";
            this.nameBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addConditionButton
            // 
            this.addConditionButton.BackColor = System.Drawing.Color.Transparent;
            this.addConditionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addConditionButton.Image = global::VisualCode.Properties.Resources.plus;
            this.addConditionButton.Location = new System.Drawing.Point(0, 91);
            this.addConditionButton.Name = "addConditionButton";
            this.addConditionButton.Size = new System.Drawing.Size(20, 20);
            this.addConditionButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addConditionButton.TabIndex = 9;
            this.addConditionButton.TabStop = false;
            this.addConditionButton.Click += new System.EventHandler(this.addConditionButton_Click);
            this.addConditionButton.MouseEnter += new System.EventHandler(this.addConditionButton_MouseEnter);
            this.addConditionButton.MouseLeave += new System.EventHandler(this.addConditionButton_MouseLeave);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(24, 63);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 22);
            this.textBox2.TabIndex = 13;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 22);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // AriphmeticBlock
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.addConditionButton);
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.varLinkInput2);
            this.Controls.Add(this.varLinkInput1);
            this.DoubleBuffered = true;
            this.Name = "AriphmeticBlock";
            this.Size = new System.Drawing.Size(193, 114);
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public VarLinkInput varLinkInput1;
        public VarLinkInput varLinkInput2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        protected System.Windows.Forms.Label nameBlock;
        protected VarLinkOutput varLinkOutput;
        protected System.Windows.Forms.PictureBox addConditionButton;
    }
}
