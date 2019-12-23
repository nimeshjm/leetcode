using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] { 1, 2 }, 3, ExpectedResult = new[] { 0, 1 })]
        [TestCase(new[] { 2, 7, 11, 15 }, 9, ExpectedResult = new[] { 0, 1 })]
        public int[] Test1(int[] nums, int target)
        {
            var sut = new TwoSum.Domain.TwoSum();

            return sut.FindIndices(nums, target);
        }
    }
}