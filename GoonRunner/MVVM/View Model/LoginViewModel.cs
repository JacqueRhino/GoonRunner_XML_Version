using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using GoonRunner.MVVM.Model;
using System.Security.Cryptography;

namespace GoonRunner.MVVM.View_Model
{
    class LoginViewModel : BaseViewModel
    {
        public bool isLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            isLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login(Window p)
        {
            
            if (p == null)
                return;


            string passEncode = MD5Hash(Password);
            var accCount = DataProvider.Ins.goonRunnerDB.ACCNHANVIENs.Where(Record => Record.UserName == UserName && Record.Pass == passEncode).Count();


            if (accCount > 0)
            {
                isLogin = true;
                MessageBox.Show("Bạn đã đăng nhập thành công!"); 
                p.Close();
            }
            else
            {
                MessageBox.Show("Username hoặc Password bị sai, vui lòng nhập lại.");
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
