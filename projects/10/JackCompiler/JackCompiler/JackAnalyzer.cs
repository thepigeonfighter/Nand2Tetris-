using System;
using System.IO;
using System.Linq;

namespace JackCompiler
{
    public class JackAnalyzer
    {
        private string destdir;
        public string Analyze(string filePath)
        {
            
            if (IsDirectory(filePath))
            {
                SetDestDir(filePath,true);
                HandleDirectory(filePath);
            }
            else
            {
                SetDestDir(filePath, false);
                HandleFile(filePath);
            }

            return destdir;
        }
        private void SetDestDir(string filePath, bool isDir)
        {
            if (!isDir)
            {
                string dirName = Directory.GetParent(filePath).Name;
                destdir = Path.GetDirectoryName(filePath) + $@"\JackCompilerOutput\{dirName}\";
                
            }
            else
            {
                destdir = filePath + $@"\JackCompilerOutput\";
            }
            Directory.CreateDirectory(destdir);
        }
        private string GetDestinationPath(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string path = destdir + fileName + ".xml";
            return path;
        }
        private void HandleFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File path entered is not a valid directory");
            }
            string[] classLines = File.ReadAllLines(filePath);
            Tokenizer tokenizer = new Tokenizer(classLines);
            string outputFilePath = GetDestinationPath(filePath);
            CompilationEngine compilationEngine = new CompilationEngine(tokenizer, outputFilePath);

        }
        private void HandleDirectory(string dirPath)
        {
            if(!Directory.Exists(dirPath))
            {
                throw new Exception("Path entered is not a valid directory");
            }
            string[] files = Directory.GetFiles(dirPath).Where(x => x.EndsWith(".jack")).ToArray();
            foreach(var file in files)
            {
                HandleFile(file);
            }
        }
        private bool IsDirectory(string filePath)
        {
            FileAttributes fileAttributes = File.GetAttributes(filePath);
            return fileAttributes.HasFlag(FileAttributes.Directory);
        }
    }
}
