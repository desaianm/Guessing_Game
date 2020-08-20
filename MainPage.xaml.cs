using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//using Windows.UI.Popups;


namespace Quiz_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Random rnd = new Random();
        private int guessnum = 0;
        private Boolean result = false;
        int a = 1;
        int b = 2;
        int c = 3;
        public MainPage()
        {
            Startup();
        }

        public int Guessnum { get => guessnum; set => guessnum = value; }
        public bool Result { get => result; set => result = value; }

        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            var text = Num1_Button.Content.ToString();
            a = int.Parse(text);
            Num3_Button.Background = new SolidColorBrush(Windows.UI.Colors.Gray);

            if (a == guessnum) {
                Num1_Button.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                Result = true;
            }
            else {
                Num1_Button.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                Result = false;
            }
            Message();
        }

        private void Num2_Click(object sender, RoutedEventArgs e)
        {
            var text = Num2_Button.Content.ToString();
            b = int.Parse(text);

            if (b == guessnum)
            {
                Num2_Button.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                Result = true;
            }
            else
            {
                Num2_Button.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                Result = false;
            }
            Message();

        }

        private void Num3_Click(object sender, RoutedEventArgs e)
        {
            var text = Num3_Button.Content.ToString();
            c = int.Parse(text);
            if (c == guessnum)
            {
                Num3_Button.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                Result = true;
            }
            else
            {
                Num3_Button.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                Result = false;

            }
            Message();
        }
        private void Startup()
        {
            Random rnd = new Random();
            guessnum = rnd.Next(1, 10);
            int a = 0;
            int b = 0;
            int c = 0;
            this.InitializeComponent();

            Num1_Button.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
            Num2_Button.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
            Num3_Button.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
            if (guessnum > 5)
            {
                if (guessnum > 8)
                {
                    a = guessnum;
                    b = guessnum - 1;
                    c = guessnum - 2;
                }
                else if (guessnum < 8)
                {
                    a = guessnum;
                    b = guessnum + 1;
                    c = guessnum + 2;

                }


            }
            else if (guessnum <= 5)
            {
                a = guessnum;
                b = guessnum + 1;
                c = guessnum + 2;


            }
            else
            {
                guessnum = rnd.Next(1,10);
                if (guessnum <1)
                {
                    guessnum += 1;
                }
                
            }
            Num1_Button.Content = a;
            Num2_Button.Content = b;
            Num3_Button.Content = c;

        }
        private async void Message()
        {
            string msg = "";
            if (Result)
            {
                msg = "You Won !!!!!! Would you like to Play Again? ";
            }
            else
            {
                msg = "You Lost !!!!!! Would you like to Play Again?";
            }
            var messageDialog = new MessageDialog(msg);
           

            messageDialog.Commands.Add(new UICommand(
                "OK", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand(
                "Close", new UICommandInvokedHandler(this.CommandInvokedHandler)));

          
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;

            await messageDialog.ShowAsync();



           // var dialog = new MessageDialog("Would you like to Play Again?");
           // await dialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Close") {

                Application.Current.Exit();
            }
            else
            {
                Startup();
            }

        }
    }
    }
