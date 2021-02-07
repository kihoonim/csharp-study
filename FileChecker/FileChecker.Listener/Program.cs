using System.IO;
using System.Threading;

namespace FileChecker.Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            Watcher watcher = new Watcher(
                @"a", 
                "*.*",
               NotifyFilters.LastAccess 
               | NotifyFilters.LastWrite 
               | NotifyFilters.FileName 
               | NotifyFilters.DirectoryName,
               new BasicWatcherActions());

            watcher.Start();

            while(true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
