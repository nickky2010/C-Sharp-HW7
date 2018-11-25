using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW7_5.Extend;

namespace HW7_5
{
    class Menu
    {
        //Вертикальное меню
        private string[] menu;
        private Hospital[] hospital;
        private Table[] table;
        private bool isRun = true;
        private int current;
        private int last;

        public Menu(string[] menu, Hospital[] hospital, Table[] table)
        {
            this.menu = new string[menu.Length+1];
            for (int i = 0; i < menu.Length; i++)
            {
                this.menu[i] = menu[i];
            }
            this.menu[menu.Length] = "Выход";
            this.hospital = hospital;
            this.table = table;
            isRun = true;
            current = 0;
            last = 0;
        }
        public void Show ()
        {
            while (isRun)
            {
                //вывод меню
                BaseColor();
                Console.Clear();
                Console.CursorVisible = false;
                for (int i = 0; i < menu.Length; i++)
                {
                    ShowMenuItem(i, menu[i]);
                }
                // выбор пункта меню
                bool isNoEnter = true;
                while (isNoEnter)
                {
                    BaseColor();
                    ShowMenuItem(last, menu[last]);
                    LightColor();
                    ShowMenuItem(current, menu[current]);
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                        isNoEnter = false;
                    else
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        last = current;
                        current = (current == menu.Length - 1) ? 0 : current + 1;
                    }
                    else
                            if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        last = current;
                        current = (current == 0) ? menu.Length - 1 : current - 1;
                    }
                }// конец тела цикла while (isNoEnter)

                // действие в соответствии с выбором пользователя
                switch (current)
                {
                    case 0:
                    case 1:
                    case 2:
                        {
                            RealiseFunction(current);
                            break;
                        }
                    case 3:
                        {
                            isRun = false;
                            break;
                        }
                }
            }// конец цикла while (isRun)
        }
        private void RealiseFunction(int numberMenu)
        {
            BaseColor();
            Console.Clear();
            Console.WriteLine("Клавиша:");
            Console.WriteLine("\tEnd – вывод фамилии, даты поступления и года рождения");
            Console.WriteLine("\tHome - вывод фамилии и возраста");
            Console.WriteLine("\tЛюбая другая - вывод фамилии, продолжительности пребывания в больнице и возраста");
            ConsoleKeyInfo k = Console.ReadKey();
            Console.Clear();
            if (k.Key == ConsoleKey.Home)
            {
                Console.SetCursorPosition(0, 0);
                ((TableHome)table[1]).Print((Diagnoz)numberMenu, hospital);
            }
            else if (k.Key == ConsoleKey.End)
            {
                Console.SetCursorPosition(0, 0);
                ((TableEnd)table[2]).Print((Diagnoz)numberMenu, hospital);
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                ((TableOrdinary)table[0]).Print((Diagnoz)numberMenu, hospital);
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }

        private static void BaseColor()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void LightColor()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        private static void ShowMenuItem(int itemIndex, string item)
        {
            Console.SetCursorPosition(25, 8 + itemIndex);
            Console.WriteLine(item);
        }
    }
}
