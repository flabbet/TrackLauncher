using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrackLauncher.Model;
using TrackLauncher.ViewModel;

namespace TrackLauncher.Views
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Popup()
        {
            InitializeComponent();
        }

        private void Popup_Loaded(object sender, RoutedEventArgs e)
        {
            PopupViewModel viewModel = new PopupViewModel();
            DataContext = viewModel;
            viewModel.RequestClose += () => { Close(); };
        }
    }
}
