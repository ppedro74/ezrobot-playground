using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EZ_Builder.Scripting;

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
                new CustomFunction("IsHighResolution", new string[] { }, "bool", IsHighResolutionFunction, "returns true when the underlying timer is based on a high-resolution performance counter."),
                new CustomFunction("Millis", new string[] { }, "Int64", MillisFunction, "returns the number of milliseconds elapsed since January 1, 1970 00:00:00 UTC"),
                new CustomFunction("Ticks", new string[] { }, "Int64", TicksFunction, "returns a long integer representing the tick counter value of the underlying timer mechanism."),
                new CustomFunction("TicksToMilliseconds", new string[] { "ticks" }, "Double", TicksToMillisecondsFunction, "Convert ticks to milliseconds"),
                new CustomFunction("DateTimeTicks", new string[] { }, "Int64", DateTimeTicksFunction, "Returns the number of ticks elapsed since January 1, 1 00:00:00 Gregorian Calendar UTC"),
                new CustomFunction("DateTimeTicksToMilliseconds", new string[] { "ticks" }, "Double", DateTimeTicksToMillisecondsFunction, "Convert DateTime's ticks to milliseconds"),
                new CustomFunction("DataQuery", new string[] { "connection", "query" }, "Int32", DataQueryFunction, ""),
            };

        }





        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DebugToFile("OnFormClosing::Begin");
            if (mainForm == this)
            {
                base.OnFormClosing(e);
            }
            DebugToFile("OnFormClosing::End");
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DebugToFile("OnFormClosed::Begin");
            base.OnFormClosed(e);
            DebugToFile("OnFormClosed::End");
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DebugToFile("MainForm_FormClosing::Begin");
            DebugToFile("MainForm_FormClosing::End");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DebugToFile("MainForm_FormClosed::Begin");

            if (mainForm != this)
            {
                return;
            }

            ExpressionEvaluation.FunctionEval.AdditionalFunctionEvent -= this.FunctionEval_AdditionalFunctionEvent;
            mainForm = null;
            DebugToFile("MainForm_FormClosed::End");
        }

        private static object DateTimeTicksToMillisecondsFunction(string functionName, object[] functionArguments)
        {
            long ticks;

            var str = functionArguments[0] as string;
            if (str != null)
            {
                if (!long.TryParse(str, out ticks))
                {
                    throw new Exception("DateTimeTicksToMilliseconds cannot convert ticks (argument 0) to long");
                }
            }
            else
            {
                ticks = Convert.ToInt64(functionArguments[0]);
            }

            var ts = new TimeSpan(ticks);
            return ts.TotalMilliseconds;
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

            var seconds = ticks / (double)Stopwatch.Frequency;
            var milliseconds = seconds * 1000;

            return milliseconds;
        }

        private static object IsHighResolutionFunction(string functionName, object[] functionArguments)
        {
            return Stopwatch.IsHighResolution;
        }

        private static object DateTimeTicksFunction(string functionName, object[] functionArguments)
        {
            return DateTime.UtcNow.Ticks;
        }

        private static object TicksFunction(string functionName, object[] functionArguments)
        {
            //Note: If Stopwatch.IsHighResolution==false DateTime.UtcNow.Ticks is used
            return Stopwatch.GetTimestamp();
        }

        private static object MillisFunction(string functionName, object[] functionArguments)
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        private static object DataQueryFunction(string functionName, object[] functionArguments)
        {
            var providerConnectionString = functionArguments[0] as string;
            var query = functionArguments[1] as string;
            var limit = functionArguments.Length > 2 ? Convert.ToInt32(functionArguments[2]) : 100;
            var outputVariable = functionArguments.Length > 3 ? functionArguments[3] as string : "$data_";

            if (string.IsNullOrWhiteSpace(providerConnectionString))
            {
                throw new Exception("Argument 0: provider connection string is required");
            }
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new Exception("Argument 1: query is required");
            }
            if (limit <= 0)
            {
                throw new Exception("Optional argument 2: limit is invalid");
            }

            if (!IsVariableNameValid(outputVariable, out var errorText))
            {
                throw new Exception("Optional argument 3: output variable " + errorText);
            }

            var tokens = providerConnectionString.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var providerName = tokens[0];
            var connectionString = tokens[1];

            var dbProviderFactory = DbProviderFactories.GetFactory(providerName);
            var row = 0;

            using (var dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;

                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = query;
                for (var ax = 4; ax < functionArguments.Length; ax++)
                {
                    var dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = "@" + (ax - 4);
                    dbParameter.Value = functionArguments[ax];
                    dbCommand.Parameters.Add(dbParameter);
                }


                dbConnection.Open();
                using (var dbDataReader = dbCommand.ExecuteReader())
                {
                    //Intentional: create empty arrays to return data
                    var numberOfColumns = dbDataReader.FieldCount;
                    for (var col = 0; col < numberOfColumns; col++)
                    {
                        VariableManager.CreateVariableArray(outputVariable + col, string.Empty, 0);
                    }

                    for (row = 0; dbDataReader.Read() && row < limit; row++)
                    {
                        for (var col = 0; col < numberOfColumns; col++)
                        {
                            var value = dbDataReader.IsDBNull(col) ? string.Empty : dbDataReader.GetValue(col);
                            VariableManager.AppendToVariableArray(outputVariable + col, value);
                        }
                    }
                }
            }

            return row;
        }

        public static bool IsVariableNameValid(string value, out string errorText)
        {
            errorText = null;

            if (string.IsNullOrWhiteSpace(value))
            {
                errorText = "is required";
            }
            else if (value[0] != '$')
            {
                errorText = "does not start with $";
            }
            else if (value[1] >= '0' && value[1] <= '9')
            {
                errorText = "cannot start with a number";
            }
            else if (value.Substring(1).Any(ch => !((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch == '_'))))
            {
                //only 0-9, A-Z, a-z and _ characters
                errorText = "has invalid chars";
            }

            return errorText == null;
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

        private static void DebugToFile(object obj, bool logTime = true)
        {
            var text = obj is Exception ? "=>Error Exception:\r\n" + obj : obj.ToString();

            var sb = new StringBuilder();
            if (logTime)
            {
                sb.Append(DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture));
                sb.Append(">");
            }

            sb.Append(text);
            sb.AppendLine();

            var logFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MiscUtilityPlugin.log");
            File.AppendAllText(logFile, sb.ToString());
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            DebugToFile("MainForm_Load::Begin");

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

            msg.Append("====== DbProviderFactories: ======");
            msg.AppendLine();

            var dt = DbProviderFactories.GetFactoryClasses();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    msg.AppendFormat("{0}=[{1}] ", col.ColumnName, row[col.ColumnName]);
                }

                msg.AppendLine();
            }

            msg.Append("==================================");
            msg.AppendLine();

            this.WriteDebug(msg, false, false);

            DebugToFile("MainForm_Load::End");

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