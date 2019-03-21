using System;
using System.IO;

namespace HackAssembler
{
    internal class Program
    {
        private static string _filePath;
        private static void Main(string[] args)
        {
            if (args.Length == 0 || args == null)
            {
                Console.WriteLine("Please enter the path to the file you wish to assemble.");
                string filePath = Console.ReadLine();
                FindFile(filePath);
            }
            else if (File.Exists(args[0]))
            {
                string path = args[0];
                FindFile(path);
            }
            else if(!File.Exists(args[0]))
            {
                Console.WriteLine("File not found");
            }

            
           

            Console.WriteLine("Press 'x' to exit, or enter another .asm file to be assembled");
            while (true)
            {
              string line =  Console.ReadLine();
                if (line == "x")
                {
                    break;
                }
                else
                {
                    FindFile(line);
                }
            }
        }
        private static void FindFile(string filePath)
        {
            if(!filePath.Contains(".asm"))
            {
                Console.WriteLine("Unsupported File format! Use .asm files only." );
                return;
            }
            filePath = filePath.Trim('"');
            if (File.Exists(filePath))
            {
                Console.WriteLine("File found, attempting conversion");
                _filePath = filePath;
                string[] lines = File.ReadAllLines(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                WriteConvertedFile(lines, fileName);
            }
            else
            {
                Console.WriteLine("File not found!");
            }
        }
        private static void WriteConvertedFile(string[] lines, string fileName)
        {
            
            try
            {
                string[] convertedLines = HackParser.Parse(lines);
                string newPath = _filePath.Replace(".asm", ".hack");
                File.WriteAllLines(newPath, convertedLines);
                Console.WriteLine("Write sucessful, file stored at " + newPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
