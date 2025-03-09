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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}