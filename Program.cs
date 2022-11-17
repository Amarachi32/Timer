using System;
namespace timer
{
    class Program
    {
        public delegate void PerSecondsCallback();
        static void Main(string[] args)
        {
            Console.Write("Enter a WorkTime duration in seconds: ");
            var workDuration = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a RestTime duration in seconds: ");
            var restDuration = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter how long you willl like to work before you rest: ");
            var workInterval = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("your total work duration is: {0}secs, resting period {1}secs ", workDuration, workInterval);
            CountDown(workInterval, () =>
            {
                workInterval--;
                workDuration--;
                Console.WriteLine("your total work duration is: {0}secs, to rest in {1}secs ", workDuration, workInterval);

            });

            Console.WriteLine("you have {0} seconds to rest", restDuration);
            CountDown(restDuration, () =>
            {

                restDuration--;
                if (restDuration == 0)
                {
                    Console.WriteLine("\n your resting period is over\n");
                }else
                Console.WriteLine("you have {0} seconds to rest", restDuration);
            });

            Console.WriteLine("your total work duration is: {0}secs", workDuration);
            CountDown(workDuration, () =>
            {
                workDuration--;
                if (workDuration == 0)
                {
                    Console.WriteLine("\n you have completed your duration");
                    Console.ReadKey();
                }else
                Console.WriteLine("your total work duration is: {0}secs", workDuration);

            });



        }

        static void CountDown(int delayInSeconds, PerSecondsCallback perSecondsCallback)
        {
            bool finishedCountdown = false;
            DateTime initialTime = DateTime.UtcNow;
            var perSecondIncrement = 0;
            while (!finishedCountdown)
            {
                DateTime timeNow = DateTime.UtcNow;
                TimeSpan timeDifference = timeNow - initialTime;
                var secondsElapsed = perSecondIncrement;

                if (Math.Floor(timeDifference.TotalSeconds) > perSecondIncrement)
                    perSecondIncrement++;

                if (secondsElapsed < perSecondIncrement)
                    perSecondsCallback();

                if (timeDifference.TotalSeconds >= delayInSeconds)
                {
                    finishedCountdown = true;
                }
            }
        }

    }
}





