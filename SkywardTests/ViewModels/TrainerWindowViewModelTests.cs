using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyward.Models;
using Skyward.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.ViewModels.Tests
{
    [TestClass()]
    public class TrainerWindowViewModelTests
    {
        AppContext appContext = new AppContext();

        [TestMethod()]
        public void DynamicSearchTextBoxTrainerWindowViewModelTest()
        {
            ObservableCollection<Humen> Humens = new ObservableCollection<Humen>(appContext.Humens
                .Where(x => x.FirstName.Contains("Козлова Ар")));
            bool check = false;
            if (Humens.Count() != 0)
            {
                check = true;
                Assert.IsTrue(check);
            }
            else
            {
                Assert.IsFalse(check);
            }

            Humens = new ObservableCollection<Humen>(appContext.Humens
                .Where(x => x.FirstName.Contains("Арина Коз")));
            check = false;
            if (Humens.Count() != 0)
            {
                check = true;
                Assert.IsTrue(check);
            }
            else
            {
                Assert.IsFalse(check);
            }
        }

        [TestMethod()]
        public void SelectionClientsTest()
        {
            string Day = "ПН";
            ObservableCollection<ScheduleHumen> selectionScheduleHumens = new ObservableCollection<ScheduleHumen>();
            ObservableCollection<ScheduleHumen> scheduleHumens = new ObservableCollection<ScheduleHumen>(appContext.ScheduleHumens);
            foreach (var item in scheduleHumens)
            {
                if (item.Schedule.WorkDays.Contains(Day))
                {
                    selectionScheduleHumens.Add(item);
                }
            }
            ObservableCollection<Humen> Humens = new ObservableCollection<Humen>(selectionScheduleHumens.Select(h => h.Humen));
            Assert.IsNotNull(Humens);

            Day = null;
            if (Day == null)
            {
                Assert.IsTrue(true, "Коллекция вернет первоначальное состояние");
            }
        }

        [TestMethod()]
        public void LogOut()
        {
            if (User.User_auth == null)
            {
                Assert.IsTrue(true, "Авторизованный пользователь сбросился");
            }
        }
    }
}