using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestPalindromicSubstring.Domain
{
    public class PalindromeSlidingWindow
    {
        public string LongestPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }

            if (IsPalindrome(word))
            {
                return word;
            }

            var palindromes = GetPalindromesOfLength(word, 2).Union(GetPalindromesOfLength(word, 3)).ToList();
            if (palindromes.Count == 0)
            {
                return word[0].ToString();
            }

            var currentLongestPalindrome = palindromes.Last().Item1;

            do
            {
                palindromes = GetExpandedPalindromes(word, palindromes);
                if (palindromes.Count > 0)
                {
                    currentLongestPalindrome = palindromes.Last().Item1;
                }
            } while (palindromes.Count > 0);

            return currentLongestPalindrome;
        }

        private List<(string, int)> GetExpandedPalindromes(string word, List<(string, int)> palindromes)
        {
            var newPalindromes = new List<(string, int)>();
            for (int i = 0; i < palindromes.Count; i++)
            {
                var currentPalindrome = GetExpandedPalindrome(word, palindromes[i]);
                if (currentPalindrome.Item2 != -1)
                {
                    newPalindromes.Add(currentPalindrome);
                }
            }

            return newPalindromes;
        }

        private (string,int) GetExpandedPalindrome(string word, (string, int) palindrome)
        {
            var thisPalindrome = ExpandWindow(word, palindrome.Item1, palindrome.Item2);
            if (IsPalindrome(thisPalindrome))
            {
                return (thisPalindrome, palindrome.Item2 - 1);
            }

            return (string.Empty, -1);
        }

        private List<(string,int)> GetPalindromesOfLength(string word, int length)
        {
            return Split(word, length)
                .Where(w => IsPalindrome(w.Item1))
                .ToList();
        }

        public bool IsPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            if (word.Length == 1)
            {
                return true;
            }

            var halfLength = word.Length / 2;
            var isEven = word.Length % 2 == 0;
            var leftHalf = word.Substring(0, halfLength);
            var rightHalf = word.Substring(isEven ? halfLength : halfLength + 1).ToCharArray();
            Array.Reverse(rightHalf);

            return leftHalf.Equals(new String(rightHalf));
        }

        private List<(string,int)> Split(string array, int chunkSize)
        {
            var result = new List<(string,int)>();

            for (int i = 0; i < array.Length - (chunkSize - 1); i++)
            {
                var temp = new StringBuilder();
                for (int j = i; j < i + chunkSize; j++)
                {
                    temp.Append(array[j]);
                }

                result.Add((temp.ToString(), i));
            }

            return result;
        }

        private string ExpandWindow(string data, string initial, int index)
        {
            if (index == 0)
            {
                return string.Empty;
            }

            if (index + initial.Length == data.Length)
            {
                return string.Empty;
            }

            return $"{data[index - 1]}{initial}{data[index + initial.Length]}";
        }
    }
}
