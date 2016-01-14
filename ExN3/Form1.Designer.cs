namespace ExN3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadPageButton = new System.Windows.Forms.Button();
            this.pagePathText = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.searchParamText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loadFromXmlButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadPageButton
            // 
            this.loadPageButton.Location = new System.Drawing.Point(220, 337);
            this.loadPageButton.Name = "loadPageButton";
            this.loadPageButton.Size = new System.Drawing.Size(75, 23);
            this.loadPageButton.TabIndex = 1;
            this.loadPageButton.Text = "Старт";
            this.loadPageButton.UseVisualStyleBackColor = true;
            this.loadPageButton.Click += new System.EventHandler(this.loadPageButton_Click);
            // 
            // pagePathText
            // 
            this.pagePathText.Location = new System.Drawing.Point(47, 339);
            this.pagePathText.Name = "pagePathText";
            this.pagePathText.Size = new System.Drawing.Size(168, 20);
            this.pagePathText.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(450, 290);
            this.treeView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "URI:";
            // 
            // searchParamText
            // 
            this.searchParamText.Location = new System.Drawing.Point(105, 310);
            this.searchParamText.MaxLength = 2;
            this.searchParamText.Name = "searchParamText";
            this.searchParamText.Size = new System.Drawing.Size(87, 20);
            this.searchParamText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Глубина поиска";
            // 
            // loadFromXmlButton
            // 
            this.loadFromXmlButton.Location = new System.Drawing.Point(344, 336);
            this.loadFromXmlButton.Name = "loadFromXmlButton";
            this.loadFromXmlButton.Size = new System.Drawing.Size(118, 23);
            this.loadFromXmlButton.TabIndex = 7;
            this.loadFromXmlButton.Text = "Загрузить из xml";
            this.loadFromXmlButton.UseVisualStyleBackColor = true;
            this.loadFromXmlButton.Click += new System.EventHandler(this.loadFromXmlButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.statusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(475, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabel1.Text = "Status bar:";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 376);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(447, 16);
            this.progressBar.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 426);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.loadFromXmlButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchParamText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pagePathText);
            this.Controls.Add(this.loadPageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ссылочки";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadPageButton;
        private System.Windows.Forms.TextBox pagePathText;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchParamText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadFromXmlButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

