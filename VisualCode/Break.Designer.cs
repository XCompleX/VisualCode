
namespace VisualCode {
    partial class Break {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Break));
            this.linkInput = new VisualCode.LinkInput();
            this.nameBlock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkInput
            // 
            this.linkInput.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.linkInput.BackColor = System.Drawing.Color.Transparent;
            this.linkInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("linkInput.BackgroundImage")));
            this.linkInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.linkInput.Location = new System.Drawing.Point(3, 5);
            this.linkInput.Name = "linkInput";
            this.linkInput.Size = new System.Drawing.Size(24, 30);
            this.linkInput.TabIndex = 0;
            // 
            // nameBlock
            // 
            this.nameBlock.AutoSize = true;
            this.nameBlock.BackColor = System.Drawing.Color.Transparent;
            this.nameBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBlock.ForeColor = System.Drawing.Color.Black;
            this.nameBlock.Location = new System.Drawing.Point(33, 12);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new System.Drawing.Size(50, 17);
            this.nameBlock.TabIndex = 2;
            this.nameBlock.Text = "Break";
            // 
            // Break
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.nameBlock);
            this.Controls.Add(this.linkInput);
            this.DoubleBuffered = true;
            this.Name = "Break";
            this.Size = new System.Drawing.Size(200, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkInput linkInput;
        private System.Windows.Forms.Label nameBlock;
    }
}
