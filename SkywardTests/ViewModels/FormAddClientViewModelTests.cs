using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyward.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyward.Models;

namespace Skyward.ViewModels.Tests
{
    [TestClass()]
    public class FormAddClientViewModelTests
    {
        AppContext appContext = new AppContext();

        [TestMethod()]
        public void AddClientTest()
        {
            int days = 1;
            Ticket newTicket = new Ticket()
            { 
                Id = appContext.Tickets.Count() + 1,
                TypeTicketId = 1,
                PurchaseDate = DateTime.UtcNow.Date,
                DateOfDelay = DateTime.UtcNow.Date.AddDays(days)
            };
            if (newTicket.Id != null && newTicket.TypeTicketId != null && newTicket.PurchaseDate != null && newTicket.DateOfDelay != null)
            {
                appContext.Tickets.Add(newTicket);
            }


            string TimeHourStart = "08:00";
            string TimeHourFinish = "12:00";
            DateTime newWorkTimeStart = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                int.Parse(TimeHourStart.Substring(0, 2)), 0, 0);
            DateTime newWorkTimeEnd = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                int.Parse(TimeHourFinish.Substring(0, 2)), 0, 0);
            Schedule newSchedule = new Schedule() 
            { 
                Id = appContext.Schedules.Count() + 1,
                WorkTimeStart = newWorkTimeStart,
                WorkTimeEnd = newWorkTimeEnd,
                WorkDays = String.Format("ПН, ВТ, ЧТ").ToUpper()
            };
            if (newSchedule.Id != null && newSchedule.WorkTimeStart != null 
                && newSchedule.WorkTimeEnd != null && newSchedule.WorkDays != null && TimeHourStart != TimeHourFinish)
            {
                appContext.Schedules.Add(newSchedule);
            }


            Humen newHumen = new Humen()
            {
                Id = appContext.Humens.Count() + 1,
                FirstName = "Соболев",
                Name = "Николай",
                LastName = "Петрович",
                Phone = "89456541236",
                Age = 27,
                Male = "Мужской",
                TicketId = newTicket.Id
            };
            if (newHumen.Id != null && newHumen.FirstName != null && newHumen.Name != null && newHumen.LastName != null &&
                newHumen.Phone != null && newHumen.Age != null && newHumen.Male != null)
            {
                appContext.Humens.Add(newHumen);
            }


            ScheduleHumen newScheduleHumen = new ScheduleHumen();
            newScheduleHumen.Id = appContext.ScheduleHumens.Count() + 1;
            newScheduleHumen.ScheduleId = newSchedule.Id;
            newScheduleHumen.HumenId = newHumen.Id;
            if (newScheduleHumen.Id != null && newScheduleHumen.ScheduleId != null && newScheduleHumen.HumenId != null)
            {
                appContext.ScheduleHumens.Add(newScheduleHumen);
            }


            appContext.SaveChanges();
            if (appContext.Tickets.Contains(newTicket) && appContext.Schedules.Contains(newSchedule) &&
                appContext.Humens.Contains(newHumen) && appContext.ScheduleHumens.Contains(newScheduleHumen))
            {
                Assert.IsTrue(true, "Клиент успешно добавлен");
            }
            else
            {
                Assert.Fail();
            }




            appContext.ScheduleHumens.Remove(newScheduleHumen);
            appContext.Humens.Remove(newHumen);
            appContext.Schedules.Remove(newSchedule);
            appContext.Tickets.Remove(newTicket);
            appContext.SaveChanges();
        }
    }
}