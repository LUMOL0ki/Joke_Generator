using Jokes.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Jokes.UI.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationViewItem SelectedItem;

        public MainPage()
        {
            this.InitializeComponent();
            JokeNavView.SelectedItem = HomeItem;
            JokeNavView.Header = HomeItem.Tag;
            SelectedItem = HomeItem;
            JokeFrame.Navigate(typeof(JokePage), CategoryType.None);
        }

        private void JokeNavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = sender.SelectedItem as NavigationViewItem;

            if (SelectedItem != item)
            {
                switch (item.Tag)
                {
                    case "Home":
                        JokeFrame.Navigate(typeof(JokePage), CategoryType.None);
                        break;
                    case "General":
                        JokeFrame.Navigate(typeof(JokePage), CategoryType.General);
                        break;
                    case "Programming":
                        JokeFrame.Navigate(typeof(JokePage), CategoryType.Programming);
                        break;
                    case"Info":
                        JokeFrame.Navigate(typeof(InfoPage));
                        break;
                    default:
                        break;
                }

                JokeNavView.Header = item.Content.ToString();
                SelectedItem = item;
            }
        }
        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*
            NavigationViewItem item = sender as NavigationViewItem;
            if (JokeNavView.SelectedItem != item)
            {
                JokeNavView.SelectedItem = item;
                SelectedItem = item;
            }*/
        }
    }
}
