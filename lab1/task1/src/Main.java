public class Main
{
    public static void main(String[] args)
    {
        Worker[] workers = new Worker[3];

        for(int i = 0; i < workers.length; i++)
        {
            workers[i] = new Worker(i, 6);
            workers[i].start();
        }
    }
}