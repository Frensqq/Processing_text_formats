using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleInterface
{
    
    public class ConsoleMethods()
    {

        public int Menu()
        {
            Console.WriteLine("Список доступных действий:");
            Console.WriteLine("1) Запись данных в файл // 2) Импорт данных из файла // 3) Сортировка // 4) Поиск // 0) Выход");
            int menu = Convert.ToInt16(Console.ReadLine());

            if (menu < 0 || menu > 4)
            {
                Console.WriteLine($"Дествия под значением {menu} несуществует!\nВведите число от 0 до 4!");
                return -1;
            }
            else { 
                return menu;
            }
        }

        public string addType(string fileName, int TypeFile)
        {
            string file = fileName;

            switch (TypeFile)
            {
                case 0:
                    Console.WriteLine("\nadd .json");
                    file = file + ".json";
                    break;
                case 1:
                    Console.WriteLine("\nadd .xml");
                    file = file + ".xml";
                    break;
                case 2:
                    Console.WriteLine("\nadd .csv");
                    file = file + ".csv";
                    break;
                case 3:
                    Console.WriteLine("\nadd .yaml");
                    file = file + ".yaml";
                    break;
                default:
                    Console.WriteLine("Error add type file");
                    break;
                   
            }
            return file;
        }
    }
}
