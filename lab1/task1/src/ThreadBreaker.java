public class ThreadBreaker implements Runnable
{
    private volatile boolean _canBreak;
    private final int _sleepTime;

    public ThreadBreaker(int milisecondsToWait)
    {
        _canBreak = false;
        _sleepTime = milisecondsToWait;
    }

    @Override
    public void run()
    {
        try
        {
            Thread.sleep(_sleepTime);
        } catch (InterruptedException e)
        {
            e.printStackTrace();
        }
        _canBreak = true;
    }

    public synchronized boolean CanBreak()
    {
        return  _canBreak;
    }
}
