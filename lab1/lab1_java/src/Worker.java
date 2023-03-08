public class Worker extends Thread
{
    private final int _id;
    private final SuperThreadBreaker _threadBreaker;
    private final int _step;

    public Worker(int id, int step, SuperThreadBreaker breaker)
    {
        _id = id;
        _step = step;
        _threadBreaker = breaker;
    }

    @Override
    public void run()
    {
        long count_steps = 0;
        long sum = 0;
        boolean isStopped = false;
        do
        {
            count_steps++;
            sum += _step;
            isStopped = _threadBreaker.CanBreak(_id);
        } while (!isStopped);
        System.out.println("Id: " + _id + " | count_steps: " + count_steps + " | sum " + sum);
    }
}
