
namespace VisualCode {
    partial class LogicBlock {
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogicBlock));
            this.addConditionButton = new System.Windows.Forms.PictureBox();
            this.nameBlock = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.varLinkInput2 = new VisualCode.VarLinkInput();
            this.varLinkInput1 = new VisualCode.VarLinkInput();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).BeginInit();
            this.SuspendLayout();
            // 
            // addConditionButton
            // 
            this.addConditionButton.BackColor = System.Drawing.Color.Transparent;
            this.addConditionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addConditionButton.Image = global::VisualCode.Properties.Resources.plus;
            this.addConditionButton.Location = new System.Drawing.Point(-2, 92);
            this.addConditionButton.Name = "addConditionButton";
            this.addConditionButton.Size = new System.Drawing.Size(20, 20);
            this.addConditionButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addConditionButton.TabIndex = 17;
            this.addConditionButton.TabStop = false;
            this.addConditionButton.Click += new System.EventHandler(this.addConditionButton_Click);
            this.addConditionButton.MouseEnter += new System.EventHandler(this.addConditionButton_MouseEnter);
            this.addConditionButton.MouseLeave += new System.EventHandler(this.addConditionButton_MouseLeave);
            // 
            // nameBlock
            // 
            this.nameBlock.BackColor = System.Drawing.Color.Transparent;
            this.nameBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBlock.ForeColor = System.Drawing.Color.Black;
            this.nameBlock.Location = new System.Drawing.Point(28, 0);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(141, 30);
            this.nameBlock.TabIndex = 16;
            this.nameBlock.Text = "LOGIC";
            this.nameBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.Items.AddRange(new object[] {
            "AND(&&)",
            "OR(||)"});
            this.comboBox1.Location = new System.Drawing.Point(69, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 33);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "AND(&&)";
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(170, 92);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(18, 18);
            this.varLinkOutput.TabIndex = 12;
            // 
            // varLinkInput2
            // 
            this.varLinkInput2.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput2.BackgroundImage")));
            this.varLinkInput2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput2.Location = new System.Drawing.Point(-2, 64);
            this.varLinkInput2.Name = "varLinkInput2";
            this.varLinkInput2.Size = new System.Drawing.Size(18, 18);
            this.varLinkInput2.TabIndex = 11;
            this.varLinkInput2.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            // 
            // varLinkInput1
            // 
            this.varLinkInput1.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput1.BackgroundImage")));
            this.varLinkInput1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput1.Location = new System.Drawing.Point(-2, 36);
            this.varLinkInput1.Name = "varLinkInput1";
            this.varLinkInput1.Size = new System.Drawing.Size(18, 18);
            this.varLinkInput1.TabIndex = 10;
            this.varLinkInput1.BackgroundImageChanged += new System.EventHandler(this.changeInputValue);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(22, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 18);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(22, 66);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 18);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // LogicBlock
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.addConditionButton);
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.varLinkInput2);
            this.Controls.Add(this.varLinkInput1);
            this.DoubleBuffered = true;
            this.Name = "LogicBlock";
            this.Size = new System.Drawing.Size(193, 115);
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox addConditionButton;
        private System.Windows.Forms.Label nameBlock;
        private VarLinkOutput varLinkOutput;
        public System.Windows.Forms.ComboBox comboBox1;
        public VarLinkInput varLinkInput2;
        public VarLinkInput varLinkInput1;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox2;
    }
}
