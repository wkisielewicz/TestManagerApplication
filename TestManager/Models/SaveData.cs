using System.IO;
using System.Xml.Serialization;

namespace TestManager.Models
{
    /// <summary>
    ///     Save data to xml file as a settings for Automated tests classes
    /// </summary>
    public class SaveData
    {
        public static void SaveDataObject(object obj, string filename)
        {
            var serializer = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, obj);
            writer.Close();
        }
    }
}
