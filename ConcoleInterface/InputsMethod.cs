using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProcessingTextFormats.Models;

namespace ConcoleInterface
{
    public class InputsMetods
    {
        static public string inputSerachString()
        {
            Console.Write("Введите строку для поиска: ");
            string searchString = Console.ReadLine();
            return searchString;
        }

        static public int inputIndex()
        {
            Console.Write("Введите номер записи (от 1): ");
            int index = 1;
            try
            {
                index = Convert.ToInt32(Console.ReadLine());
                return index;
            }
            catch
            {
                Console.WriteLine("\nОшибка ввода! Выбрана 1-ая запись\n");
                return index;
            }
        }


        static public SportTeam createSportTeam(int index)
        {

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите спортивную команду: ");
            string typeSport = Console.ReadLine();


            List<string> achivments = new List<string>();
            while (true)
            {
                Console.Write("Введите достижение или 0 для продолжения: ");
                string achivment = Console.ReadLine();

                if (achivment == "0" || achivment == "exit" || achivment == "q")
                {
                    break;
                }
                else
                {
                    achivments.Add(achivment);
                }
            }

            SportTeam newSportTeam = new SportTeam(
               index,
               name,
               surname,
               age,
               typeSport,
               achivments
            );

            return newSportTeam;
        }

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
                case 1:
                    file = file + ".json";
                    Console.WriteLine(file);
                    break;
                case 2:
                    file = file + ".xml";
                    Console.WriteLine(file);
                    break;
                case 3:
                    file = file + ".csv";
                    Console.WriteLine(file);
                    break;
                case 4:
                    file = file + ".yaml";
                    Console.WriteLine(file);
                    break;
                default:
                    Console.WriteLine("Error add type file");
                    break;

            }
            return file;
        }
    }
}
