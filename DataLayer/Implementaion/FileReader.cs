using DataLayer.Interfaces;

namespace DataLayer.Implementaion
{
    public class FileReader : IFileReader
    {
        public async Task<string[]> ReadAllLinesAsync(string filePath)
        {
            return await File.ReadAllLinesAsync(filePath);
        }
    }
}
