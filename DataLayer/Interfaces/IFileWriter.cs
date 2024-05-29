namespace DataLayer.Interfaces
{
    public interface IFileWriter
    {
        Task WriteAllLinesAsync(string destination, string[] lines);
    }
}
