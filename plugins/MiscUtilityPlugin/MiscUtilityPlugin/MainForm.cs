using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiscUtilityPlugin
{
    public partial class MainForm : EZ_Builder.UCForms.FormPluginMaster
    {
        private static MainForm mainForm = null;
        private readonly CustomFunction[] functions;

        public MainForm()
        {
            if (mainForm != null)
            {
                mainForm.Focus();
                mainForm.WriteDebug("Warning: Only one MiscUtilityPlugin control per project");
                this.Shown += (s, e) => this.Close();
                return;
            }

            mainForm = this;

            this.InitializeComponent();

            this.functions = new[]
            {
                new CustomFunction("Millis", new string[] { }, "Int64", MillisFunction, "returns the number of milliseconds elapsed since January 1, 1970 00:00:00 UTC"),
                new CustomFunction("Ticks", new string[] { }, "Int64", TicksFunction, "returns the number of ticks elapsed since January 1, 1 00:00:00 Gregorian Calendar UTC"),
                new CustomFunction("TicksToMilliseconds", new string[] { "ticks" }, "Double", TicksToMillisecondsFunction, "Convert ticks to milliseconds"),
            };
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (mainForm == this)
            {
                base.OnFormClosing(e);
            }
        }

        private static object TicksToMillisecondsFunction(string functionName, object[] functionArguments)
        {
            long ticks;

            var str = functionArguments[0] as string;
            if (str != null)
            {
                if (!long.TryParse(str, out ticks))
                {
                    throw new Exception("TicksToMilliseconds cannot convert ticks (argument 0) to long");
                }
            }
            else
            {
                ticks = Convert.ToInt64(functionArguments[0]);
            }

            var ts = new TimeSpan(ticks);
            return ts.TotalMilliseconds;
        }

        private static object TicksFunction(string functionName, object[] functionArguments)
        {
            return DateTime.UtcNow.Ticks;
        }

        private static object MillisFunction(string functionName, object[] functionArguments)
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        public void WriteDebug(object obj, bool clear = false, bool logTime = true)
        {
            if (!this.IsHandleCreated)
            {
                //no handle yet
                return;
            }

            var text = obj is Exception ? "=>Error Exception:\r\n" + obj : obj.ToString();

            this.LogTextBox.SynchronizedInvoke(
                () =>
                {
                    if (clear)
                    {
                        this.LogTextBox.Text = string.Empty;
                    }

                    var sb = new StringBuilder(this.LogTextBox.Text.Length + text.Length + 32);
                    sb.Append(this.LogTextBox.Text);
                    if (logTime)
                    {
                        sb.Append(DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture));
                        sb.Append(">");
                    }
                    sb.Append(text);
                    sb.AppendLine();
                    this.LogTextBox.Text = sb.ToString();

                    this.LogTextBox.SelectionLength = 0;
                    this.LogTextBox.SelectionStart = this.LogTextBox.Text.Length;
                    this.LogTextBox.ScrollToCaret();
                });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (mainForm != this)
            {
                return;
            }

            ExpressionEvaluation.FunctionEval.AdditionalFunctionEvent += this.FunctionEval_AdditionalFunctionEvent;

            var msg = new StringBuilder();
            msg.Append("====== Available functions: ======");
            msg.AppendLine();

            foreach (var customFunction in this.functions)
            {
                msg.Append("# ");
                msg.Append(customFunction.Description);
                msg.AppendLine();

                msg.AppendFormat(
                    "{0} ({1}) => {2}",
                    customFunction.Name,
                    string.Join(", ", customFunction.ParametersNames.Select(x => "<" + x + ">")),
                    customFunction.ReturnType
                    );
                msg.AppendLine();

                msg.AppendLine();
            }
            msg.Append("==================================");
            msg.AppendLine();

            this.WriteDebug(msg, false, false);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainForm != this)
            {
                return;
            }

            ExpressionEvaluation.FunctionEval.AdditionalFunctionEvent -= this.FunctionEval_AdditionalFunctionEvent;
            mainForm = null;
        }

        /// 
        /// This is executed when a function is specified in any ez-scripting that isn't a native function.
        /// You can check to see if the function that was called is your function.
        /// If it is, do something and return something.
        /// If you don't return something, a default value of TRUE is returned.
        /// If you throw an exception, the ez-script control will receive the exception and present the error to the user.
        /// 
        private void FunctionEval_AdditionalFunctionEvent(object sender, ExpressionEvaluation.AdditionalFunctionEventArgs e)
        {
            foreach (var customFunction in this.functions)
            {
                if (!e.Name.Equals(customFunction.Name, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var numberOfArguments = e.Parameters != null ? e.Parameters.Length : 0;

                if (numberOfArguments < customFunction.ParametersNames.Length)
                {
                    var msg = new StringBuilder();
                    msg.AppendFormat(
                        "Expects {0} parameter(s). Usage: {1}({2})",
                        customFunction.ParametersNames.Length,
                        customFunction.Name,
                        string.Join(", ", customFunction.ParametersNames.Select(x => "<" + x + ">")));

                    throw new Exception(msg.ToString());
                }

                e.ReturnValue = customFunction.Function(customFunction.Name, e.Parameters);
                return;
            }
        }
    }
}