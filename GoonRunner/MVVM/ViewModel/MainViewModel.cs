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
        public SidebarNhanVienViewModel SidebarNhanVienVM { get; set; }
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
        
        private object _currentSidebarView;

        public object CurrentSidebarView
        {
            get { return _currentSidebarView; }
            set
            {
                _currentSidebarView = value;
                OnPropertyChanged("CurrentSidebarView");
            }
        }
        
        private bool _sidebarButtonEnabled;

        public bool SidebarButtonEnabled
        {
            get { return _sidebarButtonEnabled; }
            set
            {
                _sidebarButtonEnabled = value;
                OnPropertyChanged("SidebarButtonEnabled");
            }
        }

        private int _sidebarLeftGapWidth;

        public int SidebarLeftGapWidth
        {
            get { return _sidebarLeftGapWidth; }
            set
            {
                _sidebarLeftGapWidth = value;
                OnPropertyChanged("SidebarLeftGapWidth");
            }
        }

        private int _sidebarWidth;

        public int SidebarWidth
        {
            get { return _sidebarWidth; }
            set
            {
                _sidebarWidth = value;
                OnPropertyChanged("SidebarWidth");
            }
        }

        private string _split2Enabled;

        public string Split2Enabled
        {
            get { return _split2Enabled; }
            set
            {
                _split2Enabled = value;
                OnPropertyChanged("Split2Enabled");
            }
        }

        public MainViewModel()
        {
            
            HomeVM = new HomeViewModel();
            NhanVienVM = new NhanVienViewModel();
            SidebarNhanVienVM = new SidebarNhanVienViewModel();
            CurrentView = HomeVM;
            // DisableSidebar();
            
            //Change View

            HomeViewCommand = new Wpf.Ui.Input.RelayCommand<RadioButton>(o =>
            {
                CurrentView = HomeVM;
                DisableSidebar();

            });
            
            NhanVienViewCommand = new Wpf.Ui.Input.RelayCommand<RadioButton>(o =>
            {
                CurrentView = NhanVienVM;
                CurrentSidebarView = SidebarNhanVienVM;
                EnableSidebar();
            });
            
            SignOutCommand = new RelayCommand<Window>((p) => true, (p) =>
            {
                p.Hide();
                LogInView loginWindow = new LogInView();
                var loginWM = loginWindow.DataContext as LoginViewModel;
                loginWM.UserName = "";
                loginWM.Password = "";
                loginWM.ErrorMassage = "";
                loginWindow.Show();
            });
        }

        private void EnableSidebar()
        {
            SidebarButtonEnabled = true;
        }
        private void DisableSidebar()
        {
            SidebarButtonEnabled = false;
        }
    }
}
