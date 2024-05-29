using DataLayer.Interfaces;
using LogicLayer.Interfaces;

namespace LogicLayer.Implementaion;
    public class FileLogic : IFileLogic
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public FileLogic(IFileReader fileReader, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

    public async Task<string[]> ReadAllLinesAsync(string source)
        {
            return await _fileReader.ReadAllLinesAsync(source);
        }

    public async Task WriteAllLinesAsync(string destination, string[] lines)
        {
           await _fileWriter.WriteAllLinesAsync(destination, lines);
        }
    }
