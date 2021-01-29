namespace MASES.CLRTests.WinFormsTestControl
{
    partial class TestControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contentBox = new System.Windows.Forms.TextBox();
            this.btnSelectFromTextBox = new System.Windows.Forms.Button();
            this.btnSelectFromComboBox = new System.Windows.Forms.Button();
            this.cbContent = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // contentBox
            // 
            this.contentBox.AcceptsReturn = true;
            this.contentBox.Location = new System.Drawing.Point(12, 91);
            this.contentBox.Multiline = true;
            this.contentBox.Name = "contentBox";
            this.contentBox.Size = new System.Drawing.Size(585, 373);
            this.contentBox.TabIndex = 7;
            // 
            // btnSelectFromTextBox
            // 
            this.btnSelectFromTextBox.Location = new System.Drawing.Point(13, 35);
            this.btnSelectFromTextBox.Name = "btnSelectFromTextBox";
            this.btnSelectFromTextBox.Size = new System.Drawing.Size(204, 23);
            this.btnSelectFromTextBox.TabIndex = 6;
            this.btnSelectFromTextBox.Text = "Press to select from TextBox";
            this.btnSelectFromTextBox.UseVisualStyleBackColor = true;
            this.btnSelectFromTextBox.Click += new System.EventHandler(this.btnSelectFromTextBox_Click);
            // 
            // btnSelectFromComboBox
            // 
            this.btnSelectFromComboBox.Location = new System.Drawing.Point(12, 5);
            this.btnSelectFromComboBox.Name = "btnSelectFromComboBox";
            this.btnSelectFromComboBox.Size = new System.Drawing.Size(205, 23);
            this.btnSelectFromComboBox.TabIndex = 5;
            this.btnSelectFromComboBox.Text = "Press to select from ComboBox";
            this.btnSelectFromComboBox.UseVisualStyleBackColor = true;
            this.btnSelectFromComboBox.Click += new System.EventHandler(this.btnSelectFromComboBox_Click);
            // 
            // cbContent
            // 
            this.cbContent.FormattingEnabled = true;
            this.cbContent.Items.AddRange(new object[] {
            "One",
            "Two",
            "Three",
            "Four",
            "Five"});
            this.cbContent.Location = new System.Drawing.Point(12, 64);
            this.cbContent.Name = "cbContent";
            this.cbContent.Size = new System.Drawing.Size(121, 21);
            this.cbContent.TabIndex = 4;
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentBox);
            this.Controls.Add(this.btnSelectFromTextBox);
            this.Controls.Add(this.btnSelectFromComboBox);
            this.Controls.Add(this.cbContent);
            this.Name = "TestControl";
            this.Size = new System.Drawing.Size(860, 642);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentBox;
        private System.Windows.Forms.Button btnSelectFromTextBox;
        private System.Windows.Forms.Button btnSelectFromComboBox;
        private System.Windows.Forms.ComboBox cbContent;
    }
}
