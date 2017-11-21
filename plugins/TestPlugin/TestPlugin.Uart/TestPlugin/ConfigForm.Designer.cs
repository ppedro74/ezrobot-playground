namespace TestPlugin
{
    partial class ConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Setting1TextBox = new System.Windows.Forms.TextBox();
            this.Setting2TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.UseSomethingCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Setting #1:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Setting1TextBox
            // 
            this.Setting1TextBox.Location = new System.Drawing.Point(156, 13);
            this.Setting1TextBox.Name = "Setting1TextBox";
            this.Setting1TextBox.Size = new System.Drawing.Size(196, 20);
            this.Setting1TextBox.TabIndex = 1;
            // 
            // Setting2TextBox
            // 
            this.Setting2TextBox.Location = new System.Drawing.Point(156, 39);
            this.Setting2TextBox.Name = "Setting2TextBox";
            this.Setting2TextBox.Size = new System.Drawing.Size(196, 20);
            this.Setting2TextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Setting #2:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(156, 112);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(88, 50);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelEditButton.Location = new System.Drawing.Point(264, 112);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(88, 50);
            this.CancelEditButton.TabIndex = 14;
            this.CancelEditButton.Text = "&Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = true;
            // 
            // UseSomethingCheckBox
            // 
            this.UseSomethingCheckBox.AutoSize = true;
            this.UseSomethingCheckBox.Location = new System.Drawing.Point(156, 65);
            this.UseSomethingCheckBox.Name = "UseSomethingCheckBox";
            this.UseSomethingCheckBox.Size = new System.Drawing.Size(98, 17);
            this.UseSomethingCheckBox.TabIndex = 21;
            this.UseSomethingCheckBox.Text = "Use Something";
            this.UseSomethingCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(370, 186);
            this.Controls.Add(this.UseSomethingCheckBox);
            this.Controls.Add(this.CancelEditButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Setting2TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Setting1TextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Plugin\'s Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Setting1TextBox;
        private System.Windows.Forms.TextBox Setting2TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.CheckBox UseSomethingCheckBox;
    }
}