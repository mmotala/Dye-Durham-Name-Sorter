using DataLayer.Interfaces;
using LogicLayer.Implementaion;
using Moq;

namespace LogicLayer.Tests
{
    [TestFixture]
    public class FileLogicTests
    {
        private Mock<IFileReader> _fileReaderMock;
        private Mock<IFileWriter> _fileWriterMock;
        private FileLogic _fileLogic;

        [SetUp]
        public void Setup()
        {
            _fileReaderMock = new Mock<IFileReader>();
            _fileWriterMock = new Mock<IFileWriter>();
            _fileLogic = new FileLogic(_fileReaderMock.Object, _fileWriterMock.Object);
        }

        [Test]
        public async Task ReadAllLinesAsync_ShouldReturnLinesFromSource()
        {
            // Arrange
            var source = "source.txt";
            var expectedLines = new[] { "John Doe", "Jane Smith" };

            _fileReaderMock.Setup(fr => fr.ReadAllLinesAsync(source)).ReturnsAsync(expectedLines);

            // Act
            var result = await _fileLogic.ReadAllLinesAsync(source);

            // Assert
            Assert.That(result, Is.EqualTo(expectedLines));
            _fileReaderMock.Verify(fr => fr.ReadAllLinesAsync(source), Times.Once);
        }

        [Test]
        public async Task WriteAllLinesAsync_ShouldWriteLinesToDestination()
        {
            // Arrange
            var destination = "destination.txt";
            var lines = new[] { "John Doe", "Jane Smith" };

            _fileWriterMock.Setup(fw => fw.WriteAllLinesAsync(destination, lines)).Returns(Task.CompletedTask);

            // Act
            await _fileLogic.WriteAllLinesAsync(destination, lines);

            // Assert
            _fileWriterMock.Verify(fw => fw.WriteAllLinesAsync(destination, lines), Times.Once);
        }
    }
}
