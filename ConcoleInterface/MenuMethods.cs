using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleInterface
{
    public class MenuMethods()//Различные меню программ (То где осуществляется выбор)
    {
        public int Menu()
        {
            Console.WriteLine("\n----------------------Меню----------------------\n");
            Console.WriteLine("Список доступных действий:");
            Console.WriteLine("1) Запись данных в файл \n2) Считывание данных из файла \n3) Вывод данных на экран \n4) Сортировка \n5) Поиск \n6) Добавить данные с труктуру\n7) Удаление данных из структуры\n8) Изменение данных из структуры \n0) Выход");
            Console.Write("\nВвод:");
            int menu = 0;
            try
            {
                menu = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("\n------------------------------------------------\n");
            }
            catch
            {
                Console.WriteLine($"Ошибка ввода данных");
                Console.WriteLine("\n------------------------------------------------\n");
                return -1;
            }
            if (menu < 0 || menu > 8)
            {
                Console.WriteLine($"Дествия под значением {menu} несуществует!\nВведите число от 0 до 4!");
                return -1;
            }
            else
            {
                return menu;
            }

        }

        public int TypeFileMenu()
        {
            Console.WriteLine("Выберите расширение файла");
            Console.WriteLine("1) Json // 2) XML // 3) CSV // 4) Yaml");
            Console.Write("Ввод: ");
            int type = -1;
            try
            {
                type = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine($"Ошибка ввода данных!\nВведите число");
                return -1;
            }

            if (type < 1 || type > 4)
            {
                Console.WriteLine($"Раширение под значением {type} несуществует!");
                return -1;
            }
            else
            {
                return type;
            }
        }
    }
}
