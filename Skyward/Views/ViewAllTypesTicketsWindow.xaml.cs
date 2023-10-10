using Skyward.Models;
using Skyward.Tools;
using Skyward.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ViewAllTypesTicketsWindow.xaml
    /// </summary>
    public partial class ViewAllTypesTicketsWindow : Window
    {
        public ViewAllTypesTicketsWindow()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Types tickets" });
            AppContext appContext = new AppContext();
            Typetickets_table.ItemsSource = new ObservableCollection<TypeTicket>(appContext.TypeTickets);
        }
    }
}
