public class Worker extends Thread
{
    private final int _id;
    private final ThreadBreaker _threadBreaker;

    public Worker(int id, int lifeTimeInSeconds)
    {
        _id = id;
        _threadBreaker = new ThreadBreaker(lifeTimeInSeconds * 1000);
    }

    @Override
    public void run()
    {
        (new Thread(_threadBreaker)).start();
        long sum = 0;
        boolean isStopped = false;
        do
        {
            sum++;
            isStopped = _threadBreaker.CanBreak();
        } while (!isStopped);
        System.out.println("id: " + _id + " - " + sum);
    }
}
