using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TrackLauncher.Helpers;

namespace TrackLauncher.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate{ };
        private RelayCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if(_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(param => Close(), param => CanClose());
                }
                return _closeCommand;
            }
        }

        internal void RaisePropertyChanged(string property)
        {
            if(property != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event Action RequestClose;
        public virtual void Close()
        {
            RequestClose?.Invoke();
        }

        public virtual bool CanClose()
        {
            return true;
        }

     
    }
}
