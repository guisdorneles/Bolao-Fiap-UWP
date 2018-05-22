using BolaoFiapUWP.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BolaoFiapUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            switch (((Button)sender).Tag)
            {
                case "Home":
                    var email = txtEmail.Text;
                    var senha = txtPassword.Password;
                    //Metodo para validar o Login 
                    Notificacao("teste1", "teste2");
                    Frame.Navigate(typeof(Navegacao.NavigationView));
                    break;
                case "Cadastro":
                    Frame.Navigate(typeof(CadastroUsuario));
                    break;

            }
        }
        private void Notificacao(string titulo, string msg)
        {
            XmlDocument toastXml = new XmlDocument();

            string toastXmlString =
            $@"<toast>
                <visual>
                  <binding template='ToastGeneric'>
                    <text>{titulo.Trim()}</text>
                    <text>{msg.Trim()}</text>
                  </binding>
                </visual>
            </toast>";

            toastXml.LoadXml(toastXmlString);

            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
