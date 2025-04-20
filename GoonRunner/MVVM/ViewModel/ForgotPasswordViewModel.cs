using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GoonRunner.MVVM.View;

namespace GoonRunner.MVVM.ViewModel
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        public ICommand ReturnCommand { get; set; }
        public ForgotPasswordViewModel()
        {
            ReturnCommand = new RelayCommand<Window>(p =>
            {
                LogInView loginView = new LogInView();
                loginView.Show();
                p.Hide();
            });
        }
    }
}
