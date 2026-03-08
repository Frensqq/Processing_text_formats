using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using YamlDotNet.Serialization;


interface FileAction<T>
{
    List<T> ReadFile(string fileName);
    void WriteFile(List<T> data, string fileName);

}

public class JsonMethods<T>: FileAction<T> 
{
    public List<T> ReadFile(string fileName)
    {
        string dataStr = "";
        using (StreamReader reader = new StreamReader(fileName))
        {
            dataStr =  reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(dataStr);
        }
    }

    public void WriteFile(List<T> data, string fileName) { 

        string dataStr = JsonConvert.SerializeObject(data);
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.Write(dataStr);
        }
    }
}

public class XmlMethods<T> : FileAction<T>
{
    public List<T> ReadFile(string fileName)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));
        using (StreamReader reader = new StreamReader(fileName))
        {
            return (List<T>)deserializer.Deserialize(reader);
        }
    }

    public void WriteFile(List<T> data, string fileName)
    {

        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            serializer.Serialize(writer, data);
        }
    }
}


public class YamlMethods<T> : FileAction<T>
{
    public List<T> ReadFile(string fileName)
    {
        string dataStr = "";
        var deserializer = new DeserializerBuilder().Build();
        using (StreamReader reader = new StreamReader(fileName))
        {
            dataStr = reader.ReadToEnd();
            return deserializer.Deserialize<List<T>>(dataStr);
        }
    }

    public void WriteFile(List<T> data, string fileName)
    {

        var serializer = new SerializerBuilder().Build();
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            string dataStr = serializer.Serialize(data);
            writer.Write(dataStr);
        }
    }
}

public class CsvMethods<T> : FileAction<T>
{
    public List<T> ReadFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
        using (CsvReader csv = new CsvReader(reader, CultureInfo.CurrentCulture))
        {
            return csv.GetRecords<T>().ToList();
        }
    }

    public void WriteFile(List<T> data, string fileName)
    {
        var serializer = new SerializerBuilder().Build();
        using (StreamWriter writer = new StreamWriter(fileName,false, Encoding.UTF8))
        using(CsvWriter csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
        {
            csv.WriteRecords(data);
        }
    }
}

public class Metods
{
    


}
