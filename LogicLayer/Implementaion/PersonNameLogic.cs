using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Implementaion
{
    public class PersonNameLogic : IPersonNameLogic
    {
        private readonly IFileLogic _fileLogic;

        public PersonNameLogic(IFileLogic fileLogic)
        {
            _fileLogic = fileLogic;

        }

        public async Task<List<PersonName>> SortAndSaveNamesAsync(string source, string outputFile)
        {
            List<PersonName> names = await ReadAllNamesAsync(source);
            var sortedNames = SortNamesAlphabetically(names);
            await SaveNamesToFileAsync(outputFile, sortedNames);
            return sortedNames;

        }

        public void DisplayNames(List<PersonName> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private List<PersonName> SortNamesAlphabetically(List<PersonName> names)
        {
            return names.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.MiddleName1).ThenBy(p => p.MiddleName2).ToList();
    }

        private async Task<List<PersonName>> ReadAllNamesAsync(string source)
        {
            var allNames = await _fileLogic.ReadAllLinesAsync(source);
            var personNames = allNames.Select(name => new PersonName(name)).ToList();
            return personNames;
        }

        private async Task SaveNamesToFileAsync(string destination, List<PersonName> names)
        {
            var lines = names.Select(name => name.ToString()).ToArray();
            await _fileLogic.WriteAllLinesAsync(destination, lines);
        }
    }
}
