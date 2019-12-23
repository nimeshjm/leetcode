using System;

namespace LongestPalindromicSubstring.Domain
{
    public class Palindrome
    {
        public string FindLongest(string word)
        {
            if (IsPalindrome(word))
                return word;

            return string.Empty;
        }

        public bool IsPalindrome(string word)
        {
            var halfLength = word.Length / 2;
            var isEven = word.Length % 2 == 0;
            var leftHalf = word.Substring(0, halfLength);
            var rightHalf = word.Substring(isEven ? halfLength : halfLength + 1).ToCharArray();
            Array.Reverse(rightHalf);

            return leftHalf.Equals(new String(rightHalf));
        }
    }
}
