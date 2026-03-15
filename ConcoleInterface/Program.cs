using ConcoleInterface;
using ProcessingTextFormats;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using static ProcessingTextFormats.Models;

class Program
{
    private static List<SportTeam> sportTeams = new();
    

    static void Main()
    {
        Trace.WriteLine($"Main - Программа запущена");
        ConsoleMethods consoleMethods = new ConsoleMethods();
        MenuMethods menuMethods = new MenuMethods();
        FileMethods fileMethods = new FileMethods();
        generalizedMethod<SportTeam> fileSportTeams = new generalizedMethod<SportTeam>();
        Models models = new Models();

        sportTeams = fileSportTeams.ReadFile("ProgramData.json");

        while (true)
        {
            int menu = menuMethods.Menu();

            if (menu == 0) {
                Trace.WriteLine($"Main - Программа, выход");
                Console.WriteLine("Сохранить результат в памяти программы?\nДа -- Введите 1,\nНет -- Введите любой символ");
                Console.Write("Ввод: ");
                string save = Console.ReadLine();
                if (save == "1" || save == "Y" || save == "Yes" || save == "Да" || save == "Д")
                {
                    Console.Write("Данные были сохранены и будут считаны при следующем запуске!");
                    Trace.WriteLine($"Main - Программа, выход - Данные сохранены");
                    fileSportTeams.WriteFile(sportTeams, "ProgramData.json");
                }
                break;
            }
            else if (menu > 0 && menu < 9)
            {
                Trace.WriteLine($"Main - Программа, запуск метода № {menu}");
                sportTeams = consoleMethods.StartMethods(menu, sportTeams); 
            }
            else
            {
                Trace.WriteLine($"Main - Программа, Ошибка! - Возващено значение не соотиветсвующее не одному из методов");
                continue;
            }
        }
    }
}