using System;
using System.Collections.Generic;
using System.Linq;

namespace StackQueueHashSolutions;

public static class StackQueueHashSolutions
{
    // 1. Queue Using Two Stacks
    public class QueueUsingStacks<T>
    {
        private readonly Stack<T> enqueueStack = new();
        private readonly Stack<T> dequeueStack = new();

        public int Count => enqueueStack.Count + dequeueStack.Count;

        public void Enqueue(T item) => enqueueStack.Push(item);

        public T Dequeue()
        {
            MoveItems();
            if (dequeueStack.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return dequeueStack.Pop();
        }

        public T Peek()
        {
            MoveItems();
            if (dequeueStack.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return dequeueStack.Peek();
        }

        private void MoveItems()
        {
            if (dequeueStack.Count == 0)
                while (enqueueStack.Count > 0)
                    dequeueStack.Push(enqueueStack.Pop());
        }
    }

    // 2. Sort a Stack Using Recursion
    public static void SortStack(Stack<int> stack)
    {
        if (stack.Count <= 1)
            return;

        int value = stack.Pop();
        SortStack(stack);
        InsertInSortedOrder(stack, value);
    }

    private static void InsertInSortedOrder(Stack<int> stack, int value)
    {
        if (stack.Count == 0 || stack.Peek() <= value)
        {
            stack.Push(value);
            return;
        }

        int top = stack.Pop();
        InsertInSortedOrder(stack, value);
        stack.Push(top);
    }

    // 3. Stock Span Problem
    public static int[] StockSpan(int[] prices)
    {
        int[] span = new int[prices.Length];
        Stack<int> indices = new();

        for (int i = 0; i < prices.Length; i++)
        {
            while (indices.Count > 0 && prices[indices.Peek()] <= prices[i])
                indices.Pop();

            span[i] = indices.Count == 0 ? i + 1 : i - indices.Peek();
            indices.Push(i);
        }

        return span;
    }

    // 4. Sliding Window Maximum
    public static int[] SlidingWindowMaximum(int[] nums, int k)
    {
        if (nums.Length == 0 || k <= 0 || k > nums.Length)
            return Array.Empty<int>();

        List<int> result = new();
        LinkedList<int> deque = new(); // Stores useful indices.

        for (int i = 0; i < nums.Length; i++)
        {
            while (deque.Count > 0 && deque.First!.Value <= i - k)
                deque.RemoveFirst();

            while (deque.Count > 0 && nums[deque.Last!.Value] <= nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            if (i >= k - 1)
                result.Add(nums[deque.First!.Value]);
        }

        return result.ToArray();
    }

    // 5. Circular Tour / Petrol Pump Problem
    public static int CircularTour(int[] petrol, int[] distance)
    {
        if (petrol.Length == 0 || petrol.Length != distance.Length)
            return -1;

        int totalSurplus = 0;
        int currentSurplus = 0;
        int start = 0;

        for (int i = 0; i < petrol.Length; i++)
        {
            int gain = petrol[i] - distance[i];
            totalSurplus += gain;
            currentSurplus += gain;

            if (currentSurplus < 0)
            {
                start = i + 1;
                currentSurplus = 0;
            }
        }

        return totalSurplus >= 0 && start < petrol.Length ? start : -1;
    }

    // 6. Find All Zero-Sum Subarrays
    public static List<(int Start, int End)> FindZeroSumSubarrays(int[] nums)
    {
        List<(int Start, int End)> result = new();
        Dictionary<long, List<int>> prefixPositions = new()
        {
            [0] = new List<int> { -1 }
        };

        long sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            if (prefixPositions.TryGetValue(sum, out List<int>? positions))
            {
                foreach (int startPosition in positions)
                    result.Add((startPosition + 1, i));
            }

            if (!prefixPositions.ContainsKey(sum))
                prefixPositions[sum] = new List<int>();

            prefixPositions[sum].Add(i);
        }

        return result;
    }

    // 7. Pair With Given Sum
    public static bool HasPairWithSum(int[] nums, int target)
    {
        HashSet<int> seen = new();

        foreach (int num in nums)
        {
            if (seen.Contains(target - num))
                return true;

            seen.Add(num);
        }

        return false;
    }

    // 8. Longest Consecutive Sequence
    public static int LongestConsecutiveSequence(int[] nums)
    {
        HashSet<int> numbers = nums.ToHashSet();
        int longest = 0;

        foreach (int number in numbers)
        {
            if (numbers.Contains(number - 1))
                continue;

            int current = number;
            int length = 1;

            while (numbers.Contains(current + 1))
            {
                current++;
                length++;
            }

            longest = Math.Max(longest, length);
        }

        return longest;
    }

    // 9. Custom Hash Map using separate chaining
    public class CustomHashMap<TKey, TValue>
    {
        private class Entry
        {
            public TKey Key { get; }
            public TValue Value { get; set; }

            public Entry(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly List<Entry>[] buckets;
        private readonly IEqualityComparer<TKey> comparer;

        public CustomHashMap(int capacity = 16, IEqualityComparer<TKey>? comparer = null)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            buckets = new List<Entry>[capacity];
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        private int GetBucketIndex(TKey key)
        {
            int hash = comparer.GetHashCode(key!);
            return (hash & 0x7fffffff) % buckets.Length;
        }

        public void Put(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            buckets[index] ??= new List<Entry>();

            foreach (Entry entry in buckets[index])
            {
                if (comparer.Equals(entry.Key, key))
                {
                    entry.Value = value;
                    return;
                }
            }

            buckets[index].Add(new Entry(key, value));
        }

        public bool TryGet(TKey key, out TValue value)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] != null)
            {
                foreach (Entry entry in buckets[index])
                {
                    if (comparer.Equals(entry.Key, key))
                    {
                        value = entry.Value;
                        return true;
                    }
                }
            }

            value = default!;
            return false;
        }

        public TValue Get(TKey key)
        {
            if (TryGet(key, out TValue value))
                return value;

            throw new KeyNotFoundException("Key was not found.");
        }

        public bool Remove(TKey key)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] == null)
                return false;

            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (comparer.Equals(buckets[index][i].Key, key))
                {
                    buckets[index].RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
    }

    // 10. Two Sum - returns the two indices.
    public static (int FirstIndex, int SecondIndex)? TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> indexByValue = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int needed = target - nums[i];

            if (indexByValue.TryGetValue(needed, out int previousIndex))
                return (previousIndex, i);

            indexByValue[nums[i]] = i;
        }

        return null;
    }

    // Small demonstration of every solution.
}
