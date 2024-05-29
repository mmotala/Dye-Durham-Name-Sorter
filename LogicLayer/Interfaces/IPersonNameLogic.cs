using LogicLayer.Models;

namespace LogicLayer.Interfaces
{
    public interface IPersonNameLogic
    {
        Task<List<PersonName>> SortAndSaveNamesAsync(string source, string outputFile);
        void DisplayNames(List<PersonName> names);
    }
}
