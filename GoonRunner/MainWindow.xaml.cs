using System.Windows;
using System.Windows.Input;

namespace GoonRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ClosedOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizedOnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DragMoving(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}