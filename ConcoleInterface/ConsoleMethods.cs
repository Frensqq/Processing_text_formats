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

            List<SportTeam> sortedList = new List<SportTeam>();

            switch (sortDirection)
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

        public void SearchMethods(List<SportTeam> sportTeams, int parametr)
        {
            if (parametr == -1)
            {
                Console.WriteLine("Параметр поиска не определен");
                return ;
            }
            if (sportTeams == null || sportTeams.Count == 0)
            {
                Console.WriteLine("Нет данных для поиска");
                return ;
            }

            


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
                    SearchMethods(sportTeams, menuMethods.SortMenu());
                    return sportTeams;
                case 6:

                    return sportTeams;
                case 7:

                    return sportTeams;
                case 8:

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
