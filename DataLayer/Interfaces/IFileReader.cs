namespace DataLayer.Interfaces
{
    public interface IFileReader
    {
        Task<string[]> ReadAllLinesAsync(string source);
    }
}
