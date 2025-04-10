using GoonRunner.MVVM.View;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace GoonRunner.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand HomeViewCommand { get; set; }
        public ICommand NhanVienViewCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public NhanVienViewModel NhanVienVM { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public MainViewModel()
        {
            
            HomeVM = new HomeViewModel();
            NhanVienVM = new NhanVienViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new Wpf.Ui.Input.RelayCommand<RadioButton>(o =>
            {
                CurrentView = HomeVM;
            });
            
            NhanVienViewCommand = new Wpf.Ui.Input.RelayCommand<RadioButton>(o =>
            {
                CurrentView = NhanVienVM;
            });
            
            SignOutCommand = new RelayCommand<Window>((p) => true, (p) =>
            {
                p.Hide();
                LogIn loginWindow = new LogIn();
                var loginWM = loginWindow.DataContext as LoginViewModel;
                loginWM.UserName = "";
                loginWM.Password = "";
                loginWM.ErrorMassage = "";
                loginWindow.Show();
            });
        }
    }
}
