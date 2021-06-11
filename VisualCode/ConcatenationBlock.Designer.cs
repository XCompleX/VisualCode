
namespace VisualCode {
    partial class ConcatenationBlock {
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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.Location = new System.Drawing.Point(110, 47);
            this.comboBox1.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 62);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 35);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // nameBlock
            // 
            this.nameBlock.Text = "CONCATENATION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "+";
            // 
            // ConcatenationBlock
            // 
            this.Controls.Add(this.label1);
            this.Name = "ConcatenationBlock";
            this.Controls.SetChildIndex(this.addConditionButton, 0);
            this.Controls.SetChildIndex(this.varLinkInput1, 0);
            this.Controls.SetChildIndex(this.varLinkInput2, 0);
            this.Controls.SetChildIndex(this.varLinkOutput, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.nameBlock, 0);
            this.Controls.SetChildIndex(this.checkBox2, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.addConditionButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}
