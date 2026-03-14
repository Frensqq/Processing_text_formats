using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProcessingTextFormats.Models;

namespace ConcoleInterface
{

    public class FileMethods()
    {
        generalizedMethod<SportTeam> fileSportTeams = new generalizedMethod<SportTeam>();
        private static List<SportTeam> sportTeams = new();

        public List<SportTeam> ConvertFileToSportTeam(ConsoleMethods consoleMethods)
        {
             
            string fileName = "";
            while (true)
            {
                Console.WriteLine("Ввод файла для первого считывания данных");
                fileName = consoleMethods.createFullFileName();
                if (fileName != "")
                {
                    try
                    {
                        sportTeams = fileSportTeams.ReadFile(fileName);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Не удалось получит доступ к файлу");
                    }
                }
                else
                {
                    Console.WriteLine("Не удалось получит доступ к файлу");
                }
            }
            return sportTeams;

        }

        public void ConvertSportTeamToFile(List<SportTeam> sportTeams, ConsoleMethods consoleMethods)
        {

            string fileName = "";
            while (true)
            {
                Console.WriteLine("Ввод файла записи");
                fileName = consoleMethods.createFullFileName();
                if (fileName != "")
                {
                    try
                    {
                        fileSportTeams.WriteFile(sportTeams, fileName);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Не удалось получит доступ к файлу");
                    }
                }
                else
                {
                    Console.WriteLine("Имя или путь файла не корректно");
                }
            }
        }
    }
}
