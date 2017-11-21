namespace TestPlugin
{
    using System;

    public class Command
    {
        public Command(string name, string[] parametersNames, Action<string, string[]> action)
        {
            this.Name = name;
            this.ParametersNames = parametersNames;
            this.Action = action;
        }

        public string Name { get; set; }

        public string[] ParametersNames { get; set; }

        public Action<string, string[]> Action { get; set; }
    }
}