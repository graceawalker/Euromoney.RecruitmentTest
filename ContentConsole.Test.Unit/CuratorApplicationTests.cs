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
    public class CuratorApplicationTests
    {
        [Test]
        public void counting_bad_words_in_input_should_display_total()
        {
            var input = "some sentence to count";

            var consoleOutputWrapper = new Mock<IConsoleWrapper>();
            consoleOutputWrapper.Setup(x => x.ReadLine()).Returns(input);
            var badWordService = new Mock<IBadWordService>();
            badWordService.Setup(x => x.GetTotalBadWords(input)).Returns(2);

            var SUT = new CuratorApplication(badWordService.Object, consoleOutputWrapper.Object);
            SUT.Run();

            consoleOutputWrapper.Verify(x => x.ReadLine());
            consoleOutputWrapper.Verify(x => x.WriteLine("Enter some text to count, then press Enter"));
            consoleOutputWrapper.Verify(x => x.ReadLine());
            consoleOutputWrapper.Verify(x => x.WriteLine("Scanned the text:"));
            consoleOutputWrapper.Verify(x => x.WriteLine(input));
            consoleOutputWrapper.Verify(x => x.WriteLine("Total Number of negative words: 2"));
            consoleOutputWrapper.Verify(x => x.WriteLine("Press ANY key to exit."));
            consoleOutputWrapper.Verify(x => x.ReadKey());
        }
    }
}
