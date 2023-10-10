using Skyward.Models;
using Skyward.Tools;
using Skyward.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Skyward.ViewModels
{
    public class FormAddClientViewModel : BaseViewModel
    {
        AppContext appContext = new AppContext();

        private RelayCommand _add;

        private RelayCommand _insertDay;

        private List<string> _days;

        public RelayCommand InsertDay
        {
            get
            {
                return _insertDay ??
                    (_insertDay = new RelayCommand(x =>
                    {
                        bool inList = _days.Contains(Day);
                        if (inList == false)
                        {
                            _days.Add(Day);
                            Schedule.WorkDays += Day + ", ";
                        }
                        else
                        {
                            MessageBox.Show("День уже задан");
                        }
                    }
                    ));
            }
        }

        public RelayCommand Add
        {
            get
            {
                return _add ??
                    (_add = new RelayCommand(x =>
                    {
                        if (Humen.FirstName != "" && Humen.Name != "" && Humen.Age != 0 && Humen.Phone.Length == 11 && Male != "" 
                            && TimeHourStart != "" && TimeHourFinish != "" && Schedule.WorkDays.Count() >= 2 && TypeTicket != null)
                        {
                            if (TimeHourStart != TimeHourFinish)
                            {
                                bool check = true;
                                foreach (var symbol in Humen.Phone)
                                    if (!char.IsDigit(symbol))
                                    {
                                        check = false;
                                        break;
                                    }
                                if (Humen.Phone.StartsWith("8") && check == true)
                                {
                                    Ticket newTicket = new Ticket();
                                    newTicket.Id = appContext.Tickets.Count() + 1;
                                    newTicket.TypeTicketId = TypeTicket.Id;
                                    newTicket.PurchaseDate = DateTime.UtcNow.Date;
                                    if (newTicket.TypeTicketId == 1)
                                    {
                                        int days = 1;
                                        newTicket.DateOfDelay = DateTime.UtcNow.Date.AddDays(days);
                                    }
                                    else if (newTicket.TypeTicketId == 2)
                                    {
                                        int days = 7;
                                        newTicket.DateOfDelay = DateTime.UtcNow.Date.AddDays(days);
                                    }
                                    else if (newTicket.TypeTicketId == 3)
                                    {
                                        int days = 30;
                                        newTicket.DateOfDelay = DateTime.UtcNow.Date.AddDays(days);
                                    }
                                    else if (newTicket.TypeTicketId == 4)
                                    {
                                        int year = 1;
                                        newTicket.DateOfDelay = DateTime.UtcNow.Date.AddYears(year);
                                    }
                                    appContext.Tickets.Add(newTicket);
                                    appContext.SaveChanges();

                                    Schedule newSchedule = new Schedule();
                                    newSchedule.Id = appContext.Schedules.Count() + 1;
                                    newSchedule.WorkTimeStart = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                                        int.Parse(TimeHourStart.Substring(0, 2)), 0, 0);
                                    newSchedule.WorkTimeEnd = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                                        int.Parse(TimeHourFinish.Substring(0, 2)), 0, 0);
                                    Schedule.WorkDays.Remove(Schedule.WorkDays.Length - 2);
                                    newSchedule.WorkDays = Schedule.WorkDays.ToUpper().TrimEnd(',');
                                    appContext.Schedules.Add(newSchedule);
                                    appContext.SaveChanges();

                                    Humen newHumen = new Humen();
                                    newHumen.Id = appContext.Humens.Count() + 1;
                                    newHumen.FirstName = Humen.FirstName.Replace(" ", "").Substring(0, 1).ToUpper() + Humen.FirstName.Replace(" ", "").Substring(1);
                                    newHumen.Name = Humen.Name.Replace(" ", "").Substring(0, 1).ToUpper() + Humen.Name.Replace(" ", "").Substring(1);
                                    newHumen.LastName = Humen.LastName.Replace(" ", "").Substring(0, 1).ToUpper() + Humen.LastName.Replace(" ", "").Substring(1);
                                    newHumen.Phone = Humen.Phone;
                                    newHumen.Age = Humen.Age;
                                    newHumen.Male = Male;
                                    newHumen.TicketId = newTicket.Id;
                                    appContext.Humens.Add(newHumen);
                                    appContext.SaveChanges();

                                    ScheduleHumen newScheduleHumen = new ScheduleHumen();
                                    newScheduleHumen.Id = appContext.ScheduleHumens.Count() + 1;
                                    newScheduleHumen.ScheduleId = newSchedule.Id;
                                    newScheduleHumen.HumenId = newHumen.Id;
                                    appContext.ScheduleHumens.Add(newScheduleHumen);
                                    appContext.SaveChanges();

                                    foreach (var w in App.Current.Windows)
                                        if (w is FormAddClient fac)
                                            fac.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Номер должен начинаться с 8 и должен иметь 11 цифр");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Время начало и конца не может быть одинаковым.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Все поля должны быть заполненными или неправильно заполнено поле.");
                        }
                    }
                    ));
            }
        }

        private ObservableCollection<TypeTicket> _typeTickets;

        private TypeTicket _typeTicket;

        public TypeTicket TypeTicket
        {
            get => _typeTicket;
            set
            {
                _typeTicket = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TypeTicket> TypeTickets
        {
            get => _typeTickets;
            set
            {
                _typeTickets = value;
                OnPropertyChanged();
            }
        }

        private List<string> _timeHour;
        private List<string> _males;

        private string _timeHourStart;
        private string _timeHourFinish;
        private string _male;

        public string TimeHourStart
        {
            get => _timeHourStart;
            set
            {
                _timeHourStart = value;
                OnPropertyChanged();
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

        public string Male
        {
            get => _male;
            set
            {
                _male = value;
                OnPropertyChanged();
            }
        }

        public string TimeHourFinish
        {
            get => _timeHourFinish;
            set
            {
                _timeHourFinish = value;
                OnPropertyChanged();
            }
        }

        public List<string> Males
        {
            get => _males;
            set
            {
                _males = value;
                OnPropertyChanged();
            }
        }

        public List<string> TimeHour
        {
            get => _timeHour;
            set
            {
                _timeHour = value;
                OnPropertyChanged();
            }
        }

        private Humen _humen;

        private Schedule _schedule;

        private Ticket _ticket;

        public Humen Humen
        {
            get => _humen;
            set
            {
                _humen = value;
                OnPropertyChanged();
            }
        }
        public Schedule Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }
        public Ticket Ticket
        {
            get => _ticket;
            set
            {
                _ticket = value;
                OnPropertyChanged();
            }
        }

        public FormAddClientViewModel()
        {
            Humen = new Humen();
            Schedule = new Schedule();
            Ticket = new Ticket();
            TypeTickets = new ObservableCollection<TypeTicket>(appContext.TypeTickets);
            TypeTicket = new TypeTicket();

            TimeHour = new List<string>();
            TimeHourStart = "";
            TimeHourFinish = "";
            for (int i = 0; i < 24; i++)
            {
                if (i >= 0 && i < 10)
                {
                    TimeHour.Add($"0" + i + ":00");
                }
                else
                {
                    TimeHour.Add($"" + i + ":00");
                }
            }
            Males = new List<string>();
            Male = "";
            Males.Add("Женский");
            Males.Add("Мужской");

            WorkDays = new List<string>();
            WorkDays.Add("ПН");
            WorkDays.Add("ВТ");
            WorkDays.Add("СР");
            WorkDays.Add("ЧТ");
            WorkDays.Add("ПТ");
            WorkDays.Add("СБ");
            WorkDays.Add("ВС");
            Day = "";

            _days = new List<string>();
        }
    }
}
