using ConcoleInterface;
using ProcessingTextFormats;
using System.ComponentModel.Design;
using static ProcessingTextFormats.Models;

class Program
{
    private static List<SportTeam> sportTeams = new();

    static void Main()
    {
        ConsoleMethods consoleMethods = new ConsoleMethods();
        MenuMethods menuMethods = new MenuMethods();
        FileMethods fileMethods = new FileMethods();
        Models models = new Models();

        sportTeams = fileMethods.ConvertFileToSportTeam(consoleMethods);

        while (true)
        {
            int menu = menuMethods.Menu();

            if (menu == 0) break;
            else if (menu == -1) continue;
            else sportTeams = consoleMethods.StartMethods(menu,  sportTeams);
        }
    }
}