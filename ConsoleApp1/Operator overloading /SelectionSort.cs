namespace Operator_overloading;

public class SelectionSort
{
    public void implementation()
    {
        int[] nums = { 42, 7, 19, 3, 88, 12 };
        for (int i = 0; i < nums.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[minIndex] > nums[j]) minIndex = j;
            }

            if (minIndex != i)
            {
                (nums[i], nums[minIndex]) = (nums[minIndex], nums[i]);
            }
        }

        foreach (int i in nums)
        {
            Console.WriteLine(i);
        }
    }
}