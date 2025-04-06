using System.Linq;
using System.Security.Cryptography;
using System.Text;
using GoonRunner.MVVM.Model;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace GoonRunner.MVVM.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _userName;
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }
        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => true, Login);
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => { Password = p.Password; });
        }

        private void Login(Window p)
        {

            if (p == null)
                return;

            
            if (string.IsNullOrEmpty(UserName))
            {
                MessageBox.Show("Xin hãy nhập tên người dùng");
                return;
            }

            if (UserName.Length < 3)
            {
                MessageBox.Show("Tên người dùng phải dài ít nhất là 3 ký tự");
                return;
            }
            
            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Xin hãy nhập mật khẩu");
                return;
            }
            
            if (Password.Length < 3)
            {
                MessageBox.Show("Mật khẩu phải dài ít nhất là 3 ký tự");
                return;
            }
            string passEncode = MD5Hash(Password);
            var accCount = DataProvider.Ins.goonRunnerDB.ACCNHANVIENs.Count(record => record.UserName == UserName && record.Pass == passEncode);


            if (accCount > 0)
            {
                IsLogin = true;
                MessageBox.Show("Bạn đã đăng nhập thành công!");
                p.Close();
            }
            else
            {
                MessageBox.Show("Username hoặc Password bị sai, vui lòng nhập lại.");
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
