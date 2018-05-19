using BolaoFiapUWP.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BolaoFiapUWP.Navegacao
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationView : Page
    {
        public NavigationView()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += On_BackRequested;
        }

        private void NavigationView_ItemInvoked(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (!args.IsSettingsInvoked)
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "Inicio":
                    ContentFrame.Navigate(typeof(Home));
                    break;
                case "Cadastro":
                    ContentFrame.Navigate(typeof(Home));
                    break;
                    //Colocar aqui as paginas para ser chamadas ao clicar no menu
            }
        }

        private void On_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!e.Handled && ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
                e.Handled = true;
            }
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                ContentFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            Dictionary<Type, string> lookup = new Dictionary<Type, string>()
                {
                    {typeof(Home), "Home"},
                };

            String stringTag = lookup[ContentFrame.SourcePageType];

            var navItem = NavView.MenuItems.FirstOrDefault(item => item is NavigationViewItem && ((NavigationViewItem)item).Tag.Equals(stringTag)) as NavigationViewItem;

            if (navItem != null)
            {
                navItem.IsSelected = true;
            }

        }
    }
}

