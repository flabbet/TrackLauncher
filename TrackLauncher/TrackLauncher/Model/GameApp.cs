using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TrackLauncher.Model
{
    class GameApp : INotifyPropertyChanged
    {
        private string _appName;
        private static int _nextID = 0;
        private string _appPath;
        private BitmapSource _appImage;


        public string ApplicationName
        {
            get
            {
              return _appName;
            }
            set
            {
                if (_appName != value)
                {
                    _appName = value;
                    RaisePropertyChanged("ApplicationName");
                }
            }
        }

        public string AppPath
        {
            get
            {
                return _appPath;
            }
            set
            {
                if (_appPath != value)
                {
                    _appPath = value;
                    RaisePropertyChanged("ImagePath");
                }
            }
        }

        public BitmapSource AppImage
        {
            get
            {
                return _appImage;
            }
            set
            {
                if(_appImage != value)
                {
                    _appImage = value;
                    RaisePropertyChanged("AppImage");
                }
            }
        }

        public int ID { get; }

        public GameApp(string appName, string appPath)
        {
            ApplicationName = appName;
            AppPath = appPath;
            AppImage = ShellFile.FromFilePath(AppPath).Thumbnail.SmallBitmapSource;
            ID = _nextID;
            _nextID++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
