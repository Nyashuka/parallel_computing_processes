using System.Threading;
using System;

namespace lab1_sharp
{
    public class Worker 
    {
        private readonly int _id;
        private readonly ThreadBreaker _threadBreaker;

        public Worker(int id, int lifeTimeInSeconds)
        {
            _id = id;
            _threadBreaker = new ThreadBreaker(lifeTimeInSeconds * 1000);
        }


        public void Run()
        {
            _threadBreaker.Run();
            new Thread(() => 
            {
                long sum = 0;
                bool isStopped = false;
                do
                {
                    sum++;
                    isStopped = _threadBreaker.CanBreak();
                } while (!isStopped);
                Console.WriteLine(_id + " - " + sum);
            }).Start();        
        }
    }
}
