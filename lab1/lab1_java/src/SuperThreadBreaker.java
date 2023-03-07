public class SuperThreadBreaker implements Runnable
{
    private final int WAIT_PER_TICK = 100;
    private volatile boolean[] _canBreak;
    private int[] _sleepTime;

    public SuperThreadBreaker(int[] sleepTime)
    {
        _sleepTime = sleepTime;
        _canBreak = new boolean[sleepTime.length];
    }

    @Override
    public void run()
    {
        while (true)
        {
            boolean ended = true;

            try {
                Thread.sleep(WAIT_PER_TICK);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }

            for (int i = 0; i < _sleepTime.length; i++)
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
    }

    public synchronized boolean CanBreak(int index)
    {
        return _canBreak[index];
    }
}
