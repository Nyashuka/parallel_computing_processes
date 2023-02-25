using System.Threading;

namespace lab1_sharp
{
    public class ThreadBreaker
    {
        private volatile bool _canBreak;
        private readonly int _sleepTime;

        public ThreadBreaker(int milisecondsToWait)
        {
            _canBreak = false;
            _sleepTime = milisecondsToWait;
        }

        public void Run()
        {
            new Thread(() =>
            {

                Thread.Sleep(_sleepTime);
                _canBreak = true;

            }).Start();
        }

        public bool CanBreak()
        {
            lock (this)
            {
                return _canBreak;
            }
        }
    }
}
