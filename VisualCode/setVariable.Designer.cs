
namespace VisualCode {
    partial class setVariable {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setVariable));
            this.BlockName = new System.Windows.Forms.Label();
            this.nameVariable = new System.Windows.Forms.Label();
            this.linkOutput = new VisualCode.LinkOutput();
            this.linkInput = new VisualCode.LinkInput();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.varLinkInput = new VisualCode.VarLinkInput();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.InputValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BlockName
            // 
            this.BlockName.BackColor = System.Drawing.Color.Transparent;
            this.BlockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlockName.Location = new System.Drawing.Point(73, 3);
            this.BlockName.Name = "BlockName";
            this.BlockName.Size = new System.Drawing.Size(45, 30);
            this.BlockName.TabIndex = 3;
            this.BlockName.Text = "SET";
            this.BlockName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameVariable
            // 
            this.nameVariable.BackColor = System.Drawing.Color.Transparent;
            this.nameVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameVariable.ForeColor = System.Drawing.Color.White;
            this.nameVariable.Location = new System.Drawing.Point(0, 36);
            this.nameVariable.Name = "nameVariable";
            this.nameVariable.Size = new System.Drawing.Size(187, 25);
            this.nameVariable.TabIndex = 6;
            this.nameVariable.Text = "name";
            this.nameVariable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkOutput
            // 
            this.linkOutput.BackColor = System.Drawing.Color.Transparent;
            this.linkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkOutput.BackgroundImage")));
            this.linkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkOutput.Location = new System.Drawing.Point(163, 3);
            this.linkOutput.Name = "linkOutput";
            this.linkOutput.Size = new System.Drawing.Size(24, 30);
            this.linkOutput.TabIndex = 8;
            // 
            // linkInput
            // 
            this.linkInput.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.linkInput.BackColor = System.Drawing.Color.Transparent;
            this.linkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkInput.BackgroundImage")));
            this.linkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkInput.Location = new System.Drawing.Point(0, 3);
            this.linkInput.Name = "linkInput";
            this.linkInput.Size = new System.Drawing.Size(24, 30);
            this.linkInput.TabIndex = 9;
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(171, 73);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(16, 19);
            this.varLinkOutput.TabIndex = 10;
            // 
            // varLinkInput
            // 
            this.varLinkInput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput.BackgroundImage")));
            this.varLinkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput.Location = new System.Drawing.Point(0, 73);
            this.varLinkInput.Name = "varLinkInput";
            this.varLinkInput.Size = new System.Drawing.Size(16, 19);
            this.varLinkInput.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(86, 74);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // InputValue
            // 
            this.InputValue.BackColor = System.Drawing.Color.DarkGray;
            this.InputValue.Location = new System.Drawing.Point(22, 73);
            this.InputValue.Name = "InputValue";
            this.InputValue.Size = new System.Drawing.Size(143, 22);
            this.InputValue.TabIndex = 15;
            this.InputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InputValue.TextChanged += new System.EventHandler(this.InputValue_TextChanged);
            this.InputValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputValue_KeyPress);
            // 
            // setVariable
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.InputValue);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.varLinkInput);
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.linkInput);
            this.Controls.Add(this.linkOutput);
            this.Controls.Add(this.nameVariable);
            this.Controls.Add(this.BlockName);
            this.DoubleBuffered = true;
            this.Name = "setVariable";
            this.Size = new System.Drawing.Size(190, 115);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label BlockName;
        private LinkInput linkInput;
        public VarLinkOutput varLinkOutput;
        public VarLinkInput varLinkInput;
        public System.Windows.Forms.Label nameVariable;
        public System.Windows.Forms.TextBox InputValue;
        public System.Windows.Forms.CheckBox checkBox1;
        public LinkOutput linkOutput;
    }
}
