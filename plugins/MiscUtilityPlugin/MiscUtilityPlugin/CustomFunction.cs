using System;

namespace MiscUtilityPlugin
{
    public class CustomFunction
    {
        public CustomFunction(string name, string[] parametersNames, string returnType, Func<string, object[], object> function, string description = null)
        {
            this.Name = name;
            this.ParametersNames = parametersNames ?? new string[] { };
            this.Function = function;
            this.ReturnType = returnType;
            this.Description = description;
        }

        public string Name { get; private set; }

        public string[] ParametersNames { get; private set; }

        public Func<string, object[], object> Function { get; private set; }

        public string ReturnType { get; private set; }

        public string Description { get; private set; }
    }
}