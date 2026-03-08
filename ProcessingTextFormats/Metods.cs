using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


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
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        using (StreamReader reader = new StreamReader(fileName))
        {
            return (List<T>)serializer.Deserialize(reader);
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


public class Metods
{
    


}
