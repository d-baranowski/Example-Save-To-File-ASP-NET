using System;
using System.IO;

namespace SaveToTextFileOnServer.Services
{
    public interface IDataProvider
    {
        void Write(String data);
        string Read();
    }

    public class DataProviderService : IDataProvider
    {
        private static readonly string FILE_LOCATION = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/file.txt";
        public string Read()
        {
            String line = "";
            using (var fileStream = File.Open(FILE_LOCATION, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                }
            }
            return line;
        }

        public void Write(string data)
        {
            if (!File.Exists(FILE_LOCATION))
            {
                File.Create(FILE_LOCATION);
            }
            using (var sw = new StreamWriter(FILE_LOCATION, true))
            {
                sw.Write(data);
            }
        }
    }
}