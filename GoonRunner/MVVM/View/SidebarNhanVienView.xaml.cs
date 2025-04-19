using System.Windows;
using System.Windows.Controls;

namespace GoonRunner.MVVM.View
{
    public partial class SidebarNhanVienView : UserControl
    {
        public SidebarNhanVienView()
        {
            InitializeComponent();
        }

        private void Test(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}