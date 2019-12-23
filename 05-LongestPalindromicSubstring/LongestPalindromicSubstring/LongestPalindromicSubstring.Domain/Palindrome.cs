using System;

namespace LongestPalindromicSubstring.Domain
{
    public class Palindrome
    {
        public string LongestPalindrome(string word)
        {
            if (IsPalindrome(word))
            {
                return word;
            }

            var currentLongestPalindrome = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                var currentWord = word.Substring(i);

                for (int k = currentWord.Length; k >= 0; k--)
                {
                    string thisWord = currentWord.Substring(0, k);
                    if (IsPalindrome(thisWord) && thisWord.Length > currentLongestPalindrome.Length)
                    {
                        currentLongestPalindrome = thisWord;
                    }
                }
            }

            return currentLongestPalindrome;
        }

        public bool IsPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            var halfLength = word.Length / 2;
            var isEven = word.Length % 2 == 0;
            var leftHalf = word.Substring(0, halfLength);
            var rightHalf = word.Substring(isEven ? halfLength : halfLength + 1).ToCharArray();
            Array.Reverse(rightHalf);

            return leftHalf.Equals(new String(rightHalf));
        }
    }
}
