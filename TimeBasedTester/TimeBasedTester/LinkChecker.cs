using System;
using System.Timers;

namespace TimeBasedTester
{
    class LinkChecker
    {
        private Timer _timer;
        private bool _isRunning = true;
        private int _timesExecuted = 0;

        public void Check(string url, int numOfSeconds)
        {
            try
            {
                Console.WriteLine("## Starting to check - " + url + " ##");
                
                _timer = new Timer(numOfSeconds*1000);
                _timer.Interval = numOfSeconds*1000;
                _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                _timer.Start();

                do
                {
                    CheckLink.ReadUrl(url);
                    _timesExecuted++;
                } while (_isRunning);

            }
            catch (Exception ex)
            {
                Console.WriteLine("## Unknown Exception " + ex.Message + " ##");
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _timer.Stop();
            _isRunning = false;
            Console.WriteLine("## Finished.  Executed: " + _timesExecuted + " times. ##");
        }
    }
}
