using System.Linq;
using System.Security.Cryptography;
using System.Text;
using GoonRunner.MVVM.Model;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using GoonRunner.MVVM.View;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace GoonRunner.MVVM.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public class Taikhoan
        {
            public string Displayname { get; set; }
            public string Privilege { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public ObservableCollection<Taikhoan> taikhoans { get; set; }
        public bool IsLogin { get; set; }
        private string _userName;
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }

        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        private string _placeholder;
        public string Placeholder { get => _placeholder; set { _placeholder = value; OnPropertyChanged(); } }

        private string _errormessage;
        public string ErrorMassage { get => _errormessage; set { _errormessage = value; OnPropertyChanged(); } }

        private string _privilege;
        public string Privilege { get => _privilege; set { _privilege = value; OnPropertyChanged(); } }

        private string _displayname;
        public string DisplayName { get => _displayname; set { _displayname = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }

        public LoginViewModel()
        {
            taikhoans = new ObservableCollection<Taikhoan>();
            XDocument doc = XDocument.Load(@"Data\Taikhoan.xml");
            foreach (var element in doc.Descendants("Taikhoan"))
            {
                taikhoans.Add(new Taikhoan
                {
                    Displayname = element.Element("Displayname").Value,
                    Privilege = element.Element("Privilege").Value,
                    Username = element.Element("Username").Value,
                    Password = element.Element("Password").Value,
                });
            }
            IsLogin = false;
            Placeholder = "Nhập mật khẩu";
            LoginCommand = new RelayCommand<Window>((p) => true, (p) => Login(p));
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) =>
            {
                if (string.IsNullOrEmpty(p.Password))
                {
                    Placeholder = "Nhập mật khẩu";
                }
                else
                    Placeholder = "";
                Password = p.Password;
            });

            ForgotPasswordCommand = new RelayCommand<Window>((p) => true, (p) => 
            {
                var forgotPasswordView = new ForgotPasswordView();
                forgotPasswordView.Show();
                p.Hide();
            });
        }

        private void LoginBYPASS(Window p)
        {
            IsLogin = true;
            p.Hide();
            MainWindowView mainwindow = new MainWindowView();
            mainwindow.Show();
        }
        private void Login(Window p)
        {
            if (p == null)
                return;
            
            if (string.IsNullOrEmpty(UserName))
            {
                ErrorMassage = "Hãy nhập tên người dùng";
                return;
            }

            if (UserName.Length < 3)
            {
                ErrorMassage = "Tên người dùng phải dài ít nhất là 3 ký tự";
                return;
            }
            
            if (string.IsNullOrEmpty(Password))
            {
                ErrorMassage = "Hãy nhập mật khẩu";
                return;
            }
            
            if (Password.Length < 3)
            {
                ErrorMassage = "Mật khẩu phải dài ít nhất là 3 ký tự";
                return;
            }

            // Kiểm tra tài khoản
            if (CheckAccount())
            {
                IsLogin = true;
                Placeholder = "Nhập mật khẩu";
                MainWindowView mainwindow = new MainWindowView();
                var MainVM = mainwindow.DataContext as MainViewModel;
                MainVM.DisplayName = DisplayName; // Gắn DisplayName qua bên MainWindow
                MainVM.Privilege = Privilege; // Gắn Privilege qua bên MainWindow
                mainwindow.Show();
                p.Hide();
            }
            else
            {
                ErrorMassage = "Tên tài khoản hoặc mật khẩu không đúng.";
            }
        }

        private bool CheckAccount()
        {
            int accCount = taikhoans.Where(p => p.Username == UserName && p.Password == Password).Count();
            if (accCount > 0)
            {
                DisplayName = taikhoans.Where(p => p.Username == UserName && p.Password == Password).Select(p => p.Displayname).FirstOrDefault();
                Privilege = taikhoans.Where(p => p.Username == UserName && p.Password == Password).Select(p => p.Privilege).FirstOrDefault();
                return true;
            }
            else
            {
                return false;
            }
        }
        private static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            foreach (var t in bytes)
            {
                hash.Append(t.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
