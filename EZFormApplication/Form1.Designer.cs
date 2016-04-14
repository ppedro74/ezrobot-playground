﻿namespace EZFormApplication
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.IpAddressTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TakeAPicButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ImageFileNameTB = new System.Windows.Forms.TextBox();
            this.StartCameraButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FpsLabel = new System.Windows.Forms.Label();
            this.fpsLabelLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DebugTextBox = new System.Windows.Forms.TextBox();
            this.OneSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // IpAddressTB
            // 
            this.IpAddressTB.Location = new System.Drawing.Point(35, 15);
            this.IpAddressTB.Name = "IpAddressTB";
            this.IpAddressTB.Size = new System.Drawing.Size(94, 20);
            this.IpAddressTB.TabIndex = 1;
            this.IpAddressTB.Text = "192.168.18.85";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TakeAPicButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ImageFileNameTB);
            this.groupBox1.Location = new System.Drawing.Point(15, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 87);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picture";
            // 
            // TakeAPicButton
            // 
            this.TakeAPicButton.Location = new System.Drawing.Point(71, 45);
            this.TakeAPicButton.Name = "TakeAPicButton";
            this.TakeAPicButton.Size = new System.Drawing.Size(75, 23);
            this.TakeAPicButton.TabIndex = 9;
            this.TakeAPicButton.Text = "Take a PIC";
            this.TakeAPicButton.UseVisualStyleBackColor = true;
            this.TakeAPicButton.Click += new System.EventHandler(this.TakeAPicButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Image File";
            // 
            // ImageFileNameTB
            // 
            this.ImageFileNameTB.Location = new System.Drawing.Point(71, 19);
            this.ImageFileNameTB.Name = "ImageFileNameTB";
            this.ImageFileNameTB.Size = new System.Drawing.Size(321, 20);
            this.ImageFileNameTB.TabIndex = 7;
            // 
            // StartCameraButton
            // 
            this.StartCameraButton.Location = new System.Drawing.Point(144, 15);
            this.StartCameraButton.Name = "StartCameraButton";
            this.StartCameraButton.Size = new System.Drawing.Size(105, 23);
            this.StartCameraButton.TabIndex = 10;
            this.StartCameraButton.Tag = "Start Camera|Stop Camera";
            this.StartCameraButton.Text = "Start Camera";
            this.StartCameraButton.UseVisualStyleBackColor = true;
            this.StartCameraButton.Click += new System.EventHandler(this.StartCameraButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FpsLabel);
            this.groupBox2.Controls.Add(this.fpsLabelLabel);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(15, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 154);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video";
            // 
            // FpsLabel
            // 
            this.FpsLabel.AutoSize = true;
            this.FpsLabel.Location = new System.Drawing.Point(294, 43);
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(0, 13);
            this.FpsLabel.TabIndex = 11;
            this.FpsLabel.Visible = false;
            // 
            // fpsLabelLabel
            // 
            this.fpsLabelLabel.AutoSize = true;
            this.fpsLabelLabel.Location = new System.Drawing.Point(191, 43);
            this.fpsLabelLabel.Name = "fpsLabelLabel";
            this.fpsLabelLabel.Size = new System.Drawing.Size(97, 13);
            this.fpsLabelLabel.TabIndex = 9;
            this.fpsLabelLabel.Text = "frames per second:";
            this.fpsLabelLabel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 120);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DebugTextBox);
            this.groupBox3.Location = new System.Drawing.Point(15, 296);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 190);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // DebugTextBox
            // 
            this.DebugTextBox.Location = new System.Drawing.Point(11, 19);
            this.DebugTextBox.Multiline = true;
            this.DebugTextBox.Name = "DebugTextBox";
            this.DebugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DebugTextBox.Size = new System.Drawing.Size(381, 160);
            this.DebugTextBox.TabIndex = 5;
            // 
            // OneSecondTimer
            // 
            this.OneSecondTimer.Interval = 1000;
            this.OneSecondTimer.Tick += new System.EventHandler(this.OneSecondTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 495);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.StartCameraButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IpAddressTB);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IpAddressTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button TakeAPicButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ImageFileNameTB;
        private System.Windows.Forms.Button StartCameraButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label FpsLabel;
        private System.Windows.Forms.Label fpsLabelLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox DebugTextBox;
        private System.Windows.Forms.Timer OneSecondTimer;
    }
}

