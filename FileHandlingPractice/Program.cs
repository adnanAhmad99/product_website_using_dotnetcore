using System.IO;

namespace FileHandlingPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] currentDir = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach(string data in currentDir)
            {
                Console.WriteLine(data);

            }

        }
    }
}
