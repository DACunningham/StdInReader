using Moq;
using InputReader;
using System;
using System.IO;
using System.Text;
using Xunit;
using FluentAssertions;

namespace StdInReaderTest
{
    public class StdInReaderTests
    {
        [Theory]
        [InlineData("INPUT_FILE")]
        public void StdInReader_ValidFilePath_ReturnsArrayWithData(string environmentVar)
        {
            // Arrange
            Environment.SetEnvironmentVariable(environmentVar, "C:\\test.txt");
            int[][] testArray = GetCorrectResult();

            var mockFileManager = new Mock<IFileManager>();
            mockFileManager.Setup(f => f.StreamReader(It.IsAny<string>()))
                .Returns(GetMockStream());

            StdInReader reader = new StdInReader(mockFileManager.Object);

            // Act

            int[][] result = reader.GetInputJaggedArray(environmentVar);


            // Assert
            for (int i = 0; i < result.Length; i++)
            {
                result[i].Should().Equal(testArray[i]);
            }
        }

        [Theory]
        [InlineData("WRONG_KEY")]
        public void StdInReader_InvalidFilePath_ThrowsArgumentNullException(string environmentVar)
        {
            // Arrange
            Environment.SetEnvironmentVariable("INPUT_FILE", "C:\\test.txt");
            int[][] testArray = GetCorrectResult();

            var mockFileManager = new Mock<IFileManager>();
            mockFileManager.Setup(f => f.StreamReader(null))
                .Throws(new ArgumentNullException());

            StdInReader reader = new StdInReader(mockFileManager.Object);

            // Act
            Action act = () => reader.GetInputJaggedArray(environmentVar);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        private StreamReader GetMockStream()
        {
            string fakeFileContents = "5 3\n" +
                "1 2 50\n" +
                "2 3 50\n" +
                "3 4 50\n";
            byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
            MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);
            return new StreamReader(fakeMemoryStream);
        }

        private int[][] GetCorrectResult()
        {
            int[][] result = new int[4][];
            result[0] = new int[2] { 5, 3 };
            result[1] = new int[3] { 1, 2, 50 };
            result[2] = new int[3] { 2, 3, 50 };
            result[3] = new int[3] { 3, 4, 50 };

            return result;
        }
    }
}
