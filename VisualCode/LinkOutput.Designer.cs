
namespace VisualCode {
    partial class LinkOutput {
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
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LinkOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Name = "LinkOutput";
            this.Leave += new System.EventHandler(this.lostFocus);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseEnter += new System.EventHandler(this.mouseEnter);
            this.MouseLeave += new System.EventHandler(this.mouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
