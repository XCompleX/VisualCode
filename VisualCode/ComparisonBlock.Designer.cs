
namespace VisualCode {
    partial class ComparisonBlock {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparisonBlock));
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.nameBlock = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.varLinkInput2 = new VisualCode.VarLinkInput();
            this.varLinkInput1 = new VisualCode.VarLinkInput();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(22, 67);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 18);
            this.checkBox2.TabIndex = 28;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(22, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 18);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // nameBlock
            // 
            this.nameBlock.BackColor = System.Drawing.Color.Transparent;
            this.nameBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBlock.ForeColor = System.Drawing.Color.Black;
            this.nameBlock.Location = new System.Drawing.Point(-2, 1);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(198, 30);
            this.nameBlock.TabIndex = 26;
            this.nameBlock.Text = "COMPARISON NUMBERIC";
            this.nameBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.Items.AddRange(new object[] {
            "==",
            "!=",
            "<=",
            ">=",
            "<",
            ">"});
            this.comboBox1.Location = new System.Drawing.Point(129, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(59, 33);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.Text = "==";
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(170, 93);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(18, 18);
            this.varLinkOutput.TabIndex = 22;
            // 
            // varLinkInput2
            // 
            this.varLinkInput2.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput2.BackgroundImage")));
            this.varLinkInput2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput2.Location = new System.Drawing.Point(-2, 65);
            this.varLinkInput2.Name = "varLinkInput2";
            this.varLinkInput2.Size = new System.Drawing.Size(18, 18);
            this.varLinkInput2.TabIndex = 21;
            this.varLinkInput2.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            this.varLinkInput2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.varLinkMouseDown);
            // 
            // varLinkInput1
            // 
            this.varLinkInput1.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput1.BackgroundImage")));
            this.varLinkInput1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput1.Location = new System.Drawing.Point(-2, 37);
            this.varLinkInput1.Name = "varLinkInput1";
            this.varLinkInput1.Size = new System.Drawing.Size(18, 18);
            this.varLinkInput1.TabIndex = 20;
            this.varLinkInput1.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            this.varLinkInput1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.varLinkMouseDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(65, 22);
            this.textBox1.TabIndex = 29;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(22, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 22);
            this.textBox2.TabIndex = 30;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // ComparisonBlock
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.varLinkInput2);
            this.Controls.Add(this.varLinkInput1);
            this.DoubleBuffered = true;
            this.Name = "ComparisonBlock";
            this.Size = new System.Drawing.Size(199, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public VarLinkInput varLinkInput2;
        public VarLinkInput varLinkInput1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox1;
        protected VarLinkOutput varLinkOutput;
        protected System.Windows.Forms.Label nameBlock;
    }
}
