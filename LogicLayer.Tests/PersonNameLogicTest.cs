using LogicLayer.Implementaion;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Moq;

namespace LogicLayer.Tests
{
    [TestFixture]
    public class PersonNameLogicTests
    {
        private Mock<IFileLogic> _fileLogicMock;
        private PersonNameLogic _personNameLogic;

        [SetUp]
        public void Setup()
        {
            _fileLogicMock = new Mock<IFileLogic>();
            _personNameLogic = new PersonNameLogic(_fileLogicMock.Object);
        }

        [Test]
        public async Task SortAndSaveNamesAsync_ReadsSortsAndSavesNames()
        {
            // Arrange
            var sourceFile = "source.txt";
            var outputFile = "output.txt";
            var unsortedNames = new string[]
            {
                    "John Smith",
                    "Alice Johnson",
                    "Bob Brown"
            };
            var expectedSortedNames = new List<PersonName>
                {
                new("Bob Brown"),
                new("Alice Johnson"),
                new("John Smith")
                };

            _fileLogicMock.Setup(f => f.ReadAllLinesAsync(sourceFile)).ReturnsAsync(unsortedNames);
            _fileLogicMock.Setup(f => f.WriteAllLinesAsync(outputFile, It.IsAny<string[]>())).Returns(Task.CompletedTask);

            // Act
            var sortedNames = await _personNameLogic.SortAndSaveNamesAsync(sourceFile, outputFile);

            // Assert
            Assert.That(sortedNames.Count, Is.EqualTo(expectedSortedNames.Count));
            for (int i = 0; i < expectedSortedNames.Count; i++)
            {
                Assert.That(sortedNames[i].ToString(), Is.EqualTo(expectedSortedNames[i].ToString()));
            }
            _fileLogicMock.Verify(f => f.ReadAllLinesAsync(sourceFile), Times.Once);
            _fileLogicMock.Verify(f => f.WriteAllLinesAsync(outputFile, It.IsAny<string[]>()), Times.Once);
        }
    }
}