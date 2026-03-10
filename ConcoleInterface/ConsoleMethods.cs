using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            Console.Write("Ввод:");
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

        public void StartMethods(int task)
        {
            InputsMetods inputsMetods = new InputsMetods();
            switch (task)
            {
                case 1:
                    string fileName = inputsMetods.addFileName();
                    int codeType = TypeFileMenu();
                    if (codeType != 1)
                    {
                        fileName = inputsMetods.addType(fileName, codeType);
                    }

                    break;
                case 2:

                    
                    break;
                case 3:
                    
                    break;
                case 4:

                    break;
                default:
                    Console.WriteLine("Error add type file");
                    break;

            }
        }

        public int TypeFileMenu()
        {
            Console.WriteLine("Выберите расширение файла");
            Console.WriteLine("1) Json // 2) XML // 3) CSV // 4) Yaml");
            Console.Write("Ввод: ");
            int type = Convert.ToInt16(Console.ReadLine());

            if (type < 1 || type > 4)
            {
                Console.WriteLine($"Раширение под значением {type} несуществует!\nВведите число от 1 до 4!");
                return -1;
            }
            else
            {
                return type;
            }
        }
        
    } 

    public class InputsMetods
    {
        public string addFileName()
        {
            Console.WriteLine("Введите путь создания с именем файла на конце.");
            Console.Write("Ввод:");
            string fileName = Console.ReadLine();
            return fileName;
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
