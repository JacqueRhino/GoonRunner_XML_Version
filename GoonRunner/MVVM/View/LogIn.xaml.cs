using System.Windows;
using System.Windows.Input;

namespace GoonRunner.MVVM.View
{
    public partial class LogIn 
    {
        public LogIn()
        {
            InitializeComponent();
        }
        private void DragMoving(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
            if (!AuthenticateSuccessful()) return;
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }
        
    }
}