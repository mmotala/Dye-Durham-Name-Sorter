namespace LogicLayer.Interfaces
{
    public interface IFileLogic
    {
        Task<string[]> ReadAllLinesAsync(string filePath);
        Task WriteAllLinesAsync(string filePath, string[] lines);
    }
}
