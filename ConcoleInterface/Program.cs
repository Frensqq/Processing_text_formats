using ConcoleInterface;
using ProcessingTextFormats;
using System.ComponentModel.Design;

ConsoleMethods consoleMethods = new ConsoleMethods();
MenuMethods menuMethods = new MenuMethods();
Models models = new Models();



string firtFileName = "";
while (true)
{
    Console.WriteLine("Ввод файла для первого считывания данных");
    firtFileName = consoleMethods.createFullFileName();
    if( firtFileName != "")
    {

        break;
    }
    else
    {
        Console.WriteLine("Не удалось получит доступ к файлу");
    }
}



while (true)
{
    int menu = menuMethods.Menu();

    if (menu == 0) break;
    else if (menu == -1) continue;
    else consoleMethods.StartMethods(menu);

}