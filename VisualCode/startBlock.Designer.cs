
namespace VisualCode {
    partial class startBlock {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startBlock));
            this.name = new System.Windows.Forms.Label();
            this.linkOutput = new VisualCode.LinkOutput();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            // 
            // linkOutput
            // 
            this.linkOutput.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.linkOutput, "linkOutput");
            this.linkOutput.Name = "linkOutput";
            // 
            // startBlock
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.linkOutput);
            this.Controls.Add(this.name);
            this.DoubleBuffered = true;
            this.Name = "startBlock";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label name;
        public LinkOutput linkOutput;
    }
}
