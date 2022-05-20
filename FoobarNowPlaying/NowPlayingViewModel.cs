using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace FoobarNowPlaying
{
    public class NowPlayingViewModel : INotifyPropertyChanged
    {
        private readonly string FoobarFilepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "foobar2000", "foobar2000.exe");
        private readonly int OneSecondDelayInMS = 1000;

        private string songName;
        private string artist;
        private string album;

        public string SongName
        {
            get => songName;
            set 
            { 
                songName = value;
                OnPropertyChanged(nameof(SongName));
            }
        }

        public string Artist
        {
            get => artist;
            set 
            { 
                artist = value; 
                OnPropertyChanged(nameof(Artist));
            }
        }

        public string Album
        {
            get => album;
            set 
            { 
                album = value;
                OnPropertyChanged(nameof(Album));
            }
        }

        public NowPlayingViewModel()
        {
            using Process foobarProcess = new();
            ProcessStartInfo startInfo = new()
            {
                FileName = FoobarFilepath
            };

            foobarProcess.StartInfo = startInfo;
            foobarProcess.Start();

            Thread.Sleep(OneSecondDelayInMS);

            while (!foobarProcess.HasExited)
            {
                FormatTrackTitleFromWindowTitle(foobarProcess);
            }
        }

        private string FormatTrackTitleFromWindowTitle(Process process)
        {
            throw new NotImplementedException();
        }

        #region INPC Implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
