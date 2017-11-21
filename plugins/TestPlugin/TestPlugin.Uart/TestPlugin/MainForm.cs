namespace TestPlugin
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using EZ_Builder;

    public partial class MainForm : EZ_Builder.UCForms.FormPluginMaster
    {
        private const int ezbPort = 0;
        private const int ezbUartPort = 0;
        private const int ezbUartBaudRate = 57600;
        private readonly Command[] commands;
        private bool ledState = false;

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

        private void ToggleLedButton_Click(object sender, EventArgs e)
        {
            this.ledState = !this.ledState;
            var cmd = string.Format("SET_LED {0} red\r\n", this.ledState ? "0" : "255");
            var response = this.UartSendString(cmd);
            this.WriteDebug("Response: " + response);
        }

        private void ReadAnalogButton_Click(object sender, EventArgs e)
        {
            var cmd = "READ_ANALOG 0\r\n";
            var response = this.UartSendString(cmd);
            this.WriteDebug("Response: " + response);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EZBManager.EZBs[ezbPort].OnConnectionChange += this.EZB_OnConnectionChange;
        }

        private void EZB_OnConnectionChange(bool isConnected)
        {
            if (isConnected)
            {
                //Reinitialize the UART when there is a new connection
                this.UartInit();
            }
        }

        private void UartInit()
        {
            if (!EZBManager.EZBs[ezbPort].IsConnected)
            {
                return;
            }
            this.WriteDebug(string.Format("UARTExpansionInit Ezb=[{0}] Uart=[{1}] BaudRate=[{2}]", ezbPort, ezbUartPort, ezbUartBaudRate));
            EZBManager.EZBs[ezbPort].Uart.UARTExpansionInit(ezbUartPort, ezbUartBaudRate);
        }

        private string UartSendString(string cmds, bool readResponse = true)
        {
            if (!EZBManager.EZBs[ezbPort].IsConnected)
            {
                return null;
            }

            var data = Encoding.ASCII.GetBytes(cmds);
            EZBManager.EZBs[ezbPort].Uart.UARTExpansionWrite((int)ezbUartPort, data);

            if (!readResponse)
            {
                return null;
            }

            for (var retry = 0; retry < 3; retry++)
            {
                Thread.Sleep(100);
                var responseBytes = new byte[] { };
                var available = EZBManager.EZBs[ezbPort].Uart.UARTExpansionAvailableBytes(ezbUartPort);
                if (available > 0)
                {
                    responseBytes = EZBManager.EZBs[ezbPort].Uart.UARTExpansionRead(ezbUartPort, available);
                    var responseText = Encoding.ASCII.GetString(responseBytes, 0, responseBytes.Length);
                    return responseText;
                }
            }

            return null;
        }
    }
}