namespace Operator_overloading;

public class InsertionSort
{
    public void implementation()
    {
        int []nums = { 42, 7, 19, 3, 88, 12 };
        for (int i = 1; i < nums.Length; i++)
        {
            int key = nums[i];
            int j = i-1;
            while (j >= 0 && key < nums[j])
            {
                nums[j + 1] = nums[j];
                j--;
            }

            nums[j + 1] = key;
        }
        foreach (int i in nums)
        {
            Console.WriteLine(i);
        }
    }
}