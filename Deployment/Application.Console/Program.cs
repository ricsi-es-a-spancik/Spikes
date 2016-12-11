using LibraryCLRWrapper;
using System.Configuration;

namespace Application.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var imagePath = ConfigurationManager.AppSettings["imagepath"];

            if (imagePath != null)
            {
                System.Console.WriteLine($"Opening image from path {imagePath}...");

                var imageDisplay = new ImageDisplay();
                imageDisplay.Display(imagePath);

                PrintLoadedAssemblies();

                System.Console.ReadLine();
            }
            else
            {
                throw new System.IO.FileNotFoundException(imagePath);
            }
        }

        static void PrintLoadedAssemblies()
        {
            System.Console.WriteLine("\nList of loaded assemblies:\n");

            foreach (var assembly in System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                System.Console.WriteLine($"  {assembly.Name}");
                System.Console.WriteLine($"  {assembly.FullName}");
                System.Console.WriteLine($"  {assembly.CodeBase}");
                System.Console.WriteLine($"  {assembly.Version}\n");
            }
        }
    }
}
