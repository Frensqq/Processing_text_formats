using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleInterface
{
    public class MenuMethods()//Различные меню программ (То где осуществляется выбор)
{
        public int Menu()
        {
            Console.WriteLine("\n----------------------Меню----------------------\n");
            Console.WriteLine("Список доступных действий:");
            Console.WriteLine("1) Считывание данных из файла \n2) Запись данных в файл  \n3) Вывод данных на экран \n4) Сортировка \n5) Поиск \n6) Добавить данные с труктуру\n7) Удаление данных из структуры\n8) Изменение данных из структуры \n0) Выход");
            Console.Write("\nВвод:");
            int menu = 0;
            try
            {
                Trace.WriteLine($"MainMenu - попытка ввыбора действия - {menu} ");
                menu = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("\n------------------------------------------------\n");
            }
            catch
            {
                Console.WriteLine("Ошибка ввода данных");
                Trace.WriteLine("MainMenu - Ошибка ввода данных - не поддерживаемый тип данных");
                Console.WriteLine("\n------------------------------------------------\n");
                return -1;
            }
            if (menu < 0 || menu > 8)
            {
                Trace.WriteLine($"MainMenu - Выбранное пользователем действие - {menu} несуществует");
                Console.WriteLine($"Дествия под значением {menu} несуществует!\nВведите число от 0 до 4!");
                return -1;
            }
            else
            {
                Trace.WriteLine($"MainMenu - выбранно действие - {menu} ");
                return menu;
            }

        }

        public int TypeFileMenu()
        {
            Console.WriteLine("Выберите расширение файла");
            Console.WriteLine("1) Json // 2) XML // 3) CSV // 4) Yaml");
            Console.Write("Ввод: ");
            int type = -1;
            try
            {
                Trace.WriteLine($"TypeFileMenu - попытка ввыбора типа файла - {type} ");
                type = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Trace.WriteLine($"TypeFileMenu (Выбор типа файлов) - Ошибка ввода данных - не поддерживаемый тип данных");
                Console.WriteLine($"Ошибка ввода данных!\n");
                return -1;
            }

            if (type < 1 || type > 4)
            {
                Trace.WriteLine($"TypeFileMenu (Выбор типа файлов) - Действия №{type} не существует - выбранного действия не существует");
                Console.WriteLine($"Раширение под значением {type} несуществует!");
                return -1;
            }
            else
            {
                Trace.WriteLine($"TypeFileMenu (Выбор типа файлов) - Действиe №{type} выбрано");
                return type;
            }
        }

        public int SortMenu()
        {
            Console.WriteLine("Выберите поле по которому выполниться дейстиве");
            Console.WriteLine("1) Age // 2) Name // 3) Surname // 4) typeSport");
            Console.Write("Ввод: ");
            int parametr = -1;
            try
            {
                Trace.WriteLine($"SortMenu (Меню сортировки) - попытка ввыбора поля сортировки - {parametr} ");
                parametr = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Trace.WriteLine($"SortMenu (Меню сортировки) - Ошибка ввода данных - Введенный тип данных не поддерживается");
                Console.WriteLine($"Ошибка ввода данных!\nВведите число");
                return -1;
            }

            if (parametr < 1 || parametr > 4)
            {
                Trace.WriteLine($"SortMenu (Меню сортировки) - Ошибка ввода данных - Введенное действие №{parametr} не существует");
                Console.WriteLine($"Поле {parametr} несуществует!");
                return -1;
            }
            else
            {
                Trace.WriteLine($"SortMenu (Меню сортировки) - Поле сортировки выбрано - Введенное действие №{parametr}");
                return parametr;
            }
        }

        public int SortDirectionMenu() {

            Console.WriteLine("Выберите направление сортировки");
            Console.WriteLine("1) По возврастанию // 2) По убыванию");
            Console.Write("Ввод: ");
            int parametr = -1;
            try
            {
                Trace.WriteLine($"SortDirectionMenu (Выбор направления сортировки) - попытка ввыбора направления сортировки - {parametr} ");
                parametr = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Trace.WriteLine($"SortDirectionMenu  (Выбор направления сортировки) - Ошибка ввода данных - Введенный тип данных не поддерживается");
                Console.WriteLine($"Ошибка ввода данных!\nВведите число");
                return -1;
            }

            if (parametr < 1 || parametr > 2)
            {
                Trace.WriteLine($"SortDirectionMenu  (Выбор направления сортировки) - Ошибка ввода данных - Введенное действие №{parametr} не существует");
                Console.WriteLine($"Поле {parametr} несуществует!");
                return -1;
            }
            else
            {
                Trace.WriteLine($"SortDirectionMenu  (Выбор направления сортировки) - Направление сортировки выбрано - Введенное действие №{parametr}");
                return parametr;
            }
        }
    }
}
