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
        private static CodeWriter codeWriter = new CodeWriter();
        static void Main(string[] args)
        {
            if (args.Length == 0 || args == null)
            {
                Console.WriteLine("Please enter the path to the file or directory you wish to assemble.");
                string filePath = Console.ReadLine();
                filePath = SanitizeInput(filePath);
                HandleFilePath(filePath);
            }
            else if (File.Exists(args[0]))
            {
                string path = args[0];
                path = SanitizeInput(path);
                HandleFilePath(path);
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
                    line = SanitizeInput(line);
                    HandleFilePath(line);
                }
            }
        }
        private static string SanitizeInput(string filePath)
        {
            string sanitizedFilePath = filePath;
            sanitizedFilePath = filePath.Trim('"');
            sanitizedFilePath = sanitizedFilePath.Trim();
            return sanitizedFilePath;
        }
        private static void HandleFilePath(string filePath)
        {
            try
            {
                if (IsDirectory(filePath))
                {
                    TranslateDirectory(filePath);
                }
                else
                {
                    ConvertFile(filePath);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static bool IsDirectory(string filePath)
        {
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(filePath);
                return fileAttributes.HasFlag(FileAttributes.Directory);
            }
            catch
            {
                return false;
            }
        }
        private static void TranslateDirectory(string dirPath)
        {
            if(!ValidDirectory(dirPath))
            {
                return;
            }
            string sysFile = GetSystemFile(dirPath);
            List<string> files = GetVMFiles(dirPath).Where(x=>x != sysFile).ToList();
            
            List<string> translatedFileLines = TranslateFile(sysFile,true);
            foreach (var file in files)
            {
                translatedFileLines.AddRange(TranslateFile(file,false));
            }
            WriteTranslatedFile(dirPath, translatedFileLines);

        }
        
        private static List<string> TranslateFile(string filePath, bool isDirectory)
        {
           
            Parser parser = new Parser();
            string[] lines = File.ReadAllLines(filePath);
            string fileName = GetFileName(filePath);        
            List<LineCommand> commands = parser.Parse(lines.ToList(), fileName, isDirectory);
            List<string> formattedLines = codeWriter.FormatParsedLines(filePath, commands);
            return formattedLines;
        }
        private static List<string> GetVMFiles(string dirPath)
        {
            List<string> files = Directory.EnumerateFiles(dirPath).Where(x => x.EndsWith(".vm")).ToList();
            return files;
        }
        private static bool ValidDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Console.WriteLine("File not found!!");
                return false;
            }
            List<string> files = GetVMFiles(dirPath);
            if (files.Count == 0)
            {
                Console.WriteLine("No '.vm' files found in this directory.");
                return false;
            }
            if (!File.Exists(GetSystemFile(dirPath)))
            {
                Console.WriteLine("No Sys.vm file found.Unable to compile program.");
                return false;
            }
            return true;
        }
        private static string GetSystemFile(string dirPath)
        {
            return $@"{dirPath}/Sys.vm";
        }
        private static void ConvertFile(string filePath)
        {
            filePath = filePath.Trim('"');
            if(!File.Exists(filePath))
            {
                Console.WriteLine("File not found!!");
                return;
            }
                List<string> formattedLines = TranslateFile(filePath, false);
                WriteTranslatedFile(filePath, formattedLines);
            
        }
        private static void WriteTranslatedFile(string filePath, List<string> contents)
        {
            string fileName = GetFileName(filePath);
            string destPath = GetDestinationPath(filePath, fileName);
            File.WriteAllLines(destPath, contents);
            Console.WriteLine("File Conversion sucessful. File saved at " + destPath);
        }
        private static string GetFileName(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }
        private static string GetDestinationPath(string filePath, string fileName)
        {
            if(IsDirectory(filePath))
            {
                return $@"{filePath}\{fileName}.asm"; 
            }
            return $@"{Path.GetDirectoryName(filePath)}\{fileName}.asm";
        }
    }
}
