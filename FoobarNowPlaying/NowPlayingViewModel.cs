using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoobarNowPlaying
{
    public class NowPlayingViewModel : INotifyPropertyChanged
    {
        private readonly string FoobarFilepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "foobar2000", "foobar2000.exe");

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

        }



        #region INPC Implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
