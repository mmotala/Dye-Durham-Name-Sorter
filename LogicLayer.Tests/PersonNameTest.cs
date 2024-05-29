using LogicLayer.Models;

namespace LogicLayer.Tests
{
    [TestFixture]
    public class PersonNameTest
    {
        [Test]
        public void Constructor_WithTwoNames_SetsFirstNameAndLastName()
        {
            // Arrange
            var fullName = "John Doe";

            // Act
            var personName = new PersonName(fullName);

            // Assert
            Assert.That(personName.FirstName, Is.EqualTo("John"));
            Assert.That(personName.LastName, Is.EqualTo("Doe"));
            Assert.That(personName.MiddleName1, Is.Null);
            Assert.That(personName.MiddleName2, Is.Null);

        }

        [Test]
        public void Constructor_WithThreeNames_SetsFirstNameMiddleNameAndLastName()
        {
            // Arrange
            var fullName = "John Michael Doe";

            // Act
            var personName = new PersonName(fullName);

            // Assert
            Assert.That(personName.FirstName, Is.EqualTo("John"));
            Assert.That(personName.MiddleName1, Is.EqualTo("Michael"));
            Assert.That(personName.LastName, Is.EqualTo("Doe"));
            Assert.That(personName.MiddleName2, Is.Null);
        }

        [Test]
        public void Constructor_WithFourNames_SetsFirstNameTwoMiddleNamesAndLastName()
        {
            // Arrange
            var fullName = "John Michael David Doe";

            // Act
            var personName = new PersonName(fullName);

            // Assert
            Assert.That(personName.FirstName, Is.EqualTo("John"));
            Assert.That(personName.MiddleName1, Is.EqualTo("Michael"));
            Assert.That(personName.MiddleName2, Is.EqualTo("David"));
            Assert.That(personName.LastName, Is.EqualTo("Doe"));

        }

        [Test]
        public void Constructor_WithUnexpectedNameFormat_ThrowsArgumentException()
        {
            // Arrange
            var fullName = "John Michael David Edward Doe";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new PersonName(fullName));
            Assert.That(ex.Message, Is.EqualTo("Unexpected name format: John Michael David Edward Doe"));
        }

        [Test]
        public void ToString_WithTwoMiddleNames_ReturnsFullNameWithTwoMiddleNames()
        {
            // Arrange
            var personName = new PersonName("John Michael David Doe");

            // Act
            var result = personName.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("John Michael David Doe"));
        }

        [Test]
        public void ToString_WithOneMiddleName_ReturnsFullNameWithOneMiddleName()
        {
            // Arrange
            var personName = new PersonName("John Michael Doe");

            // Act
            var result = personName.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("John Michael Doe"));
        }

        [Test]
        public void ToString_WithNoMiddleNames_ReturnsFullNameWithoutMiddleNames()
        {
            // Arrange
            var personName = new PersonName("John Doe");

            // Act
            var result = personName.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("John Doe"));
        }
    }
}