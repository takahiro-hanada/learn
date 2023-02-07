
namespace My
{
#if V2
    partial class PlugIn : IPlugIn2
    {
        public string Greet2(string name) => $"Hi {name} (v2)";
    }
#endif
}
