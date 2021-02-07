using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileChecker.Listener
{
    public class BasicWatcherActions : IWatcherActions
    {
        public void OnChanged(FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath);
        }

        public void OnCreated(FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath);
        }

        public void OnDeleted(FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath);
        }

        public void OnRenamed(RenamedEventArgs e)
        {
            Console.WriteLine(e.FullPath);
        }
    }
}
