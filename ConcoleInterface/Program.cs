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
        Models models = new Models();

        sportTeams = fileMethods.ConvertFileToSportTeam(consoleMethods);

        while (true)
        {
            int menu = menuMethods.Menu();

            if (menu == 0) {
                Trace.WriteLine($"Main - Программа, выход");
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