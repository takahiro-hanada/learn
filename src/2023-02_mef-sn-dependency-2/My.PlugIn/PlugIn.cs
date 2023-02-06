using System.ComponentModel.Composition;

namespace My
{
    [Export(typeof(IPlugIn))]
    public class PlugIn : IPlugIn
    {
        object IPlugIn.Utility => Utility;

        Utility Utility { get; } = new Utility();

        public string Greet(string name) => Utility.CreateGreetMessage(name);
    }
}
