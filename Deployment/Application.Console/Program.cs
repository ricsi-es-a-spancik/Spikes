using LibraryCLRWrapper;

namespace Application.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("image path: ");
            var imagePath = System.Console.ReadLine();

            var imageDisplay = new ImageDisplay();
            imageDisplay.Display(imagePath);

            System.Console.ReadLine();
        }
    }
}
