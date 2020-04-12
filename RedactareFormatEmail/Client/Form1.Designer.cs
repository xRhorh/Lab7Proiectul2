namespace GUIApp
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
            this.FilesBox = new System.Windows.Forms.ListBox();
            this.PropertiesBox = new System.Windows.Forms.ListBox();
            this.FullPathImageTextBox = new System.Windows.Forms.TextBox();
            this.AddImageButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.DeleteFileButton = new System.Windows.Forms.Button();
            this.TitlePropertyTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.AddPropertyButton = new System.Windows.Forms.Button();
            this.DeletePropertyButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ResetFilesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FilesBox
            // 
            this.FilesBox.FormattingEnabled = true;
            this.FilesBox.ItemHeight = 16;
            this.FilesBox.Location = new System.Drawing.Point(16, 8);
            this.FilesBox.Name = "FilesBox";
            this.FilesBox.Size = new System.Drawing.Size(554, 516);
            this.FilesBox.TabIndex = 0;
            this.FilesBox.SelectedIndexChanged += new System.EventHandler(this.FilesBox_MouseClick);
            // 
            // PropertiesBox
            // 
            this.PropertiesBox.FormattingEnabled = true;
            this.PropertiesBox.ItemHeight = 16;
            this.PropertiesBox.Location = new System.Drawing.Point(586, 7);
            this.PropertiesBox.Name = "PropertiesBox";
            this.PropertiesBox.Size = new System.Drawing.Size(485, 516);
            this.PropertiesBox.TabIndex = 1;
            // 
            // FullPathImageTextBox
            // 
            this.FullPathImageTextBox.Location = new System.Drawing.Point(18, 560);
            this.FullPathImageTextBox.Name = "FullPathImageTextBox";
            this.FullPathImageTextBox.Size = new System.Drawing.Size(422, 22);
            this.FullPathImageTextBox.TabIndex = 2;
            // 
            // AddImageButton
            // 
            this.AddImageButton.Location = new System.Drawing.Point(459, 556);
            this.AddImageButton.Name = "AddImageButton";
            this.AddImageButton.Size = new System.Drawing.Size(111, 30);
            this.AddImageButton.TabIndex = 3;
            this.AddImageButton.Text = "Add file";
            this.AddImageButton.UseVisualStyleBackColor = true;
            this.AddImageButton.Click += new System.EventHandler(this.AddImageButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(18, 662);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(193, 55);
            this.OpenFileButton.TabIndex = 6;
            this.OpenFileButton.Text = "Open file";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // DeleteFileButton
            // 
            this.DeleteFileButton.Location = new System.Drawing.Point(394, 662);
            this.DeleteFileButton.Name = "DeleteFileButton";
            this.DeleteFileButton.Size = new System.Drawing.Size(176, 55);
            this.DeleteFileButton.TabIndex = 7;
            this.DeleteFileButton.Text = "Delete file";
            this.DeleteFileButton.UseVisualStyleBackColor = true;
            this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButton_Click);
            // 
            // TitlePropertyTextBox
            // 
            this.TitlePropertyTextBox.Location = new System.Drawing.Point(589, 563);
            this.TitlePropertyTextBox.Name = "TitlePropertyTextBox";
            this.TitlePropertyTextBox.Size = new System.Drawing.Size(290, 22);
            this.TitlePropertyTextBox.TabIndex = 8;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(589, 623);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(479, 22);
            this.DescriptionTextBox.TabIndex = 9;
            // 
            // AddPropertyButton
            // 
            this.AddPropertyButton.Location = new System.Drawing.Point(903, 556);
            this.AddPropertyButton.Name = "AddPropertyButton";
            this.AddPropertyButton.Size = new System.Drawing.Size(168, 37);
            this.AddPropertyButton.TabIndex = 10;
            this.AddPropertyButton.Text = "Add property";
            this.AddPropertyButton.UseVisualStyleBackColor = true;
            this.AddPropertyButton.Click += new System.EventHandler(this.AddPropertyButton_Click);
            // 
            // DeletePropertyButton
            // 
            this.DeletePropertyButton.Location = new System.Drawing.Point(878, 662);
            this.DeletePropertyButton.Name = "DeletePropertyButton";
            this.DeletePropertyButton.Size = new System.Drawing.Size(192, 55);
            this.DeletePropertyButton.TabIndex = 11;
            this.DeletePropertyButton.Text = "Delete property";
            this.DeletePropertyButton.UseVisualStyleBackColor = true;
            this.DeletePropertyButton.Click += new System.EventHandler(this.DeletePropertyButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(591, 662);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(210, 55);
            this.SearchButton.TabIndex = 12;
            this.SearchButton.Text = "Search files";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ResetFilesButton
            // 
            this.ResetFilesButton.Location = new System.Drawing.Point(228, 662);
            this.ResetFilesButton.Name = "ResetFilesButton";
            this.ResetFilesButton.Size = new System.Drawing.Size(147, 55);
            this.ResetFilesButton.TabIndex = 13;
            this.ResetFilesButton.Text = "Show all ";
            this.ResetFilesButton.UseVisualStyleBackColor = true;
            this.ResetFilesButton.Click += new System.EventHandler(this.ResetFilesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Title input box";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 603);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Description input box";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Full path input box";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1080, 739);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResetFilesButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DeletePropertyButton);
            this.Controls.Add(this.AddPropertyButton);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.TitlePropertyTextBox);
            this.Controls.Add(this.DeleteFileButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.AddImageButton);
            this.Controls.Add(this.FullPathImageTextBox);
            this.Controls.Add(this.PropertiesBox);
            this.Controls.Add(this.FilesBox);
            this.MinimumSize = new System.Drawing.Size(1098, 786);
            this.Name = "Form1";
            this.Text = "MyPhotos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FilesBox;
        private System.Windows.Forms.ListBox PropertiesBox;
        private System.Windows.Forms.TextBox FullPathImageTextBox;
        private System.Windows.Forms.Button AddImageButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button DeleteFileButton;
        private System.Windows.Forms.TextBox TitlePropertyTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Button AddPropertyButton;
        private System.Windows.Forms.Button DeletePropertyButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ResetFilesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

