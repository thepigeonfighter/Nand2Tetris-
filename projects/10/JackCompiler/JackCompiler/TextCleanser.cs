using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class TextCleanser
    {
        public static List<string> RemoveWhitespaceAndComments(List<string> lines)
        {
            var modifiedLines = new List<string>();
             modifiedLines = RemoveLineComments(lines);
            modifiedLines = RemoveBlockComments(modifiedLines);
            modifiedLines = RemoveWhiteSpace(modifiedLines);
            return modifiedLines;
        }
        private static List<string>RemoveWhiteSpace(List<string> lines)
        {
            var modifiedLines = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {             
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    lines[i] = lines[i].Trim();
                    modifiedLines.Add(lines[i]);
                }
            }
            return modifiedLines;
        }
        private static List<string> RemoveLineComments(List<string> lines)
        {
            var modifiedLines = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains("//") )
                {
                    int index = lines[i].IndexOf("//");
                    lines[i] = lines[i].Remove(index);
                }
                modifiedLines.Add(lines[i]);
            }
            return modifiedLines;
        }
        private static List<string> RemoveBlockComments(List<string> lines)
        {
            var modifiedLines = new List<string>();
            bool inComment = false;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains("/**"))
                {
                    inComment = true;
                }                
                if(!inComment)
                {
                    modifiedLines.Add(lines[i]);
                }
                if (lines[i].Contains("*/"))
                {
                    inComment = false;
                }



            }
            return modifiedLines;
        }
    }
}
