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
    public class DisplayApplicationOptionsTests
    {
        [Test]
        public void showing_options_Should_display_options()
        {
            var readerApplication = new Mock<IReaderApplication>();
            var curatorApplication = new Mock<ICuratorApplication>();
            var consoleWrapper = new Mock<IConsoleWrapper>();

            var SUT = new ApplicationOptions(readerApplication.Object, curatorApplication.Object, consoleWrapper.Object);
            SUT.ShowApplicationOptions();

            consoleWrapper.Verify(x => x.WriteLine("Filter negative words? (y/n)"));

        }

        [Test]
        public void selecting_to_filter_should_run_application_as_reader()
        {
            var readerApplication = new Mock<IReaderApplication>();
            var curatorApplication = new Mock<ICuratorApplication>();
            var consoleWrapper = new Mock<IConsoleWrapper>();

            consoleWrapper.Setup(x => x.ReadKey()).Returns('y');

            var SUT = new ApplicationOptions(readerApplication.Object, curatorApplication.Object, consoleWrapper.Object);
            SUT.ShowApplicationOptions();

            readerApplication.Verify(x => x.Run());

        }

        [Test]
        public void selecting_not_to_filter_should_run_application_as_curator()
        {
            var readerApplication = new Mock<IReaderApplication>();
            var curatorApplication = new Mock<ICuratorApplication>();
            var consoleWrapper = new Mock<IConsoleWrapper>();

            consoleWrapper.Setup(x => x.ReadKey()).Returns('n');

            var SUT = new ApplicationOptions(readerApplication.Object, curatorApplication.Object, consoleWrapper.Object);
            SUT.ShowApplicationOptions();

            curatorApplication.Verify(x => x.Run());

        }
    }
}
