using System;
using System.Globalization;
using System.Linq;
using EZ_Builder.UCForms;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.TextToSpeech.v1;

namespace WatsonTest.EZPlugin
{
    public partial class MainForm : FormPluginMaster
    {
        private const string TextToSpeechServiceUrl = "https://gateway-wdc.watsonplatform.net/text-to-speech/api";
        private const string TextToSpeechServiceApiKey = "---secret-key---";

        public MainForm()
        {
            this.InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Log("Press TEST to fetch TTS voices.");
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.TestButton.Enabled = false;

                var result = this.GetTextToSpeechService().ListVoices();
                var voices = result.Result?._Voices;
                if (voices == null)
                {
                    this.Log("Problem: Voices are null");
                }
                else
                {
                    var voiceNames = voices.Select(x => x.Name).ToArray();
                    this.Log($"Voices:\r\n...{string.Join("\r\n...", voiceNames)}");
                    this.Log($"   total #{voices.Count} voices found");
                }
            }
            catch (Exception ex)
            {
                this.Log(ex);
            }
            finally
            {
                this.TestButton.Enabled = true;
            }
        }

        private TextToSpeechService GetTextToSpeechService()
        {
            if (string.IsNullOrEmpty(TextToSpeechServiceApiKey) || TextToSpeechServiceApiKey.Contains("secret"))
            {
                throw new Exception("ERROR: Api Key is not defined");
            }

            var authenticator = new IamAuthenticator(TextToSpeechServiceApiKey);
            var service = new TextToSpeechService(authenticator);
            service.SetServiceUrl(TextToSpeechServiceUrl);
            return service;
        }

        private void Log(object obj)
        {
            var text = obj is Exception ? " Exception=[\r\n" + obj + "]" : obj.ToString();
            this.LogTextBox.Text = this.LogTextBox.Text + DateTime.Now.ToString("HH:mm:ss.fff>>", CultureInfo.InvariantCulture) + text + "\r\n";
            if (this.AutoScrollCB.Checked)
            {
                this.LogTextBox.SelectionLength = 0;
                this.LogTextBox.SelectionStart = this.LogTextBox.Text.Length;
                this.LogTextBox.ScrollToCaret();
            }
        }

        private void ClearDebugButton_Click(object sender, EventArgs e)
        {
            this.LogTextBox.Text = "";
        }
    }
}