namespace nsLexMainForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFStart = new System.Windows.Forms.Button();
            this.tbFSource = new System.Windows.Forms.TextBox();
            this.tbFMessage = new System.Windows.Forms.TextBox();
            this.lblFSource = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnFRecord = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFStart
            // 
            this.btnFStart.Location = new System.Drawing.Point(16, 178);
            this.btnFStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnFStart.Name = "btnFStart";
            this.btnFStart.Size = new System.Drawing.Size(607, 47);
            this.btnFStart.TabIndex = 0;
            this.btnFStart.Text = "Пуск";
            this.btnFStart.UseVisualStyleBackColor = true;
            this.btnFStart.Click += new System.EventHandler(this.btnFStart_Click);
            // 
            // tbFSource
            // 
            this.tbFSource.AcceptsReturn = true;
            this.tbFSource.AcceptsTab = true;
            this.tbFSource.Location = new System.Drawing.Point(16, 42);
            this.tbFSource.Margin = new System.Windows.Forms.Padding(4);
            this.tbFSource.Multiline = true;
            this.tbFSource.Name = "tbFSource";
            this.tbFSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFSource.Size = new System.Drawing.Size(607, 118);
            this.tbFSource.TabIndex = 1;
            // 
            // tbFMessage
            // 
            this.tbFMessage.Location = new System.Drawing.Point(16, 245);
            this.tbFMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tbFMessage.Multiline = true;
            this.tbFMessage.Name = "tbFMessage";
            this.tbFMessage.Size = new System.Drawing.Size(607, 36);
            this.tbFMessage.TabIndex = 2;
            // 
            // lblFSource
            // 
            this.lblFSource.AutoSize = true;
            this.lblFSource.Location = new System.Drawing.Point(27, 12);
            this.lblFSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFSource.Name = "lblFSource";
            this.lblFSource.Size = new System.Drawing.Size(113, 17);
            this.lblFSource.TabIndex = 3;
            this.lblFSource.Text = "Исходный текст";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 357);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(259, 148);
            this.listBox1.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(357, 357);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(266, 148);
            this.listBox2.TabIndex = 6;
            // 
            // btnFRecord
            // 
            this.btnFRecord.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFRecord.Location = new System.Drawing.Point(16, 301);
            this.btnFRecord.Name = "btnFRecord";
            this.btnFRecord.Size = new System.Drawing.Size(607, 37);
            this.btnFRecord.TabIndex = 7;
            this.btnFRecord.Text = "Распределить по таблицам";
            this.btnFRecord.UseVisualStyleBackColor = false;
            this.btnFRecord.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(696, 120);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(250, 293);
            this.treeView1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(735, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Синтаксическое дерево";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 532);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnFRecord);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblFSource);
            this.Controls.Add(this.tbFMessage);
            this.Controls.Add(this.tbFSource);
            this.Controls.Add(this.btnFStart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Отладка транслитератора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFStart;
        private System.Windows.Forms.TextBox tbFSource;
        private System.Windows.Forms.TextBox tbFMessage;
        private System.Windows.Forms.Label lblFSource;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnFRecord;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
    }
}

