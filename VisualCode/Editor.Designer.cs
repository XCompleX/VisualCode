
namespace VisualCode {
    partial class Editor {
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Variables_Panel = new System.Windows.Forms.Panel();
            this.Variables_List = new System.Windows.Forms.FlowLayoutPanel();
            this.Variables_ToggleButton = new System.Windows.Forms.PictureBox();
            this.Variables_nameLabel = new System.Windows.Forms.Label();
            this.Variables_AddButton = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.собратьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.собратьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.собратьИЗапуститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debuggingPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.WorkSpace = new VisualCode.Space();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сгенерированныйКодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.Variables_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Variables_ToggleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Variables_AddButton)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.debuggingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.flowLayoutPanel1.Controls.Add(this.Variables_Panel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 33);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(307, 708);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.flowLayoutPanel1_Click);
            // 
            // Variables_Panel
            // 
            this.Variables_Panel.AutoScroll = true;
            this.Variables_Panel.AutoScrollMinSize = new System.Drawing.Size(1, 0);
            this.Variables_Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Variables_Panel.Controls.Add(this.Variables_List);
            this.Variables_Panel.Controls.Add(this.Variables_ToggleButton);
            this.Variables_Panel.Controls.Add(this.Variables_nameLabel);
            this.Variables_Panel.Controls.Add(this.Variables_AddButton);
            this.Variables_Panel.Location = new System.Drawing.Point(3, 3);
            this.Variables_Panel.Name = "Variables_Panel";
            this.Variables_Panel.Size = new System.Drawing.Size(304, 221);
            this.Variables_Panel.TabIndex = 0;
            this.Variables_Panel.Click += new System.EventHandler(this.Variables_Panel_Click);
            // 
            // Variables_List
            // 
            this.Variables_List.AutoScroll = true;
            this.Variables_List.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Variables_List.Location = new System.Drawing.Point(8, 35);
            this.Variables_List.Name = "Variables_List";
            this.Variables_List.Size = new System.Drawing.Size(283, 169);
            this.Variables_List.TabIndex = 4;
            this.Variables_List.Click += new System.EventHandler(this.Variables_List_Click);
            // 
            // Variables_ToggleButton
            // 
            this.Variables_ToggleButton.BackColor = System.Drawing.Color.Transparent;
            this.Variables_ToggleButton.BackgroundImage = global::VisualCode.Properties.Resources.triangle;
            this.Variables_ToggleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Variables_ToggleButton.Location = new System.Drawing.Point(8, 8);
            this.Variables_ToggleButton.Name = "Variables_ToggleButton";
            this.Variables_ToggleButton.Size = new System.Drawing.Size(23, 20);
            this.Variables_ToggleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Variables_ToggleButton.TabIndex = 3;
            this.Variables_ToggleButton.TabStop = false;
            this.Variables_ToggleButton.Click += new System.EventHandler(this.Variables_ToggleButton_Click);
            this.Variables_ToggleButton.MouseEnter += new System.EventHandler(this.ToggleButton_MouseEnter);
            this.Variables_ToggleButton.MouseLeave += new System.EventHandler(this.ToggleButton_MouseLeave);
            // 
            // Variables_nameLabel
            // 
            this.Variables_nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Variables_nameLabel.AutoSize = true;
            this.Variables_nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Variables_nameLabel.Location = new System.Drawing.Point(37, 8);
            this.Variables_nameLabel.Name = "Variables_nameLabel";
            this.Variables_nameLabel.Size = new System.Drawing.Size(126, 20);
            this.Variables_nameLabel.TabIndex = 1;
            this.Variables_nameLabel.Text = "Переменные";
            // 
            // Variables_AddButton
            // 
            this.Variables_AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Variables_AddButton.BackColor = System.Drawing.Color.Transparent;
            this.Variables_AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Variables_AddButton.Image = global::VisualCode.Properties.Resources.plus;
            this.Variables_AddButton.Location = new System.Drawing.Point(267, 8);
            this.Variables_AddButton.Name = "Variables_AddButton";
            this.Variables_AddButton.Size = new System.Drawing.Size(24, 21);
            this.Variables_AddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Variables_AddButton.TabIndex = 2;
            this.Variables_AddButton.TabStop = false;
            this.Variables_AddButton.Click += new System.EventHandler(this.Variables_AddButton_Click);
            this.Variables_AddButton.MouseEnter += new System.EventHandler(this.Variables_AddButton_MouseEnter);
            this.Variables_AddButton.MouseLeave += new System.EventHandler(this.Variables_AddButton_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1582, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.собратьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // собратьToolStripMenuItem
            // 
            this.собратьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.собратьToolStripMenuItem1,
            this.собратьИЗапуститьToolStripMenuItem});
            this.собратьToolStripMenuItem.Name = "собратьToolStripMenuItem";
            this.собратьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.собратьToolStripMenuItem.Text = "Собрать";
            // 
            // собратьToolStripMenuItem1
            // 
            this.собратьToolStripMenuItem1.Name = "собратьToolStripMenuItem1";
            this.собратьToolStripMenuItem1.Size = new System.Drawing.Size(234, 26);
            this.собратьToolStripMenuItem1.Text = "Собрать";
            this.собратьToolStripMenuItem1.Click += new System.EventHandler(this.собратьToolStripMenuItem1_Click);
            // 
            // собратьИЗапуститьToolStripMenuItem
            // 
            this.собратьИЗапуститьToolStripMenuItem.Name = "собратьИЗапуститьToolStripMenuItem";
            this.собратьИЗапуститьToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.собратьИЗапуститьToolStripMenuItem.Text = "Собрать и запустить";
            this.собратьИЗапуститьToolStripMenuItem.Click += new System.EventHandler(this.собратьИЗапуститьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // debuggingPanel
            // 
            this.debuggingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debuggingPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.debuggingPanel.Controls.Add(this.label1);
            this.debuggingPanel.Controls.Add(this.richTextBox1);
            this.debuggingPanel.Location = new System.Drawing.Point(318, 566);
            this.debuggingPanel.Name = "debuggingPanel";
            this.debuggingPanel.Size = new System.Drawing.Size(1252, 175);
            this.debuggingPanel.TabIndex = 3;
            this.debuggingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.debuggingPanel_MouseDown);
            this.debuggingPanel.MouseLeave += new System.EventHandler(this.debuggingPanel_MouseLeave);
            this.debuggingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.debuggingPanel_MouseMove);
            this.debuggingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.debuggingPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Компиляция";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.richTextBox1.Location = new System.Drawing.Point(7, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1242, 133);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // WorkSpace
            // 
            this.WorkSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkSpace.BackColor = System.Drawing.Color.Transparent;
            this.WorkSpace.BackgroundImage = global::VisualCode.Properties.Resources.imgonline_com_ua_Resize_3SG9bKq0gx1;
            this.WorkSpace.Location = new System.Drawing.Point(325, 36);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.Size = new System.Drawing.Size(1245, 524);
            this.WorkSpace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WorkSpace.TabIndex = 1;
            this.WorkSpace.TabStop = false;
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сгенерированныйКодToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // сгенерированныйКодToolStripMenuItem
            // 
            this.сгенерированныйКодToolStripMenuItem.Name = "сгенерированныйКодToolStripMenuItem";
            this.сгенерированныйКодToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.сгенерированныйКодToolStripMenuItem.Text = "Сгенерированный код";
            this.сгенерированныйКодToolStripMenuItem.Click += new System.EventHandler(this.сгенерированныйКодToolStripMenuItem_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.debuggingPanel);
            this.Controls.Add(this.WorkSpace);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1600, 800);
            this.Name = "Editor";
            this.Text = "VisualCode";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Variables_Panel.ResumeLayout(false);
            this.Variables_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Variables_ToggleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Variables_AddButton)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.debuggingPanel.ResumeLayout(false);
            this.debuggingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel Variables_Panel;
        private System.Windows.Forms.Label Variables_nameLabel;
        private System.Windows.Forms.PictureBox Variables_AddButton;
        private System.Windows.Forms.PictureBox Variables_ToggleButton;
        private System.Windows.Forms.Timer timer1;
        private Space WorkSpace;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem собратьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem собратьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem собратьИЗапуститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.Panel debuggingPanel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.FlowLayoutPanel Variables_List;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сгенерированныйКодToolStripMenuItem;
    }
}

