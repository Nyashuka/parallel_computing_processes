using System;

namespace lab1_sharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int workersCount = 5;
            int[] sleepTime = new int[workersCount];

            for (int i = 0; i < workersCount; i++)
            {
                sleepTime[i] = 5000;
            }

            SuperThreadBreaker breaker = new SuperThreadBreaker(sleepTime);
            Worker[] workers = new Worker[workersCount];

            for (int i = 0; i < workersCount; i++)
            {
                workers[i] = new Worker(i, breaker);
                workers[i].Run();
            }

            breaker.Run();

        }
    }
}
