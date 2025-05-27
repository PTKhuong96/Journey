public class Solution {
    public int DifferenceOfSums(int n, int m) {
        int result = 0;
        
        for (int i = 0; i <= n; i++)
        {
            if (i % m == 0)
            {
                result = result - i;
            }
            else
            {
                result = result + i;
            }
        }
        
        return result;
    }
}