using System;
using System.Linq;

int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = int.Parse(Console.ReadLine());
nums = TransformArray(nums, Reverse(nums));
nums = nums.Where(IsNotDivisible(n)).ToArray();

Console.WriteLine(String.Join(" ",nums));



static int[] TransformArray(int[] array, Func<int[], int[]> action)
{
    return action(array);
}

static Func<int, bool> IsNotDivisible(int filterNumber)
{
    return  n=> n % filterNumber != 0;
}

static Func<int[], int[]> Reverse(int[] array)
{
    int[] result = new int[array.Length];
    for(int i = 0; i < array.Length; i++)
    {
        result[i] = array[array.Length - 1 - i];
    }
    return array => result;
}

