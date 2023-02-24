using System;

namespace lab1_sharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[9];
            Random random = new Random(); 

            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker(i, random.Next(3, 9));
                workers[i].Run();
            }
        }
    }
}
