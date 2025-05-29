public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for (int i = 0; i <= nums.Length - 2; i++)
        {
            for (int j = i + 1; j <= nums.Length - 1; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[2] {i, j};
                }
            }
        }
        return new int[0];
    }
}


--USING HASH MAP--

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> numbersDic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int findingNumber = target - nums[i];
            if (numbersDic.ContainsKey(findingNumber))
            {
                return new int[]{i, numbersDic[findingNumber]};
            }

            numbersDic.Add(nums[i], i);
        }

        return null;
    }
}
// for each number
// int current number = nums[i].
// number need to find = target - nums[i]
// if dic has that => return {i, dic[number need to find]}
// if dic could not find that => dic.add(current number, i);