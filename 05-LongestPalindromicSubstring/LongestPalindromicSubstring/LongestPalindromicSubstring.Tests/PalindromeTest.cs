using LongestPalindromicSubstring.Domain;
using NUnit.Framework;

namespace Tests
{
    public class PalindromeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("babad", ExpectedResult = "bab")]
        [TestCase("cbbd", ExpectedResult = "bb")]
        [TestCase("madam", ExpectedResult = "madam")]
        public string FindLongestTest(string word)
        {
            var sut = new Palindrome();

            return sut.FindLongest(word);
        }

        [TestCase("babad", ExpectedResult = false)]
        [TestCase("cbbd", ExpectedResult = false)]
        [TestCase("madam", ExpectedResult = true)]
        public bool IsPalindromeTest(string word)
        {
            var sut = new Palindrome();

            return sut.IsPalindrome(word);
        }

    }
}