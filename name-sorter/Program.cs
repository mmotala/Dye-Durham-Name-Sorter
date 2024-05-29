using Microsoft.Extensions.DependencyInjection;
using DataLayer.Interfaces;
using LogicLayer.Interfaces;
using DataLayer.Implementaion;
using LogicLayer.Implementaion;

namespace name_sorter
{
    static class Program
    {
         static async Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: name-sorter <file-path>");
                return;
            }

            string filePath = args[0];
            string outputFilePath = "sorted-names-list.txt";

            // Set up DI
            var serviceProvider = ConfigureServices();

            // Resolve the main application logic
            var app = serviceProvider.GetService<App>();
            await app.RunAsync(filePath, outputFilePath);
        }

        private static ServiceProvider ConfigureServices()
        {
            // Configure services
            var services = new ServiceCollection();

            services.AddTransient<IFileReader, FileReader>();
            services.AddTransient<IFileWriter, FileWriter>();
            services.AddTransient<IFileLogic, FileLogic>();
            services.AddTransient<IPersonNameLogic, PersonNameLogic>();
            services.AddTransient<App>();

            return services.BuildServiceProvider();
        }
    }

    public class App
    {
        private readonly IPersonNameLogic _personNameLogic;

        public App(IPersonNameLogic personNameLogic)
        {
            _personNameLogic = personNameLogic;
        }

        public async Task RunAsync(string filePath, string outputFilePath)
        {
            try
            {
                // Sort and save names to a file
                var sortedNames = await _personNameLogic.SortAndSaveNamesAsync(filePath, outputFilePath);

                // Output the sorted names
                _personNameLogic.DisplayNames(sortedNames);

                Console.WriteLine($"Sorted names have been written to {outputFilePath}");
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine($"File not found: {fnfEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine($"Invalid file format: {argEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}   