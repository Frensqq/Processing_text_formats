using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleInterface
{
   
    public class ConsoleMethods()
    {




        public void StartMethods(int task)
        {


            switch (task)
            {
                case 1:

                    break;
                case 2:


                    break;
                case 3:

                    break;
                case 4:

                    break;
                default:
                    Console.WriteLine("Error add type file");
                    break;

            }

        }


        public string createFullFileName()
        {
            InputsMetods inputsMetods = new InputsMetods();
            MenuMethods menuMethods = new MenuMethods();
            string fileName = inputsMetods.addFileName();
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
