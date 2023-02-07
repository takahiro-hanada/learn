using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace My
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"App's Contract Type: {typeof(IPlugIn).FullName} ({typeof(IPlugIn).Assembly.GetName().FullName})");

            var folder = GetFolder();

            var catalog = new DirectoryCatalog(folder.FullName);

            var container = new CompositionContainer(catalog);

            object objPlugIn;

            try
            {
                objPlugIn = container.GetExport<object>().Value;
            }
            catch (ReflectionTypeLoadException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                foreach(var tex in ex.LoaderExceptions)
                {
                    Console.WriteLine(tex.Message);
                }

                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            var plugInInterfaceType = objPlugIn.GetType().GetInterface(nameof(IPlugIn));

            Console.WriteLine($"App's Contract Type: {plugInInterfaceType.FullName} ({plugInInterfaceType.Assembly.GetName().FullName})");

            const string name = "Tom";

            var result = Greet(objPlugIn, name);

            if (result != null)
            {
                Console.WriteLine($"PlugIn Function Result: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The plugin's contract is a other type.");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            Console.ReadLine();
        }

        static string Greet(object objPlugIn, string name) =>
#if V1_V2
            objPlugIn is IPlugIn plugIn ? plugIn.Greet(name) : null;
#elif V2_V1
            objPlugIn is IPlugIn2 plugIn2 ? plugIn2.Greet2(name) : objPlugIn is IPlugIn plugIn ? plugIn.Greet(name) : null;
#elif V2_V2
            objPlugIn is IPlugIn2 plugIn2 ? plugIn2.Greet2(name) : objPlugIn is IPlugIn plugIn ? plugIn.Greet(name) : null;
#endif

        static DirectoryInfo GetFolder() =>
#if V1_V2 && !NETCOREAPP
            new DirectoryInfo(@"..\..\..\My.PlugIn\bin\V2\netstandard2.0");
#elif V2_V1 && !NETCOREAPP
            new DirectoryInfo(@"..\..\..\My.PlugIn\bin\V1\netstandard2.0");
#elif V2_V2 && !NETCOREAPP
            new DirectoryInfo(@"..\..\..\My.PlugIn\bin\V2\netstandard2.0");
#elif V1_V2 && NETCOREAPP
            new DirectoryInfo(@"..\..\..\..\My.PlugIn\bin\V2\netstandard2.0");
#elif V2_V1 && NETCOREAPP
            new DirectoryInfo(@"..\..\..\..\My.PlugIn\bin\V1\netstandard2.0");
#elif V2_V2 && NETCOREAPP
            new DirectoryInfo(@"..\..\..\..\My.PlugIn\bin\V2\netstandard2.0");
#endif
    }
}