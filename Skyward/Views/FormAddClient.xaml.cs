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
    /// Логика взаимодействия для FormAddClient.xaml
    /// </summary>
    public partial class FormAddClient : Window
    {
        public FormAddClient()
        {
            InitializeComponent();
            System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "New client" });
            DataContext = new FormAddClientViewModel();
        }
    }
}
