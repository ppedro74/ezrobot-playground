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
            this.MainUCTabControl = new EZ_Builder.UCForms.UCTabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.UseSomethingCheckBox = new System.Windows.Forms.CheckBox();
            this.Setting2TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Setting1TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AdvancedTabPage = new System.Windows.Forms.TabPage();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MainUCTabControl.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainUCTabControl
            // 
            this.MainUCTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.MainUCTabControl.BackColor = System.Drawing.Color.White;
            this.MainUCTabControl.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(170)))), ((int)(((byte)(234)))));
            this.MainUCTabControl.ButtonSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(146)))), ((int)(((byte)(66)))));
            this.MainUCTabControl.ButtonTextColor = System.Drawing.Color.White;
            this.MainUCTabControl.Controls.Add(this.GeneralTabPage);
            this.MainUCTabControl.Controls.Add(this.AdvancedTabPage);
            this.MainUCTabControl.ItemSize = new System.Drawing.Size(60, 50);
            this.MainUCTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainUCTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.MainUCTabControl.MarginLeft = 0;
            this.MainUCTabControl.MarginTop = 0;
            this.MainUCTabControl.Multiline = true;
            this.MainUCTabControl.Name = "MainUCTabControl";
            this.MainUCTabControl.Padding = new System.Drawing.Point(0, 0);
            this.MainUCTabControl.SelectedIndex = 0;
            this.MainUCTabControl.Size = new System.Drawing.Size(371, 202);
            this.MainUCTabControl.TabIndex = 22;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.UseSomethingCheckBox);
            this.GeneralTabPage.Controls.Add(this.Setting2TextBox);
            this.GeneralTabPage.Controls.Add(this.label2);
            this.GeneralTabPage.Controls.Add(this.Setting1TextBox);
            this.GeneralTabPage.Controls.Add(this.label1);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 54);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(363, 144);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "General";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // UseSomethingCheckBox
            // 
            this.UseSomethingCheckBox.AutoSize = true;
            this.UseSomethingCheckBox.Location = new System.Drawing.Point(156, 64);
            this.UseSomethingCheckBox.Name = "UseSomethingCheckBox";
            this.UseSomethingCheckBox.Size = new System.Drawing.Size(98, 17);
            this.UseSomethingCheckBox.TabIndex = 28;
            this.UseSomethingCheckBox.Text = "Use Something";
            this.UseSomethingCheckBox.UseVisualStyleBackColor = true;
            // 
            // Setting2TextBox
            // 
            this.Setting2TextBox.Location = new System.Drawing.Point(156, 38);
            this.Setting2TextBox.Name = "Setting2TextBox";
            this.Setting2TextBox.Size = new System.Drawing.Size(196, 20);
            this.Setting2TextBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Setting #2:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Setting1TextBox
            // 
            this.Setting1TextBox.Location = new System.Drawing.Point(156, 12);
            this.Setting1TextBox.Name = "Setting1TextBox";
            this.Setting1TextBox.Size = new System.Drawing.Size(196, 20);
            this.Setting1TextBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Setting #1:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdvancedTabPage
            // 
            this.AdvancedTabPage.Location = new System.Drawing.Point(4, 54);
            this.AdvancedTabPage.Name = "AdvancedTabPage";
            this.AdvancedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedTabPage.Size = new System.Drawing.Size(363, 144);
            this.AdvancedTabPage.TabIndex = 1;
            this.AdvancedTabPage.Text = "Advanced";
            this.AdvancedTabPage.UseVisualStyleBackColor = true;
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelEditButton.Location = new System.Drawing.Point(291, 220);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(88, 50);
            this.CancelEditButton.TabIndex = 29;
            this.CancelEditButton.Text = "&Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(183, 220);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(88, 50);
            this.SaveButton.TabIndex = 28;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(395, 282);
            this.Controls.Add(this.CancelEditButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MainUCTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Plugin\'s Configuration";
            this.MainUCTabControl.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.CheckBox UseSomethingCheckBox;
        private System.Windows.Forms.TextBox Setting2TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Setting1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage AdvancedTabPage;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.Button SaveButton;
        private EZ_Builder.UCForms.UCTabControl MainUCTabControl;
    }
}