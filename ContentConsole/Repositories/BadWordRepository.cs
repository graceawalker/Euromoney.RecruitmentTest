using System.Collections.Generic;

namespace ContentConsole.Repositories
{
    public interface IBadWordRepository
    {
        List<string> All();
    }

    public class BadWordRepository : IBadWordRepository
    {
        public List<string> All()
        {
            return new List<string> { "swine", "bad", "nasty", "horrible" };
        }
    }
}