//Задание 3.
//Определить количество предложений, содержащих даты в формате дд/мм/гггг или дд.мм.гггг 
//и адреса электронной почты.Заменить в исходной строке в каждой дате год из четырех цифр на год из двух цифр.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HW7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // dd/mm/yyyy или dd.mm.yyyy
            string input = @"Вася прислал Маше 12.03.2018 года письмо по адресу masha3@mail.ru с шифром ы12/04/201890.!!! 
Маша была рада.... Она 31/12/2018 ждет Васю в гости по адресу wa_s.d2@yandex.ru.com. 
Он надеется, что он приедет!!! Это мечта под номером 45.06.2000";
            string datePattern = @"(0[1-9]|[12][0-9]|3[01])([- /.])(0[1-9]|1[012])([- /.])(\d)(\d)(\d)(\d)";
            string emailPattern = @"\b\w+_?\w*\.?\w+@(\w{1,7}\.){1,3}[a-z]{2,3}\b";
            string sentencePattern = @"[.!?]+\s*";
            Regex sentenceRegex = new Regex(sentencePattern);
            Regex dateRegex = new Regex(datePattern);
            Regex emailRegex = new Regex(emailPattern);
            string[] sentences = sentenceRegex.Split(input);
            int countDate = 0;
            int countEmail = 0;
            Console.WriteLine("Исходная строка: ");
            Console.WriteLine("================");
            foreach (string s in sentences)
            {
                // if (dateRegex.IsMatch(s)) // если правильное регулярное выражение
                if (IsHasDate(s, dateRegex) )
                    countDate++;
                if (emailRegex.IsMatch(s))
                    countEmail++;
                Console.WriteLine(s);
            }
            Console.WriteLine("\nКоличество предложений с датами = " + countDate);
            Console.WriteLine("Количество предложений с email = " + countEmail);
            // замена 
            Console.WriteLine("\nЗамена в исходной строке в каждой дате год из четырех цифр на год из двух цифр: ");
            Console.WriteLine("=================================================================================");
            string output = dateRegex.Replace(input, @"$1$2$3$4$7$8");
            Console.WriteLine(output);
            Console.ReadKey();
        }
        // метод для проверки есть ли в строке правильная дата
        static bool IsHasDate(string sent, Regex r)
        {
            MatchCollection ms = r.Matches(sent);  // выбираем все подстроки соответствующие паттерну
            foreach (Match item in ms)
            {
                try
                {
                    Convert.ToDateTime(item.Value);
                    return true;
                }
                catch 
                {
                }
            }
            return false;
        }
    }
}
