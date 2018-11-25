//Задание 2.
//Заменить все большие буквы в исходной строке маленькими. После каждого слова вставить символ $. 
//Сформировать массив строк String из предложений текста, в которых все слова состоят не больше чем из пяти символов.
//Разделителями слов считать пробел, запятую, точку с запятой. 
//Разделителями предложений считать точку, восклицательный и вопросительный знаки, символ конца строки.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Happy New Year! I am a small. I am a very happiness!";
            Console.WriteLine("Source line:");
            Console.WriteLine(str);
            // Заменить все большие буквы в исходной строке маленькими.
            //unsafe
            //{
            //    fixed (char* c = str)
            //    {
            //        for (int i = 0; i < str.Length; i++)
            //        {
            //            if (str[i] >= 'A' && str[i] <= 'Z')
            //            {
            //                c[i] = (char)(str[i] + 32);
            //            }
            //        }
            //    }
            //}
            Console.WriteLine("\nWe change big letters for small:");
            Console.WriteLine(str.ToLower());
            //После каждого слова вставить символ $. Разделителями слов считать пробел, запятую, точку с запятой. 
            Regex regexWord = new Regex(@"[\s+\,\;]");
            Regex regexSeparator = new Regex(@"\w*[^?:\,[\s]+|\s+\,\;]W*?");
            string[] words = regexWord.Split(str);
            string[] separators = regexSeparator.Split(str); // при сплите [0] элемента образуется "" вместо " ", дальше все нормально
            StringBuilder strPlusSymbol = new StringBuilder();
            char symb = '$';
            int wl = words.Length;
            int sl = separators.Length;
            for (int i = 0, j = 1; i < wl; i++) // при сплите [0] элемента образуется "" вместо " ", дальше все нормально, поэтому j=1
            {
                if (j < sl)
                    strPlusSymbol.Append(words[i] + symb + separators[j++]);
                else
                    strPlusSymbol.Append(words[i] + symb);
            }
            Console.WriteLine("\nInsert character $:");
            Console.WriteLine(strPlusSymbol);
            //Сформировать массив строк String из предложений текста, в которых все слова состоят не больше чем из пяти символов.
            Regex regexLine = new Regex(@"\s[\w*[\s\,\;]*\w{6,}]*[\w{6,}[\s\,\;]*\w*]*(?=[!.])[!.]");  
            string[] line = regexLine.Split(str);
            Console.WriteLine("\n\nSentences of text in which all words consist of no more than five characters:");
            foreach (string s in line)
            {
                if(s!="")
                    Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
