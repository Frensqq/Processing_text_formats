using ProcessingTextFormats;
using static ProcessingTextFormats.Models;

namespace Tests;

[TestFixture]
public class SimpleConvertTest
{
    private List<SportTeam> _sportTems;
    private string _filePath = "testFile";
    private List<string> _fileFormat;
    private generalizedMethod<SportTeam> _fileMethod;

    [SetUp]
    public void SetUp()
    {
        _sportTems = new List<SportTeam>
        {
            new SportTeam(1, "Иван", "Иванов", 25, "Футбол", new List<string> { "Чемпион области", "Лучший бомбардир" }),
            new SportTeam(2, "Петр", "Петров", 30, "Баскетбол", new List<string> { "Победитель турнира" }),
            new SportTeam(3, "Сергей", "Сергеев", 22, "Плавание", new List<string>())
        };

        _fileFormat = new List<string>
        {
            ".json",
            ".xml",
            ".yaml",
            ".csv",
        };

        _fileMethod = new generalizedMethod<SportTeam>();
    }

    [TearDown]
    public void clearFile()
    {
        foreach (var item in _fileFormat)
        {
            string fileName = _filePath + item;
            if (File.Exists(fileName))
            {
                Console.WriteLine("Delete ->" + fileName);
                File.Delete(fileName);
            }
        }
    }

    ////Тест функции записи в файл
    //[Test]
    //public void WriteToFile()
    //{


    //    foreach (var item in _fileFormat)
    //    {
    //        try
    //        {

    //            string filePath = _filePath + item;
    //            File.Create(filePath);
    //            Console.WriteLine(filePath);
    //            _fileMethod.WriteFile(_sportTems, _filePath);
    //        }
    //        catch {
    //            Console.WriteLine($"Ошибка {_filePath}{item}");
    //        }
    //    }
    //}

    [Test]
    public void WriteToFile()
    {
        foreach (var item in _fileFormat)
        {
            string filePath = _filePath + item;

            // Удаляем если существует
            if (File.Exists(filePath))
                File.Delete(filePath);

            // Записываем - файл создастся автоматически
            _fileMethod.WriteFile(_sportTems, filePath);

            // Проверяем что файл создался
            Assert.That(File.Exists(filePath), Is.True);

            // Проверяем что можно прочитать
            var readData = _fileMethod.ReadFile(filePath);
            Assert.That(readData, Is.Not.Null);
            Assert.That(readData.Count, Is.EqualTo(3));
        }
    }


    [Test]
    public void ReadFromFile()
    {
        foreach (var item in _fileFormat)
        {
            string filePath = _filePath + item;

            // Сначала записываем
            _fileMethod.WriteFile(_sportTems, filePath);

            // Потом читаем
            var readData = _fileMethod.ReadFile(filePath);

            // Проверяем
            Assert.That(readData, Is.Not.Null);
            Assert.That(readData.Count, Is.EqualTo(3));
            Assert.That(readData[0].name, Is.EqualTo("Иван"));
            Assert.That(readData[1].secondname, Is.EqualTo("Петров"));
        }
    }


}
        


        
    

    

