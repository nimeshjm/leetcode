using System;

namespace LongestPalindromicSubstring.Domain
{
    public class Palindrome
    {
        public string FindLongest(string word)
        {
            if (IsPalindrome(word))
                return word;

            for (int i = 0; i < word.Length; i++)
            {
                var currentWord = word.Substring(i);

                for (int k = currentWord.Length; k >= 0; k--)
                {
                    if (IsPalindrome(currentWord.Substring(0, k)))
                    {
                        return currentWord.Substring(0, k);
                    }
                }
            }

            return string.Empty;
        }

        public bool IsPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word) || word.Length == 1)
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
