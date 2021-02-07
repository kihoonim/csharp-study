using System;
using System.IO;

namespace FileChecker.Listener
{
    public class Watcher : IDisposable
    {
        private bool disposedValue = false;
        private readonly FileSystemWatcher _watcher;

        public Watcher(
            string path,
            string filter,
            NotifyFilters notifyFilters,
            IWatcherActions actions)
        {
            _watcher = new FileSystemWatcher();

            _watcher.Path = path;
            _watcher.Filter = filter;
            _watcher.NotifyFilter = notifyFilters;

            _watcher.Changed += (object source, FileSystemEventArgs e) => { actions.OnChanged(e); };
            _watcher.Created += (object source, FileSystemEventArgs e) => { actions.OnCreated(e); };
            _watcher.Deleted += (object source, FileSystemEventArgs e) => { actions.OnDeleted(e); };
            _watcher.Renamed += (object source, RenamedEventArgs e) => { actions.OnRenamed(e); };
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                _watcher.Dispose();

                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~Watcher()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
