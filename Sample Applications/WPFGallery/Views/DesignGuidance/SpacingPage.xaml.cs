using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using WPFGallery.Helpers;
using WPFGallery.ViewModels;

namespace WPFGallery.Views
{
    /// <summary>
    /// Interaction logic for SpacingPage.xaml
    /// </summary>
    public partial class SpacingPage : Page
    {
        public SpacingPageViewModel ViewModel { get; }

        public SpacingPage(SpacingPageViewModel viewModel)
        {
            InitializeComponent();
            UpdateImageResources();
            ViewModel = viewModel;
            DataContext = this;
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                UpdateImageResources();
            });
        }

        private void UpdateImageResources()
        {
            if (Utility.IsLightTheme())
            {
                DialogImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Design/Dialog.light.png"));
                CardImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Design/Cards.light.png"));
            }
            else
            {
                DialogImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Design/Dialog.dark.png"));
                CardImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Design/Cards.dark.png"));
            }
        }
    }
}
