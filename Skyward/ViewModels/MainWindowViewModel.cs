using Skyward.Models;
using Skyward.Tools;
using Skyward.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Skyward.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        AppContext wpfContext = new AppContext();

        private RelayCommand _authorization;

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand Authorization
        {
            get
            {
                return _authorization ??
                    (_authorization = new RelayCommand(x =>
                    {
                        if (x is PasswordBox password)
                        {
                            User user = wpfContext.Users.FirstOrDefault(p => p.Login == User.Login && p.Password == password.Password);
                            if (user != null)
                            {
                                User.User_auth = user;
                                if (User.User_auth.RoleUser.Role_user == "А" || User.User_auth.RoleUser.Role_user == "К")
                                {
                                    ConsultantWindow window = new ConsultantWindow();
                                    window.Show();
                                    foreach (var w in App.Current.Windows)
                                        if (w is MainWindow mainWindow)
                                            mainWindow.Close();
                                }
                                else if (User.User_auth.RoleUser.Role_user == "Т")
                                {
                                    TrainerWindow window = new TrainerWindow();
                                    window.Show();
                                    foreach (var w in App.Current.Windows)
                                        if (w is MainWindow mainWindow)
                                            mainWindow.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверно введен пароль или логин.");
                            }
                        }
                    }
                    ));
            }
        }
        public MainWindowViewModel()
        {
            User = new User();
        }
    }
}
