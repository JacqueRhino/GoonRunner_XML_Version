using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace GoonRunner.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

        }
        private void ClosedOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeOnClick(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Maximized ?
                WindowState.Normal : WindowState.Maximized);                
        }

        private void MinimizedOnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DragMoving(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left) return;
            if (WindowState == WindowState.Maximized)
            {
                var point = e.GetPosition(this);
                Top = 0;
                Left = (Width > point.X ?  point.X/2 : Width/2 + point.X );
                WindowState = WindowState.Normal;
            }

            DragMove();
        }
        
        private Point GetMousePosition(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(this);
            return new Point(point.X, point.Y);
        }
        
        private void SetMenuWidth(object sender, DragDeltaEventArgs e)
        {
            if (MainGrid.ColumnDefinitions[1].Width.Value < 205)
                MainGrid.ColumnDefinitions[1].Width = new GridLength(95);
        }
    }
}