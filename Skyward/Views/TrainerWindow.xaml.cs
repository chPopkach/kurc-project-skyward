using Skyward.Models;
using Skyward.Tools;
using Skyward.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Skyward.Views
{
    /// <summary>
    /// Логика взаимодействия для TrainerWindow.xaml
    /// </summary>
    public partial class TrainerWindow : Window
    {
        public TrainerWindow()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = String.Format("{0} {1} {2}", User.User_auth.Humen.FirstName, User.User_auth.Humen.Name, User.User_auth.Humen.LastName) });
            DataContext = trainerWindowViewModel = new TrainerWindowViewModel();
        }

        private TrainerWindowViewModel trainerWindowViewModel;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainerWindowViewModel.DynamicSearchTextBoxTrainerWindowViewModel(DynamicSearchTextBoxTrainerWindowViewModel.Text);
        }
    }
}
