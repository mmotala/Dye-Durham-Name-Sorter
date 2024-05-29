using DataLayer.Interfaces;

namespace DataLayer.Implementaion
{
    public class FileWriter : IFileWriter
    {
        public async Task WriteAllLinesAsync(string filePath, string[] lines)
        {
            await File.WriteAllLinesAsync(filePath, lines);
        }
    }
}
