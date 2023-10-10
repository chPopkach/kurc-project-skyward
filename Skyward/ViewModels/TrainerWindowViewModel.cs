using Skyward.Models;
using Skyward.Tools;
using Skyward.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Skyward.ViewModels
{
    public class TrainerWindowViewModel : BaseViewModel
    {
        AppContext appContext = new AppContext();

        private RelayCommand _startView;

        private RelayCommand _allClientsView;

        private RelayCommand _terminateSession;

        private RelayCommand _selectionClients;

        public RelayCommand SelectionClients
        {
            get
            {
                return _selectionClients ??
                    (_selectionClients = new RelayCommand(x =>
                    {
                        if (Day != null)
                        {
                            ObservableCollection<ScheduleHumen> selectionScheduleHumens = new ObservableCollection<ScheduleHumen>();
                            ObservableCollection<ScheduleHumen> scheduleHumens = new ObservableCollection<ScheduleHumen>(appContext.ScheduleHumens);
                            foreach (var item in scheduleHumens)
                            {
                                if (item.Schedule.WorkDays.Contains(Day))
                                {
                                    selectionScheduleHumens.Add(item);
                                }
                            }
                            Humens = new ObservableCollection<Humen>(selectionScheduleHumens.Select(h => h.Humen).Where(t => t.Id != 1 && t.Id != User.User_auth.HumenId));
                        }
                        else
                        {
                            DateTime DateNow = DateTime.UtcNow.Date;
                            Humens = new ObservableCollection<Humen>(appContext.Humens.Where(t => t.Id != User.User_auth.HumenId && t.TicketId != null && t.Ticket.DateOfDelay.Date >= DateNow.Date));

                            MessageBox.Show("Не выбран день для отбора по расписанию");
                        }
                        
                    }
                    ));
            }
        }

        private string _day;
        private List<string> _workDays;

        public List<string> WorkDays
        {
            get => _workDays;
            set
            {
                _workDays = value;
                OnPropertyChanged();
            }
        }

        public string Day
        {
            get => _day;
            set
            {
                _day = value;
                OnPropertyChanged();
            }
        }

        public void DynamicSearchTextBoxTrainerWindowViewModel(string text)
        {
            if (text == "")
            {
                Humens = new ObservableCollection<Humen>(appContext.Humens
                    .Where(t => t.Id != User.User_auth.HumenId && t.Id != 1));
            }
            else
            {
                Humens = new ObservableCollection<Humen>(appContext.Humens
                    .Where(t => t.Id != User.User_auth.HumenId && t.Id != 1)
                    .Where(x => x.FirstName.Contains(text)));
            }
        }

        public RelayCommand StartView
        {
            get
            {
                return _startView ??
                    (_startView = new RelayCommand(x =>
                    {
                        DateTime DateNow = DateTime.UtcNow.Date;
                        Humens = new ObservableCollection<Humen>(appContext.Humens
                            .Where(t => t.Id != User.User_auth.HumenId && t.TicketId != null && t.Ticket.DateOfDelay.Date >= DateNow.Date));
                    }
                    ));
            }
        }

        public RelayCommand AllClientsView
        {
            get
            {
                return _allClientsView ??
                    (_allClientsView = new RelayCommand(x =>
                    {
                        Humens = new ObservableCollection<Humen>(appContext.Humens
                            .Where(t => t.Id != User.User_auth.HumenId && t.Id != 1));
                    }
                    ));
            }
        }

        public RelayCommand TerminateSession
        {
            get
            {
                return _terminateSession ??
                    (_terminateSession = new RelayCommand(x =>
                    {
                        MainWindow window = new MainWindow();
                        window.Show();
                        foreach (var w in App.Current.Windows)
                            if (w is TrainerWindow tw)
                                tw.Close();
                    }
                    ));
            }
        }

        private ObservableCollection<Humen> _humens;

        private ObservableCollection<ScheduleHumen> _scheduleHumens;

        public ObservableCollection<Humen> Humens
        {
            get => _humens;
            set
            {
                _humens = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ScheduleHumen> ScheduleHumens
        {
            get => _scheduleHumens;
            set
            {
                _scheduleHumens = value;
                OnPropertyChanged();
            }
        }

        public TrainerWindowViewModel()
        {
            DateTime DateNow = DateTime.UtcNow.Date;
            Humens = new ObservableCollection<Humen>(appContext.Humens.Where(t => t.Id != User.User_auth.HumenId && t.TicketId != null && t.Ticket.DateOfDelay.Date >= DateNow.Date));
            WorkDays = new List<string>();
            WorkDays.Add("ПН");
            WorkDays.Add("ВТ");
            WorkDays.Add("СР");
            WorkDays.Add("ЧТ");
            WorkDays.Add("ПТ");
            WorkDays.Add("СБ");
            WorkDays.Add("ВС");
            Day = "";
        }
    }
}
