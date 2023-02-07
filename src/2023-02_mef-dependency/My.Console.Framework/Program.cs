using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace My
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"PlugIn Contract Type: {typeof(IPlugIn).FullName} ({typeof(IPlugIn).Assembly.GetName().FullName})");

            var folder = GetFolder();

            var catalog = new DirectoryCatalog(folder.FullName);

            var container = new CompositionContainer(catalog);

            var plugIn = container.GetExport<IPlugIn>().Value;

            const string name = "Tom";

            var result = Greet(plugIn, name);

            Console.WriteLine($"PlugIn Function Result: {result}");

            Console.ReadLine();
        }

        static string Greet(IPlugIn plugIn, string name) =>
#if V1_V2
            plugIn.Greet(name);
#elif V2_V1
            plugIn is IPlugIn2 plugIn2 ? plugIn2.Greet2(name) : plugIn.Greet(name);
#elif V2_V2
            plugIn is IPlugIn2 plugIn2 ? plugIn2.Greet2(name) : plugIn.Greet(name);
#endif

        static DirectoryInfo GetFolder() =>
#if V1_V2
            new DirectoryInfo(@"..\..\..\My.PlugIn\bin\V2\netstandard2.0");
#elif V2_V1
            new DirectoryInfo(@"..\..\..\My.PlugIn\bin\V1\netstandard2.0");
#elif V2_V2
            new DirectoryInfo(@"..\..\..\My.PlugIn\bin\V2\netstandard2.0");
#endif
    }
}
