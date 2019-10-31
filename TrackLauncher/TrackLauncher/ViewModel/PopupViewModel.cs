using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TrackLauncher.Helpers;
using TrackLauncher.Model;
using TrackLauncher.Views;
using static System.String;

namespace TrackLauncher.ViewModel
{
    class PopupViewModel : ViewModelBase
    {
        private string _newApplicationName;
        private string _newApplicationPath;
        private string _pathButtonBackgroundColor;
        public RelayCommand OkCommand { get; set; }
        public RelayCommand PickPath { get; set; }

        public string NewApplicationName
        {
            get { return _newApplicationName; }
            set
            {
                if (_newApplicationName != value)
                {
                    _newApplicationName = value;
                    RaisePropertyChanged("NewApplicationName");
                }
            }
        }


        public string NewApplicationPath {
            get
            {
                return _newApplicationPath;
            }
            set
            {
                if (_newApplicationPath != value)
                {
                    _newApplicationPath = value;
                    RaisePropertyChanged("NewApplicationPath");
                }
            }
        }

        public string PathButtonBorderColor
        {
            get
            {
                return _pathButtonBackgroundColor;
            }
            set
            {
                if(_pathButtonBackgroundColor != value)
                {
                    _pathButtonBackgroundColor = value;
                    RaisePropertyChanged("PathButtonBorderColor");
                }
            }
        }

        public PopupViewModel()
        {
            OkCommand = new RelayCommand(ClosePopup, CanClickOk);
            PickPath = new RelayCommand(SelectPath);
            PathButtonBorderColor = "#f08080";
        }

        private void SelectPath(object property)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Select Application Directory", DereferenceLinks = true
            };
            dialog.ShowDialog();    
            
            NewApplicationPath = dialog.FileName;

            if (IsNullOrEmpty(NewApplicationName))
            {
                NewApplicationName = dialog.SafeFileName.Split('.')[0];
            }

            PathButtonBorderColor = IsNullOrEmpty(dialog.FileName) == false ? "#b8f080" : "#f08080";

        }

        private bool CanClickOk(object property)
        {
            return !IsNullOrEmpty(NewApplicationPath) || !IsNullOrWhiteSpace(NewApplicationName);
        }

        private void ClosePopup(object property)
        {
            NewAppInfo.appName = NewApplicationName;
            NewAppInfo.appPath = NewApplicationPath;
            this.Close();
        }
    }
}
