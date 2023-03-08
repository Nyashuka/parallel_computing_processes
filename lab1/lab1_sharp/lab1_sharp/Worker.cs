using System.Threading;
using System;

namespace lab1_sharp
{
    public class Worker 
    {
        private readonly int _id;
        private readonly SuperThreadBreaker _threadBreaker;
        private readonly int _step;

        public Worker(int id, int step, SuperThreadBreaker breaker)
        {
            _id = id;
            _step = step;
            _threadBreaker = breaker;
        }

        public void Run()
        {        
            new Thread(() => 
            {
                long sum = 0;
                long count_steps = 0;
                bool isStopped = false;
                do
                {
                    count_steps++;
                    sum += _step;
                    isStopped = _threadBreaker.CanBreak(_id);
                } while (!isStopped);

                Console.WriteLine($"Id: {_id} | count_steps: {count_steps} | sum: {sum}");
            }).Start();        
        }
    }
}
