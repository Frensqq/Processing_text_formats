using ProcessingTextFormats;

namespace Tests;

[TestFixture]
public class SimpleJsonTest
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Test]
    public void CanWriteAndReadJsonFile()
    {
        
        JsonMethods<Person> method = new JsonMethods<Person>();
        var testFile = "test.json";

        var peopleToWrite = new List<Person>
            {
                new Person { Name = "Иван", Age = 30 },
                new Person { Name = "Мария", Age = 25 }
            };

        //ЗАПИСЬ
        method.WriteFile(peopleToWrite, testFile);

        //ЧТЕНИЕ
        var peopleRead = method.ReadFile(testFile);

        //ПРОВЕРКА
        Assert.That(peopleRead.Count, Is.EqualTo(2));
        Assert.That(peopleRead[0].Name, Is.EqualTo("Иван"));
        Assert.That(peopleRead[0].Age, Is.EqualTo(30));
        Assert.That(peopleRead[1].Name, Is.EqualTo("Мария"));
        Assert.That(peopleRead[1].Age, Is.EqualTo(25));

        //УДАЛЕНИЕ
        if (File.Exists(testFile))
            File.Delete(testFile);
    }

    [Test]
    public void CanWriteAndReadXmlFile()
    {

        XmlMethods<Person> method = new XmlMethods<Person>();
        var testFile = "test.xml";

        var peopleToWrite = new List<Person>
            {
                new Person { Name = "Иван", Age = 30 },
                new Person { Name = "Мария", Age = 25 }
            };

        //ЗАПИСЬ
        method.WriteFile(peopleToWrite, testFile);

        //ЧТЕНИЕ
        var peopleRead = method.ReadFile(testFile);

        //ПРОВЕРКА
        Assert.That(peopleRead.Count, Is.EqualTo(2));
        Assert.That(peopleRead[0].Name, Is.EqualTo("Иван"));
        Assert.That(peopleRead[0].Age, Is.EqualTo(30));
        Assert.That(peopleRead[1].Name, Is.EqualTo("Мария"));
        Assert.That(peopleRead[1].Age, Is.EqualTo(25));

        //УДАЛЕНИЕ
        //if (File.Exists(testFile))
        //    File.Delete(testFile);
    }
}
