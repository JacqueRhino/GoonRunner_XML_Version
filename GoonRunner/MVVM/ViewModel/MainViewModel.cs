using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoonRunner.MVVM.View;
using System.Windows.Input;
using System.Windows;

namespace GoonRunner.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool isLoaded { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                isLoaded = true;
                if (p == null)
                    return;
                LogIn loginWindow = new LogIn();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginWM = loginWindow.DataContext as LoginViewModel;
                if (loginWM.isLogin)
                    p.Show();
                else
                    p.Close();
            });
        }
    }
}
