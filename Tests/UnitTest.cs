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
    [Test]
    public void WriteToFile()
    {
        foreach (var item in _fileFormat)
        {
            string filePath = _filePath + item;

            _fileMethod.WriteFile(_sportTems, filePath);
            Assert.That(File.Exists(filePath), Is.True);

            //проверка то что в файл был записана информация
            var readData = _fileMethod.ReadFile(filePath);
            Assert.That(readData, Is.Not.Null);
            Assert.That(readData.Count, Is.EqualTo(3));
        }
    }


    ////Тест функции чтения в файл
    [Test]
    public void ReadFromFile()
    {
        foreach (var item in _fileFormat)
        {
            string filePath = _filePath + item;

            _fileMethod.WriteFile(_sportTems, filePath);

            var readData = _fileMethod.ReadFile(filePath);

            Assert.That(readData, Is.Not.Null);
            Assert.That(readData.Count, Is.EqualTo(3));
            Assert.That(readData[0].name, Is.EqualTo("Иван"));
            Assert.That(readData[0].secondname, Is.EqualTo("Иванов"));
            Assert.That(readData[0].age, Is.EqualTo(25));
        }
    }
}