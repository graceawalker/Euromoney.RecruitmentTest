using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Repositories;

namespace ContentConsole.Services
{
    public interface IBadWordService
    {
        int GetTotalBadWords(string input);
        string FilterBadWords(string input);
    }

    public class BadWordService : IBadWordService
    {
        private readonly IBadWordRepository _badWordRepository;

        public BadWordService(IBadWordRepository badWordRepository)
        {
            _badWordRepository = badWordRepository;
        }

        public int GetTotalBadWords(string input)
        {
            int badWordsCount = 0;
            var badWords = _badWordRepository.All();

            badWords.ForEach(x =>
            {
                if (input.Contains(x))
                    badWordsCount++;
            });

            return badWordsCount;
        }

        public string FilterBadWords(string input)
        {
            var badWords = _badWordRepository.All();

            badWords.ForEach(x =>
            {
                if (input.Contains(x))
                {
                    var length = x.Length;
                    var wordReplacement = x[0] + new String('#', length - 2) + x.Substring(length - 1);
                    input = input.Replace(x, wordReplacement);
                }
            });

            return input;
        }
    }
}
