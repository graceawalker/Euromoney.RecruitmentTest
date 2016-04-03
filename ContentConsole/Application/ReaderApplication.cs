using ContentConsole.Services;
using ContentConsole.Wrapper;

namespace ContentConsole.Application
{
    public interface IReaderApplication : IApplication
    {

    }
    public class ReaderApplication : IReaderApplication
    {
        private readonly IBadWordService _badWordService;
        private readonly IConsoleWrapper _consoleWrapper;

        public ReaderApplication(IBadWordService badWordService, IConsoleWrapper consoleWrapper)
        {
            _badWordService = badWordService;
            _consoleWrapper = consoleWrapper;
        }

        public void Run()
        {
            _consoleWrapper.Clear();
            _consoleWrapper.WriteLine("Enter some text to filter, then press Enter");
            var input = _consoleWrapper.ReadLine();

            _consoleWrapper.WriteLine("Filtered text:");
            _consoleWrapper.WriteLine(_badWordService.FilterBadWords(input));
            _consoleWrapper.WriteLine("Total Number of negative words: " + _badWordService.GetTotalBadWords(input));

            _consoleWrapper.WriteLine("Press ANY key to exit.");
            _consoleWrapper.ReadKey();
        }
    }
}
