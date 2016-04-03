using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Application;
using ContentConsole.Wrapper;

namespace ContentConsole
{
    public interface IDisplayApplicationOptions
    {
        void ShowApplicationOptions();
    }

    public class ApplicationOptions : IDisplayApplicationOptions
    {
        private readonly IReaderApplication _readerApplication;
        private readonly ICuratorApplication _curatorApplication;
        private readonly IConsoleWrapper _consoleWrapper;

        public ApplicationOptions(IReaderApplication readerApplication, ICuratorApplication curatorApplication, IConsoleWrapper consoleWrapper)
        {
            _readerApplication = readerApplication;
            _curatorApplication = curatorApplication;
            _consoleWrapper = consoleWrapper;
        }

        public void ShowApplicationOptions()
        {
            _consoleWrapper.WriteLine("Filter negative words? (y/n)");
            if (_consoleWrapper.ReadKey() == 'y')
                _readerApplication.Run();
            else
                _curatorApplication.Run();
        }
    }
}
