using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Repositories;
using ContentConsole.Services;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BadWordServiceTests
    {
        [Test]
        public void counting_bad_words_in_content()
        {
            var badWordRepo = new Mock<IBadWordRepository>();
            badWordRepo.Setup(x => x.All()).Returns(new List<string> {"bad", "nasty"});

            var SUT = new BadWordService(badWordRepo.Object);
            var result = SUT.GetTotalBadWords("some bad content");

            result.ShouldBe(1);
        }

        [Test]
        public void filtering_bad_words_in_content()
        {
            var badWordRepo = new Mock<IBadWordRepository>();
            badWordRepo.Setup(x => x.All()).Returns(new List<string> { "bad", "nasty" });

            var SUT = new BadWordService(badWordRepo.Object);
            var result = SUT.FilterBadWords("some bad nasty content");

            result.ShouldBe("some b#d n###y content");
        }
    }
}
