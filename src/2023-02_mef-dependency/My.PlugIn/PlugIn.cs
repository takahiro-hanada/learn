using System.ComponentModel.Composition;

namespace My
{
    [Export(typeof(IPlugIn))]
    public partial class PlugIn : IPlugIn
    {
        public string Greet(string name) => $"Hello {name}";
    }
}
