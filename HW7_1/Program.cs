//                                                      Задание 1.
//  Определить сколько раз самое длинное слово встретилось в тексте.
//  Сформировать новую строку типа StringBuilder из слов, заключенных в скобки.
//  Разделителями слов считать пробел, точку, запятую или символ конца строки.
//  Исходную строку не вводить, а задавать в виде константы.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = "EPAM was ranked as a Top 25 Enterprise Company in IDC’s Financial Insights FinTech Rankings. " +
                    "This prestigious ranking recognizes the top global enterprise providers of financial technology serving multiple " +
                    "industries that derive less than one-third of their revenues from financial institutions.";
                Regex regex = new Regex(@"(?:\.[\s+]+|[,.+\s+])");
                string[] sentence = regex.Split(input);
                int maxWordLenght = sentence[0].Length;             // количество букв в максимально длинном слове
                int indexMaxWordLenght = 0;                         // индекс по которому расположено максимально длинное слово в массиве
                int countMaxWordLenght = 1;                         // счетчик сколько раз самое длинное слово встретилось в тексте
                int countEqualWord = 0;                             // счетчик количества слов равнозначных по длине самому длинному слову
                StringBuilder wordsInBracked = new StringBuilder();
                char lb = '(';
                char rb = ')';
                wordsInBracked.Append(lb + sentence[0] + rb);
                for (int i = 1; i < sentence.Length - 1; i++)
                {
                    wordsInBracked.Append(lb + sentence[i] + rb);
                    if (maxWordLenght < sentence[i].Length)
                    {
                        maxWordLenght = sentence[i].Length;
                        indexMaxWordLenght = i;
                        countMaxWordLenght = 0;
                        countEqualWord = 0;
                    }
                    else if (maxWordLenght == sentence[i].Length)
                    {
                        if (sentence[i] == sentence[indexMaxWordLenght])
                            countMaxWordLenght++;
                        else
                            countEqualWord++;
                    }
                }
                Console.WriteLine(wordsInBracked);
                Console.WriteLine("\nThe longest word: " + sentence[indexMaxWordLenght]);
                Console.WriteLine("The longest word met in the text = " + countMaxWordLenght);
                Console.WriteLine("Words equivalent in length to the longest word = " + countEqualWord);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
