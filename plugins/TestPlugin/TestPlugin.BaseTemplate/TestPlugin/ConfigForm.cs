namespace TestPlugin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using EZ_Builder.Config.Sub;
    using EZ_Builder.UCForms;
    using EZ_Builder.UCForms.UC;

    public partial class ConfigForm : Form
    {
        private readonly PluginV1 pluginV1;

        public ConfigForm(PluginV1 config)
        {
            this.InitializeComponent();
            this.pluginV1 = config;

            this.Setting1TextBox.Text = config.STORAGE.GetKey(ConfigKeys.Setting1, string.Empty).ToString();
            this.Setting2TextBox.Text = config.STORAGE.GetKey(ConfigKeys.Setting2, string.Empty).ToString();
            this.UseSomethingCheckBox.Checked = Convert.ToBoolean(config.STORAGE.GetKey(ConfigKeys.UseSomething, false));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string msg;
            if (this.IsConfigValid(out msg))
            {
                this.UpdatePluginConfiguration();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(msg, "Attention required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePluginConfiguration()
        {
            this.pluginV1.STORAGE.AddOrUpdate(ConfigKeys.Setting1, this.Setting1TextBox.Text);
            this.pluginV1.STORAGE.AddOrUpdate(ConfigKeys.Setting2, this.Setting2TextBox.Text);
            this.pluginV1.STORAGE.AddOrUpdate(ConfigKeys.UseSomething, this.UseSomethingCheckBox.Checked);
        }

        private bool IsConfigValid(out string msg)
        {
            msg = null;
            var errors = new List<string>();

            if (string.IsNullOrEmpty(this.Setting1TextBox.Text))
            {
                errors.Add("Setting1 must not be empty");
            }

            if (!EZ_B.Functions.IsNumeric(this.Setting2TextBox.Text))
            {
                errors.Add("Setting2 must be a numberic value");
            }

            if (errors.Count > 0)
            {
                msg = string.Join("\r\n", errors);
                return false;
            }

            return true;
        }


        //private void InitializeComponent1()
        //{
        //    ComponentResourceManager resources = new ComponentResourceManager(typeof(FormConfig));
        //    this.ucTabControl1 = new UCTabControl();

        //    this.tabPage1 = new TabPage();
        //    this.tabPage2 = new TabPage();

        //    this.ucTabControl1.SuspendLayout();
        //    this.tabPage1.SuspendLayout();
        //    this.tabPage2.SuspendLayout();

        //    this.ucTabControl1.Appearance = TabAppearance.Buttons;
        //    this.ucTabControl1.BackColor = Color.White;
        //    this.ucTabControl1.ButtonBackColor = Color.FromArgb(76, 170, 234);
        //    this.ucTabControl1.ButtonSelectedBackColor = Color.FromArgb(51, 146, 66);
        //    this.ucTabControl1.ButtonTextColor = Color.White;
        //    this.ucTabControl1.Controls.Add(this.tabPage1);
        //    this.ucTabControl1.Controls.Add(this.tabPage2);
        //    this.ucTabControl1.Dock = DockStyle.Fill;
        //    this.ucTabControl1.ItemSize = new Size(60, 50);
        //    this.ucTabControl1.Location = new Point(0, 0);
        //    this.ucTabControl1.Margin = new Padding(0);
        //    this.ucTabControl1.MarginLeft = 0;
        //    this.ucTabControl1.MarginTop = 0;
        //    this.ucTabControl1.Multiline = true;
        //    this.ucTabControl1.Name = "ucTabControl1";
        //    this.ucTabControl1.Padding = new Point(0, 0);
        //    this.ucTabControl1.SelectedIndex = 0;
        //    this.ucTabControl1.Size = new Size(531, 488);
        //    this.ucTabControl1.TabIndex = 8;
        //    this.tabPage1.Location = new Point(4, 54);
        //    this.tabPage1.Name = "tabPage1";
        //    this.tabPage1.Padding = new Padding(3);
        //    this.tabPage1.Size = new Size(523, 430);
        //    this.tabPage1.TabIndex = 0;
        //    this.tabPage1.Text = "General";
        //    this.tabPage1.UseVisualStyleBackColor = true;
        //    this.tabPage2.Controls.Add(this.ucUseAPIKey);
        //    this.tabPage2.Location = new Point(4, 54);
        //    this.tabPage2.Name = "tabPage2";
        //    this.tabPage2.Padding = new Padding(3);
        //    this.tabPage2.Size = new Size(523, 430);
        //    this.tabPage2.TabIndex = 1;
        //    this.tabPage2.Text = "Advanced";
        //    this.tabPage2.UseVisualStyleBackColor = true;
        //    this.ucTabControl1.ResumeLayout(false);
        //    this.tabPage1.ResumeLayout(false);
        //    this.tabPage2.ResumeLayout(false);
        //}
    }
}