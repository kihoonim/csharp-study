using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileChecker.Listener
{
    public interface IWatcherActions
    {
        void OnChanged(FileSystemEventArgs e);
        void OnCreated(FileSystemEventArgs e);
        void OnDeleted(FileSystemEventArgs e);
        void OnRenamed(RenamedEventArgs e);
    }
}
