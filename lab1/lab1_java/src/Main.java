public class Main
{
    public static void main(String[] args)
    {
        int workersCount = 5;
        int[] sleepTime = { 5000,6000,7000,5000,4000,6000,7000,6000,9000};

        SuperThreadBreaker breaker = new SuperThreadBreaker(sleepTime);
        Worker[] workers = new Worker[workersCount];

        for (int i = 0; i < workersCount; i++)
        {
            workers[i] = new Worker(i, breaker);
            new Thread(workers[i]).start();
        }

        new Thread(breaker).start();
    }
}