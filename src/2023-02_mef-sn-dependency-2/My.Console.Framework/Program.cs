using System;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;

namespace My
{
    static class Program
    {
        static Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        static string Path
        {
            get
            {
                return _config.AppSettings.Settings["Path"].Value;
            }
            set
            {
                _config.AppSettings.Settings["Path"].Value = value;
                _config.Save();
            }
        }

        static Utility _utility = new Utility();

        static string Greet()
        {
            return _utility.CreateGreetMessage("Tom");
        }

        static void Main(string[] args)
        {
            const string run = "run";
            const string path = "path";

            Console.WriteLine($"Current: {Path}");

            while (true)
            {
                Console.Write($"{run} / {path}: ");

                var line = Console.ReadLine();

                if (line == run)
                {
                    Run();
                }
                else if (line == path)
                {
                    Console.Write($"New: ");

                    line = Console.ReadLine();

                    if (Directory.Exists(line))
                    {
                        Path = line;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Directory not found");

                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Invalid Command");

                    Console.ResetColor();
                }
            }
        }

        static void Run()
        {
            var path = Path;

            var catalog = new DirectoryCatalog(path);

            var _container = new CompositionContainer(catalog);

            var plugIn = _container.GetExport<IPlugIn>().Value;

            Console.WriteLine($"App's Utiity Type:    {typeof(Utility).FullName} ({typeof(Utility).Assembly.GetName().FullName})");
            Console.WriteLine($"App's Result:         {Greet()}");

            Console.WriteLine($"PlugIn's Utiity Type: {plugIn.Utility?.GetType().FullName} ({plugIn.Utility?.GetType().Assembly.GetName().FullName})");
            Console.WriteLine($"PlugIn's Result:      {plugIn.Greet("Tom")}");
        }
    }
}
