using System;

namespace TwoSum.Domain
{
    public class TwoSum
    {
        public int[] FindIndices(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int k = i + 1; k < nums.Length; k++)
                {
                    if (nums[i] + nums[k] == target)
                    {
                        return new[] { i, k };
                    }
                }
            }

            return null;
        }
    }
}
