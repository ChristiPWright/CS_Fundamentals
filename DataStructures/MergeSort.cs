public class Solution {
    public int[] SortArray(int[] nums) {
        int[] left;
        int[] right;
        int[] result = new int[nums.Length];
        
        //avoids infinite recursion
        if (nums.Length <= 1){
            return nums;
        }

        int midPoint = nums.Length /2;

        left = new int[midPoint];

        if (nums.Length % 2 == 0){
            right = new int[midPoint];
        }
        else{
            right = new int[midPoint + 1];
        }
        //populate left array
        for (int i = 0; i < midPoint; i++){
            left[i] = nums[i];
        }
        //populate right array
        int x = 0;
        for (int i = midPoint; i < nums.Length; i++){
            right[x] = nums[i];
            x++;
        }
        //recursively sort the lieft array
        left = SortArray(left);
        right = SortArray(right);
        result = merge(left, right);
        Console.WriteLine(result);
        return result;
    }
    public static int[] merge(int[] left, int[] right){
        int resultLength = right.Length + left.Length;
        int [] result = new int[resultLength];

        //what is this syntax??
        int indexLeft = 0, indexRight = 0, indexResult = 0;

        while (indexLeft < left.Length || indexRight < right.Length){
            //if both arrays have elements
            if (indexLeft < left.Length && indexRight < right.Length){
                if (left[indexLeft] <= right[indexRight]){
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            else if (indexLeft < left.Length){
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            else if (indexRight < right.Length){
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }
        return result;
    }
}

// Tested Successfully on https://leetcode.com/problems/sort-an-array/ 12/15

