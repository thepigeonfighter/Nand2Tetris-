using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JackCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            JackAnalyzer analyzer = new JackAnalyzer();
            Console.WriteLine("Enter path to file or directory you wish to compile, or enter 'x' to exit");
            while (true)
            {

                string word = Console.ReadLine();
                if(word == "x")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string destination = analyzer.Analyze(word);
                    Console.WriteLine($"Compilation successful, saved at {destination}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
