
namespace VisualCode {
    partial class read {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(read));
            this.blockName = new System.Windows.Forms.Label();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.SuspendLayout();
            // 
            // blockName
            // 
            this.blockName.BackColor = System.Drawing.Color.Transparent;
            this.blockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blockName.ForeColor = System.Drawing.Color.Black;
            this.blockName.Location = new System.Drawing.Point(3, 0);
            this.blockName.Name = "blockName";
            this.blockName.Size = new System.Drawing.Size(176, 36);
            this.blockName.TabIndex = 3;
            this.blockName.Text = "READ";
            this.blockName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(185, 8);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(15, 22);
            this.varLinkOutput.TabIndex = 4;
            // 
            // read
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.blockName);
            this.DoubleBuffered = true;
            this.Name = "read";
            this.Size = new System.Drawing.Size(203, 40);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label blockName;
        private VarLinkOutput varLinkOutput;
    }
}
