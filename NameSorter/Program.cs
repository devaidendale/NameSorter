using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NameSorter.Models;
using NameSorter.Services;

namespace NameSorter
{
    public class Program
    {
        private static IServiceProvider serviceProvider;

        public static void Main(string[] args)
        {
            try
            {
                configureServices(Environment.GetCommandLineArgs()[1], "./sorted-names-list.txt");
                var nameService = serviceProvider.GetService<INameService>();

                var names = new List<Name>();
                nameService.getNames(names);

                // Criteria: "The names should be sorted correctly":
                nameService.sortNames(names);

                // Criteria: "It should write/overwrite the sorted list of names to a file called sorted-names-list.txt":
                nameService.saveNames(names);

                // Criteria: "It should print the sorted list of names to screen":
                names.ForEach(i => Console.WriteLine("{0}", i));

                // Criteria: "Unit tests should exist":
                // Run the tests on the NameSorter.Tests project.
            }
            catch (Exception e)
            {
                // Simple/quick console input checking and exception handling:
                switch (e.GetType().ToString())
                {
                    case "System.IndexOutOfRangeException":
                    case "System.TypeInitializationException":
                    case "System.IO.FileNotFoundException":
                        Console.Write("Error: Please specify a valid input file.\n\n");
                        break;
                    default:
                        Console.WriteLine($"Error: {e.Message}\n");
                        break;
                }
                Console.Write(getHelp());
            }
        }

        private static void configureServices(string sourceFilename, string destinationFilename)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDataService>(s => new DataFileService(sourceFilename, destinationFilename));
            services.AddSingleton<INameService, NameService>();

            serviceProvider = services.BuildServiceProvider();
        }

        private static string getHelp()
        {
            return @"Usage: name-sorter <input filename>

Synopsis: This program reads data from the <input filename>, sorts it, and 
   then both prints and writes the result to screen and sorted-names-list.txt.
";
        }
    }
}
