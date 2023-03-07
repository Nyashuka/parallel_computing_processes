public class Worker extends Thread
{
    private final int _id;
    private final SuperThreadBreaker _threadBreaker;

    public Worker(int id, SuperThreadBreaker breaker)
    {
        _id = id;
        _threadBreaker = breaker;
    }

    @Override
    public void run()
    {
        long sum = 0;
        boolean isStopped = false;
        do
        {
            sum++;
            isStopped = _threadBreaker.CanBreak(_id);
        } while (!isStopped);
        System.out.println(_id + " - " + sum);
    }
}
