namespace TestPlugin
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using EZ_Builder.Config.Sub;

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
    }
}