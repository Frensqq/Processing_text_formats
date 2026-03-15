using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static ProcessingTextFormats.Models;

namespace ConcoleInterface
{
    public class InputsMetods
    {
        static public string inputSerachString()
        {
            Trace.WriteLine($"inputSerachString  (Ввод поискового запроса) - Ввод запущен");
            Console.Write("Введите строку для поиска: ");
            string searchString = Console.ReadLine();
            Trace.WriteLine($"inputSerachString  (Ввод поискового запроса) - Данные введены {searchString}");
            return searchString;
        }

        static public int inputIndex()
        {
            Trace.WriteLine($"inputIndex  (Ввод индекса) - Ввод запущен");
            Console.Write("Введите номер записи (от 1): ");
            int index = 1;
            try
            {
                index = Convert.ToInt32(Console.ReadLine());
                Trace.WriteLine($"inputIndex  (Ввод индекса) - Данные введены {index}");
                return index;
            }
            catch
            {
                Trace.WriteLine($"inputIndex  (Ввод индекса) - Ошибка ввода - Не поддерживаемый тип данных - index = 1 возвращен по умолчанию");
                Console.WriteLine("\nОшибка ввода! Выбрана 1-ая запись\n");
                return index;
            }
        }


        static public SportTeam createSportTeam(int index)
        {

            Trace.WriteLine($"createSportTeam  (Создание записи SportTeam) - Начало создания - Ввод данных");
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = 18;
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
                Trace.WriteLine($"createSportTeam  (Создание записи SportTeam) - Ввода возвраста - Успешно");
            }
            catch
            {
                Trace.WriteLine($"createSportTeam  (Создание записи SportTeam) - Ошибка ввода возвраста - Неподдерживаемый тип данных");
            }
            
            Console.Write("Введите спортивную команду: ");
            string typeSport = Console.ReadLine();


            List<string> achivments = new List<string>();
            while (true)
            {
                
                Console.Write("Введите достижение или 0 для продолжения: ");
                string achivment = Console.ReadLine();

                if (achivment == "0" || achivment == "exit" || achivment == "q")
                {
                    Trace.WriteLine($"createSportTeam  (Создание записи SportTeam) - Запись - Завершения ввода достижений");
                    break;
                }
                else
                {
                    Trace.WriteLine($"createSportTeam  (Создание записи SportTeam) - Запись - Добавления достижений");
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
            Trace.WriteLine($"createSportTeam  (Создание записи SportTeam) - Запись создана");
            return newSportTeam;
        }

        public string addFileName()
        {
            Trace.WriteLine($"addFileName  (Создание имени файла) - Начало Ввода ");
            Console.WriteLine("Введите путь создания с именем файла на конце.");
            Console.Write("Ввод:");
            string fileName = Console.ReadLine();
            Trace.WriteLine($"addFileName  (Создание имени файла) - Успешно  ");
            return fileName;
        }
        public string addType(string fileName, int TypeFile)
        {
            string file = fileName;
            Trace.WriteLine($"addType  (Добавление типа файла) ");

            switch (TypeFile)
            {
                case 1:                   
                    file = file + ".json";
                    Console.WriteLine(file);
                    Trace.WriteLine($"addType  (Добавление типа файла) - добавлено json = {file} - Успешно");
                    break;
                case 2:
                    file = file + ".xml";
                    Console.WriteLine(file);
                    Trace.WriteLine($"addType  (Добавление типа файла) - добавлено xml = {file} - Успешно");
                    break;
                case 3:
                    file = file + ".csv";
                    Console.WriteLine(file);
                    Trace.WriteLine($"addType  (Добавление типа файла) - добавлено csv = {file} - Успешно");
                    break;
                case 4:
                    file = file + ".yaml";
                    Console.WriteLine(file);
                    Trace.WriteLine($"addType  (Добавление типа файла) - добавлено yaml = {file} - Успешно");
                    break;
                default:
                    Trace.WriteLine($"addType  (Добавление типа файла) - Ошибка тип файла соответсвующий значению = {TypeFile} не существует");
                    Console.WriteLine("Error add type file");
                    break;

            }
            return file;
        }
    }
}
