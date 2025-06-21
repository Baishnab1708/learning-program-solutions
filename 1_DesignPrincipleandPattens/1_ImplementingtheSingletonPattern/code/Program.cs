using System;

namespace SingletonPatternExample
{

    public class Logger
    {
        private static readonly Logger _instance = new Logger();

        private Logger()
        {
            Console.WriteLine("Logger instance created");
        }

        public static Logger GetInstance()
        {
            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            logger1.Log("Logging from logger1");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("Logging from logger2");

            if (logger1 == logger2)
            {
                Console.WriteLine("Both logger1 and logger2 are the same instance.");
            }
            else
            {
                Console.WriteLine("Different logger instances!");
            }
        }
    }
}


