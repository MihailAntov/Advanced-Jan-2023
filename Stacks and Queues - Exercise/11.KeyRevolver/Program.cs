using System;
using System.Collections.Generic;
using System.Linq;

int bulletPrice = int.Parse(Console.ReadLine());
int barrelSize = int.Parse(Console.ReadLine());
int bulletsShot = 0;
Stack<int> bullets = new Stack<int>(Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
int totalBullets = bullets.Count();

Queue<int> locks = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int pay = int.Parse(Console.ReadLine());

while(bullets.Any())
{
    int currentBullet = bullets.Pop();
    bulletsShot++;
    
    int currentLock = locks.Peek();

    if(currentBullet<= currentLock)
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine($"Ping!");
    }

    if (bulletsShot == barrelSize && bullets.Any())
    {
        Console.WriteLine("Reloading!");
        bulletsShot = 0;
    }

    if (!locks.Any())
    {
        break;
    }
}

if(locks.Any())
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}
else
{
    int earnings = pay - bulletPrice * (totalBullets - bullets.Count);
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnings}");
}



