namespace TestPlugin
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ConfigurationButton = new EZ_Builder.UCForms.UC.UCConfigurationButton();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReadAnalogButton = new System.Windows.Forms.Button();
            this.ToggleLedButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigurationButton
            // 
            this.ConfigurationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfigurationButton.Image = ((System.Drawing.Image)(resources.GetObject("ConfigurationButton.Image")));
            this.ConfigurationButton.Location = new System.Drawing.Point(3, 3);
            this.ConfigurationButton.Name = "ConfigurationButton";
            this.ConfigurationButton.Size = new System.Drawing.Size(30, 24);
            this.ConfigurationButton.TabIndex = 0;
            this.ConfigurationButton.UseVisualStyleBackColor = true;
            this.ConfigurationButton.Click += new System.EventHandler(this.ConfigurationButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.Black;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextBox.ForeColor = System.Drawing.Color.Lime;
            this.LogTextBox.Location = new System.Drawing.Point(0, 30);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(473, 173);
            this.LogTextBox.TabIndex = 1;
            this.LogTextBox.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReadAnalogButton);
            this.panel1.Controls.Add(this.ToggleLedButton);
            this.panel1.Controls.Add(this.ConfigurationButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 30);
            this.panel1.TabIndex = 2;
            // 
            // ReadAnalogButton
            // 
            this.ReadAnalogButton.Location = new System.Drawing.Point(154, 4);
            this.ReadAnalogButton.Name = "ReadAnalogButton";
            this.ReadAnalogButton.Size = new System.Drawing.Size(102, 23);
            this.ReadAnalogButton.TabIndex = 4;
            this.ReadAnalogButton.Text = "Read Analog A0";
            this.ReadAnalogButton.UseVisualStyleBackColor = true;
            this.ReadAnalogButton.Click += new System.EventHandler(this.ReadAnalogButton_Click);
            // 
            // ToggleLedButton
            // 
            this.ToggleLedButton.Location = new System.Drawing.Point(48, 4);
            this.ToggleLedButton.Name = "ToggleLedButton";
            this.ToggleLedButton.Size = new System.Drawing.Size(100, 23);
            this.ToggleLedButton.TabIndex = 3;
            this.ToggleLedButton.Text = "Toggle Red Led";
            this.ToggleLedButton.UseVisualStyleBackColor = true;
            this.ToggleLedButton.Click += new System.EventHandler(this.ToggleLedButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 203);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Test Plugin";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EZ_Builder.UCForms.UC.UCConfigurationButton ConfigurationButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ReadAnalogButton;
        private System.Windows.Forms.Button ToggleLedButton;
    }
}

