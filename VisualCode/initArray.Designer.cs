
namespace VisualCode {
    partial class initArray {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(initArray));
            this.name = new System.Windows.Forms.Label();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.varLinkInput1 = new VisualCode.VarLinkInput();
            this.linkInput = new VisualCode.LinkInput();
            this.linkOutput = new VisualCode.LinkOutput();
            this.nameBlock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.ForeColor = System.Drawing.Color.White;
            this.name.Location = new System.Drawing.Point(3, 24);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(157, 32);
            this.name.TabIndex = 0;
            this.name.Text = "name";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(30, 62);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(34, 22);
            this.indexTextBox.TabIndex = 1;
            this.indexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // varLinkInput1
            // 
            this.varLinkInput1.BackColor = System.Drawing.Color.Transparent;
            this.varLinkInput1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkInput1.BackgroundImage")));
            this.varLinkInput1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkInput1.Location = new System.Drawing.Point(6, 62);
            this.varLinkInput1.Name = "varLinkInput1";
            this.varLinkInput1.Size = new System.Drawing.Size(18, 22);
            this.varLinkInput1.TabIndex = 2;
            this.varLinkInput1.BackgroundImageChanged += new System.EventHandler(this.varLinkInput1_BackgroundImageChanged);
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
            this.linkOutput.Location = new System.Drawing.Point(142, 0);
            this.linkOutput.Name = "linkOutput";
            this.linkOutput.Size = new System.Drawing.Size(24, 30);
            this.linkOutput.TabIndex = 4;
            // 
            // nameBlock
            // 
            this.nameBlock.BackColor = System.Drawing.Color.Transparent;
            this.nameBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBlock.ForeColor = System.Drawing.Color.Black;
            this.nameBlock.Location = new System.Drawing.Point(30, 0);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(106, 30);
            this.nameBlock.TabIndex = 10;
            this.nameBlock.Text = "INIT ARRAY";
            this.nameBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // initArray
            // 
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.linkOutput);
            this.Controls.Add(this.linkInput);
            this.Controls.Add(this.varLinkInput1);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.name);
            this.DoubleBuffered = true;
            this.Name = "initArray";
            this.Size = new System.Drawing.Size(169, 102);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.TextBox indexTextBox;
        protected VarLinkInput varLinkInput1;
        private System.Windows.Forms.Label nameBlock;
        public LinkInput linkInput;
        public LinkOutput linkOutput;
        public System.Windows.Forms.Label name;
    }
}
