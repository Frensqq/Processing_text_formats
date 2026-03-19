using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
                Console.WriteLine("Ввод файла для считывания данных");
                fileName = consoleMethods.createFullFileName();
                if (fileName != "")
                {
                    try
                    {
                        sportTeams = fileSportTeams.ReadFile(fileName);
                        Trace.WriteLine($"ConvertFileToSportTeam - Считывание файла {fileName} - Успешно");
                        break;
                    }
                    catch
                    {
                        Trace.WriteLine($"ConvertFileToSportTeam - Считывание файла {fileName} - Ошибка! Не удалось считать файл");
                        Console.WriteLine("Не удалось получит доступ к файлу");
                    }
                }
                else
                {
                    Trace.WriteLine($"ConvertFileToSportTeam - Считывание файла {fileName} - Ошибка! Путь пуст");
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
                        Trace.WriteLine($"ConvertSportTeamToFile - Запись в файл {fileName} - Успешно");
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Не удалось получит доступ к файлу");
                        Trace.WriteLine($"ConvertSportTeamToFile - Запись в файл {fileName} - Ошибка! Не удалось считать файл");
                    }
                }
                else
                {
                    Console.WriteLine("Имя или путь файла не корректно");
                    Trace.WriteLine($"ConvertSportTeamToFile - Запись в файл {fileName} - Ошибка! Путь к файлу пуст");
                }
            }
        }
    }
}
