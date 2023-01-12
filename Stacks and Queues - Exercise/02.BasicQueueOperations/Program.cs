int[] cmdArgs = Console.ReadLine()
    .Split()
    .Select(n => int.Parse(n))
    .ToArray();

int n = cmdArgs[0];
int s = cmdArgs[1];
int x = cmdArgs[2];

int[] ints = Console.ReadLine()
    .Split()
    .Select(n => int.Parse(n))
    .ToArray();
Queue<int> queue = new Queue<int>();
for (int i = 0; i < n; i++)
{
    queue.Enqueue(ints[i]);
    if (i == ints.Length - 1)
    {
        break;
    }
}

for (int i = 0; i < s; i++)
{
    queue.Dequeue();
    if (queue.Count == 0)
    {
        break;
    }
}

if (queue.Count == 0)
{
    Console.WriteLine("0");
}
else if (queue.Contains(x))
{
    Console.WriteLine("true");
}
else
{
    Console.WriteLine(queue.Min());
}