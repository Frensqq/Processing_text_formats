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

        public void OutputSportTeam(List<SportTeam> sportTeams)
        {
            sportTeams.ForEach(sportTeam =>
            {
                Console.WriteLine(sportTeam.ToString());
            });
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

                    return sportTeams;
                case 5:

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
            MenuMethods menuMethods = new MenuMethods();
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
