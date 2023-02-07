using System;
using System.ComponentModel.Composition;

namespace My
{
    [Export(typeof(object))]
    public partial class PlugIn : IPlugIn
    {
        public string Greet(string name) => $"Hello {name} (v1)";
    }
}
