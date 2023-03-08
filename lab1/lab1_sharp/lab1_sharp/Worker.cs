using System.Threading;
using System;

namespace lab1_sharp
{
    public class Worker 
    {
        private readonly int _id;
        private readonly SuperThreadBreaker _threadBreaker;

        public Worker(int id, SuperThreadBreaker breaker)
        {
            _id = id;
            _threadBreaker = breaker;
        }


        public void Run()
        {        
            new Thread(() => 
            {
                long sum = 0;
                bool isStopped = false;
                do
                {
                    sum++;
                    isStopped = _threadBreaker.CanBreak(_id);
                } while (!isStopped);

                Console.WriteLine(_id + " - " + sum);
            }).Start();        
        }
    }
}
