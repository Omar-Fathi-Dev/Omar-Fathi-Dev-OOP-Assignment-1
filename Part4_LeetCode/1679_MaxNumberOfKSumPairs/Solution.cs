
public class Solution
{
    public int MaxOperations(int[] nums, int k) {
        Array.Sort(nums);
        int left = 0;
        int right = nums.Length - 1;
        int counter = 0;
        while (left < right)
        {
            if (nums[left] + nums[right] == k)
            {
                counter++;
                left++;
                right--;
            }
            else if (nums[left] + nums[right] > k)
                right--;
            else
                left++;
        }
        return counter;
    }

    
    
    

   
}