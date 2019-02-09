using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args == null)
            {
                Console.WriteLine("Please enter the path to the file you wish to assemble.");
                string filePath = Console.ReadLine();
                ConvertFile(filePath);
            }
            else if (File.Exists(args[0]))
            {
                string path = args[0];
                ConvertFile(path);
            }
            else if (!File.Exists(args[0]))
            {
                Console.WriteLine("File not found");
            }




            Console.WriteLine("Press 'x' to exit, or enter another .asm file to be assembled");
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "x")
                {
                    break;
                }
                else
                {
                    ConvertFile(line);
                }
            }
        }
        private static void ConvertFile(string filePath)
        {
            filePath = filePath.Trim('"');
            if(!File.Exists(filePath))
            {
                Console.WriteLine("File not found!!");
                return;
            }
            try
            {

                Parser parser = new Parser();
                string[] lines = File.ReadAllLines(filePath);
                List<LineCommand> parsedLines = parser.Parse(lines.ToList());
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string destPath =$@"{Path.GetDirectoryName(filePath)}\{fileName}.asm";
                CodeWriter codeWriter = new CodeWriter();
                codeWriter.WriteCodeToFile(destPath, parsedLines);
                Console.WriteLine("File Conversion sucessful. File saved at " + destPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
