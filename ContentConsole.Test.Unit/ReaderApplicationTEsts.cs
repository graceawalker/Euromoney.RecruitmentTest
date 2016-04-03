using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Application;
using ContentConsole.Services;
using ContentConsole.Wrapper;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class ReaderApplicationTests
    {
        [Test]
        public void counting_bad_words_in_input_should_display_total_with_filter()
        {
            var input = "some sentence to filter";
            var filteredInput = "filtered sentence";

            var consoleOutputWrapper = new Mock<IConsoleWrapper>();
            consoleOutputWrapper.Setup(x => x.ReadLine()).Returns(input);
            var badWordService = new Mock<IBadWordService>();
            badWordService.Setup(x => x.GetTotalBadWords(input)).Returns(2);
            badWordService.Setup(x => x.FilterBadWords(input)).Returns(filteredInput);

            var SUT = new ReaderApplication(badWordService.Object, consoleOutputWrapper.Object);
            SUT.Run();

            consoleOutputWrapper.Verify(x => x.Clear());
            consoleOutputWrapper.Verify(x => x.WriteLine("Enter some text to filter, then press Enter"));
            consoleOutputWrapper.Verify(x => x.ReadLine());
            consoleOutputWrapper.Verify(x => x.WriteLine("Filtered text:"));
            consoleOutputWrapper.Verify(x => x.WriteLine(filteredInput));
            consoleOutputWrapper.Verify(x => x.WriteLine("Total Number of negative words: 2"));
            consoleOutputWrapper.Verify(x => x.WriteLine("Press ANY key to exit."));
            consoleOutputWrapper.Verify(x => x.ReadKey());
        }
    }
}
