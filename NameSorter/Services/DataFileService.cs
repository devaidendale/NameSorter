using System.IO;

namespace NameSorter.Services
{
    public interface IDataService
    {
        string[] dumpData();
        void writeData(string[] data);
    }

    public class DataFileService : IDataService
    {
        private readonly string source, destination;

        public DataFileService(string _source, string _destination)
        {
            this.source = _source;
            this.destination = _destination;
        }

        public string[] dumpData()
        {
            return File.ReadAllLines(source);
        }

        public void writeData(string[] data)
        {
            File.WriteAllLines(destination, data);
        }
    }
}