using System.Reflection;
using System.Xml.Linq;

namespace My
{
    public sealed class Utility
    {
        public string CreateGreetMessage(string name)
        {
            return $"Hello {name}";
        }
    }
}
