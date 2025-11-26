public class Singleton
{
    private static volatile Singleton instance;
    private static readonly object padlock = new object();
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    { instance = new Singleton(); }
                }
            }
            return instance;
        }
    }
}