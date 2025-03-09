using System;
using System.Windows;
using System.Windows.Input;

namespace GoonRunner.MVVM.View
{
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        private void DragAndmove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ClosedOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizedOnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private bool AuthenticateSuccessful()
        {
            return true;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthenticateSuccessful())
            {
                MainWindow mainWindow = new MainWindow();
                App.Current.MainWindow = mainWindow;
                this.Close();
                mainWindow.Show();
            }
        }
        
    }
}