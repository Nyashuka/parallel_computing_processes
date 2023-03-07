using System.Threading;

namespace lab1_sharp
{
    public class SuperThreadBreaker
    {
        private volatile bool[] _canBreak;
        private volatile int[] _sleepTime;
        private const int WAIT_PER_TICK = 100;

        public SuperThreadBreaker(int[] sleepTime)
        {
            _sleepTime = sleepTime;
            _canBreak = new bool[sleepTime.Length];  
        }

        public void Run()
        {
            new Thread(() =>
            {
                while (true)
                {
                    bool ended = true;

                    Thread.Sleep(WAIT_PER_TICK);

                    for (int i = 0; i < _sleepTime.Length; i++)
                    {
                        if (_canBreak[i])
                            continue;

                        ended = false;
                        _sleepTime[i] -= WAIT_PER_TICK;
                        

                        if (_sleepTime[i] <= 0)
                        {
                            _canBreak[i] = true;
                        }
                    }

                    if (ended)
                        break;
                }
            }).Start();
        }

        public bool CanBreak(int index)
        {
            lock (this)
            {
                return _canBreak[index];
            }
        }
    }
}
