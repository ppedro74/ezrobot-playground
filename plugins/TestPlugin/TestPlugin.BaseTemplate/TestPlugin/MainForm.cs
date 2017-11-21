namespace TestPlugin
{
    using System;
    using System.Globalization;
    using System.Linq;

    public partial class MainForm : EZ_Builder.UCForms.FormPluginMaster
    {
        private readonly Command[] commands;

        public MainForm()
        {
            this.InitializeComponent();

            this.commands = new[]
            {
                new Command("Command1", new[] { "param1", "param2" }, this.DoCommand1),
                new Command("Command2", new[] { "param1", "param2", "param3" }, this.DoCommand2),
            };
        }

        public override void SetConfiguration(EZ_Builder.Config.Sub.PluginV1 cf)
        {
            cf.STORAGE.AddIfNotExist(ConfigKeys.Setting1, string.Empty);
            cf.STORAGE.AddIfNotExist(ConfigKeys.Setting2, string.Empty);
            cf.STORAGE.AddIfNotExist(ConfigKeys.UseSomething, false);

            base.SetConfiguration(cf);
        }

        public override void SendCommand(string windowCommand, params string[] values)
        {
            foreach (var command in this.commands)
            {
                if (windowCommand.Equals(command.Name, StringComparison.OrdinalIgnoreCase))
                {
                    command.Action(windowCommand, values);
                    return;
                }
            }
            base.SendCommand(windowCommand, values);
        }

        public override object[] GetSupportedControlCommands()
        {
            return this.commands.
                Select(c => new[] { c.Name }.Concat(c.ParametersNames.Select(p => "[" + p + "]"))).
                Select(x => string.Join(", ", x)).
                Select(x => (object)x).
                ToArray();
        }

        private void ConfigurationButton_Click(object sender, EventArgs e)
        {
            using (var form = new ConfigForm(this._cf))
            {
                form.ShowDialog();
            }
        }

        private void DoCommand1(string name, string[] parameters)
        {
            //TODO
            this.WriteDebug("Executing command1");
        }

        private void DoCommand2(string name, string[] parameters)
        {
            //TODO
            this.WriteDebug("Executing command2");
        }

        private void WriteDebug(object obj, bool clear = false)
        {
            if (!this.IsHandleCreated)
            {
                //no handle yet
                return;
            }

            var text = (obj is Exception) ? "=>Error Exception:\r\n" + obj.ToString() : obj.ToString();

            this.LogTextBox.SynchronizedInvoke(() =>
            {
                if (clear)
                {
                    this.LogTextBox.Text = string.Empty;
                }
                this.LogTextBox.Text = this.LogTextBox.Text + DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture) + ">" + text + "\r\n";

                this.LogTextBox.SelectionLength = 0;
                this.LogTextBox.SelectionStart = this.LogTextBox.Text.Length;
                this.LogTextBox.ScrollToCaret();
            });
        }
    }
}