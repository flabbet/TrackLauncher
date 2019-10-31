using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrackLauncher.Helpers;
using TrackLauncher.Model;
using TrackLauncher.Views;

namespace TrackLauncher.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        public ObservableCollection<GameApp> GameApps { get; set; } = new ObservableCollection<GameApp>();
        public RelayCommand LaunchCommand { get; set; }
        public RelayCommand AddAppCommand { get; set;}
        private GameApp _selectedApp;

        public GameApp SelectedApp
        {
            get { return _selectedApp; }
            set
            {
                if (value != null)
                {
                    _selectedApp = value;
                    RaisePropertyChanged("SelectedApp");
                }
            }
        }


        public ViewModelMain()
        {
            LaunchCommand = new RelayCommand(OnLaunch, CanLaunch);
            AddAppCommand = new RelayCommand(AddApp);
        }

        private void OnLaunch(object parameter)
        {
            Process.Start(SelectedApp.AppPath);
        }

        private void AddApp(object parameter)
        {
            Popup newAppPopup = new Popup();
            newAppPopup.ShowDialog();
            if (NewAppInfo.appName == null || NewAppInfo.appPath == null) return;

            GameApps.Add(new GameApp(NewAppInfo.appName, NewAppInfo.appPath));
            SelectedApp = GameApps.Last();
            NewAppInfo.ResetValues();
        }

        private bool CanLaunch(object property)
        {
            return SelectedApp != null;
        }
    }
}
