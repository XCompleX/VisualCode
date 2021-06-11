
namespace VisualCode {
    partial class ComparisionStringBlock {
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 37);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(22, 65);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Visible = false;
            // 
            // nameBlock
            // 
            this.nameBlock.Text = "COMPARISON STRING";
            // 
            // ComparisionStringBlock
            // 
            this.Name = "ComparisionStringBlock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
