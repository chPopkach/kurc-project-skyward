using Skyward.Models;
using Skyward.Tools;
using Skyward.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Skyward.ViewModels
{
    public class FormChangeScheduleViewModel : BaseViewModel
    {
        AppContext appContext = new AppContext();

        private RelayCommand _changeScheduleCommand;

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

        public RelayCommand ChangeScheduleCommand
        {
            get
            {
                return _changeScheduleCommand ??
                    (_changeScheduleCommand = new RelayCommand(x =>
                    {
                        if (TimeHourStart != "" && TimeHourFinish != "" && Schedule.WorkDays.Count() >= 2 && TimeHourStart != TimeHourFinish)
                        {
                            ScheduleHumen? scheduleHumen = new ScheduleHumen();
                            scheduleHumen = appContext.ScheduleHumens.FirstOrDefault(x => x.HumenId == Humen.Humen_change.Id);
                            if (scheduleHumen != null)
                            {
                                appContext.ScheduleHumens.Remove(scheduleHumen);
                                appContext.Schedules.Remove(scheduleHumen.Schedule);
                                appContext.SaveChanges();
                            }
                            Schedule newSchedule = new Schedule();
                            newSchedule.Id = scheduleHumen.Schedule.Id;
                            newSchedule.WorkTimeStart = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                                int.Parse(TimeHourStart.Substring(0, 2)), 0, 0);
                            newSchedule.WorkTimeEnd = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                                int.Parse(TimeHourFinish.Substring(0, 2)), 0, 0);
                            Schedule.WorkDays.Remove(Schedule.WorkDays.Length - 2);
                            newSchedule.WorkDays = Schedule.WorkDays.ToUpper().TrimEnd(',');
                            appContext.Schedules.Add(newSchedule);
                            appContext.SaveChanges();

                            ScheduleHumen newScheduleHumen = new ScheduleHumen();
                            newScheduleHumen.Id = scheduleHumen.Id;
                            newScheduleHumen.ScheduleId = newSchedule.Id;
                            newScheduleHumen.HumenId = Humen.Humen_change.Id;
                            appContext.ScheduleHumens.Add(newScheduleHumen);
                            appContext.SaveChanges();

                            foreach (var w in App.Current.Windows)
                                if (w is FormChangeSchedule cw)
                                    cw.Close();

                            Humen.Humen_change = null;
                        }
                        else
                        {
                            MessageBox.Show("Поля не могут быть пустыми.");
                        }
                    }
                    ));
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

        public Humen Humen
        {
            get => _humen;
            set
            {
                _humen = value;
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

        public Schedule Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }
        public FormChangeScheduleViewModel()
        {
            Humen = new Humen();
            Schedule = new Schedule();

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
