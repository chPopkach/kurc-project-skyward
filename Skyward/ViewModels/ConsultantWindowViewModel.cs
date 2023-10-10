using iTextSharp.text;
using iTextSharp.text.pdf;
using Skyward.Models;
using Skyward.Tools;
using Skyward.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Skyward.ViewModels
{
    public class ConsultantWindowViewModel : BaseViewModel
    {
        AppContext appContext = new AppContext();

        private RelayCommand _startView;

        private RelayCommand _allClientsView;

        private RelayCommand _terminateSession;

        private RelayCommand _allTrainersView;

        private RelayCommand _allConsultantsView;

        private RelayCommand _openFormAddClient;

        private RelayCommand _allTypesTickets;

        private RelayCommand _generateAReport;

        public RelayCommand GenerateAReport
        {
            get
            {
                return _generateAReport ??
                    (_generateAReport = new RelayCommand(x =>
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document();

                        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        PdfWriter.GetInstance(doc, new FileStream($"{path}\\Report.pdf", FileMode.Create));

                        doc.Open();

                        PdfPTable table = new PdfPTable(4);

                        table.AddCell("PurchaseDate");
                        table.AddCell("DateOfDelay");
                        table.AddCell("TypeTicket");
                        table.AddCell("Price");

                        DateTime date = DateTime.Now.AddMonths(-1);
                        decimal? smoant = 0;
                        ObservableCollection<TypeTicket> typeTickets = new ObservableCollection<TypeTicket>(appContext.TypeTickets);
                        foreach (var item in appContext.Tickets)
                        {
                            if (item.PurchaseDate.Date > date)
                            {
                                table.AddCell($"{string.Format(item.PurchaseDate.Date.ToString()).Trim(new char[] {'0', ':'})}");
                                table.AddCell($"{string.Format(item.DateOfDelay.Date.ToString()).Trim(new char[] { '0', ':' })}");
                                foreach (var part in typeTickets)
                                {
                                    if (item.TypeTicketId == part.Id)
                                    {
                                        if (part.type_ticket == "На день")
                                        {
                                            table.AddCell($"Day");
                                        }
                                        else if (part.type_ticket == "На неделю")
                                        {
                                            table.AddCell($"Week");
                                        }
                                        else if (part.type_ticket == "На месяц")
                                        {
                                            table.AddCell($"Month");
                                        }
                                        else if (part.type_ticket == "На год")
                                        {
                                            table.AddCell($"Year");
                                        }
                                        table.AddCell($"{part.price}p.");
                                        smoant += part.price;
                                    }
                                }
                            }
                        }
                        PdfPCell cell = new PdfPCell(new Phrase("Total:"));
                        cell.Colspan = 3;
                        table.AddCell(cell);
                        table.AddCell($"{smoant}p.");

                        doc.Add(table);
                        doc.Close();

                        MessageBox.Show($"Отчет создан по пути {path}" + @"\" + "Report.pdf");
                    }
                    ));
            }
        }

        public RelayCommand AllConsultantsView
        {
            get
            {
                return _allConsultantsView ??
                    (_allConsultantsView = new RelayCommand(x =>
                    {
                        List<User> usersConsultants = new List<User>();
                        usersConsultants = appContext.Users
                            .Where(t => t.RoleUser.Role_user == "К")
                            .ToList();
                        Humens.Clear();
                        foreach (var i in usersConsultants)
                        {
                            foreach (var j in appContext.Humens)
                            {
                                if (j.Id == i.HumenId)
                                {
                                    Humens.Add(j);
                                }
                            }
                        }
                    }
                    ));
            }
        }

        public RelayCommand AllTypesTickets
        {
            get
            {
                return _allTypesTickets ??
                    (_allTypesTickets = new RelayCommand(x =>
                    {
                        ViewAllTypesTicketsWindow viewAllTypesTicketsWindow = new ViewAllTypesTicketsWindow();
                        viewAllTypesTicketsWindow.Show();
                    }
                    ));
            }
        }

        public RelayCommand OpenFormAddClient
        {
            get
            {
                return _openFormAddClient ??
                    (_openFormAddClient = new RelayCommand(x =>
                    {
                        FormAddClient formAddClient = new FormAddClient();
                        formAddClient.ShowDialog();
                        DateTime DateNow = DateTime.UtcNow.Date;
                        Humens = new ObservableCollection<Humen>(appContext.Humens
                            .Where(t => t.Id != User.User_auth.HumenId && t.TicketId != null && t.Ticket.DateOfDelay.Date >= DateNow.Date));
                    }
                    ));
            }
        }

        private RelayCommand _openFormChangeSchedule;

        public RelayCommand OpenFormChangeSchedule
        {
            get
            {
                return _openFormChangeSchedule ??
                    (_openFormChangeSchedule = new RelayCommand(x =>
                    {
                        Humen.Humen_change = Humen;
                        if (Humen != null)
                        {
                            FormChangeSchedule formAddClient = new FormChangeSchedule();
                            formAddClient.ShowDialog();
                            DateTime DateNow = DateTime.UtcNow.Date;
                            Humens = new ObservableCollection<Humen>(appContext.Humens
                                .Where(t => t.Id != User.User_auth.HumenId && t.TicketId != null && t.Ticket.DateOfDelay.Date >= DateNow.Date));
                        }
                        else
                        {
                            MessageBox.Show("Не выделен человек, у которого будет меняться расписание.");
                        }
                    }));
            }
        }

        public void DynamicSearchTextBoxConsultantWindowViewModel(string text)
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

        public RelayCommand AllTrainersView
        {
            get
            {
                return _allTrainersView ??
                    (_allTrainersView = new RelayCommand(x =>
                    {
                        List<User> usersTrainers = new List<User>();
                        usersTrainers = appContext.Users
                            .Where(t => t.RoleUser.Role_user == "Т")
                            .ToList();
                        Humens.Clear();
                        foreach(var i in usersTrainers)
                        {
                            foreach (var j in appContext.Humens)
                            {
                                if (j.Id == i.HumenId)
                                {
                                    Humens.Add(j);
                                }
                            }
                        }
                    }
                    ));
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
                            if (w is ConsultantWindow cw)
                                cw.Close();
                    }
                    ));
            }
        }

        private Humen _humen;

        public Humen Humen
        {
            get => _humen;
            set
            {
                _humen = value;
                OnPropertyChanged();
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

        public ConsultantWindowViewModel()
        {
            DateTime DateNow = DateTime.UtcNow.Date;
            Humens = new ObservableCollection<Humen>(appContext.Humens
                .Where(t => t.Id != User.User_auth.HumenId && t.TicketId != null && t.Ticket.DateOfDelay.Date >= DateNow.Date));

            Humen = new Humen();
        }
    }
}
