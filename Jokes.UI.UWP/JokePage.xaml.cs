using Jokes.Core.Controllers;
using Jokes.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Jokes.UI.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JokePage : Page
    {
        public CategoryType Category { get; set; }

        private Joke Joke { get; set; }
        private JokeManager JokeManager = ((App)Application.Current).JokeManager;
        public JokePage()
        {
            this.InitializeComponent();
            Category = CategoryType.None;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Category = (CategoryType)e.Parameter;
            await ShowJokeAsync();
        }

        public async Task ShowJokeAsync()
        {
            JokeProggress.IsActive = true;
            JokePanel.Visibility = Visibility.Collapsed;
            switch (Category)
            {
                case CategoryType.None:
                    Joke = await JokeManager.GetRandomJoke();
                    break;
                case CategoryType.General:
                    Joke = await JokeManager.GetGeneralJoke();
                    break;
                case CategoryType.Programming:
                    Joke = await JokeManager.GetProgrammingJoke();
                    break;
                default:
                    break;
            }

            if(Joke != null)
            {
                SetupText.Text = Joke.Setup;
                PunclineText.Text = Joke.Punchline;
            }
            JokePanel.Visibility = Visibility.Visible;
            JokeProggress.IsActive = false;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await ShowJokeAsync();
        }
    }
}
