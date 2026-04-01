using ProcessingTextFormats;
using static ProcessingTextFormats.Models;
using ConcoleInterface;

namespace Tests;

[TestFixture]
public class SimpleConvertTest
{
    private List<SportTeam> _sportTeams;
    private string _filePath = "testFile";
    private List<string> _fileFormat;
    private generalizedMethod<SportTeam> _fileMethod;
    private ConsoleMethods _consoleMethods;

    [SetUp]
    public void SetUp()
    {
        _sportTeams = new List<SportTeam>
        {
            new SportTeam(1, "Иван", "Иванов", 25, "Футбол", new List<string> { "Чемпион области", "Лучший бомбардир" }),
            new SportTeam(2, "Петр", "Петров", 30, "Баскетбол", new List<string> { "Победитель турнира" }),
            new SportTeam(3, "Сергей", "Сергеев", 22, "Плавание", new List<string>()),
            new SportTeam(4, "Иван", "Петров", 28, "Футбол", new List<string>())


        };

        _fileFormat = new List<string>
        {
            ".json",
            ".xml",
            ".yaml",
            ".csv",
        };

        _fileMethod = new generalizedMethod<SportTeam>();
        _consoleMethods = new ConsoleMethods();
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

    //Тест функции записи в файл
    [Test]
    public void WriteToFile_Json_CSV_XML_YAML()
    {
        foreach (var item in _fileFormat)
        {
            string filePath = _filePath + item;

            _fileMethod.WriteFile(_sportTeams, filePath);
            Assert.That(File.Exists(filePath), Is.True);

            //проверка то что в файл был записана информация
            var readData = _fileMethod.ReadFile(filePath);
            Assert.That(readData, Is.Not.Null);
            Assert.That(readData.Count, Is.EqualTo(4));
        }
    }


    //Тест функции чтения в файл
    [Test]
    public void ReadFromFile_Json_CSV_XML_YAML()
    {
        foreach (var item in _fileFormat)
        {
            string filePath = _filePath + item;

            _fileMethod.WriteFile(_sportTeams, filePath);

            var readData = _fileMethod.ReadFile(filePath);

            Assert.That(readData, Is.Not.Null);
            Assert.That(readData.Count, Is.EqualTo(4));
            Assert.That(readData[0].name, Is.EqualTo("Иван"));
            Assert.That(readData[0].secondname, Is.EqualTo("Иванов"));
            Assert.That(readData[0].age, Is.EqualTo(25));
        }
    }


    [Test]
    public void SearchMethods_FindByName()
    {
        var result = _consoleMethods.SearchMethods(_sportTeams, "Иван");
        Assert.That(result.Count, Is.EqualTo(2));
    }

    // Поиск по фамилии
    [Test]
    public void SearchMethods_FindBySecondName()
    {
        var result = _consoleMethods.SearchMethods(_sportTeams, "Петров");
        Assert.That(result.Count, Is.EqualTo(2));
    }

    // Поиск по типу спорта
    [Test]
    public void SearchMethods_FindByTypeSport()
    {
        var result = _consoleMethods.SearchMethods(_sportTeams, "Футбол");
        Assert.That(result.Count, Is.EqualTo(2));
    }

    // Поиск частичного совпадения
    [Test]
    public void SearchMethods_PartialMatch()
    {
        var result = _consoleMethods.SearchMethods(_sportTeams, "Пет");
        Assert.That(result.Count, Is.EqualTo(2)); 
    }

    // Поиск без результатов
    [Test]
    public void SearchMethods_NoMatches()
    {
        var result = _consoleMethods.SearchMethods(_sportTeams, "Сидоров");
        Assert.That(result.Count, Is.EqualTo(0));
    }

    //: Вывод данных (OutputSportTeam)
    [Test]
    public void OutputSportTeam()
    {
        Assert.DoesNotThrow(() => _consoleMethods.OutputSportTeam(_sportTeams));
    }

    // Удаление спортсмена
    [Test]
    public void DeleteSportsmen()
    {
        int initialCount = _sportTeams.Count;
        var result = _consoleMethods.deleteSTMethods(_sportTeams, 1);

        Assert.That(result.Count, Is.EqualTo(initialCount - 1));
    }

    // Удаление спортсмена с неверным индексом
    [Test]
    public void DeleteSportsmen_NoCorrectIndex()
    {
        int initialCount = _sportTeams.Count;
        var result = _consoleMethods.deleteSTMethods(_sportTeams, 99);

        Assert.That(result.Count, Is.EqualTo(initialCount));
    }
}