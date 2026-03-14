using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ProcessingTextFormats.Models;

namespace ConcoleInterface
{
   
    public class ConsoleMethods()
    {
        FileMethods fileMethods = new FileMethods();
        MenuMethods menuMethods = new MenuMethods();

        public void OutputSportTeam(List<SportTeam> sportTeams)
        {
            sportTeams.ForEach(sportTeam =>
            {
                Console.WriteLine(sportTeam.ToString());
            });
        }

        public List<SportTeam> sortMethod(List<SportTeam> sportTeams, int parametr)
        {
            if (parametr == -1)
            {
                Console.WriteLine("Параметр сортировки не определен");
                return sportTeams;
            }
            if (sportTeams == null || sportTeams.Count == 0)
            {
                Console.WriteLine("Нет данных для сортировки");
                return sportTeams;
            }

            int sortDirection = menuMethods.SortDirectionMenu();
            if (sortDirection == -1)
            {
                return sportTeams;
            }

            List<SportTeam> sortedList = new List<SportTeam>();

            switch (parametr)
            {
                case 1: 
                    if (sortDirection == 1)
                        sortedList = sportTeams.OrderBy(t => t.age).ToList();
                    else
                        sortedList = sportTeams.OrderByDescending(t => t.age).ToList();
                    Console.WriteLine("Сортировка по возрасту выполнена");
                    return sortedList;

                case 2: 
                    if (sortDirection == 1)
                        sortedList = sportTeams.OrderBy(t => t.name).ToList();
                    else
                        sortedList = sportTeams.OrderByDescending(t => t.name).ToList();
                    Console.WriteLine("Сортировка по имени выполнена");
                    return sortedList;

                case 3: 
                    if (sortDirection == 1)
                        sortedList = sportTeams.OrderBy(t => t.secondname).ToList();
                    else
                        sortedList = sportTeams.OrderByDescending(t => t.secondname).ToList();
                    Console.WriteLine("Сортировка по фамилии выполнена");
                    return sortedList;

                case 4: 
                    if (sortDirection == 1)
                        sortedList = sportTeams.OrderBy(t => t.typeSport).ToList();
                    else
                        sortedList = sportTeams.OrderByDescending(t => t.typeSport).ToList();
                    Console.WriteLine("Сортировка по типу спорта выполнена");
                    return sortedList;

                default:
                    Console.WriteLine("Неверный параметр сортировки");
                    return sportTeams;
            }
        }

        public List<SportTeam> SearchMethods(List<SportTeam> sportTeams, string stringSerach)
        {

            List<SportTeam> searchResult = new List<SportTeam>();

            foreach (SportTeam team in sportTeams) {
                if (team.name.Contains(stringSerach) || team.secondname.Contains(stringSerach) || team.typeSport.Contains(stringSerach))
                {
                    searchResult.Add(team);
                }
            }
            return searchResult;
        }

        public List<SportTeam> addSTMethods(List<SportTeam> sportTeams)
        {
            int index = sportTeams.Count();
            SportTeam sportTeam = InputsMetods.createSportTeam(index);
            sportTeams.Add(sportTeam);
            Console.WriteLine($"Добаление спортсмена {sportTeam.name} {sportTeam.secondname} - Успешно!");
            return sportTeams;
        }

        public List<SportTeam> deleteSTMethods(List<SportTeam> sportTeams, int  index)
        {
            try
            {
                sportTeams.RemoveAt(index--);
                Console.WriteLine($"Удаление записи №{index} - Успешно!");
            }
            catch {
                Console.WriteLine($"Записи №{index} - Ненадена");
            }

            return sportTeams;
        }

        public List<SportTeam> redactSTMethods(List<SportTeam> sportTeams, int index)
        {
            try
            {
                sportTeams[index] = InputsMetods.createSportTeam(index);
                Console.WriteLine($"Редактирование записи №{index} - Успешно!");
            }
            catch
            {
                Console.WriteLine($"Запись №{index} - Ненадена или редактирование неудалось");
            }
            return sportTeams;
        }

        public List<SportTeam> StartMethods(int task, List<SportTeam> sportTeams)
        {
            switch (task)
            {
                case 1:
                    return fileMethods.ConvertFileToSportTeam(this);
                    
                case 2:
                    fileMethods.ConvertSportTeamToFile(sportTeams, this);
                    return sportTeams;
                case 3:
                    OutputSportTeam(sportTeams);
                    return sportTeams;
                case 4:
                    sportTeams = sortMethod(sportTeams, menuMethods.SortMenu());
                    return sportTeams;
                case 5:
                    SearchMethods(sportTeams, "");
                    return sportTeams;
                case 6:
                    sportTeams = addSTMethods(sportTeams);
                    return sportTeams;
                case 7:
                    sportTeams = deleteSTMethods(sportTeams, InputsMetods.inputIndex());
                    return sportTeams;
                case 8:
                    sportTeams = redactSTMethods(sportTeams, InputsMetods.inputIndex());
                    return sportTeams;
                default:
                    Console.WriteLine("Error add type file");
                    return sportTeams;

            }
        }


        public string createFullFileName()
        {
            InputsMetods inputsMetods = new InputsMetods();
            
            string fileName = inputsMetods.addFileName();

            string extension = Path.GetExtension(fileName).ToLower();
            string[] validExtensions = { ".json", ".xml", ".csv", ".yaml" };

            if (validExtensions.Contains(extension))
            {
                Console.WriteLine($"Используется файл: {fileName}");
                return fileName;
            }

            int type = menuMethods.TypeFileMenu();
            if (type == -1)
            {
                return "";
            }

            fileName = inputsMetods.addType(fileName, type);
            return fileName;
        }
    } 

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
            while (true) {
                Console.Write("Введите достижение или 0 для продолжения: ");
                string achivment = Console.ReadLine();
                
                if(achivment == "0" || achivment == "exit" || achivment == "q")
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
