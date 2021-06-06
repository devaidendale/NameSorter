using System;
using System.Collections.Generic;
using NameSorter.Models;

namespace NameSorter.Services
{
    public interface INameService
    {
        void sortNames(List<Name> names);
        void getNames(List<Name> names);
        void saveNames(List<Name> names);
    }

    public class NameService : INameService
    {
        private readonly IDataService dataService;

        public NameService(IDataService _dataService)
        {
            this.dataService = _dataService;
        }

        public void sortNames(List<Name> names)
        {
            names.Sort();
        }

        public void getNames(List<Name> names)
        {
            string[] data = dataService.dumpData();
            convertDataToNames(data, names);
        }

        public void saveNames(List<Name> names)
        {
            string[] data = new string[names.Count];
            convertNamesToData(names, data);
            dataService.writeData(data);
        }

        public void convertDataToNames(string[] data, List<Name> names)
        {
            Array.ForEach(data, name => names.Add(new Name(name)));
        }

        public void convertNamesToData(List<Name> names, string[] data)
        {
            for (int idx = 0; idx < names.Count; idx++)
                data[idx] = names[idx].ToString();
        }
    }
}