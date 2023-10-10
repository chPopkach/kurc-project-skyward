using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyward.Models;
using Skyward.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.ViewModels.Tests
{
    [TestClass()]
    public class FormChangeScheduleViewModelTests
    {
        AppContext appContext = new AppContext();

        [TestMethod()]
        public void FormChangeScheduleTest()
        {
            string TimeHourStart = "10:00";
            string TimeHourFinish = "18:00";
            DateTime newWorkTimeStart = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                int.Parse(TimeHourStart.Substring(0, 2)), 0, 0);
            DateTime newWorkTimeEnd = new DateTime(DateTime.UtcNow.Date.Year, DateTime.UtcNow.Date.Month, DateTime.UtcNow.Date.Day,
                int.Parse(TimeHourFinish.Substring(0, 2)), 0, 0);

            if (TimeHourStart != "" && TimeHourFinish != "" && TimeHourStart != TimeHourFinish)
            {
                ScheduleHumen? scheduleHumen = new ScheduleHumen();
                scheduleHumen = appContext.ScheduleHumens.FirstOrDefault(x => x.HumenId == 1);
                if (scheduleHumen != null)
                {
                    appContext.ScheduleHumens.Remove(scheduleHumen);
                    appContext.Schedules.Remove(scheduleHumen.Schedule);
                    appContext.SaveChanges();
                }

                Schedule newSchedule = new Schedule();
                newSchedule.Id = scheduleHumen.Schedule.Id;
                newSchedule.WorkTimeStart = newWorkTimeStart;
                newSchedule.WorkTimeEnd = newWorkTimeEnd;
                newSchedule.WorkDays = "ПН, ЧТ, пт".ToUpper();
                appContext.Schedules.Add(newSchedule);

                ScheduleHumen newScheduleHumen = new ScheduleHumen();
                newScheduleHumen.Id = scheduleHumen.Id;
                newScheduleHumen.ScheduleId = newSchedule.Id;
                newScheduleHumen.HumenId = 1;
                appContext.ScheduleHumens.Add(newScheduleHumen);


                appContext.SaveChanges();
                if (appContext.Schedules.Contains(newSchedule) && appContext.ScheduleHumens.Contains(newScheduleHumen))
                {
                    Assert.IsTrue(true, "Расписание успешно изменено");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}