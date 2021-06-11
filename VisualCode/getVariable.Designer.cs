
namespace VisualCode {
    partial class getVariable {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getVariable));
            this.nameVariable = new System.Windows.Forms.Label();
            this.varLinkOutput = new VisualCode.VarLinkOutput();
            this.SuspendLayout();
            // 
            // nameVariable
            // 
            this.nameVariable.BackColor = System.Drawing.Color.Transparent;
            this.nameVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameVariable.Location = new System.Drawing.Point(1, 10);
            this.nameVariable.Name = "nameVariable";
            this.nameVariable.Size = new System.Drawing.Size(174, 17);
            this.nameVariable.TabIndex = 0;
            this.nameVariable.Text = "varName";
            this.nameVariable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // varLinkOutput
            // 
            this.varLinkOutput.BackColor = System.Drawing.Color.Transparent;
            this.varLinkOutput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("varLinkOutput.BackgroundImage")));
            this.varLinkOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.varLinkOutput.Location = new System.Drawing.Point(184, 10);
            this.varLinkOutput.Name = "varLinkOutput";
            this.varLinkOutput.Size = new System.Drawing.Size(16, 19);
            this.varLinkOutput.TabIndex = 1;
            // 
            // getVariable
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.varLinkOutput);
            this.Controls.Add(this.nameVariable);
            this.DoubleBuffered = true;
            this.Name = "getVariable";
            this.Size = new System.Drawing.Size(203, 40);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label nameVariable;
        public VarLinkOutput varLinkOutput;
    }
}
