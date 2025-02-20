using ClientSeries.Models;
using ClientSeries.Services;
using ClientSeries.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientSeries.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSeriesPage : Page
    {
        public AddSeriesPage()
        {
            this.InitializeComponent();
            this.DataContext = App.Current.Services.GetService<AddSeriesViewModel>();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = args.SelectedItem as NavigationViewItem;
            if (selectedItem != null)
            {
                string tag = selectedItem.Tag.ToString();
                switch (tag)
                {
                    case "Add":
                        ContentFrame.Navigate(typeof(AddSeriesPage));
                        break;
                    case "PutOrDelete":
                        ContentFrame.Navigate(typeof(GetDeleteOrPutSeriesPage));
                        break;
                }
            }
        }
    }
}
