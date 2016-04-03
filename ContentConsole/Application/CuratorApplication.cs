using ContentConsole.Services;
using ContentConsole.Wrapper;

namespace ContentConsole.Application
{


    public interface ICuratorApplication : IApplication
    {

    }

    public class CuratorApplication : ICuratorApplication
    {
        private readonly IBadWordService _badWordService;
        private readonly IConsoleWrapper _consoleWrapper;

        public CuratorApplication(IBadWordService badWordService, IConsoleWrapper consoleWrapper)
        {
            _badWordService = badWordService;
            _consoleWrapper = consoleWrapper;
        }

        public void Run()
        {
            _consoleWrapper.Clear();
            _consoleWrapper.WriteLine("Enter some text to count, then press Enter");
            var input = _consoleWrapper.ReadLine();

            _consoleWrapper.WriteLine("Scanned the text:");
            _consoleWrapper.WriteLine(input);
            _consoleWrapper.WriteLine("Total Number of negative words: " + _badWordService.GetTotalBadWords(input));

            _consoleWrapper.WriteLine("Press ANY key to exit.");
            _consoleWrapper.ReadKey();
        }
    }
}
