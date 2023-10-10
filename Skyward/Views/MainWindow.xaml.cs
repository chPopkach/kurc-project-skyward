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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Skyward
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppContext appContext = new();
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Skyward"});
            DataContext = new MainWindowViewModel();
        }
        bool check = true;
        public void ChangeLanguage(object s, RoutedEventArgs e)
        {
            if (check == true)
            {
                var uri2 = new Uri(@"Resourses/English.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary2 = Application.LoadComponent(uri2) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
                check = false;
            }
            else
            {
                var uri2 = new Uri(@"Resourses/Russian.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary2 = Application.LoadComponent(uri2) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
                check = true;
            }
        }
    }
}
